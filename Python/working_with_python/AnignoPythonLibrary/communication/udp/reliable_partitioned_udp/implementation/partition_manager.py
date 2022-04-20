import logging
import time
from datetime import datetime
from threading import RLock, Thread
from typing import Sequence

from rx.subject import Subject

from core.business_logic.core_constants import LoggerNames, LoggerSections
from core.network_communications.network_layer.implementation.subject_params.data_received_params import DataReceivedParams
from core.network_communications.network_layer.implementation.subject_params.part_data_received_params import PartDataReceivedParams


class PartitionManager:
    def __init__(self, cleaning_wakeup_interval: int, old_message_interval: int):
        """
        @param cleaning_wakeup_interval: interval in seconds for cleaning thread to wake up
        @param old_message_interval: interval in seconds for message part to be considered old for removal
        """
        self.old_message_interval = old_message_interval
        self.cleaning_interval = cleaning_wakeup_interval
        self.logger = logging.getLogger(f'{LoggerNames.dix.name}.{LoggerSections.status.name}')
        self._on_data_received = Subject()
        self.messages_parts_dict = dict()  # [message_key][part_number]
        self.messages_parts_dict_lock = RLock()
        self.cleaning_thread = Thread(target=self.cleaning_thread_start)
        self.sent_messages_dict = dict()  # saved sent messages to prevent receiving same message again

    @staticmethod
    def partition_data(data_bytes: bytes, max_packet_size: int) -> Sequence[bytes]:
        """
        split bytes array to several smaller ones according to sender configuration's max_packet_size value
        @param max_packet_size:
        @param data_bytes: data as bytes array
        @return: an array of arrays of bytes
        """
        r = range(0, len(data_bytes), max_packet_size)
        parts = [data_bytes[a:a + max_packet_size] for a in r]
        return parts

    @property
    def on_data_received(self):
        return self._on_data_received

    def cleaning_thread_start(self):
        while True:
            time.sleep(self.cleaning_interval)
            now = datetime.now().timestamp()
            messages_to_remove = list()
            with self.messages_parts_dict_lock:
                # clean old message parts
                for message_key in self.messages_parts_dict.keys():
                    for part_number in self.messages_parts_dict[message_key]:
                        part_data: PartDataReceivedParams = self.messages_parts_dict[message_key][part_number]
                        if now > part_data.creation_timestamp + self.old_message_interval:
                            messages_to_remove.append(message_key)
                for message_key in messages_to_remove:
                    if message_key in self.messages_parts_dict:
                        self.messages_parts_dict.pop(message_key)
                # clean old message sent dictionary
                messages_to_remove = list()
                for key in self.sent_messages_dict:
                    if now > self.sent_messages_dict[key] + self.old_message_interval:
                        messages_to_remove.append(key)
                for key in messages_to_remove:
                    self.sent_messages_dict.pop(key)
                # self.logger.info(f'PartitionManager, message_dict size={len(self.messages_parts_dict)} sent_messages_dict size={len(self.sent_messages_dict)}')

    def start(self):
        self.cleaning_thread.start()

    def handle_message_part_received(self, part_data_received_params: PartDataReceivedParams):
        """
        store message part in dictionary [message_key][part_number], if all parts for a message received, notify subscribers and remove all parts
        @param part_data_received_params:
        """
        key = f'[{part_data_received_params.sender_end_point}_{part_data_received_params.message_id}]'
        all_data_bytes: bytes = b''
        with self.messages_parts_dict_lock:
            # verify message hasn't been received in the near past
            if key in self.sent_messages_dict:
                return
            # add message part to dictionary
            if key not in self.messages_parts_dict:
                self.messages_parts_dict[key] = dict()
            self.messages_parts_dict[key][part_data_received_params.part_number] = part_data_received_params
            # check if all parts for message were received
            if len(self.messages_parts_dict[key]) == part_data_received_params.total_parts:
                # build message from parts and notify subscribers
                for i in range(1, len(self.messages_parts_dict[key]) + 1):
                    part_params: PartDataReceivedParams = self.messages_parts_dict[key][i]
                    all_data_bytes += part_params.data_bytes
                self.messages_parts_dict.pop(key)
                self.sent_messages_dict[key] = datetime.now().timestamp()
        if len(all_data_bytes) > 0:
            on_data_received_params = DataReceivedParams(all_data_bytes, part_data_received_params.sender_end_point, part_data_received_params.message_id)
            self.on_data_received.on_next(on_data_received_params)

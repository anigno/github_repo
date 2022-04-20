import logging
import time
from datetime import datetime
from threading import Thread, RLock
from typing import Dict

from rx.subject import Subject

from core.business_logic.core_constants import LoggerNames, LoggerSections
from core.network_communications.network_layer.implementation.reliability_management.reliability_item import ReliabilityItem
from core.network_communications.network_layer.implementation.subject_params.ack_received_params import AckReceivedParams
from core.network_communications.network_layer.implementation.subject_params.data_sent_params import DataSentParams

class ReliabilityManager:
    """
    handle reliability of message parts by notifying resend required on a message parts
    """

    def __init__(self, wakeup_interval: float):
        """
        @param wakeup_interval: wakeup_interval interval in seconds when thread wakeup to check reliability
        """
        super().__init__()
        self.logger = logging.getLogger(f'{LoggerNames.dix.name}.{LoggerSections.status.name}')
        self.wakeup_interval = wakeup_interval
        self._reliability_dict: Dict[str, Dict[int, ReliabilityItem]] = dict()  # [reliability_key,[part_number,reliability_item]]
        self.timeout_thread = Thread(target=self._timeout_thread_start)
        self.dict_lock = RLock()
        self._on_part_message_timeout = Subject()
        self._on_message_failed = Subject()
        self._on_all_data_sent = Subject()

    @property
    def on_part_message_timeout(self):
        return self._on_part_message_timeout

    @property
    def on_message_failed(self):
        return self._on_message_failed

    @property
    def on_all_data_sent(self) -> Subject:
        return self._on_all_data_sent

    def start(self):
        self.timeout_thread.start()

    def add_message_part(self, message_id: int, data_bytes: bytes, resend_remote_ip: str, resend_remote_port: int, part_number: int, resend_count: int, resend_timeout: int):
        """
        create message part reliability_item, with next timeout timestamp and resend data, and add it to dictionary for periodic timeout checking
        """
        reliability_key: str = self.build_reliability_key(resend_remote_ip, message_id)
        reliability_item = ReliabilityItem(data_bytes, message_id, resend_remote_ip, resend_remote_port, resend_timeout, resend_count, part_number)
        reliability_item.next_timeout = datetime.now().timestamp() + resend_timeout
        with self.dict_lock:
            if reliability_key not in self._reliability_dict:
                self._reliability_dict[reliability_key] = dict()
            self._reliability_dict[reliability_key][part_number] = reliability_item

    def _timeout_thread_start(self):
        self.logger.debug(f'reliability manager timeout_thread_start starting')
        while True:
            time.sleep(self.wakeup_interval)
            key_remove_list = list()
            now = datetime.now().timestamp()
            with self.dict_lock:
                # looks for timeout ack for resending parts
                for reliability_key in self._reliability_dict.keys():
                    for part_number in self._reliability_dict[reliability_key]:
                        reliability_item: ReliabilityItem = self._reliability_dict[reliability_key][part_number]
                        if now > reliability_item.next_timeout:
                            if reliability_item.resend_left > 0:
                                reliability_item.resend_left -= 1
                                reliability_item.next_timeout = now + reliability_item.timeout
                                # todo: roniG, schedule notification on different thread or after release lock
                                # will raise event to notify resend required
                                self.on_part_message_timeout.on_next(reliability_item)
                            else:
                                key_remove_list.append(reliability_key)
                # remove messages without resend left
                for reliability_key in key_remove_list:
                    if reliability_key in self._reliability_dict:
                        self._reliability_dict.pop(reliability_key)
                        self.on_message_failed.on_next(reliability_key)

    def handle_ack_received(self, ack_received_params: AckReceivedParams):
        with self.dict_lock:
            # remove message parts for received ack, if all parts ack received, notify subscribers on message sent
            if ack_received_params.reliability_key in self._reliability_dict:
                parts_dic: dict = self._reliability_dict[ack_received_params.reliability_key]
                if ack_received_params.part_number in parts_dic:
                    parts_dic.pop(ack_received_params.part_number)
                    # if all parts ack received, notify subscribers on message sent
                    if len(self._reliability_dict[ack_received_params.reliability_key]) == 0:
                        # self.logger.debug(f'all ack received {ack_received_params}')
                        self._reliability_dict.pop(ack_received_params.reliability_key)
                        ip = ReliabilityManager.extract_ip(ack_received_params.reliability_key)
                        message_id = ReliabilityManager.extract_message_id(ack_received_params.reliability_key)
                        data_sent_params = DataSentParams(ip, message_id)
                        self.on_all_data_sent.on_next(data_sent_params)
                    return
            # self.logger.warning(f'ack received but not requested anymore {ack_received_params.reliability_key} {ack_received_params.part_number}')

    @staticmethod
    def build_reliability_key(remote_ip, message_id) -> str:
        return f'{remote_ip}_{message_id}'

    @staticmethod
    def extract_message_id(reliability_key: str):
        parts = reliability_key.split("_")
        return int(parts[1])

    @staticmethod
    def extract_ip(reliability_key: str):
        parts = reliability_key.split("_")
        return parts[0]

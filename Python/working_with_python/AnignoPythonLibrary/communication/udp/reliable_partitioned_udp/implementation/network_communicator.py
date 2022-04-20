import logging
from typing import Sequence, List, Dict, Optional

from rx.subject import Subject

from core.business_logic.core_constants import LoggerNames
from core.network_communications.network_layer.base.data_receiver_base import DataReceiverBase
from core.network_communications.network_layer.base.data_sender_base import DataSenderBase
from core.network_communications.network_layer.config.network_communicator_config import NetworkCommunicatorConfig
from core.network_communications.network_layer.implementation.message_sending_data import MessageSendingData
from core.network_communications.network_layer.implementation.partition_manager import PartitionManager


class NetworkCommunicator:
    """
    single sender multiple receivers communicator
    """

    def __init__(self, network_communicator_config: NetworkCommunicatorConfig, senders: Dict[str, DataSenderBase], receivers: List[DataReceiverBase]):
        self.logger = logging.getLogger(LoggerNames.dix.name)
        self._communicator_config = network_communicator_config
        self._data_senders = senders
        self._data_receivers = receivers
        self._on_data_received_subject = Subject()
        self._on_data_sent_subject = Subject()

        self.partition_manager = PartitionManager(network_communicator_config.cleaning_wakeup_interval, network_communicator_config.old_message_interval)
        self.partition_manager.on_data_received.subscribe(lambda data_received_params: self.partition_manager_on_data_received_handler(data_received_params))

    @property
    def on_data_received(self) -> Subject:
        return self._on_data_received_subject

    @property
    def on_all_data_sent(self) -> Subject:
        return self._on_data_sent_subject

    def start(self):
        for receiver in self._data_receivers:
            receiver.on_part_data_received.subscribe(on_next=lambda part_data: self.receiver_on_part_data_received_handler(part_data))
            receiver.start()
        for sender in self._data_senders.values():
            sender.on_all_data_sent.subscribe(on_next=lambda data_sent_params: self.sender_on_all_data_sent_handler(data_sent_params))
            sender.start()
        self.partition_manager.start()

    def select_sender(self, message_sending_data: MessageSendingData) -> DataSenderBase:
        """
        select sender for sending message, if given None, dix sender will be used, else SD sender
        """
        if message_sending_data is None or not message_sending_data.is_sd:
            if 'DIX_SENDER' in self._data_senders:
                return self._data_senders['DIX_SENDER']
            return next(self._data_senders.values().__iter__())  # return the first sender if no dix specific sender configured
        return self._data_senders['SD_SENDER']

    def send_single(self, message_id: int, data_bytes: bytes, remote_ip: str, remote_port: int, resend_count: int, resend_timeout: int,
                    message_sending_data: Optional[MessageSendingData]):
        selected_sender = self.select_sender(message_sending_data)
        ttl = -1 if not message_sending_data else message_sending_data.ttl
        qos_header_value = -1 if not message_sending_data else message_sending_data.qos_header_value
        selected_sender.send_single(message_id, data_bytes, remote_ip, remote_port, resend_count, resend_timeout, qos_header_value, ttl)

    def send_multiple(self, message_id: int, data_bytes: bytes, remote_ip_list: Sequence[str], remote_port: int, resend_count: int, timeout: int,
                      message_sending_data: MessageSendingData):
        selected_sender = self.select_sender(message_sending_data)
        ttl = -1 if not message_sending_data else message_sending_data.ttl
        qos_header_value = -1 if not message_sending_data else message_sending_data.qos_header_value
        selected_sender.send_multiple(message_id, data_bytes, remote_ip_list, remote_port, resend_count, timeout, qos_header_value, ttl)

    def send_multicast(self, message_id: int, data_bytes: bytes, multicast_ip: str, multicast_port: int, resend_count: int, resend_timeout: int,
                       verification_ip_list: Sequence[str],
                       message_sending_data: MessageSendingData):
        selected_sender = self.select_sender(message_sending_data)
        ttl = -1 if not message_sending_data else message_sending_data.ttl
        qos_header_value = -1 if not message_sending_data else message_sending_data.qos_header_value
        selected_sender.send_multicast(message_id, data_bytes, multicast_ip, multicast_port, resend_count, resend_timeout, verification_ip_list,
                qos_header_value, ttl)

    def receiver_on_part_data_received_handler(self, part_data_received_params):
        self.partition_manager.handle_message_part_received(part_data_received_params)

    def partition_manager_on_data_received_handler(self, data_received_params):
        self.on_data_received.on_next(data_received_params)

    def sender_on_all_data_sent_handler(self, data_sent_params):
        self.on_all_data_sent.on_next(data_sent_params)

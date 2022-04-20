import logging
import random
from abc import ABC, abstractmethod
from threading import RLock
from typing import Sequence

from rx.subject import Subject

from core.business_logic.core_constants import LoggerNames, LoggerSections
from core.network_communications.application_layer.message_network_behavior.qos.qos_provider_base import QosPriorityMethod
from core.utils.time_utils import TimeUtils


class DataSenderBase(ABC):
    TimeUtils.init_random_seed()
    _unique_message_id = random.randint(10 ** 6, 10 ** 7)
    unique_message_id_lock = RLock()

    # _unique_message_id = now.second + now.minute * 100 + now.hour * 10000 + now.day * 1000000 + now.month * 100000000

    @staticmethod
    def generate_message_id() -> int:
        with DataSenderBase.unique_message_id_lock:
            DataSenderBase._unique_message_id += 1
            return DataSenderBase._unique_message_id

    def __init__(self):
        self.logger = logging.getLogger(f'{LoggerNames.dix.name}.{LoggerSections.messages.name}')
        self._on_all_data_sent_subject = Subject()


    @property
    def on_all_data_sent(self) -> Subject:
        return self._on_all_data_sent_subject


    @abstractmethod
    def send_single(self, message_id: int, data_bytes: bytes, remote_ip: str, remote_port: int, resend_count: int, timeout: int, qos_header_value: int, ttl: int):
        pass

    @abstractmethod
    def send_multiple(self, message_id: int, data_bytes: bytes, remote_ip_list: Sequence[str], remote_port: int, resend_count: int, timeout: int,
                      qos_header_value: int, ttl: int):
        pass

    @abstractmethod
    def send_multicast(self, message_id: int, data_bytes: bytes, remote_ip: str, remote_port: int, resend_count: int, timeout: int, verification_ip_list: Sequence[str],
                       qos_header_value: int, ttl: int):
        pass

    @abstractmethod
    def start(self):
        pass

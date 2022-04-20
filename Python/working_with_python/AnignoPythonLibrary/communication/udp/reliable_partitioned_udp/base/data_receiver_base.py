import logging
from abc import ABC, abstractmethod

from AnignoPythonLibrary.communication.udp.reliable_partitioned_udp.config.data_receiver_config import \
    DataReceiverConfig

class DataReceiverBase(ABC):

    def __init__(self, data_receiver_config: DataReceiverConfig, ack_communicator: AckCommunicator):
        self.logger = logging.getLogger(f'DataReceiverBase')
        self.ack_communicator = ack_communicator
        self.config = data_receiver_config
        self._on_part_data_received_subject = Subject()

    @property
    def on_part_data_received(self) -> Subject:
        return self._on_part_data_received_subject

    @abstractmethod
    def start(self):
        pass

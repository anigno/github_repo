import logging
from ipaddress import IPv4Address
from socket import socket, AF_INET, SOCK_DGRAM
from threading import Thread

from rx.subject import Subject

from core.business_logic.core_constants import LoggerNames, LoggerSections
from core.network_communications.network_layer.config.ack_communicator_config import AckCommunicatorConfig
from core.network_communications.network_layer.implementation.headers.ack_header import AckHeader
from core.network_communications.network_layer.implementation.reliability_management.reliability_manager import ReliabilityManager
from core.network_communications.network_layer.implementation.subject_params.ack_received_params import AckReceivedParams
from core.network_communications.network_layer.implementation.utils.bytes_parser import BytesParser
from core.network_communications.network_layer.implementation.utils.crc_utils import CrcUtils

class AckCommunicator:
    """
    send and receive ack messages
    """

    def __init__(self, ack_communicator_config: AckCommunicatorConfig):
        self.is_started = False
        self.ack_communicator_config = ack_communicator_config
        self.socket = socket(AF_INET, SOCK_DGRAM)
        self.logger = logging.getLogger(f'{LoggerNames.dix.name}.{LoggerSections.messages.name}')
        self._on_ack_received = Subject()
        self._ack_receive_thread = Thread(target=self.ack_receive_thread_start)

    @property
    def on_ack_received(self) -> Subject:
        return self._on_ack_received

    def ack_receive_thread_start(self):
        while True:
            (received_data_bytes, address_tuple) = self.socket.recvfrom(self.ack_communicator_config.receive_buffer_size)
            sender_ip = address_tuple[0]
            crc8 = BytesParser.to_bytes(received_data_bytes[0], 1)
            header_and_data = received_data_bytes[1:]
            is_crc_valid = CrcUtils.verify_crc8(header_and_data, crc8)
            ack_header = AckHeader.from_bytes(received_data_bytes, 1)
            if is_crc_valid:
                ip_for_log = str(IPv4Address(sender_ip))
                self.logger.debug(f'ack received {ip_for_log} {ack_header.message_id}')
                reliability_key = ReliabilityManager.build_reliability_key(sender_ip, ack_header.message_id)
                ack_received_params = AckReceivedParams(reliability_key, ack_header.part_number)
                self.on_ack_received.on_next(ack_received_params)
            else:
                self.logger.warning(f'ack CRC failed on received ack from: {sender_ip} msgId: {ack_header.message_id} crc8:{crc8}')

    def send_ack(self, sender_ip: str, message_id: int, part_number: int):
        ack_header = AckHeader(message_id, part_number)
        ack_bytes = ack_header.to_bytes()
        ack_message = ack_bytes + b''  # ack message data bytes is empty
        # calculating crc for header and data
        crc8 = CrcUtils.calculate_crc8(ack_message)
        ack_message = crc8 + ack_message
        self.socket.sendto(ack_message, (sender_ip, self.ack_communicator_config.ack_port))
        self.logger.debug(f'ack sent to: {sender_ip} message_id={message_id} part={part_number}')

    def start_receiving(self):
        if self.is_started:
            return
        self.is_started = True
        self.logger.debug(f'AckCommunicator starting {self.ack_communicator_config.ack_local_ip}:{self.ack_communicator_config.ack_port}')
        self.socket.bind((self.ack_communicator_config.ack_local_ip, self.ack_communicator_config.ack_port))
        self._ack_receive_thread.start()

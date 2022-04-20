import socket
from typing import Sequence

from core.network_communications.network_layer.base.data_sender_base import DataSenderBase
from core.network_communications.network_layer.config.data_sender_config import DataSenderConfig
from core.network_communications.network_layer.implementation.headers.message_header import MessageHeader
from core.network_communications.network_layer.implementation.partition_manager import PartitionManager
from core.network_communications.network_layer.implementation.reliability_management.ack_communicator import AckCommunicator
from core.network_communications.network_layer.implementation.reliability_management.reliability_item import ReliabilityItem
from core.network_communications.network_layer.implementation.reliability_management.reliability_manager import ReliabilityManager
from core.network_communications.network_layer.implementation.subject_params.ack_received_params import AckReceivedParams
from core.network_communications.network_layer.implementation.subject_params.data_sent_params import DataSentParams
from core.network_communications.network_layer.implementation.utils import network_helper
from core.network_communications.network_layer.implementation.utils.crc_utils import CrcUtils


class DataSenderUdp(DataSenderBase):

    def __init__(self, data_sender_config: DataSenderConfig, ack_communicator: AckCommunicator, is_multiple_dixes_on_pc, domain_number: int):
        """
        @param is_multiple_dixes_on_pc: True if multiple dixes are running on same PC
        """
        super().__init__()
        self.domain_number = domain_number
        self.multiple_dixes_on_pc = is_multiple_dixes_on_pc
        self.config = data_sender_config
        self.ack_communicator = ack_communicator
        self.reliability_manager = ReliabilityManager(self.config.reliability_wakeup_interval)
        self.socket_out = None

    def init_socket_out(self):
        size_8_mega = 8 * 1024 * 1024
        multiple_dixes_on_pc_value = 1 if self.multiple_dixes_on_pc else 0
        self.socket_out = socket.socket(socket.AF_INET, socket.SOCK_DGRAM, socket.IPPROTO_UDP)
        self.socket_out.setsockopt(socket.SOL_SOCKET, socket.SO_RCVBUF, size_8_mega)
        self.socket_out.setsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF, size_8_mega)
        self.socket_out.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_TTL, self.config.ttl)
        self.socket_out.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_LOOP, multiple_dixes_on_pc_value)
        self.socket_out.bind((self.config.sender_local_ip, self.config.sender_local_port))

    def start(self):
        self.logger.debug(f'sender starting: {self.config.sender_local_ip}:{self.config.sender_local_port} multicast={self.config.sender_is_multicast}')
        self.reliability_manager.on_part_message_timeout.subscribe(lambda reliability_item: self._on_reliability_manager_part_message_timeout(reliability_item))
        self.reliability_manager.on_message_failed.subscribe(lambda reliability_key: self.on_reliability_manager_message_failed(reliability_key))
        self.reliability_manager.on_all_data_sent.subscribe(lambda reliability_key: self.on_reliability_manager_data_sent(reliability_key))
        self.ack_communicator.on_ack_received.subscribe(lambda ack_received_params: self._on_ack_communicator_ack_received_handler(ack_received_params))
        self.init_socket_out()
        self.reliability_manager.start()
        self.ack_communicator.start_receiving()

    def send_single(self, message_id: int, data_bytes: bytes, remote_ip: str, remote_port: int, resend_count: int, resend_timeout: int,
                    qos_header_value: int, ttl):
        self.logger.debug(f'send_single msgId={message_id} to {remote_ip}:{remote_port}')
        if ttl <= 0:
            ttl = self.config.ttl
        if qos_header_value >= 0:
            self.socket_out.setsockopt(socket.IPPROTO_IP, socket.IP_TOS, qos_header_value)
        is_reliable = resend_count > 0 and self.config.is_use_reliability
        # if received message_id, message notification is requested above, else create new one
        packet_size_without_header = self.config.sender_max_packet_size - MessageHeader.HEADER_LENGTH - CrcUtils.CRC8_DIGEST_SIZE
        data_bytes_parts = PartitionManager.partition_data(data_bytes, packet_size_without_header)
        total_parts = len(data_bytes_parts)
        if total_parts == 0:
            self.logger.warning(f'zero length message not sent')
        # create partitioned messages, add each to reliability management and send each part
        if ttl > 0:
            self.socket_out.setsockopt(socket.IPPROTO_IP, socket.IP_TTL, ttl)
        for part_data, part_index in zip(data_bytes_parts, range(1, total_parts + 1)):
            data_header = MessageHeader(message_id, is_reliable, part_index, total_parts)
            # calculating crc for header and data
            part_message_bytes = data_header.to_bytes() + part_data
            crc8 = CrcUtils.calculate_crc8(part_message_bytes)
            part_message_bytes = crc8 + part_message_bytes
            # send part message and add reliability if needed
            if is_reliable:
                self.reliability_manager.add_message_part(message_id, part_message_bytes, remote_ip, remote_port, part_index, resend_count, resend_timeout)
            self.socket_out.sendto(part_message_bytes, (remote_ip, remote_port))
        self.logger.debug(f'sent message with id={message_id} single')

    def send_multiple(self, message_id: int, data_bytes: bytes, remote_ip_list: Sequence[str], remote_port: int, resend_count: int, timeout: int,
                      qos_header_value: int, ttl):
        for remote_ip in remote_ip_list:
            # message_id = DataSenderUdp.generate_message_id()
            self.send_single(message_id, data_bytes, remote_ip, remote_port, resend_count, timeout, qos_header_value, ttl)

    def send_multicast(self, message_id: int, data_bytes: bytes, multicast_ip: str, multicast_port: int, resend_count: int, timeout: int, verification_ip_list: Sequence[str],
                       qos_header_value: int, ttl):
        if ttl <= 0:
            ttl = self.config.ttl
        if qos_header_value >= 0:
            self.socket_out.setsockopt(socket.IPPROTO_IP, socket.IP_TOS, qos_header_value)
        multicast_ip = network_helper.build_multicast_ip(multicast_ip, self.domain_number)
        is_reliable = resend_count > 0 and self.config.is_use_reliability
        # message_id = DataSenderBase.generate_message_id()
        # if received message_id, message notification is requested above, else create new one
        packet_size_without_header = self.config.sender_max_packet_size - MessageHeader.HEADER_LENGTH - CrcUtils.CRC8_DIGEST_SIZE
        data_bytes_parts = PartitionManager.partition_data(data_bytes, packet_size_without_header)
        total_parts = len(data_bytes_parts)
        # create partitioned messages, add each to reliability management and send each part
        if ttl > 0:
            self.socket_out.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_TTL, ttl)
        for part_data, part_index in zip(data_bytes_parts, range(1, total_parts + 1)):
            data_header = MessageHeader(message_id, is_reliable, part_index, total_parts)
            # calculating crc for header and data
            part_message_bytes = data_header.to_bytes() + part_data
            crc8 = CrcUtils.calculate_crc8(part_message_bytes)
            part_message_bytes = crc8 + part_message_bytes
            # send part message and add reliability if needed
            if is_reliable:
                for verification_ip in verification_ip_list:
                    self.reliability_manager.add_message_part(message_id, part_message_bytes, verification_ip, self.config.sender_resend_unicast_port,
                            part_index, resend_count, timeout)
            self.socket_out.sendto(part_message_bytes, (multicast_ip, multicast_port))
        self.logger.debug(f'sent message with id={message_id} multicast [verification_ip_list:{verification_ip_list}]')

    def _on_ack_communicator_ack_received_handler(self, ack_received_params: AckReceivedParams):
        self.reliability_manager.handle_ack_received(ack_received_params)

    def _on_reliability_manager_part_message_timeout(self, reliability_item: ReliabilityItem):
        self.logger.debug(f'resending msgId={reliability_item.message_id} partN={reliability_item.part_number} resend={reliability_item.resend_left} to'
                          f' {reliability_item.resend_ip}:{reliability_item.resend_port}')
        self.socket_out.sendto(reliability_item.data_bytes, (reliability_item.resend_ip, reliability_item.resend_port))

    def on_reliability_manager_message_failed(self, reliability_key):
        message_id = self.reliability_manager.extract_message_id(reliability_key)
        self.logger.debug(f'message failed, key={reliability_key} message_id={message_id}')

    def on_reliability_manager_data_sent(self, data_sent_params: DataSentParams):
        self.logger.debug(f'message with id: {data_sent_params.message_id} successfully sent to: {data_sent_params.ip}')
        self.on_all_data_sent.on_next(data_sent_params)

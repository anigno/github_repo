import ipaddress
import socket
from threading import Thread
from typing import List, Tuple, Optional

from core.network_communications.network_layer.base.data_receiver_base import DataReceiverBase
from core.network_communications.network_layer.config.data_receiver_config import DataReceiverConfig
from core.network_communications.network_layer.implementation.headers.message_header import MessageHeader
from core.network_communications.network_layer.implementation.reliability_management.ack_communicator import \
    AckCommunicator
from core.network_communications.network_layer.implementation.subject_params.part_data_received_params import \
    PartDataReceivedParams
from core.network_communications.network_layer.implementation.utils import network_helper
from core.network_communications.network_layer.implementation.utils.bytes_parser import BytesParser
from core.network_communications.network_layer.implementation.utils.crc_utils import CrcUtils


class DataReceiverUdp(DataReceiverBase):

    def __init__(self, data_receiver_config: DataReceiverConfig, ack_communicator: AckCommunicator, is_multiple_dixes_on_pc,
                 senders_local_endpoints: List[Tuple[str, int]], port: int, domain_number: int):
        """
        @param is_multiple_dixes_on_pc: True if multiple dixes are running on same PC
        @param senders_local_endpoints:  List of local ports used by this dix to ignore self messages
        """
        super().__init__(data_receiver_config, ack_communicator)
        self.domain_number = domain_number
        self.port = port
        self.senders_local_endpoints = senders_local_endpoints
        self.multiple_dixes_on_pc = is_multiple_dixes_on_pc
        self.receiver_thread = Thread(target=self.receiver_thread_start, name='DataReceiverUdp', daemon=False)
        self.socket_in: Optional[socket.socket] = None


    def init_socket_in(self):
        size_8_mega = 8 * 1024 * 1024
        multiple_dixes_on_pc_value = 1 if self.multiple_dixes_on_pc else 0
        self.socket_in = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        self.socket_in.setsockopt(socket.SOL_SOCKET, socket.SO_RCVBUF, size_8_mega)
        self.socket_in.setsockopt(socket.SOL_SOCKET, socket.SO_SNDBUF, size_8_mega)
        if self.config.is_multicast:
            multicast_ip = network_helper.build_multicast_ip(self.config.multicast_ip, self.domain_number)
            self.socket_in.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            self.socket_in.setsockopt(socket.IPPROTO_IP, socket.IP_MULTICAST_LOOP, multiple_dixes_on_pc_value)
            ip_bytes_representation = socket.inet_aton(multicast_ip) + socket.inet_aton(self.config.local_bind_ip)
            self.socket_in.setsockopt(socket.IPPROTO_IP, socket.IP_ADD_MEMBERSHIP, ip_bytes_representation)
            self.socket_in.bind(('', self.port))
            # self.logger.info(f'Receiver binding {self.config.local_bind_ip}:{self.port} multicast')
        else:
            self.socket_in.bind((self.config.local_bind_ip, self.port))

    def start(self):
        address_string = f'{network_helper.build_multicast_ip(self.config.multicast_ip, self.domain_number)}:{self.port}' if self.config.is_multicast else \
            f'{self.config.local_bind_ip}:{self.port}'
        self.logger.info(f'receiver starting [{address_string}] isMulticast={self.config.is_multicast}')
        self.init_socket_in()
        self.receiver_thread.start()

    def is_ack_requested(self):
        """Calculate if ack is requested for multicast message, not in use yet"""
        return True

    def receiver_thread_start(self):
        while True:
            try:
                # message structure: [(crc8:1)(data_header:13)(part_data:)]
                (received_data_bytes, sender_endpoint_tuple) = self.socket_in.recvfrom(self.config.receive_buffer_size)
                sender_ip = sender_endpoint_tuple[0]
                # refuse messages from same dix
                if self.multiple_dixes_on_pc and sender_endpoint_tuple in self.senders_local_endpoints:
                    self.logger.debug(f'* filtered address {sender_endpoint_tuple}')
                    continue
                crc8 = BytesParser.to_bytes(received_data_bytes[0], 1)
                header_and_data = received_data_bytes[1:]
                is_crc_valid = CrcUtils.verify_crc8(header_and_data, crc8)
                data_header = MessageHeader.from_bytes(received_data_bytes, 1)
                if is_crc_valid:
                    # extract data bytes after header and crc
                    data_bytes = received_data_bytes[MessageHeader.HEADER_LENGTH + 1:]
                    if data_header.is_reliable and self.is_ack_requested():
                        self.ack_communicator.send_ack(sender_ip, data_header.message_id, data_header.part_number)
                    part_data_received_params = PartDataReceivedParams(data_bytes, str(sender_endpoint_tuple), data_header.message_id, data_header.part_number,
                            data_header.total_parts)
                    self.on_part_data_received.on_next(part_data_received_params)
                else:
                    self.logger.warning(f'CRC failed on received part from: {sender_endpoint_tuple} msgId: {data_header.message_id} crc8:{crc8}')
            except OSError as ex:
                self.logger.error(f'[{ex}] [{ex.args}]')
                raise ex


if __name__ == '__main__':
    def build_multicast_ip(ip: str, domain_number: int) -> str:
        """convert ip to the form #.#.domain_number.#"""
        a = ip.split('.')
        b = f'{a[0]}.{a[1]}.{domain_number}.{a[3]}'
        return b

    q = '111.222.333.444'
    w = build_multicast_ip(q, 555)
    print(w)

from rx.internal import ArgumentOutOfRangeException

from core.network_communications.network_layer.implementation.utils.bytes_parser import BytesParser


class AckHeader:
    """
    header part for any ack message
    """
    HEADER_LENGTH = 8

    def __init__(self, message_id: int, part_number: int):
        self.message_id = message_id
        self.part_number = part_number

    def to_bytes(self) -> bytes:
        bs = b''
        bs += BytesParser.to_bytes(self.message_id, 4)
        bs += BytesParser.to_bytes(self.part_number, 4)
        return bytes(bs)

    @staticmethod
    def from_bytes(data_bytes: bytes, start=0) -> "AckHeader":
        if len(data_bytes) - start < AckHeader.HEADER_LENGTH:
            raise ArgumentOutOfRangeException('DataHeader bytes length is wrong')
        parser = BytesParser(data_bytes, start=start)
        message_id = parser.get_next_uint()
        part_number = parser.get_next_uint()
        return AckHeader(message_id, part_number)

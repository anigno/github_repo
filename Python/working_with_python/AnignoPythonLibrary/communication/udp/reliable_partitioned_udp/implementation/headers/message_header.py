from rx.internal import ArgumentOutOfRangeException

from core.network_communications.network_layer.implementation.utils.bytes_parser import BytesParser

class MessageHeader:
    """
    header for any message, except ack
    """
    HEADER_LENGTH = 9

    def __init__(self, message_id: int = -1, is_reliable: bool = False, part_number: int = -1, total_parts: int = -1):
        self.message_id = message_id  # 4 bytes
        self.is_reliable = is_reliable  # 1 byte
        self.part_number = part_number  # 2 bytes
        self.total_parts = total_parts  # 2 bytes

    def to_bytes(self) -> bytes:
        bs = b''
        bs += BytesParser.to_bytes(self.message_id, 4)
        bs += BytesParser.to_bytes(self.is_reliable, 1)
        bs += BytesParser.to_bytes(self.part_number, 2)
        bs += BytesParser.to_bytes(self.total_parts, 2)
        return bytes(bs)

    @staticmethod
    def from_bytes(data_bytes: bytes, start=0) -> "MessageHeader":
        if len(data_bytes) - start < MessageHeader.HEADER_LENGTH:
            raise ArgumentOutOfRangeException('DataHeader bytes length is wrong')
        parser = BytesParser(data_bytes, start=start)
        message_id = parser.get_next_uint()
        is_reliable = parser.get_next_bool()
        part_number = parser.get_next_word()
        total_parts = parser.get_next_word()
        return MessageHeader(message_id, is_reliable, part_number, total_parts)

    def __str__(self) -> str:
        return "[id:{} isR:{} p:{} t:{}]".format(self.message_id, self.is_reliable, self.part_number, self.total_parts)

# ---------------------------------------------------------------------------------------

if __name__ == '__main__':
    d = MessageHeader(1001, True, 13, 17)
    data_bytes1 = d.to_bytes()
    d2 = MessageHeader.from_bytes(data_bytes1)
    print(f'{d2}')

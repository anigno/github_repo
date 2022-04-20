class BytesParser:
    BYTES_ORDER = 'big'

    def __init__(self, data_bytes: bytes, start=0):
        self.byte_order = BytesParser.BYTES_ORDER
        self.data_bytes = data_bytes
        self.i = start

    def get_next_bool(self) -> bool:
        b = self.data_bytes[self.i:self.i + 1]
        self.i += 1
        return bool.from_bytes(b, self.byte_order)

    def get_next_uint(self) -> int:
        """32 bit unsigned int"""
        b = self.data_bytes[self.i:self.i + 4]
        self.i += 4
        return int.from_bytes(b, self.byte_order, signed=False)

    def get_next_word(self) -> int:
        b = self.data_bytes[self.i:self.i + 2]
        self.i += 2
        return int.from_bytes(b, self.byte_order, signed=False)

    def get_next_int(self) -> int:
        """32 bit signed int"""
        b = self.data_bytes[self.i:self.i + 4]
        self.i += 4
        return int.from_bytes(b, self.byte_order, signed=True)

    def get_next_bytes(self, size) -> bytes:
        """number of bytes"""
        b = self.data_bytes[self.i:self.i + size]
        self.i += size
        return b

    @staticmethod
    def to_bytes(uint_num: int, bytes_count: int) -> bytes:
        return uint_num.to_bytes(bytes_count, BytesParser.BYTES_ORDER, signed=False)

    @staticmethod
    def to_uint(data_bytes: bytes, start: int, bytes_count: int):
        i = int.from_bytes(data_bytes[start:start + bytes_count], BytesParser.BYTES_ORDER, signed=False)
        return i

    @staticmethod
    def str_to_bytes(text: str) -> bytes:
        ret = text.encode('utf-8')
        return ret

    @staticmethod
    def str_from_bytes(data_bytes: bytes) -> str:
        ret = data_bytes.decode('utf-8')
        return ret

if __name__ == '__main__':
    v1 = 0xFFFF
    b1 = BytesParser.to_bytes(v1, 2)
    v2 = BytesParser.to_uint(b1, 0, 2)
    assert v1 == v2

    l1 = [0, 1, 2, 3, 4, 5]
    print(l1[2:4])

    a = 'AbCd15'
    d = BytesParser.str_to_bytes(a)
    c = BytesParser.str_from_bytes(d)
    assert d == c

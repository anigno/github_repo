import binascii

import crc8

from core.network_communications.network_layer.implementation.utils.bytes_parser import BytesParser


class CrcUtils:
    CRC8_DIGEST_SIZE = crc8.crc8.digest_size

    @staticmethod
    def calculate_crc8(data_bytes: bytes) -> bytes:
        crc = crc8.crc8()
        crc.update(data_bytes)
        return crc.digest()

    @staticmethod
    def verify_crc8(data_bytes: bytes, crc8_val: bytes) -> bool:
        crc = CrcUtils.calculate_crc8(data_bytes)
        return crc == crc8_val

    @staticmethod
    def calculate_crc32(data_bytes: bytes) -> bytes:
        int_crc = binascii.crc32(data_bytes)
        data_bytes = BytesParser.to_bytes(int_crc, 4)
        return data_bytes

    @staticmethod
    def verify_crc32(data_bytes: bytes, crc32_val: bytes) -> bool:
        crc = CrcUtils.calculate_crc32(data_bytes)
        return crc == crc32_val


if __name__ == '__main__':
    bytes1 = b'1234567890123456789012345678901234567890'
    crc1 = CrcUtils.calculate_crc32(bytes1)
    b = CrcUtils.verify_crc32(bytes1, crc1)
    print(f'{b} {crc1} {len(crc1)})')

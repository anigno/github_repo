from datetime import datetime

class ReliabilityItem:
    def __init__(self, data_bytes: bytes, message_id: int, resent_ip: str, resend_port: int, timeout: int, resend_count: int, part_number: int):
        self.part_number = part_number
        self.data_bytes = data_bytes
        self.message_id = message_id
        self.resend_ip = resent_ip
        self.resend_port = resend_port
        self.timeout = timeout
        self.resend_left = resend_count
        self.next_timeout = datetime.now().timestamp() + self.timeout

from datetime import datetime

class PartDataReceivedParams(object):
    def __init__(self, data_bytes: bytes, sender_end_point: str, message_id: int, part_number: int, total_parts: int):
        self.total_parts = total_parts
        self.part_number = part_number
        self.message_id = message_id
        self.sender_end_point = sender_end_point
        self.data_bytes = data_bytes
        self.creation_timestamp = datetime.now().timestamp()

class DataReceivedParams:
    def __init__(self, data_bytes: bytes, sender_end_point: str, message_id: int):
        self.message_id = message_id
        self.sender_end_point = sender_end_point
        self.data_bytes = data_bytes

from typing import List

from csv_reader import CsvReader
from data_types import CommunicationPattern

class InputManager:
    def __init__(self, csv_reader: CsvReader):
        self.csv_reader = csv_reader
        self.on_input_row_read: List = []
        self.csv_reader.subscribe_to_read_row(self.row_read)

    def subscribe_on_input_row_read(self, handler):
        self.on_input_row_read.append(handler)

    def raise_on_input_row_read(self, pattern: CommunicationPattern):
        for handler in self.on_input_row_read:
            handler(pattern)

    def row_read(self, row: str):
        pattern = CommunicationPattern()
        pattern.id = int(row[0])
        pattern.timestamp = int(row[1])
        pattern.device_id = row[2]
        pattern.protocol_name = row[3]
        pattern.host = '' if len(row) < 5 else row[4]
        self.raise_on_input_row_read(pattern)

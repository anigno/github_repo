import csv
from threading import Thread

class CsvReader:
    def __init__(self, filename: str, is_live_file=False):
        self.read_row_handlers = []
        self.is_live_file = is_live_file
        self.filename = filename
        self.reading_thread = Thread(target=self.read_thread_start)

    def read_thread_start(self):
        with open(self.filename, newline='') as file:
            csc_reader = csv.reader(file, delimiter=',')
            for row in csc_reader:
                self.raise_read_event(row)

    def raise_read_event(self, row: str):
        for handler in self.read_row_handlers:
            handler(row)

    def subscribe_to_read_row(self, handler):
        self.read_row_handlers.append(handler)

    def start(self):
        if self.is_live_file:
            self.reading_thread.start()
        else:
            self.read_thread_start()

if __name__ == '__main__':
    def test_handler(row):
        print(row)

    cr = CsvReader('test_data\\test.csv')
    cr.subscribe_to_read_row(test_handler)
    cr.start()

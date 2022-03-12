import os

class OutputManager:
    def __init__(self, filename):
        self.file = open(filename, mode='w')

    def close(self):
        self.file.close()

    def write_result(self, text: str):
        self.file.write(text + os.linesep)
        print(text)

if __name__ == '__main__':
    o = OutputManager('test_data\\test.txt')
    o.write_result('aaa')
    o.close()

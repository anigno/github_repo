class AckReceivedParams:
    def __init__(self, reliability_key: str, part_number: int):
        self.reliability_key = reliability_key
        self.part_number = part_number

    def __str__(self):
        return f'[{self.reliability_key} {self.part_number}]'

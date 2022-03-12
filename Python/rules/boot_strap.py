from csv_reader import CsvReader
from input_manager import InputManager
from output_manager import OutputManager
from rules_checker import RulesChecker
from rules_manager import RulesManager

class BootStrap:
    def __init__(self):
        self.rules_csv_reader = CsvReader('test_data\\rules.csv')
        self.input_csv_reader = CsvReader('test_data\\input.csv', is_live_file=True)
        self.output_manager = OutputManager('test_data\\results.txt')
        self.rules_manager = RulesManager(self.rules_csv_reader)
        self.input_manager = InputManager(self.input_csv_reader)
        self.rules_checker = RulesChecker(self.input_manager, self.output_manager, self.rules_manager)
        self.rules_manager.start()
        self.input_csv_reader.start()

    def start(self):
        pass

if __name__ == '__main__':
    boot_strap = BootStrap()
    boot_strap.start()

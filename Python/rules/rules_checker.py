from data_types import CommunicationPattern
from input_manager import InputManager
from output_manager import OutputManager
from rules_manager import RulesManager

class RulesChecker:
    def __init__(self, input_manager: InputManager, output_manager: OutputManager, rules_manager: RulesManager):
        self.rules_manager = rules_manager
        self.output_manager = output_manager
        self.input_manager = input_manager
        self.input_manager.subscribe_on_input_row_read(self.handle_input)

    def handle_input(self, pattern: CommunicationPattern):
        rules = self.rules_manager.check_rules(pattern)
        if len(rules) > 0:
            multi_rules = self.rules_manager.check_multi_rule(rules)
            if multi_rules:
                self.output_manager.write_result(f'{pattern.id} {pattern.device_id} {multi_rules[-1].classification}')
            else:
                self.output_manager.write_result(f'{pattern.id} {pattern.device_id} {rules[-1].classification}')


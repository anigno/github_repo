from typing import List

from csv_reader import CsvReader
from data_types import CommunicationPattern, Rule
from rule_testers import RuleTesterBase, RuleTesterByCommunicationProtocol, RuleTesterByCommunicatingWith, RuleTesterByCommunicatingWithSubnet, \
    RuleTesterByCommunicatingWithDomain, MultiRuleTester

class RulesManager:
    """
    responsible for handling and checking rules
    """

    def __init__(self, csv_reader: CsvReader):
        self.csv_reader = csv_reader
        self.rules_testers_list: List[RuleTesterBase] = []
        self.multi_rules_list: List[MultiRuleTester] = []

    def start(self):
        self.csv_reader.subscribe_to_read_row(self.read_rule)
        self.csv_reader.start()

    def check_rules(self, pattern: CommunicationPattern) -> List[Rule]:
        found_rules = []
        for tester in self.rules_testers_list:
            if tester.check_rule(pattern):
                found_rules.append(tester.rule)
        return found_rules

    def check_multi_rule(self, rules_list: List[Rule]) -> List[Rule]:
        found_multi_rules = []
        for tester in self.multi_rules_list:
            if tester.check_rule(rules_list):
                found_multi_rules.append(tester.rule)
        return found_multi_rules

    def create_rule_from_row(self, row: List[str]):
        rule = Rule()
        rule.id = int(row[0])
        rule.type = row[1]
        rule.argument = row[2]
        rule.classification = row[3]
        return rule

    def read_rule(self, rule_row: List[str]):
        # build RuleTester items
        rule: Rule = self.create_rule_from_row(rule_row)
        tester = None
        if rule.type == 'communicating_protocol':
            tester = RuleTesterByCommunicationProtocol(rule)
        elif rule.type == 'communicating_with':
            tester = RuleTesterByCommunicatingWith(rule)
        elif rule.type == 'communicating_with_subnet':
            tester = RuleTesterByCommunicatingWithSubnet(rule)
        elif rule.type == 'communicating_with_domain':
            tester = RuleTesterByCommunicatingWithDomain(rule)
        if tester:
            self.rules_testers_list.append(tester)
            return
        tester = MultiRuleTester(rule)
        self.multi_rules_list.append(tester)

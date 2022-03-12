import ipaddress
from abc import ABC, abstractmethod
from typing import List

from data_types import CommunicationPattern, Rule

class RuleTesterBase(ABC):
    def __init__(self, rule: Rule):
        self.rule = rule

    @abstractmethod
    def check_rule(self, pattern: CommunicationPattern) -> bool:
        pass

class RuleTesterByCommunicationProtocol(RuleTesterBase):
    def __init__(self, rule: Rule):
        super().__init__(rule)
        self.protocol = rule.argument

    def check_rule(self, pattern: CommunicationPattern) -> bool:
        return pattern.protocol_name == self.protocol

class RuleTesterByCommunicatingWith(RuleTesterBase):
    def __init__(self, rule: Rule):
        super().__init__(rule)
        self.ip = rule.argument

    def check_rule(self, pattern: CommunicationPattern) -> bool:
        return pattern.host == self.ip

class RuleTesterByCommunicatingWithSubnet(RuleTesterBase):
    def __init__(self, rule: Rule):
        super().__init__(rule)
        self.ip_and_subnet = rule.argument

    def check_rule(self, pattern: CommunicationPattern) -> bool:
        try:
            return ipaddress.ip_address(pattern.host) in ipaddress.ip_network(self.ip_and_subnet)
        except:
            return False


class RuleTesterByCommunicatingWithDomain(RuleTesterBase):
    def __init__(self, rule: Rule):
        super().__init__(rule)
        self.domain = rule.argument

    def check_rule(self, pattern: CommunicationPattern) -> bool:
        return self.domain in pattern.host

class MultiRuleTester:
    def __init__(self, rule: Rule):
        self.rule = rule

    def check_rule(self, rules_list: List[Rule]) -> bool:
        # TODO: implement
        return False

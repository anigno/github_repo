from abc import ABC, abstractmethod
from typing import Dict, Union

class ConfigurationBase(ABC):
    def __init__(self, conf_dict: Dict[str, any]):
        self.conf_dict = conf_dict
        self.init_values_and_validate()

    @abstractmethod
    def init_values_and_validate(self):
        pass

    def __str__(self):
        return self.conf_dict.__str__()

if __name__ == '__main__':
    class TestConf(ConfigurationBase):
        def __init__(self, conf_dict: Dict[str, Union[str, int, float]]):
            super().__init__(conf_dict)

    conf_dict = {'a': 11, 'b': 3.14}
    conf = TestConf(conf_dict)
    print(conf)

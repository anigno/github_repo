from core.configuration.configuration_base import ConfigurationBase

class NetworkCommunicatorConfig(ConfigurationBase):
    _SCHEMA = {
        "type": "object",
        "properties": {
            "cleaning_wakeup_interval": {"type": "number", "minimum": 0.01, "maximum": 1000.0, "default": 7},
            "old_message_interval": {"type": "number", "minimum": 0.01, "maximum": 1000.0, "default": 8},
        }, "additionalProperties": False}

    def __init__(self, conf_data):
        super().__init__(conf_data)
        self._old_message_interval = None
        self._cleaning_wakeup_interval = None

    @property
    def schema(self):
        return NetworkCommunicatorConfig._SCHEMA

    @property
    def cleaning_wakeup_interval(self):
        return self._get_property('cleaning_wakeup_interval')

    @property
    def old_message_interval(self):
        return self._get_property('old_message_interval')

if __name__ == '__main__':
    conf_data1 = {"old_message_interval": 17, "cleaning_wakeup_interval": 7}
    network_config = NetworkCommunicatorConfig(conf_data1)
    assert network_config.cleaning_wakeup_interval == 7
    assert network_config.old_message_interval == 17

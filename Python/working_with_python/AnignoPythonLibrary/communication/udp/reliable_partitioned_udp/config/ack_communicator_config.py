from core.configuration.configuration_base import ConfigurationBase

class AckCommunicatorConfig(ConfigurationBase):
    def __init__(self, conf_data: dict):
        super().__init__(conf_data)

    _SCHEMA = {"type": "object",
               "properties": {"ack_local_ip": {"type": "string", "default": ''},
                              "ack_port": {"type": "number", "minimum": 0, "maximum": 65535, "default": 1},
                              "receive_buffer_size": {"type": "number", "minimum": 0, "maximum": 1000000, "default": 1024}},
               "additionalProperties": False
               }

    @property
    def schema(self):
        return AckCommunicatorConfig._SCHEMA

    @property
    def ack_local_ip(self) -> str:
        return self._get_property('ack_local_ip')

    @property
    def ack_port(self):
        return self._get_property('ack_port')

    @property
    def receive_buffer_size(self):
        return self._get_property('receive_buffer_size')

from core.configuration.configuration_base import ConfigurationBase

class DataSenderConfig(ConfigurationBase):
    _SCHEMA = {"type": "object",
               "properties": {
                   "name": {"type": "string", "default": "ERROR_NO_NAME"},
                   "sender_max_packet_size": {"type": "number", "minimum": 0, "maximum": 1000000, "default": 8000},
                   "sender_local_ip": {"type": "string", "default": "127.0.0.1"},
                   "sender_local_port": {"type": "number", "minimum": 0, "maximum": 65535, "default": 1001},
                   "sender_is_multicast": {"type": "boolean", "default": True},
                   "is_use_reliability": {"type": "boolean", "default": True},
                   "sender_resend_unicast_port": {"type": "number", "minimum": 0, "maximum": 65535, "default": 1051},
                   "ttl": {"type": "number", "minimum": 0, "maximum": 100, "default": 64},
                   "reliability_wakeup_interval": {"type": "number", "minimum": 0, "maximum": 100, "default": 0.5}},
               "additionalProperties": False
               }

    def __init__(self, conf_data: dict):
        super().__init__(conf_data)

    @property
    def schema(self):
        return DataSenderConfig._SCHEMA

    @property
    def name(self):
        return self._get_property('name')

    @property
    def sender_max_packet_size(self):
        """
        data sent will be divided to parts less then this size
        """
        return self._get_property('sender_max_packet_size')

    @property
    def sender_local_ip(self):
        """
        local ip for adapter binding
        """
        return self._get_property('sender_local_ip')

    @property
    def sender_local_port(self):
        """
        local port for adapter binding
        """
        return self._get_property('sender_local_port')

    @property
    def sender_is_multicast(self):
        """
        sender used for multicast messages
        """
        return self._get_property('sender_is_multicast')

    @property
    def sender_resend_unicast_port(self):
        """
        if multicast not received, unicast resend to port and verification ip
        """
        return self._get_property('sender_resend_unicast_port')

    @property
    def reliability_wakeup_interval(self):
        """
        interval for reliability thread to check reliability data timeout and old
        """
        return self._get_property('reliability_wakeup_interval')

    @property
    def is_use_reliability(self):
        """
        if this sender support reliability, or reliability supported by network
        true - reliability supported by sender
        false- by network
        """
        return self._get_property('is_use_reliability')

    @property
    def ttl(self):
        return self._get_property('ttl')

from AnignoPythonLibrary.common.configuration.configuration_base import ConfigurationBase

class DataReceiverConfig(ConfigurationBase):
    def __init__(self, conf_data: dict):
        super().__init__(conf_data)

    def init_values_and_validate(self):
        self.local_bind_ip = self.conf_dict['local_bind_ip']
        self.is_multicast = self.conf_dict['is_multicast']
        self.multicast_ip = self.conf_dict['multicast_ip']
        self.receive_buffer_size = self.conf_dict['receive_buffer_size']

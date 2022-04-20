class MessageSendingData:
    def __init__(self, ttl: int = -1, is_sd: bool = False, qos_header_value=-1):
        self.ttl = ttl  # for any negative number, value will be taken from network sender config
        self.is_sd = is_sd  # if True, special SD sender is selected
        self.qos_header_value = qos_header_value  # for any negative number, value will not be set in socket header

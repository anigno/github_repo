from typing import Optional

class Rule:
    def __init__(self):
        self.id: int = -1
        self.type: str = ''
        self.argument: Optional[str] = None
        self.classification: str = ''

class CommunicationPattern:
    def __init__(self):
        self.id: int = -1
        self.timestamp: int = -1
        self.device_id: str = ''
        self.protocol_name: str = ''
        self.host: str = ''

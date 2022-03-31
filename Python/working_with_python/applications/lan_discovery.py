import concurrent.futures
import socket
import time
from typing import Iterator

class LanDiscovery:
    CONNECTION_TIMEOUT = 0.5
    LINUX_PORTS = [20, 21, 22, 23, 25, 80, 111, 443, 445, 631, 993, 995]
    # WINDOWS_PORTS = [135, 137, 138, 139, 445]
    WINDOWS_PORTS = [135, 139, 445]
    MAC_PORTS = [22, 445, 548, 631]

    def __init__(self):
        test_ports = LanDiscovery.WINDOWS_PORTS
        self.connections_generator = self.generate_connections_test('192.168.1.', test_ports)
        self.found_hostnames = {}

    def generate_connections_test(self, base_ip: str, test_ports: Iterator) -> tuple:
        for i in range(256):
            ip = base_ip + str(i)
            for p in test_ports:
                yield (ip, p)

    def test_connection(self, ip_end_point_tuple) -> int:
        ip = ip_end_point_tuple[0]
        port = ip_end_point_tuple[1]
        with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sock:
            sock.settimeout(LanDiscovery.CONNECTION_TIMEOUT)
            result = sock.connect_ex((ip, port))
        if result == 0:
            hostname = socket.gethostbyaddr(ip)[0]
            if hostname not in self.found_hostnames:
                self.found_hostnames[hostname] = ip
                print(f'result {hostname} {ip}')
        return result

    def start(self, max_workers: int):
        with concurrent.futures.ThreadPoolExecutor(max_workers=max_workers) as executor:
            final_result = executor.map(self.test_connection, self.connections_generator)

if __name__ == '__main__':
    lan_discovery = LanDiscovery()
    lan_discovery.start(max_workers=100)

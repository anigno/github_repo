def build_multicast_ip(ip: str, domain_number: int) -> str:
    """convert ip to the form #.#.domain_number.#"""
    if domain_number == -1:
        return ip
    a = ip.split('.')
    b = f'{a[0]}.{a[1]}.{domain_number}.{a[3]}'
    return b

from typing import Dict, List

def main():
    pass

def merge_two_dict(a: Dict, b: Dict) -> Dict:
    c = {**a, **b}
    return c

def sort_dict_by_values(a: Dict) -> List:
    b = sorted(a.items(), key=lambda x: x[1], reverse=True)
    return b

def sort_dict_by_values2(a: Dict) -> List:
    import operator
    b = sorted(a.items(), key=operator.itemgetter(1),reverse=False)
    return b

if __name__ == '__main__':
    a = {1: 1, 2: 2}
    b = {2: 2, 3: 3}
    c = merge_two_dict(a, b)
    print(f'merged dict {c}')
    a = {3: 3, 1: 1, 2: 2}
    b = sort_dict_by_values(a)
    print(f'sorted dict {b}')
    c = sort_dict_by_values2(a)
    print(f'sorted dict2 {c}')




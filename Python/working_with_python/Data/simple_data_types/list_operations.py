import random
import time

def measure_func(k: int, func, *params) -> float:
    t0 = time.perf_counter()
    for a in range(k):
        b = random.randint(0, k)
        func(*params, b)
    t1 = time.perf_counter()
    return t1 - t0

k = 30000
l = []
print(f'append {k} numbers time={measure_func(k, l.append)}')  # 0.036
l = []
print(f'insert {k} numbers time={measure_func(k, l.insert, 0)}')  # 0.338

l = ['a', 'r', 'b', 'hello', 2873]
i = l.index('b')
print(i)  # 2
del l[2]
print(l)  # ['a', 'r', 'hello', 2873]
l.remove('a')
print(l)  # ['r', 'hello', 2873]
l.extend([4, 5, 6])
print(l)  # ['r', 'hello', 2873, 4, 5, 6]
l.append([1, 2, 3])
print(l)  # ['r', 'hello', 2873, 4, 5, 6, [1, 2, 3]]
l = [3, 5, 2, 1, 4]
l.sort()
print(l)  # [1, 2, 3, 4, 5]

l.clear()
print(l)  # []

del l
try:
    print(l)
except Exception as ex:
    print(ex)  # name 'l' is not defined

l = [(i, i * i) for i in range(3, 8, 2)]
print(l)  # [(3, 9), (5, 25), (7, 49)]

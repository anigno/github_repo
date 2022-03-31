import concurrent.futures
import multiprocessing
import os
import time

def some_action(some_data):
    print(f'{os.getpid()} acting on {some_data}')
    time.sleep(1)
    return 'finished' + str(some_data)

data_iteration = {11: 'aaaa',
                  22: 'bbb',
                  33: 'ccc',
                  44: 'ddd',
                  55: 'eee',
                  66: 'fff'}

def test_with_threads():
    print(f'test with threads')
    t0 = time.perf_counter()
    with concurrent.futures.ThreadPoolExecutor(4) as executor:
        result = executor.map(some_action, data_iteration)
    print(time.perf_counter() - t0)
    print(tuple(result))

def test_with_processes():
    print(f'test with processes')
    t0 = time.perf_counter()
    with concurrent.futures.ProcessPoolExecutor(4) as executor:
        result = executor.map(some_action, data_iteration)
    print(time.perf_counter() - t0)
    print(tuple(result))

def test_with_processes_old_way():
    print(f'test with processes old way')
    t0 = time.perf_counter()
    pool=multiprocessing.Pool(processes=4)
    result=pool.map(some_action, data_iteration)
    print(time.perf_counter() - t0)
    print(tuple(result))

if __name__ == '__main__':
    test_with_threads()
    test_with_processes()
    test_with_processes_old_way()
import threading
import time

t0 = time.perf_counter()
i = 0

def signal():
    global t0, i, dt
    i = (i + 1) % 2
    print(f'signal {i}')

def input_thread_start():
    while True:
        signal()
        time.sleep(1)

if __name__ == '__main__':
    thread1 = threading.Thread(target=input_thread_start)
    thread1.start()

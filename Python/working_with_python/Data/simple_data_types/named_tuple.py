from collections import namedtuple

if __name__ == '__main__':
    Car = namedtuple('Car', 'color mileage')
    print(Car)  # <class '__main__.Car'>
    my_car = Car('red', 3812.4)
    print(f'{my_car.color} {my_car.mileage} [{my_car}]')  # red 3812.4 [Car(color='red', mileage=3812.4)]

    try:
        # Car is immutable
        my_car.color = 'blue'
    except Exception as ex:
        print(ex)  # can't set attribute

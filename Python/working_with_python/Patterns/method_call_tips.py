def func(x, y, z):
    print(x, y, z)

func(1, 2, 3)

tuple_params = (4, 5, 6)
func(*tuple_params)

dict_params = {'x': 7, 'y': 8, 'z': 9}
func(**dict_params)

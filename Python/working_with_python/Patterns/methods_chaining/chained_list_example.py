class ChainedList(list):
    def __init__(self, iterable=()):
        super().__init__(iterable)

    def append(self, item) -> "ChainedList":
        super().append(item)
        return self

    def filter(self, items) -> "ChainedList":
        for item in items:
            while item in self:
                self.remove(item)
        return self

if __name__ == '__main__':
    my_list = ChainedList((1, 2, 3, 2, 4, 1))

    my_list.append(5).append(2).filter((2, 4))
    print(my_list)

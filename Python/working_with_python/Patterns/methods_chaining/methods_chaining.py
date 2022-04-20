class Person:
    def __init__(self):
        self.speed = 0
        self.fatigue = 0

    def walk(self):
        self.speed += 1
        self.fatigue += self.speed

    def stop(self):
        self.speed = 0

    def rest(self):
        self.fatigue = 0

class Person_chined(Person):
    """
    each method return self, enables to pipe methods
    """
    def walk(self):
        super().walk()
        return self

    def stop(self):
        super().stop()
        return self

    def rest(self):
        super().rest()
        return self

if __name__ == '__main__':
    person = Person()
    # none chained methods class
    person.walk()
    person.stop()
    person.rest()

    person_chained = Person_chined()
    # chained methods class, pipe methods
    person_chained.walk().stop().rest()

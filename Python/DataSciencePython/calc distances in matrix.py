import numpy as np
import matplotlib.pyplot as plt

pos = np.random.randint(0, 100, (12, 2))

pos1 = pos[:-1]
pos2 = pos[1:]
deltaPos = pos1 - pos2
powPos = deltaPos ** 2
sumPos = powPos[:, 0] + powPos[:, 1]  # x^2+y^2
sqrtPos = np.sqrt(sumPos)

plt.scatter(pos[:, 0], pos[:, 1], s=40, marker='*', color='black')
plt.plot(pos[:, 0], pos[:, 1])

for d, x, y in zip(pos[:, 0], pos[:, 1], sqrtPos):
    plt.annotate(d, (x, y))
plt.show()

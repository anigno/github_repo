import numpy as np
import matplotlib.pyplot as plt

pos = np.random.randint(0, 100, (50, 2))
r = np.random.randint(0, 50, 10)
selected = pos[r]

plt.scatter(pos[:, 0], pos[:, 1], s=90, marker='*', color='red')
plt.scatter(selected[:, 0], selected[:, 1], s=40, marker='*', color='black')
plt.show()

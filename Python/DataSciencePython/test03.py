import numpy as np

mat = np.array([1, 2, 3, 4]).reshape(4, 1)
vec = np.array([10, 20, 30])
newMat = mat + vec  # works only if one of the vectors has one dimension

mask = (mat % 2 == 0)
masked = mat[mask]

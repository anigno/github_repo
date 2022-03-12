import numpy as np
import sys

arr1 = np.array([[1, 2, 3], [4, 5, 6]])
arr2 = np.zeros((3, 4), dtype='int32')

arr3 = np.arange(0, 16)
arr4 = np.reshape(arr3, (2, 8))

arr5 = np.linspace(2, 4, 5)

size = sys.getsizeof(1.23456789)

arr6 = np.arange(10, 30)
arr6 = np.reshape(arr6, (4, 5))

# single cell access
arr6[2, 2] = 70
# slicing
arr7 = arr6[0:3, 1]

fr=2
un=5
st=2
arr8=np.arange(0,9,1)
arr9=arr8[fr:un:st]





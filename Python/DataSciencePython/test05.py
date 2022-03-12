import pandas as pd
import numpy as np

ser = pd.Series([1, 2, 3], index=list("ABC"))
ser2 = pd.Series([4, 5, 6], index=["a", "b", "c"])

print(ser)
print(ser2)

df = pd.DataFrame({'a': [1, 2, 3], 'b': [4, 5, 6]})
print(df)

df2 = pd.DataFrame(np.array([[11, 12], [13, 14]]), index=['a', 'b'], columns=['x', 'y'])

f1 = df2['x']

df['x'] = [10, 20, 30]

f2=df2.iloc[1]
f3=df2.loc['a']


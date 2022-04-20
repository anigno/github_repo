Image = readImage('lena100_SandP.tif');
b=[3 3];
showimage(Image)
a=medianFilt(Image,b);
showimage(a)

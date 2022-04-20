

a= [1:11];
b=a>0;
c=a<0;
SmallImage = [b;c;b;c;b;c;b;c;b;c;b];
SmallImage = SmallImage*255;
putImage(SmallImage);

Result = fourier2d(SmallImage);
PutImage(Result);
s= invfourier(Result);
PutImage(s);

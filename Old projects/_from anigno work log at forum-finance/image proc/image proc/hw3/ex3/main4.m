
a= [1:11];
b=a>0;
c=a<0;
SmallImage = [b;c;b;c;b;c;b;c;b;c;b];
SmallImage = SmallImage*255;
[R, q] = fourierPolar2d(SmallImage) ;

%Prove that convolution is linear:  A*(k1B1+k2B2) = k1A*B1 + k2A*B2

ImageA = readImage('lena100_SandP.tif');
ImageB1 = readImage('lena100.tif');
ImageB2 = readImage('lena100_fnoise1.tif');
k1 = 2;
k2 = 4;

convolveA = convolve(ImageA,(k1.*ImageB1+k2.*ImageB2));
convolveB1 = convolve( (k1.*ImageA) ,ImageB1);
convolveB2 = convolve( (k2.*ImageA) ,ImageB2);
str  = sum(sum(convolveA - convolveB1-convolveB2));
fprintf('The A*(k1B1+k2B2) = k1A*B1 + k2A*B2 Result is :');
disp(str);
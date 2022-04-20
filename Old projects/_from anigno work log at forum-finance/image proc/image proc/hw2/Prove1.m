
% Prove that convolution is commutative (A*B=B*A)

ImageA = readImage('lena100_SandP.tif');
ImageB = readImage('lena100.tif');
ConvolveAB = convolve(ImageA,ImageB);
ConvolveBA = convolve(ImageB,ImageA);
str  = sum(sum(ConvolveAB - ConvolveBA));
fprintf('The A*B-B*A Result is :');
disp(str);
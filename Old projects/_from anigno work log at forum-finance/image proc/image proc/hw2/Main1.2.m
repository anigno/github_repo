
Image_A = readImage('lena100.tif');
Image_B = readImage('lena100_blur.tif');

Image_A = reshape(Image_A , 100 , 100);
Image_B = reshape(Image_B , 100 , 100);

a= convolve(Image_A,Image_B);


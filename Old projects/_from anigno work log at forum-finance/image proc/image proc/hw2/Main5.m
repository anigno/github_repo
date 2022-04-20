imSize = [100 100];
orig =[30 30];


image = delta(imSize,orig);
Image_A = readImage('lena100.tif');
showimage(Image_A)
showimage(convolve(image,Image_A))
    
    













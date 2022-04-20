Image_A = readImage('lena100_SandP.tif');
fprintf('Figure1 Is The Original Image');
showimage(Image_A)


Matrix_Average = ones(3, 3);
Matrix_Average = Matrix_Average./9;

disp('Figure2 Is The Average Image with 3*3');
showimage(convolve(Image_A, Matrix_Average))
Vector_Median = [3 3];
disp('Figure3 Is The Median Image with 3*3');
showimage(MedianFilt(Image_A, Vector_Median))


Image_A_blur = readImage('lena100_blur.tif');
disp('Figure4 Is The Blur Image ');
showimage(Image_A_blur)

disp('Figure5 Is The Blur Image aftre Sharpen of 0.8');
showimage(sharpen(Image_A_blur,0.8))

disp('Figure6 Is Transfered Image ');
Image_A_Tran = readImage('lena100_trans.tif');
showimage(Image_A_Tran)

Vector_Delta_Orig = [-30 -30];
SizeTran = size(Image_A_Tran);
Vector_Delta_Imsize = [SizeTran(1)  SizeTran(2)];
disp('Figure7 Is Center Image ');
showimage(convolve(Image_A_Tran , delta(Vector_Delta_Imsize, Vector_Delta_Orig)))



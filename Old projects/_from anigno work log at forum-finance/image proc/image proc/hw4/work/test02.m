baseImage=readimage('balloons.tif');
image1=baseImage;
fori1=fft2(image1);
fori1=fftshift(fori1);
%putimage(abs(fori1));

m1=[0 0 1;0 0 1;0 1 0;0 1 0;1 0 0;1 0 0 ]/6
m2=[1 0 0;1 0 0;0 1 0;0 1 0;0 0 1;0 0 1]/6
m3=[1 1 0 0 0 0;0 0 1 1 0 0 ;0 0 0 0 1 1]/6
m4=[0 0 0 0 1 1;0 0 1 1 0 0 ;1 1 0 0 0 0]/6
fori2=convolve(fori1,m);
fori2=fori1-fori2;
%putimage(abs(fori2));
putimage(abs(fori2)-abs(fori1));
fftshift(fori2);
fori3=ifft2(fori2);
putimage(abs(fori3));


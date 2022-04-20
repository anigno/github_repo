disp(' ')
disp(' ')
disp('hw 3 image processing')
disp(' ')
%1
disp(' ')
disp('show all fourier basis functions');
for i=0:10
    for j=0:10
        bases=fbasis2d(i,j);
        colormap(gray(255));
        subplot(11,11,i*11+j+1);
        imagesc(bases);
        axis off         
    end
end
pause(5);
%2

disp(' ')
disp('testOrtho2d()  will return 1 if orthonormal');
vSpaceDim = [ 11 11];
basisFunc = 'FBasis2d';
' for orthonormal result =1'
Result = testOrtho2d(basisFunc,vSpaceDim)
pause(5);

%4
disp(' ')
disp('create 2d sine image');
a=[0:10];
b=(sin(a/10*pi/2));
image=round((b'*b)*100);
putimage(image);
title('sine image for testing');
colormap(gray(255));
pause(5);

%5
disp(' ')
disp('show the fourier2d of the image');
f=fourier2d(image);
fs=fftshift(f);
putimage(fs);
title('fourier2d of the image');
colormap(gray(255));
pause(5);

%6
disp(' ')
disp('show invert fourier back to original image');
f2=invfourier2d(f);
putimage(f2);
title('invert fourier back to original image');
pause(5);

%7
disp(' ')
disp('polar fourier')
[a,b]=fourierPolar2d(image);
putimage(fftshift(a));
title('polar fourier')
pause(5);

%8
disp(' ')
disp('difference between image and inverse polar')
disp('should be almost zero (+-)1e-10')
[a,b]=fourierPolar2d(image);
f2=(invfourierPolar2d(a,b));
sum(sum(image-f2))
pause(2);


%9
disp(' ')
disp('show  simmetric')
disp('flip polar fourier, difference should be zero');
[a,b]=fourierPolar2d(image);
polarImage=fftshift(a);
leftRight=fliplr(polarImage);
upDown=flipud(leftRight);
sum(sum(polarImage-upDown))
pause(2);

%10
disp(' ')
disp('invertive symmetric')
disp('flip twice and add theta to flipped theta')
disp('devide by pi/2, result should be integers')
[a,b]=fourierPolar2d(image);
st=fftshift(b);
fl1=flipud(st);
fl2=fliplr(fl1);
fl2=fl2;
(st+fl2)/(pi/2)
pause(2);

%11
disp(' ')
disp('linearity of the Fourier Transform ');
c=input('enter constant number please: ');
f1=fourier2d(c*image);
f2=c*fourier2d(image);
disp('result should be zeros (almost (+-)1e-10')
sum(sum(f1-f2))
pause(2);

%12
disp(' ')
disp('additivity of the Fourier Transform')
a=ones(11,1).*256;
b=zeros(11,1);
image2=[a b a b a b a b a b a];
f1=fourier2d(image+image2);
f2=fourier2d(image)+fourier2d(image2);
disp('result should be zeros (almost (+-)1e-10')
sum(sum(f1-f2))


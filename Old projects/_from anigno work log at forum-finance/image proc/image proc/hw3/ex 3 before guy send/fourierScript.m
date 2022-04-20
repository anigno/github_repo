%1
printf('show all base matrixes in one picture');
for i=0:10
    for j=0:10
        bases=fbasis2d(i,j);
        colormap(gray(255));
        axis off 
        subplot(11,11,i*11+j+1);imagesc(bases);
    end
end
input('press enter to continue');


%2
%result will be 1 if orthonormal
vSpaceDim = [ 11 11];
basisFunc = 'FBasis2d';
' for orthonormal result =1'
Result = testOrtho2d(basisFunc,vSpaceDim);


%if orthonormal, show line across, show that only 1's in main ALACHSON
for i=0:1:10
    for j=0:1:10
        base=fbasis2d(i,j);
        a=reshape(base,1,121);
        if (i==0  && j==0)
            bases_sum=a;
        else
        bases_sum=[bases_sum;a];
        end
    end
end
a=bases_sum'*bases_sum;
b=abs(a)>1e-10;
putimage(a.*256);

%4
%create 2d image
a=[1:11];
r0=a<0;
r1=(a>0)*256;
image=[r1;r0;r1;r1;r0;r1;r0;r1;r1;r0;r1];
putimage(image);

%5
%show the fourier image
f=fourier2d(d);
f1=abs(f);
m=256/max(max(f1));
f1=f1.*m;
putimage(f1);

%6
%show invert fourier back to original image
f2=invfourier2d(f);
putimage(f2);

%7
%polar fourier
[a,b]=fourierPolar2d(image);
m=256/max(max(a));
b=a.*m;
putimage(b);

%8
%inverse polar fourier, return to image
f2=invfourierPolar2d(a,b);
putimage(f2);

%9
% show simmetric
[a,b]=fourierPolar2d(image);
polarImage=fftshift(a);
%show original polar fourier
putimage(polarImage);
%transform polar image up/down and left/right
leftRight=fliplr(polarImage);
upDown=flipud(polarImage);
%both substructions must be zero (black) images
putimage(polarImage-leftRight);
putimage(polarImage-upDown);

%10
%invertive symmetric sum to pi/2
[a,b]=fourierPolar2d(image);
b=fftshift(b);
c=flipud(b);
c=fliplr(c);
d=b+c;
%the image shoud be the same color all (pi/2*10)
putimage(d*10);

%11
%linearity of the Fourier Transform 
f1=fourier2d(5.*image);
f2=5.*fourier2d(image);
%this image should be black, because it is the same result
putimage(f1-f2);

%12
%additivity of the Fourier Transform
a=ones(11,1).*256;
b=zeros(11,1);
image2=[a b a b a b a b a b a];
f1=fourier2d(image+image2);
f2=fourier2d(image)+fourier2d(image2);
%the image should be black(zeros values)
putimage(f1-f2);


ImageWaterfall = readImage('oldFaithful.tif');
tmp=fft2(ImageWaterfall);
tmp= fftshift(tmp);
%putimage(abs(tmp)/500);
%[x,y]= ginput

A = zeros(1,2);


tmp( 123 : 123,98:99 ) = A;
tmp(135 : 135, 158:159 ) = A;
%putimage(abs(tmp)/500);

tmp= ifft2(tmp);
%putimage(abs(tmp));


B=[1 1;1 1]*0.25;
C = conv2(B,abs(tmp)) ;
putimage(abs(C));

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

Imagepanda = readImage('panda.tif');
%putimage(Imagepanda);

Imagesharpen = sharpen(Imagepanda,0.9);
putimage(Imagesharpen);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
Image = readImage('diningroom.tif');

Image = Image.*4.9;
putimage(Image);

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
Image_A = readImage('lighthouse.tif');

for i = 0 :1:15
    
    %white points
    Image_B = Image_A>254;

    %black point
    Image_C = Image_A<1;
    Image_Noise = Image_B + Image_C;



   
    if mod(i,4)==0
        vector = [0  0  ; 0  1];
    end
     if mod(i,4)==1
        vector = [0  1  ; 0  0];
     end
    if mod(i,4)==2
        vector = [1  0  ; 0  0];
    end
    if mod(i,4)==3
        vector = [0  0  ; 1  0];
    end
    Image_D = convolve(Image_A,vector);

    Image_D = Image_D.*Image_Noise;
  
    %black point on new picture

    Only_Black=Image_A - Image_B*255;
    Image_A= Only_Black +Image_D;

end
putimage(Image_A);




%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

ImageWaterfall = readImage('carbacks.tif');
%putimage(ImageWaterfall);
tmp=fft2(ImageWaterfall);
tmp= fftshift(tmp);
%putimage(abs(tmp)/500);
%[x,y]= ginput

A = zeros(1,1);


tmp( 129 : 129,70:70 ) = A;
tmp(129 : 129, 188:188 ) = A;
%putimage(abs(tmp)/500);
%tmp = tmp*0.9;
tmp= ifft2(tmp);
%putimage(abs(tmp));
Image_A=abs(tmp);
Vector_Median = [3 3];
Lst_Image = MedianFilt(Image_A, Vector_Median);
%putimage(Lst_Image)
putimage(sharpen(Lst_Image,1))

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

ImageElephent = readImage('elephant.tif');

image1=ImageElephent;
%putimage((image1));
%for i=1.4:0.2:3
    i=1.6;
    fori1=fft2(image1);
    fori1=fftshift(fori1);
    d=donat(i,i+6);
    d=d<1;
    fori2=fori1.*d*0.8;
    %putimage(abs(fori2));
    fori2=fftshift(fori2);
    image2=ifft2(fori2);
    %putimage(abs(image2));
    image3=sharpen(image2,0.2);
   image3 = image3*1.05;
    putimage(abs(image3));
    
   
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
baseImage=readimage('balloons.tif');
image1=baseImage;
fImageConvMask=fft2(image1);
m=zeros(256,256);
m(128,128)=.5;
m(132,137)=.5;
fm=fft2(m);
fm2=(abs(fm) < 1e-3);
fm=fm.*(1-fm2)+ fm2;
fImage=fImageConvMask./fm;
imageFinal=fftshift(ifft2(fImage));
showimage(abs(imageFinal));

   %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

 
baseImage=readimage('camel.tif');
%putimage(baseImage);
%[x,y]= ginput
image1=baseImage;
fImageConvMask=fft2(image1);
m=zeros(256,256);
m(121 : 135,128)=1/15;
%shift matrix down
m = circshift(m,10);

fm=fft2(m);
%search for small numbers close to zero
fm2=(abs(fm) < 2e-2);
%replace those numbers with one for divide
fm=fm.*(1-fm2)+ fm2;
% because it's 1 you take the original mask
fImage=fImageConvMask./fm;
imageFinal=fftshift(ifft2(fImage));
showimage(abs(imageFinal));

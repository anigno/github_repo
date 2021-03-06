baseImage=readimage('balloons.tif');
image1=baseImage;
fori1=fft2(image1);
fori1=fftshift(fori1);

a=[1:700];
a=a<1;
d=[1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20];
e=d*28.5;
a(1)=1;
a(round(e))=1;
for i=1:1:15
    h=zeros(1,i);
    g=[h(1:i) a(i:699)];
    a=a+g;
end
c=[a(1:1+255);a(2:2+255)];
for i=3:1:120
    b=a(i:i+255);
    c=[c;b;b];
    f=mod(i,4);
    if(f==0)
        c=[c;b];
    end
end
c=c(1:256,1:256);
%putimage(c*255)
c=c<1;

%putimage(abs(fori1))
putimage(abs(fori1)/30)
fori1=fori1.*c;
putimage(abs(fori1)/30)

fori1=fftshift(fori1);
image2=ifft2(fori1);
putimage(abs(image2));
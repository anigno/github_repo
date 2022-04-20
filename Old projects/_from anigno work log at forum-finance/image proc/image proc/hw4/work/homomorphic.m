function ret=homomorphic(inputImage,lowPassValue)
tmp=inputImage;
tmp=log(tmp);
tmp=fft2(tmp);
lp=lowPass(lowPassValue);
tmp=tmp.*lp;
tmp=ifft2(tmp);
tmp=exp(tmp);
ret=tmp;
end
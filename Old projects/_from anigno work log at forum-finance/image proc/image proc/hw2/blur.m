% This Function Gives A Blurred Image

function    nim = blur(im,strength)

SizeIm = size(im);
a1 = round(SizeIm(1)*strength/2);
x = -a1:a1;
% The Sigma Should Be As follow Becuase of the Graph
%The Strength Is In ^ Because We Wanted To Have Good Performance 

sigma = (1/6)/(1.001- strength^0.1);
d = exp(-(x.^2/sigma)); 
mask = conv2(d',d); 
mask = mask./sum(sum(mask));
% Perform Convolve With The New Mask
nim = convolve(im,mask);
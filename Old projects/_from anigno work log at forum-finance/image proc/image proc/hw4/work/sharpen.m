% This Function Will Sharp The Image

function    nim = sharpen(im,strength)
% This Is The Mask We Selected
G = ones(5, 5);
G = G./25;
Delta = zeros(5,5);
Delta (3,3)=1;
SMask = (1+strength)*Delta - strength*G;

nim=convolve(im,SMask);
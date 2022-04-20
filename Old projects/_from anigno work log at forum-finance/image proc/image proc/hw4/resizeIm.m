function nim = resizeIm(im,nrow,ncol)
% 
% function nim = resizeIm(im,nrow,ncol)
%
% Function resizes the image im to beof size [nrow,ncol]
% uses interp2 with linear interpolation.
%

nim = round(interp2(im,[1:(size(im,2)-1)./(ncol-1):size(im,2)],[1:(size(im,1)-1)./(nrow-1):size(im,1)]' ));


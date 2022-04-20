function [R, Theta] = fourierPolar2d(S)

bSize = 11;

T = fourier2d(S);

tmp_matrix = T;
%flip first and second
tmp_matrix( 1, 2 : bSize) = fliplr(tmp_matrix( 1, 2 : bSize));
tmp_matrix( 2 : bSize, 1) = flipud(tmp_matrix( 2 : bSize, 1));
%flip all others
tmp_matrix( 2 : bSize, 2 : bSize) = fliplr(flipud(tmp_matrix(2 : bSize, 2 : bSize)));
tmp_matrix(1,1) = 0;

R = sqrt(T.^2 + tmp_matrix .^2);
Theta = atan2( tmp_matrix, T);
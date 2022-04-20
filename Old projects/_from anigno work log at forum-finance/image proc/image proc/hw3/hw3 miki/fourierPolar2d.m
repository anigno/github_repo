%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function [R, Theta] = fourierPolar2d(S)
%           Computes the Fourier transform of S using the above defined basis vectors. 
%            The representation is in “polar” coordinates [R, q]. 
%
%             Input:      S - a 2D grayscale image of size [11x11] in the range [0..255]. 
%             Output:    R - a 2D array of size 11x11, containing the amplitude of the Fourier Coefficients. 
%                             q - a 2D array of size 11x11, containing the phase of the Fourier Coefficients 

size = 11;

T = fourier2d(S);

Copy = T;
Copy( 1, 2 : size) = fliplr(Copy( 1, 2 : size));
Copy( 2 : size, 1) = flipud(Copy( 2 : size, 1));
Copy( 2 : size, 2 : size) = fliplr(flipud(Copy(2 : size, 2 : size)));
Copy(1,1) = 0;

R = sqrt(T.^2 + Copy .^2);
Theta = atan2( Copy, T);
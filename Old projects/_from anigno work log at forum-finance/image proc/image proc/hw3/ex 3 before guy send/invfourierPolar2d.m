%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function      S = invfourierPolar2d(R, Theta) 
%            Computes the inverse fourier transform. Given a vector represented in Fourier polar coordinates, 
%            returns the vector in the standard basis. 
%
%            Input:      R - a 2D array of size 11x11, containing the amplitude of the Fourier Coefficients. 
%                                 Theta - a 2D array of size 11x11, containing the phase of the Fourier Coefficients 
%            Output:   S - a 2D grayscale image of size 11x11 in the range [0..255]. 

S = invfourier2d(R .* cos(Theta));


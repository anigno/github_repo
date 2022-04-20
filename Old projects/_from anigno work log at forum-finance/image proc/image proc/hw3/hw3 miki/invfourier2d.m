%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function    S = invfourier2d(T)
%            Computes the inverse Fourier transform of T. That is, receives a 2D image T
%            represented in the 2d basis defined above, and gives as output the image
%            represented in the standard basis.
%
%            Input:      T - a 2D array of size 11x11, containing the Fourier transform of s.
%                                 That is T contains all the coefficients of s in the Fourier domain,
%                                 such that T(c,r) contains the coefficient of basis (c,r).
%            Output:   S - a 2D grayscale image of size 11x11 in the range [0..255].

sizex = 11;
sizey = 11;

S = zeros(sizex, sizey);
for i = 1 : sizex
    for j = 1 : sizey
        S = S + T(i,j) * FBasis2d(i-1,j-1);
    end
end




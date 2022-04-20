%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function    T = fourier2d(S)
%            Computes the fourier transform of s using the above defined
%            basis vectors.
%
%            Input:      S - a 2D grayscale image of size 11x11 in the range [0..255].
%            Output:   T - a 2D array, containing the Fourier transform of s. That is T contains all
%                                the coefficients of s in the Fourier domain.
%


xsize = 11;
ysize = 11;

for i = 1 : xsize
    for j = 1 : ysize
        T(i,j) = sum(sum( S .* FBasis2d(i-1,j-1)));
    end
end
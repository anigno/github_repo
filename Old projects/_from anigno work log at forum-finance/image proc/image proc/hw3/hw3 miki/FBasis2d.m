%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function    B2d = FBasis2d(kx,ky) 
%            This routine creates the 2D Fourier Basis vector indexed by kx,ky. 
%
%            Input:      kx,ky - integers in the range [0..10] 
%            Output:    B2d - a 2D image containing the (kx,ky) -th Fourier Basis. 
%
%            Method:  Multiply the two 1d basis vectors Bkx and Bky to obtain
%                            the 2d basis. Make sure Bkx is in the x-direction and Bky
%                            in the y direction (i.e. x are along the row and y along the columns).

B2d = FBasis1d(ky)' * FBasis1d(kx) ;
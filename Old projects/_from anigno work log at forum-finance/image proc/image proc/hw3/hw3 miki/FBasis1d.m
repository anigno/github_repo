%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function    B = FBasis1d(k) 
%             (file name is accordingly FBasis1d.m ) 
%          This routine creates the k-th 1D Fourier Basis vector. 
%
%            Input:      k - an integer in the range [0..10] 
%            Output:    B1d - a 1D image containing the k-th Fourier Basis. 
%
%            Method:  Assume a 1D vector x=0,1,2,..10, the 1D basis 
%                           vectors are defined as:

size = 11;
x = 0 : (size - 1);

if( k == 0 ) 
    B = ones(1, size) * sqrt(1 / size);
else 
    if ( (k > 0) && (k <= floor(size / 2)) )
        B = sqrt(2/size) * cos(2*pi*x*k / size);
    else
        k = 2*floor(size / 2) - k + 1;
        %k = k - floor(size / 2);
        B = sqrt(2/size) * sin(2*pi*x*k / size);
    end
end
        
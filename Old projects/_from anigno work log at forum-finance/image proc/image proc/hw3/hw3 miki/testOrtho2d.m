%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

function    Result = testOrtho2d(basisFunc,vSpaceDim); 
%            Tests that a given 2d Basis set is orthonormal. 
%
%            Input:      basisFunc - a string containing the name of the routine that
%                            creates a basis vector (e.g. 'FBasis2d'). 
%                            vSpaceSize - the size of the linear space
%                                                  (in our case vSpaceSize = [11,11]). 
%            Output:    Result - a number representing the answer:  
%                               0 = basis is not orthogonal 
%                                 1 = basis is othonormal 
%                               2 = basis is orthoganal (but not
%                               orthonormal)

epsilon = 10 ^ -10;

% build a basis matrix
M = zeros(vSpaceDim(1) * vSpaceDim(2), 1);
for i =0 : vSpaceDim(1) - 1
    for j = 0 : vSpaceDim(2) - 1
        u =eval( [ basisFunc '(' int2str(i) ',' int2str(j) ');' ] );
        u = reshape(u, 1, vSpaceDim(1) * vSpaceDim(2));
        if ( abs( u ) < epsilon )
            Result = 0;
            return;
        end
        M = [  u' M ];
    end
end
M = M( 1 : size(M,1) , 1 : size(M,2) - 1);

% check if the matrix is orthogonal/orthonormal/none
P = M' * M;

if( abs(P - eye( vSpaceDim(1) * vSpaceDim(2) )) < epsilon )
    Result = 1;
else
    [i,j] = find( abs(P) > epsilon );
    if( i == j )
        Result = 2;
    else
        Result = 0;
    end
end
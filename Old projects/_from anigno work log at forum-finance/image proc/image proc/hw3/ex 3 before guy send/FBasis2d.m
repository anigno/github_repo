function    B2d = FBasis2d(kx,ky)
X=FBasis1d(kx) ;
Y = FBasis1d(ky) ;
B2d =X' * Y;
function    T = fourier2d(S) 


N = 11;
M = 11;
NewMatrix = zeros(11,11);

%multiple fbase on the matrix
for x= 0 : 1: N-1
    for y = 0 : 1 : M-1
        FB = FBasis2d(x,y);
        TmpMatrix = S.*FB;
        SumMatrix = sum(sum(TmpMatrix));
        NewMatrix(x+1,y+1)=SumMatrix;
       
    end
end
T = NewMatrix;
function S=invfourier2d(T)

 NewImage = zeros(11,11);
 

%multiple matrix cell on each fbase and sum it
for i = 0 : 10
    for j = 0 : 10
        
        FB = FBasis2d(i,j);
        TmpMatrix = T(i+1,j+1) * FB;
         NewImage = NewImage + TmpMatrix;
             
    end
end

S=NewImage;
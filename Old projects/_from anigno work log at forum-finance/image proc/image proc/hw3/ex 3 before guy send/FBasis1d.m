function    B1d = FBasis1d(k) 

Bsize = 11;
TmpVector =[ 0:Bsize-1];

if (k ==0)
    ReturnVector = zeros(1 , Bsize);
    ReturnVector =ReturnVector+ (1/Bsize)^0.5;
else
    if k<=5
        ReturnVector  =( ( 2/Bsize ) ^ 0.5 .* cos ( (2* pi * k * TmpVector )/Bsize )  );
    else
        ReturnVector= ( ( 2/Bsize ) ^ 0.5 .* sin ( (2*pi * k * TmpVector)/Bsize) );
     end
end
     B1d = ReturnVector;
     
     
        
        
    
    
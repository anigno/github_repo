function    Result = testOrtho2d(basisFunc,vSpaceDim); 

BigMatrix = zeros(1,vSpaceDim(1) * vSpaceDim(2));

for i=0 : 1 : vSpaceDim(1)-1
    for j=0 : 1: vSpaceDim(2)-1
      
        
        commandString = ['MatrixTmp =' basisFunc  '(' int2str( i)  ',' int2str( j )  ');'] ;
        eval(commandString);
        MatrixVector = reshape (MatrixTmp ,1,vSpaceDim(1) * vSpaceDim(2) );
       if (i==0 && j==0)
           BigMatrix =  MatrixVector;
       else
           BigMatrix = [BigMatrix  ; MatrixVector];
       end
    end
end

CheckMatrix = BigMatrix * BigMatrix';


a= abs ( CheckMatrix)>1e-010;                              % cleaning sides
CheckMatrix = CheckMatrix .* a;



Answer = eye(vSpaceDim(1) * vSpaceDim(2)) - CheckMatrix;

a= abs( Answer)>1e-010       ;                               % cleaning sides
Answer = Answer .* a;


if Answer ==0
    Result = 1;
else
    tmp = eye(vSpaceDim(1) * vSpaceDim(2))<1;
    tmp1 = CheckMatrix .* tmp;
    tmp2 = tmp1~=0;
    if sum(sum ( tmp2) )== 0
        Result = 2;
    else
        Result = 0;
    end
end
    
    


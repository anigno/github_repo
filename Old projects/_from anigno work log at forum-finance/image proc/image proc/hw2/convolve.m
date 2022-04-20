% This Function Convolve Two Images And Return The Convolve Image

function    C = convolve(A,B) 


SizeA = size(A);
SizeB = size(B);
K1 = round (SizeB(1)/2-0.5);
K2 = round (SizeB(2)/2-0.5);

% This Image Will Have Zeros And Teh Original Image In The Center
Image_C = zeros( SizeA(1) +  SizeB(1)  ,  SizeA(2) + SizeB(2) );

B = fliplr(B');
B = fliplr(B');

% This Is The New Image
New_Image = zeros(SizeA(1) , SizeA(2));

% Putting the Original Image In The Center
Image_C (K1 +1: K1 + SizeA(1)  ,  K2+1: K2 + SizeA(2)  )= A;

for i=  1 : 1 :SizeA(1)
    for j=1 : 1 :SizeA(2)
        
       % Slice To Convolve
        Image_D = Image_C ( i : i+ SizeB(1)  -1, j : j+ SizeB(2) -1 ) ;
        New_Image (i , j ) = sum(sum(Image_D.*B ) );
        
    end
end

C = New_Image;
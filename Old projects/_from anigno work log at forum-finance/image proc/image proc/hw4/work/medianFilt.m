% This Function Fix The "Dirt" In The Image By  Medain Filtering
function    nim = medianFilt(im,winSize) 

SizeA = size(im);
SizeB = winSize;
K1 = round (SizeB(1)/2-0.5);
K2 = round (SizeB(2)/2-0.5);

% This Image Is An Image That in The Center Is The Original Image And On
% All Its Sides Are The Original Image

for i = 1 :SizeA (1) : SizeA(1) +  SizeB(1) +SizeA (1)+SizeA (1)
    for j = 1 : SizeA (2) :SizeA(2) +  SizeB(2) +SizeA (2)+SizeA (2)
         Image_Tmp(i :i + SizeA (1) -1 , j :j + SizeA (2) -1)=im;
    end 
end

% Take that Exact Slice That The original Image In The Center

Image_C  = Image_Tmp (SizeA (1)  + 1 - K1 :2 * SizeA (1) + K1 , SizeA (2)  + 1 - K2:2 * SizeA (2)  + K2);

New_Image = zeros(SizeA(1) , SizeA(2));

% This Will Fix The Image
for i=  1 : 1 :SizeA(1)
    for j=1 : 1 :SizeA(2)
        
        Image_D = Image_C ( i : i+ SizeB(1)  -1, j : j+ SizeB(2) -1 ) ;
        New_Image (i , j ) = Median(Median(Image_D));
        
    end
end

nim = New_Image;


      
   
    


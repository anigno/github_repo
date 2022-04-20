 % This Function Move The Image 
function    nim = delta(imSize,orig) 

 height = imSize(1);
width = imSize(2);
i = orig(1);
j = orig(2);
Delta_Image = zeros(height , width);
if ((round(height/2) -i)>0) && ((round(width/2) -j)>0)
    
    Delta_Image (round(height/2) -i, round(width/2) -j) = 1;
    nim = Delta_Image;
else
    fprintf('Invalid Input');
    Delta_Image (round(height/2) , round(width/2) ) = 1;
    nim = Delta_Image;
end


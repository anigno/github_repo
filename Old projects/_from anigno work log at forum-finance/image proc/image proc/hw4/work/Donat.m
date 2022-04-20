function A = Donat(in,out)


s=zeros(256);
for x=1:256
    for y=1:256
        if ( ( in^2<( (128-x)^2+(128-y)^2) )&& ( (128-x)^2+(128-y)^2 ) < out^2 )
            s(x,y)=1;
        end
    end
end

A = s;
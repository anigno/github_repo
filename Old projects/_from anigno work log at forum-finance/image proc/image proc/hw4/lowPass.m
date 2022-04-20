function ret=lowPass(outBorder)
s=zeros(256);
for x=1:256
    for y=1:256
        if (  ((128-x)^2+(128-y)^2 ) < outBorder^2 )
            s(x,y)=1;
        end
    end
end
ret=s;
end
function    QT = buildQT (im)
sizeIm = size(im);
cycle = round(log2(sizeIm(1))+0.5 );
c = cell(cycle,2);
c{cycle,1} =im;
c{cycle,2} =zeros(sizeIm(1));
for  y=cycle-1 : -1 : 1
     array = zeros((2^y)/2,(2^y)/2);
     array2 = zeros((2^y)/2,(2^y)/2);
    for i = 1 : 1: (2^y)/2
        for j = 1 : 1 : (2^y)/2
            A = c{y+1,1};
            B = c{y+1,2};
            array(i,j) = mean(mean(A(i*2-1 : i*2 ,j*2-1 :j*2)  )   );
            m1 = A(i*2-1,j*2-1);     m2 = A(i*2,j*2-1);   m3 = A(i*2-1,j*2);    m4 = A(i*2,j*2);
            v1 = B(i*2-1,j*2-1);     v2 = B(i*2,j*2-1);   v3 = B(i*2-1,j*2);    v4 = B(i*2,j*2);
            v12 = var2( v1,v2,m1,m2);
            v34 = var2(v3,v4,m3,m4);
            m12 = (m1+m2)/2;
            m34 = (m3+m4)/2;
            v1234= var2(v12,v34,m12,m34);
            array2(i,j) = v1234;
        end 
    end
    c{y,1} = array;
    c{y,2} = array2;
    
end
c{1,1}=mean(mean(array));
QT=c;

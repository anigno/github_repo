function    nim = segImage(QT,thresh) 

s=size(QT);
C = zeros(2^(s(1) - 1 ) );

h = 1;
for i = s(1) :- 1: 1
    A = QT{i,1};
    B = QT{i,2};
    sizeA = size(A);
    for x = 1 :1: sizeA(1)
      for y = 1 :1 :sizeA(2)
          if B(x,y)<=thresh
              C( ( x-1 )*h+1 : x*h , ( y-1 )*h+1 : y*h) = A(x,y);           
          end 
      end 
    end 
    h = h * 2;
end

nim=C;
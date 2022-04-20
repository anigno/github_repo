function cnt = zero_cross(signal)
% This function calculates the number of times that the (continuous) signal changes its
% sign.

shiftedLeft = [0 signal'];
shiftedRight = [signal' 0];

crosses = sign(shiftedLeft) - sign(shiftedRight);

cnt = sum(abs(crosses) == 2);

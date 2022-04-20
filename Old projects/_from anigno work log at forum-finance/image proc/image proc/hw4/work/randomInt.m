function randVals = randomInt(outSize,minInt,maxInt)
% 
% function randVals = randomInt(outSize,minInt,maxInt)
%
% Function returns a matrix the size of outSize of randomly
% chosen integers between minInt and maxInt using a uniform
% distribution over the integers.
%
randVals = floor(rand(outSize).*(maxInt-minInt+1-eps))+ minInt;

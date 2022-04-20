function pitch = pitch_detect(signal)
N = 256;
fs = 8e3;
m = round(fs/50)+1; % maximum gap pitch = 50Hz
n= round(fs/400)+1; % minimum gap pitch = 400Hz
R = xcorr(signal); % calculate the cross-correlation function of the input 'signal'
R = R(256:511) ;               % cutting the symmetrical part and centers vector R
R = R(n:m);                       % cutting unreasonable pitch
[pitch,r] =   find(R ==  max(R)); % taking the gap
pitch = pitch(1)+n-2; % finding the pitch cycle in samples
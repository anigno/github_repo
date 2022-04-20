function Nsig = clip(sig)

CL = 0.67*max(abs(sig));

Nsig = (sig > CL) .* (sig - CL) + (sig < -CL) .* (sig + CL);
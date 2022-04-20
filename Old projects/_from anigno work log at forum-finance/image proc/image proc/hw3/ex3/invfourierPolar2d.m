function      S = invfourierPolar2d(R, T)
%return the real (cos) of R
S = invfourier2d(R .* cos(T));


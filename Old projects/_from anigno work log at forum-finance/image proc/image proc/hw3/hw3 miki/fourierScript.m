%Fourier script
%ID: Alex Shtof - 314148230, Michael Lauterbach - 034817999

disp('Displaying all fourier basis functions...');
colormap(gray(255));
for i = 1 : 11
    for j = 1 : 11
        u = FBasis2d(i-1,j-1);
        subplot(11,11,(i-1) * 11+j);
        imagesc(u);
        axis off;
    end
end

disp('Running testOrtho2d on the fourier basis functions...');
disp('0 - Not orthogonal, 1 - Orthonormal, 2 - Orthogonal but not orthonormal');
testOrtho2d('FBasis2d', [11 11])
pause(2);

%create a gaussian  image
disp('Creating a 2D gaussian image.');
S = -5 : 5;
S = exp(-(S.^2) / 5);
S = conv2(S',S);
figNum = figure;
imagesc(S);
colormap(gray(255));
title('Gaussian 2D image');
pause(2);

disp('Calculating the fourier transform of the image...');
T = fourier2d(S);
figNum = figure;
imagesc(fftshift(T));
colormap(gray(255));
title('The fourier transform of S.');
pause(2);

disp('Reconstructing the image from the fourier transform...');
RS = invfourier2d(T);
figNum = figure;
imagesc(RS);
colormap(gray(255));
title('The reconstructed S from the fourier transform.');
disp('The difference between the reconstructed image and the source  (should be almost zero): ');
RS - S
pause(2);

disp('Calculating the polar transform of S and displaying R...');
[R, Theta] = fourierPolar2d(S);
figNum = figure;
imagesc(fftshift(R));
colormap(gray(255));
title('The R of the fourier polar transform of S.');
pause(2);

disp('Displaying invfourierPolar2d(fourierPolar2d(S))');
RS = invfourierPolar2d(R, Theta);
figNum = figure;
imagesc(RS);
colormap(gray(255));
title('The reconstructed S from the fourier polar transform.');
disp('The difference between the reconstructed image and the source (should be almost zero): ');
RS - S
pause(2);

disp('Showing the R is invertive symmetric.');
disp('Substracting R from the flipped R. The result must be zeros.');
fftshift(R) - flipud(fliplr(fftshift(R)))
pause(2);

disp('Showing the Theta is invertive symmetric.');
disp('Adding Theta and the flipped Theta and dividing by pi/2');
disp('The result must be a matrix of integers');
(fftshift(Theta) + flipud(fliplr(fftshift(Theta)))) / (pi / 2)
pause(2);

disp('Showing the linearity of the fourier transform.');
c = input('Please enter a constant number c: ');
disp('Fourier(c*S) - c*Fourier(S). Must be zeros (lower then 10^-10). ');
fourier2d(c*S) -  c*fourier2d(S)

disp('Showing additivity of the Fourier Transform.');
disp('Fourier(S + P) - (Fourier(S) + Fourier(P)). Must be zeros (lower then 10^-10) .');
P = reshape(1 : 121, 11, 11);
fourier2d(S+P) - (fourier2d(S) + fourier2d(P))

function dct_idct(image)

image = double(image);

% perform DCT on 8x8 blocks of the original image
for i = 1 : 8 : size(image,1) 
    for j = 1 : 8: size(image,2)
        block = image(i:i+7, j:j+7);
        dctImage(i:i+7, j:j+7) = dct2(block);
    end
end

% perform iDCT on 8x8 blocks of the DCT image
for i = 1 : 8 : size(image,1) 
    for j = 1 : 8: size(image,2) 
        block = dctImage(i:i+7, j:j+7);
        reconst(i:i+7, j:j+7) = idct2(block);
    end
end

% show the original image
figure; imagesc(image); colormap(gray(256)); title('Original image');

% show the reconstructed image
figure; imagesc(reconst); colormap(gray(256));title('Reconstructed image');

%show the MST between the original and the reconstructed images
MSE = mse(image, reconst)

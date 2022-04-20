function MSC_dct_idct(image, msc_num)

image = double(image);

% perform DCT on 8x8 blocks of the original image, zero the non-important
% coefficients
for i = 1 : 8 : size(image,1) 
    for j = 1 : 8: size(image,2)
        % perform DCT on a block
        block = image(i:i+7, j:j+7);
        block_dct = dct2(block);
        
        % zero the non-important coefficients
        X = [ 1 1 2 3 2 1 1 2 3 4 5 4 3 2 1 1 2 3 4 5 6 7 6 5 4 3 2 1 1 2 3 4 5 6 7 8 8 7 6 5 4 3 2 3 4 5 6 7 8 8 7 6 5 4 5 6 7 8 8 7 6 7 8 8];
        Y = [ 1 2 1 1 2 3 4 3 2 1 1 2 3 4 5 6 5 4 3 2 1 1 2 3 4 5 6 7 8 7 6 5 4 3 2 1 2 3 4 5 6 7 8 8 7 6 5 4 3 4 5 6 7 8 8 7 6 5 6 7 8 8 7 8];
        
        for k = msc_num+2 : 64
            block_dct( X(k), Y(k) ) = 0;   
        end
        
        % put the new DCT coefficients in dct image
        dctImage(i:i+7, j:j+7) = block_dct;
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
figure; imshow(image/255);

%show the MST between the original and the reconstructed images
MSE = mse(image, reconst)

% calculate PSNR
PSNR = 10 * log10( (2^8-1)^2 / mse(image, reconst))

% show the reconstructed image
figure; imshow(reconst/255);


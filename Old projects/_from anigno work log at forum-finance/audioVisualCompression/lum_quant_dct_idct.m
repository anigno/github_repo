function lum_quant_dct_idct(image, q)

image = double(image);
s = [8 8];
block_r = s(1);
block_c = s(2);

survived = 0;

% perform DCT on block_r x block_c blocks of the original image +
% quantization
for i = 1 : block_r : size(image,1) 
    for j = 1 : block_c: size(image,2)
        block = image(i:i+block_r-1, j:j+block_c-1);
        %peform a DCT transformation
        block = dct2(block);
        zero_coeffs = length(find(block==0));
        % perform quantization
        block = quantization(block, q);
        % calculate the amount of survived coefficients
        survived = survived + prod(s) - (length(find(block==0)) - zero_coeffs);
        %store the block in the DCT image
        dctImage(i:i+block_r-1, j:j+block_c-1) = block;
    end
end

% perform iDCT on block_r x block_c blocks of the DCT image
for i = 1 : block_r : size(image,1) 
    for j = 1 : block_c: size(image,2) 
        block = dctImage(i:i+block_r-1, j:j+block_c-1);
        block = iquantization(block, q);
        reconst(i:i+block_r-1, j:j+block_c-1) = idct2(block);
    end
end

% show the original image
figure; imshow(image/255);

%show the MST between the original and the reconstructed images
MSE = mse(image, reconst)

% calculate PSNR
PSNR = 10 * log10( (2^8-1)^2 / mse(image, reconst))

% show the amount of survived coefficients fraction
survived_fraction = survived / prod(size(image))

% show the reconstructed image
figure; imshow(reconst/255);
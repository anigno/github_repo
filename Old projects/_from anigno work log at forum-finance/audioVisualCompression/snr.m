function SNR = snr(inputImage, newImage)

noise = inputImage - newImage;

im_var = var(inputImage(:));
noise_var = var(noise(:));

SNR = 10*log10(im_var / noise_var);
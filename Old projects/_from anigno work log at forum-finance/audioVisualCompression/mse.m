function MSE = mse(inputImage, outputImage)
error = inputImage - outputImage;

MSE = sum(sum(error.^2)) / prod(size(error));
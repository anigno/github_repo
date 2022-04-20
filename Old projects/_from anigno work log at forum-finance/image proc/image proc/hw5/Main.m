
im = readimage('fruit.tif');
qt = buildQT(im);
thresh = 100;
newimage = segimage(qt,thresh);
putimage(newimage);


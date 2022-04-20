using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AnignoMobileLibrary.Pictures
{
    public class PictureHelper
    {
        private ImageList _imageList = new ImageList();

        public Image ResizeImage(Image image, int width, int height)
        {
            _imageList.Images.Clear();
            _imageList.ImageSize = new Size(width, height);
            _imageList.Images.Add(image);
            return _imageList.Images[0];
        }
    }
}

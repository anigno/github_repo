using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using AnignoLibrary.Helpers;

namespace AnignoLibrary.UI.ImagesControls
{
    public class Panel_ImagesThumbnail: FlowLayoutPanel,IEnumerable
    {
        private const string CATEGORY_STRING=" Panel_ImagesThumbnail";
        private Size _thumbnailMaxSize = new Size(100, 100);

        #region Properties
        [Category(CATEGORY_STRING)]
        public Size ThumbnailMaxSize
        {
            get { return _thumbnailMaxSize; }
            set { _thumbnailMaxSize = value; }
        }
        #endregion

        public int AddImage(string imageFileName)
        {
            PictureBox picture = new PictureBox();
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            Image image = Image.FromFile(imageFileName);
            image = ImagesHelper.GetResizedImage(image, _thumbnailMaxSize);
            picture.Image = image;
            picture.Text = imageFileName;
            Controls.Add(picture);
            return Controls.Count-1;
        }

        public void RemoveImage(string imageFileName)
        {
            PictureBox pictureToRemove=null;
            foreach (PictureBox picture in Controls)
            {
                if (picture.Text == imageFileName) pictureToRemove=picture;
            }
            Controls.Remove(pictureToRemove);
        }

        public void RemoveImage(int index)
        {
            Controls.RemoveAt(index);
        }

        #region IEnumerable Members
        public IEnumerator GetEnumerator()
        {
            return Controls.GetEnumerator();
        }
        #endregion

        #region Override
        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is PictureBox)
            {
                base.OnControlAdded(e);
            }
            else
            {
                Controls.Remove(e.Control);
                MessageBox.Show("Only PictureBox could be added to Panel_ImagesThumbnail control!", "", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Private

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using AnignoLibrary.Helpers;

namespace AnignoLibrary.UI.ImagesControls.Panel_ImageThumbnailsControl
{
    public class Panel_ImagesThumbnail: FlowLayoutPanel,IEnumerable
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING=" Panel_ImagesThumbnail";

		#endregion Const Fields 

		#region Fields (1) 


        private Size _thumbnailMaxSize = new Size(100, 100);

		#endregion Fields 

		#region Read only Properties (1) 

        [Category(CATEGORY_STRING)]
        [Browsable(false)]
        public ImageItem[] SelectedImages
        {
            get {
                List<ImageItem> selectedList = new List<ImageItem>();
                foreach (ImageItem item in Controls)
                {
                    if (item.Selected)
                    {
                        selectedList.Add(item);
                    }
                }
                return selectedList.ToArray();
            }
        }

		#endregion Read only Properties 

		#region Properties (1) 


        [Category(CATEGORY_STRING)]
        public Size ThumbnailMaxSize
        {
            get { return _thumbnailMaxSize; }
            set { _thumbnailMaxSize = value; }
        }


		#endregion Properties 

		#region Overridden Methods (1) 

        protected override void OnControlAdded(ControlEventArgs e)
        {
            //if (e.Control is PictureBox)
            //{
            //    base.OnControlAdded(e);
            //}
            //else
            //{
            //    Controls.Remove(e.Control);
            //    MessageBox.Show("Only PictureBox could be added to Panel_ImagesThumbnail control!", "", MessageBoxButtons.OK);
            //}
        }

		#endregion Overridden Methods 

		#region Public Methods (5) 

        public int AddImage(string imageFileName)
        {
            ImageItem picture = new ImageItem(imageFileName,_thumbnailMaxSize);
            Controls.Add(picture);
            
            return Controls.Count-1;
        }

        public IEnumerator GetEnumerator()
        {
            return Controls.GetEnumerator();
        }

        public void RemoveAllImages()
        {
            Controls.Clear();
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

		#endregion Public Methods 

    }
}
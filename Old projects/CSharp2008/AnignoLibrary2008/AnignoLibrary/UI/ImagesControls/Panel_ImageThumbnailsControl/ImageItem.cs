using System.IO;
using System.Windows.Forms;
using System.Drawing;
using AnignoLibrary.Helpers;

namespace AnignoLibrary.UI.ImagesControls.Panel_ImageThumbnailsControl
{
    public class ImageItem : FlowLayoutPanel
    {

		#region Fields (5) 


        private readonly string _fileName;

        private bool _selected;

        private readonly Label labelFileName = new Label();
        private readonly PictureBox _realPicture = new PictureBox();
        private readonly PictureBox _ThumbPicture = new PictureBox();

		#endregion Fields 

		#region Constructors (1) 

        public ImageItem(string fileName, Size thumbnailMaxSize)
        {
            Margin = new Padding(3);
            Image image;
            try
            {
                image=Image.FromFile(fileName);
            }
            catch
            {
                MessageBox.Show("Couldn't read image file or file is not an image!", "", MessageBoxButtons.OK);
                return;
            }
            _realPicture.Image=image;
            Image thumbImage = ImagesHelper.GetResizedImage(image, thumbnailMaxSize);
            _ThumbPicture.Image = thumbImage;
            _ThumbPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            _fileName = fileName;
            labelFileName.Text = Path.GetFileNameWithoutExtension(fileName);
            Width = _ThumbPicture.Width + 12;
            Height = _ThumbPicture.Height + 6+labelFileName.Height;
            Controls.Add(_ThumbPicture);
            Controls.Add(labelFileName);
            _ThumbPicture.MouseClick += _ThumbPicture_MouseClick;
        }

		#endregion Constructors 

		#region Read only Properties (1) 

        public string FileName
        {
            get { return _fileName; }
        }

		#endregion Read only Properties 

		#region Properties (1) 


        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (_selected)
                {
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    
                    
                }
                else
                {
                    BorderStyle = System.Windows.Forms.BorderStyle.None;
                }
            }
        }


		#endregion Properties 

		#region Event Handlers (1) 

        void _ThumbPicture_MouseClick(object sender, MouseEventArgs e)
        {
            Selected = !Selected;
        }

		#endregion Event Handlers 

    }
}

using System.Drawing;
using System.Windows.Forms;
using AnignoLibrary.UI.Misc;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace AnignoLibrary.UI.Forms
{
    public partial class FormRoundedCorners : Form
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " FormRoundedCorners";

		#endregion Const Fields 

		#region Fields (9) 


        private bool _showControls = true;
        private bool _drawBorder=true;
        private float _cornersRadious = 50;
        private float _gradientAngle = 30;
        private int _mouseX;
        private int _mouseY;

        private Color _transparentColor = Color.FromArgb(254, 254, 254);
        private Color _gradientColorFirst = SystemColors.Window;
        private Color _gradientColorSecond = SystemColors.Window;

		#endregion Fields 

		#region Constructors (1) 

        public FormRoundedCorners()
        {
            InitializeComponent();
            TransparencyKey = TransparentColor;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            pictureBoxIcon.Image = Icon.ToBitmap();
            labelClose.MouseClick += labelClose_MouseClick;
            labelMinimize.MouseClick += labelMinimize_MouseClick;
            labeltext.MouseDown += labeltext_MouseDown;
            labeltext.MouseMove += labeltext_MouseMove;
        }

		#endregion Constructors 

		#region Read only Properties (1) 

        [Category(CATEGORY_STRING)]
        public Color TransparentColor
        {
            get { return _transparentColor; }
        }

		#endregion Read only Properties 

		#region Properties (6) 


        [Category(CATEGORY_STRING)]
        public bool ShowControls
        {
            get { return _showControls; }
            set
            {
                _showControls = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public bool DrawBorder
        {
            get { return _drawBorder; }
            set
            {
                _drawBorder = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float CornersRadious
        {
            get { return _cornersRadious; }
            set
            {
                _cornersRadious = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float GradientAngle
        {
            get { return _gradientAngle; }
            set
            {
                _gradientAngle = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color GradientColorFirst
        {
            get { return _gradientColorFirst; }
            set
            {
                _gradientColorFirst = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color GradientColorSecond
        {
            get { return _gradientColorSecond; }
            set
            {
                _gradientColorSecond = value;
                Refresh();
            }
        }


		#endregion Properties 

		#region Event Handlers (4) 

        void labelClose_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        void labelMinimize_MouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        void labeltext_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseX = e.X;
            _mouseY = e.Y;
        }

        void labeltext_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - _mouseX;
                Top += e.Y - _mouseY;
            }
        }

		#endregion Event Handlers 

		#region Overridden Methods (2) 

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.X > Width - CornersRadious / 4 && e.Y > Height - CornersRadious / 4)
            {
                Cursor = Cursors.Hand;
                if (e.Button == MouseButtons.Left)
                {
                    Width = e.X;
                    Height = e.Y;
                }
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush brushTransparent = new SolidBrush(TransparentColor);
            //SolidBrush brushBackgound = new SolidBrush(BackColor);
            GraphicsPath roundedCornersPath = UIHelper.GetRoundedRectanglePath(0, 0, Width - 1, Height - 1, CornersRadious);
            //Fill four rectangles in each corner with transparent color
            e.Graphics.FillRectangle(brushTransparent, -1, -1, CornersRadious, CornersRadious);
            e.Graphics.FillRectangle(brushTransparent, Width - CornersRadious + 1, -1, CornersRadious, CornersRadious);
            e.Graphics.FillRectangle(brushTransparent, -1, Height - CornersRadious, CornersRadious + 1, CornersRadious + 1);
            e.Graphics.FillRectangle(brushTransparent, Width - CornersRadious + 1, Height - CornersRadious + 1, CornersRadious + 1, CornersRadious + 1);
            //Fill rounded rectangle with current background color and draw rounded corners border with current forecolor
            UIHelper.FillLinearGradientRoundedRectangle(e.Graphics, 0, 0, Width, Height, GradientColorFirst, GradientColorSecond, GradientAngle, CornersRadious);
            if(DrawBorder)e.Graphics.DrawPath(new Pen(ForeColor), roundedCornersPath);
            //Draw the icon, text and controls
            labelMinimize.Visible = labelMaximize.Visible = ShowControls;
            pictureBoxIcon.Width = pictureBoxIcon.Height = Font.Height;
            pictureBoxIcon.Left = (int)(CornersRadious / 2);
            labeltext.Left = pictureBoxIcon.Left + pictureBoxIcon.Width;
            labeltext.Width = (int)(Width - CornersRadious - pictureBoxIcon.Width - labelMinimize.Width - labelClose.Width - labelMaximize.Width);
            labeltext.Height = Font.Height;
            labelMinimize.Left = labeltext.Left + labeltext.Width;
            labelMaximize.Left = labelMinimize.Left + labelMinimize.Width;
            labelClose.Left = labelMaximize.Left + labelMaximize.Width;

        }

		#endregion Overridden Methods 

    }
}
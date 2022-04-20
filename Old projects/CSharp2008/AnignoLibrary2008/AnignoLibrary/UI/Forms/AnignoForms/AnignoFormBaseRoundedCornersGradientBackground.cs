using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnignoLibrary.UI.Misc;
using System.Drawing.Drawing2D;

namespace AnignoLibrary.UI.Forms.AnignoForms
{
    /// <summary>
    /// Display a form with no borders or header and a gradient background. Resize and move enabled
    /// </summary>
    public class AnignoFormBaseRoundedCornersGradientBackground : Form
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoFormBaseRoundedCornersGradientBackground";
        private const int GRIP_CIRCLE_SIZE = 6;

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private bool _isMoving;
        private bool _isResizing;
        private bool _backgroundBorderDraw;
        private float _backgroundCornersRadious = 15;
        private float _backgroundGradientAngle = 30;
        private int _headerHeiget = 20;
        private int _mouseDownX;
        private int _mouseDownY;

        private Color _backgroundBorderColor;
        private Color _backgroundFirstGradientColor = SystemColors.Control;
        private Color _backgroundSecondGradientColor = SystemColors.ControlLightLight;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoFormBaseRoundedCornersGradientBackground()
        {
            InitializeComponent();
            SetNewRegion();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public bool BackgroundBorderDraw
        {
            get { return _backgroundBorderDraw; }
            set
            {
                _backgroundBorderDraw = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float BackgroundCornersRadious
        {
            get { return _backgroundCornersRadious; }
            set
            {
                _backgroundCornersRadious = value;
                SetNewRegion();
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float BackgroundGradientAngle
        {
            get { return _backgroundGradientAngle; }
            set
            {
                _backgroundGradientAngle = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public int HeaderHeiget
        {
            get { return _headerHeiget; }
            set { _headerHeiget = value; }
        }


        [Category(CATEGORY_STRING)]
        public Color BackgroundFirstGradientColor
        {
            get { return _backgroundFirstGradientColor; }
            set
            {
                _backgroundFirstGradientColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundSecondGradientColor
        {
            get { return _backgroundSecondGradientColor; }
            set
            {
                _backgroundSecondGradientColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundBorderColor
        {
            get { return _backgroundBorderColor; }
            set
            {
                _backgroundBorderColor = value;
                Refresh();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Static Methods  ------)

        private static void DrawGripCircle(Graphics g,SolidBrush innerBrush,Pen outerPen, int x, int y,int size)
        {
            g.FillEllipse(innerBrush, x, y, size, size);
            g.DrawEllipse(outerPen, x, y, size, size);
        }

		#endregion (------  Static Methods  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (IsMoveCondition(e)) _isMoving = true;
            if (IsResizeCondition(e)) _isResizing = true;
            _mouseDownX = e.X;
            _mouseDownY = e.Y;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Cursor = IsResizeCondition(e) ? Cursors.SizeNWSE : Cursors.Default;

            if (e.Button == MouseButtons.Left)
            {
                if (_isMoving)
                {
                    Cursor = Cursors.SizeAll;
                    Left += e.X - _mouseDownX;
                    Top += e.Y - _mouseDownY;
                }
                if (_isResizing)
                {
                    Cursor = Cursors.SizeNWSE;
                    Width = e.X;
                    Height = e.Y;
                    Refresh();
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            //End process of moving or resizing
            _isMoving = _isResizing = false;
            Cursor = Cursors.Default;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Do nothing
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Draw background
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            UIHelper.FillLinearGradientRectangle(e.Graphics, 0, 0, Width, Height, BackgroundFirstGradientColor, BackgroundSecondGradientColor, BackgroundGradientAngle);
            //Draw background border
            if (BackgroundBorderDraw)
            {
                GraphicsPath pathBorders = UIHelper.GetRoundedRectanglePath(0, 0, Width - 1, Height - 1, BackgroundCornersRadious);
                Pen penBorder = new Pen(BackgroundBorderColor, 2);
                e.Graphics.DrawPath(penBorder, pathBorders);
            }
            //Draw resize grip
            DrawResizeGrip(e.Graphics);
            //Draw header
            DrawHeader(e.Graphics);
        }

        protected override void OnResize(System.EventArgs e)
        {
            base.OnResize(e);
            SetNewRegion();
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AnignoFormBaseRoundedCornersGradientBackground
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AnignoFormBaseRoundedCornersGradientBackground";
            this.ResumeLayout(false);

        }

        private bool IsResizeCondition(MouseEventArgs e)
        {
            return (e.Y > Height - GRIP_CIRCLE_SIZE * 4 && e.X > Width - GRIP_CIRCLE_SIZE * 4);
        }

        private void SetNewRegion()
        {
            GraphicsPath pathregion = UIHelper.GetRoundedRectanglePath(0, 0, Width, Height, BackgroundCornersRadious);
            Region = new Region(pathregion);
        }

		#endregion (------  Private Methods  ------)

		#region (------  Virtual Methods  ------)

        virtual protected void DrawHeader(Graphics g)
        {
            Pen penHeader=new Pen(ForeColor);
            g.DrawRectangle(penHeader, BackgroundCornersRadious, 0, Width - BackgroundCornersRadious*2,HeaderHeiget);
            SolidBrush brushHeader=new SolidBrush(ForeColor);
            UIHelper.DrawStringCenterPoint(Text, g, Font, brushHeader, Width / 2f, HeaderHeiget / 2f);
        }

        virtual protected void DrawResizeGrip(Graphics g)
        {
            Color colorOuter = UIHelper.GetModifiedColor(_backgroundBorderColor, 0, 50);
            Color colorInner = UIHelper.GetModifiedColor(_backgroundBorderColor, 0, 25);
            SolidBrush brushResizeGripInner = new SolidBrush(colorInner);
            Pen penResizeGripOuter = new Pen(colorOuter);
            DrawGripCircle(g, brushResizeGripInner, penResizeGripOuter, (int)(Width - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4), (int)(Height - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4), GRIP_CIRCLE_SIZE);
            DrawGripCircle(g, brushResizeGripInner, penResizeGripOuter, (int)(Width - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4), (int)(Height - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4) - GRIP_CIRCLE_SIZE, GRIP_CIRCLE_SIZE);
            DrawGripCircle(g, brushResizeGripInner, penResizeGripOuter, (int)(Width - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4), (int)(Height - GRIP_CIRCLE_SIZE * 2 - BackgroundCornersRadious / 4) - GRIP_CIRCLE_SIZE, GRIP_CIRCLE_SIZE);
            DrawGripCircle(g, brushResizeGripInner, penResizeGripOuter, (int)(Width - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4) - GRIP_CIRCLE_SIZE, (int)(Height - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4), GRIP_CIRCLE_SIZE);
            DrawGripCircle(g, brushResizeGripInner, penResizeGripOuter, (int)(Width - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4) - GRIP_CIRCLE_SIZE * 2, (int)(Height - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4), GRIP_CIRCLE_SIZE);
            DrawGripCircle(g, brushResizeGripInner, penResizeGripOuter, (int)(Width - GRIP_CIRCLE_SIZE - BackgroundCornersRadious / 4) - GRIP_CIRCLE_SIZE, (int)(Height - GRIP_CIRCLE_SIZE * 2 - BackgroundCornersRadious / 4), GRIP_CIRCLE_SIZE);
        }

        virtual protected bool IsMoveCondition(MouseEventArgs e)
        {
            return (e.Y < HeaderHeiget);
        }

		#endregion (------  Virtual Methods  ------)

    }
}
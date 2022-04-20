using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AnignoLibrary.UI.Misc;

namespace AnignoLibrary.UI._Base
{
    public class ControlRoundedCorners : Control
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " ControlRoundedCorners";

		#endregion Const Fields 

		#region Fields (4) 


        protected float _gradientAngle = 30;
        protected float _cornerRadious = 15;
        private bool _borderDraw=true;
        private Color _borderColor = Color.Black;

        protected Color _backgroundColorFirst = SystemColors.Control;
        protected Color _backgroundColorSecond = SystemColors.ControlLightLight;

		#endregion Fields 

		#region Constructors (1) 

        public ControlRoundedCorners()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            base.BackColor = Color.Transparent;
        }

		#endregion Constructors 

		#region Properties (4) 


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
        public float CornerRadious
        {
            get { return _cornerRadious; }
            set
            {
                _cornerRadious = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color BackgroundColorFirst
        {
            get { return _backgroundColorFirst; }
            set
            {
                _backgroundColorFirst = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundColorSecond
        {
            get { return _backgroundColorSecond; }
            set
            {
                _backgroundColorSecond = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public bool BorderDraw
        {
            get { return _borderDraw; }
            set
            {
                _borderDraw = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Refresh();
            }
        }

        #endregion Properties 

		#region Overridden Methods (1) 

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent); 
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            DrawControl(pevent.Graphics);
        }

		#endregion Overridden Methods 

		#region Public Methods (1) 

        public void DrawControl(Graphics g)
        {
            GraphicsPath borderPath = UIHelper.GetRoundedRectanglePath(0, 0, Width-1, Height-1, CornerRadious);
            Brush backgroundBrush = new LinearGradientBrush(g.ClipBounds, BackgroundColorFirst, BackgroundColorSecond, GradientAngle);
            g.FillPath(backgroundBrush, borderPath);
            if (BorderDraw)
            {
                Pen pen=new Pen(BorderColor);
                g.DrawPath(pen, borderPath);
            }
        }

        #endregion Public Methods 

    }
}

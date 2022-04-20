using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AnignoLibrary.UI.Misc;

namespace AnignoLibrary.UI.Buttons
{
    
    #region Delegates
    public delegate void OnButtonRoundedGlowMouseClickDelegate(ButtonRoundedGlow sender);
    #endregion

    [DefaultEvent("OnButtonRoundedGlowMouseClick")]
    public partial class ButtonRoundedGlow : UserControl
    {

		#region (------  Const Fields  ------)

        internal const string CATEGORY_STRING = " ButtonRoundedGlow";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private bool _borderVisible = true;
        private bool _mouseIsOver = false;
        private bool _mouseDown = false;
        private float _backgroundGradientAngle = 90;
        private int _roundedCornersRadious = 15;
        private int _glowAlpha = 200;

        private Color _backgroundColorFirst = Color.Gray;
        private Color _backgroundColorSecond = Color.Black;
        private Color _borderColor = Color.Black;
        private Color _glowColor = Color.FromArgb(141, 189, 255);

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public ButtonRoundedGlow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            base.BackColor = Color.Transparent;
        }

		#endregion (------  Constructors  ------)

		#region (------  Overridden Properties  ------)

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public string ButtonText
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Invalidate();
            }
        }


        [Category(CATEGORY_STRING)]
        public bool BorderVisible
        {
            get { return _borderVisible; }
            set
            {
                _borderVisible = value;
                Invalidate();
            }
        }

        [Category(CATEGORY_STRING)]
        public float BackgroundGradientAngle
        {
            get { return _backgroundGradientAngle; }
            set
            {
                _backgroundGradientAngle = value;
                Invalidate();
            }
        }

        [Category(CATEGORY_STRING)]
        public int GlowAlpha
        {
            get { return _glowAlpha; }
            set
            {
                if (value > 255) return;
                _glowAlpha = value;
                Invalidate();
            }
        }

        [Category(CATEGORY_STRING)]
        public int RoundedCornersRadious
        {
            get { return _roundedCornersRadious; }
            set
            {
                _roundedCornersRadious = value;
                Invalidate();
            }
        }


        [Category(CATEGORY_STRING)]
        public virtual Color GlowColor
        {
            get { return _glowColor; }
            set
            {
                _glowColor = value;
                Invalidate();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundColorFirst
        {
            get { return _backgroundColorFirst; }
            set
            {
                _backgroundColorFirst = value;
                Invalidate();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundColorSecond
        {
            get { return _backgroundColorSecond; }
            set
            {
                _backgroundColorSecond = value;
                Invalidate();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event OnButtonRoundedGlowMouseClickDelegate OnButtonRoundedGlowMouseClick;

		#endregion (------  Events  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(!Enabled)return;
            if (OnButtonRoundedGlowMouseClick != null) OnButtonRoundedGlowMouseClick(this);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _mouseDown = true;
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseIsOver = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseIsOver = false;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseDown = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath gpBackGroundFull = UIHelper.GetRoundedRectanglePath(0, 0, Width - 1, Height - 1, RoundedCornersRadious);
            SolidBrush sb = new SolidBrush(BackgroundColorSecond);

            e.Graphics.FillPath(sb, gpBackGroundFull);
            GraphicsPath gpBackGroundLowerHalf = UIHelper.GetRoundedUpperHalfRectanglePath(0, 0, Width - 1, Height - 1, RoundedCornersRadious);
            Rectangle rect = new Rectangle(0, 0, Width - 1, (Height + 1) / 2);
            LinearGradientBrush lgb = new LinearGradientBrush(rect, BackgroundColorFirst, BackgroundColorSecond, BackgroundGradientAngle);
            e.Graphics.FillPath(lgb, gpBackGroundLowerHalf);


            if (BorderVisible)
            {
                GraphicsPath gpBorder = UIHelper.GetRoundedRectanglePath(0, 0, Width - 1, Height - 1, RoundedCornersRadious);
                Pen pen = new Pen(BorderColor, 0.1f);
                e.Graphics.DrawPath(pen, gpBorder);
            }
            if (Enabled)
            {
                if (_mouseIsOver) DrawGlow(e.Graphics);
            }

            DrawText(e.Graphics);

        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void DrawGlow(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(-5, Height / 2 - 20, Width + 11, Height + 11);
            gp.AddEllipse(-7, Height/10 , Width + 13, Height + 11);
            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = Color.FromArgb(GlowAlpha, GlowColor);
            pgb.SurroundColors = new Color[] { Color.FromArgb(0, GlowColor) };
            g.FillPath(pgb, gp);
        }

        private void DrawText(Graphics g)
        {
            SolidBrush sb = new SolidBrush(ForeColor);
            SizeF s = g.MeasureString(Text, Font);
            float x = (float)Width / 2 - s.Width / 2;
            float y = (float)Height / 2 - s.Height / 2;
            if (_mouseDown)
            {
                x += 2;
                y += 2;
            }
            g.DrawString(Text, Font, sb, x, y);
        }

		#endregion (------  Private Methods  ------)

    }
}
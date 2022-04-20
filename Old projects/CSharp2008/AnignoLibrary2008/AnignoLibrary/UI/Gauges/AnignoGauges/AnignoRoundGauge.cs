using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AnignoLibrary.UI.Gauges.AnignoGauges.GaugeParts;
using System.ComponentModel;
using AnignoLibrary.UI.Misc;
using AnignoLibrary.UI.Controls;

namespace AnignoLibrary.UI.Gauges.AnignoGauges
{
    public class AnignoRoundGaugeExt : ControlRoundedCorners
    {

		#region Const Fields (3) 

        private const string CATEGORY_STRING_DIAL = " AnignoRoundGauge_Dial";
        private const string CATEGORY_STRING_GAUGE = " AnignoRoundGauge";
        private const string CATEGORY_STRING_NEEDLE = " AnignoRoundGauge_Needle";

		#endregion Const Fields 

		#region Fields (10) 


        private float _value;
        private float _minimum;
        private float _maximum = 100;
        private float _minimumAngle = 150;
        private float _maximumAngle = 390;
        private float _textPositionFromCenterX = 0;
        private float _textPositionFromCenterY = 40;

        private Bitmap _backBuffer;
        private readonly Dial _dial;
        private readonly Needle _needle = new Needle();

		#endregion Fields 

		#region Constructors (1) 

        public AnignoRoundGaugeExt()
        {
            _dial = new Dial(Font);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

		#endregion Constructors 

		#region Properties (25) 


        [Category(CATEGORY_STRING_NEEDLE)]
        public bool Needle_BorderDraw
        {
            get { return _needle.BorderDraw; }
            set
            {
                _needle.BorderDraw = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public bool Needle_CenterCircleDraw
        {
            get { return _needle.CenterCircleDraw; }
            set
            {
                _needle.CenterCircleDraw = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public bool Dial_DrawNumbers
        {
            get { return _dial.DrawNumbers; }
            set
            {
                _dial.DrawNumbers = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public bool Dial_CastToInteger
        {
            get { return _dial.CastToInteger; }
            set
            {
                _dial.CastToInteger = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (Maximum == Minimum) Maximum += 1;
                _needle.Angle = ((MaximumAngle - MinimumAngle) / (Maximum - Minimum) * _value + MinimumAngle) % 360;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float MinimumAngle
        {
            get { return _minimumAngle; }
            set
            {
                _dial.MinimumAngle = _minimumAngle = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float MaximumAngle
        {
            get { return _maximumAngle; }
            set
            {
                _dial.MaximumAngle = _maximumAngle = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float Minimum
        {
            get { return _minimum; }
            set
            {
                _dial.Minimum = _minimum = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float Maximum
        {
            get { return _maximum; }
            set
            {
                _dial.Maximum = _maximum = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public float Needle_HeadLength
        {
            get { return _needle.HeadLength; }
            set
            {
                if (value < 1) return;
                _needle.HeadLength = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public float Needle_TailLength
        {
            get { return _needle.TailLength; }
            set
            {
                if (value < 1) return;
                _needle.TailLength = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public float Needle_Width
        {
            get { return _needle.Width; }
            set
            {
                if (value < 1) return;
                _needle.Width = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public float Needle_CenterCircleRadious
        {
            get { return _needle.CenterCircleRadious; }
            set
            {
                _needle.CenterCircleRadious = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public float Dial_Thickness
        {
            get { return _dial.Thickness; }
            set
            {
                _dial.Thickness = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public float Dial_Radious
        {
            get { return _dial.DialRadious; }
            set
            {
                _dial.DialRadious = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public float Dial_TextRadious
        {
            get { return _dial.DialTextRadious; }
            set
            {
                _dial.DialTextRadious = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float TextPositionFromCenterX
        {
            get { return _textPositionFromCenterX; }
            set
            {
                _textPositionFromCenterX = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_GAUGE)]
        public float TextPositionFromCenterY
        {
            get { return _textPositionFromCenterY; }
            set
            {
                _textPositionFromCenterY = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public int Dial_NumberOfTicks
        {
            get { return _dial.NumberOfTicks; }
            set
            {
                if (value < 0) return;
                _dial.NumberOfTicks = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING_NEEDLE)]
        public Color Needle_BackgroundColorFirst
        {
            get { return _needle.BackgroundColorFirst; }
            set
            {
                _needle.BackgroundColorFirst = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public Color Needle_BackgroundColorSecond
        {
            get { return _needle.BackgroundColorSecond; }
            set
            {
                _needle.BackgroundColorSecond = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_NEEDLE)]
        public Color Needle_BorderColor
        {
            get { return _needle.BorderColor; }
            set
            {
                _needle.BorderColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public Color Dial_Color
        {
            get { return _dial.DialColor; }
            set
            {
                _dial.DialColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public Color Dial_TickColor
        {
            get { return _dial.TickColor; }
            set
            {
                _dial.TickColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING_DIAL)]
        public Font Dial_Font
        {
            get { return _dial.DialFont; }
            set
            {
                _dial.DialFont = value;
                Refresh();
            }
        }


		#endregion Properties 

		#region Overridden Methods (2) 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush textBrush = new SolidBrush(ForeColor);
            Graphics g = Graphics.FromImage(_backBuffer);
            g.Clear(BackColor);
            _dial.Draw(g, ClientRectangle.Width / 2f, ClientRectangle.Height / 2f);
            UIHelper.DrawStringCenterPoint(Text, g, Font, textBrush, ClientRectangle.Width / 2f + TextPositionFromCenterX, ClientRectangle.Height / 2f + TextPositionFromCenterY);
            _needle.Draw(g, ClientRectangle.Width / 2f, ClientRectangle.Height / 2f);
            e.Graphics.DrawImage(_backBuffer, 0, 0);

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Width > Height) Height = Width;
            if (Height > Width) Width = Height;
            _backBuffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
        }

		#endregion Overridden Methods 

    }
}
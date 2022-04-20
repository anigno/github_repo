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
    public class AnignoRoundGauge : ControlRoundedCorners
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
        private readonly Dial[] _dials=new Dial[0];
        private readonly Needle[] _needles = new Needle[0];

		#endregion Fields 

		#region Constructors (1) 

        public AnignoRoundGauge()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

		#endregion Constructors 

		#region Properties (25) 




		#endregion Properties 

		#region Overridden Methods (2) 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush textBrush = new SolidBrush(ForeColor);
            Graphics g = Graphics.FromImage(_backBuffer);
            g.Clear(BackColor);
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
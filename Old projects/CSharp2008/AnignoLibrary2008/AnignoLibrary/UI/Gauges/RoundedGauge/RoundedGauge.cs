using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace AnignoLibrary.UI.Gauges.RoundedGauge
{
    public class RoundedGauge : Control
    {
        #region Fields
        //Generic
        private float _value = 0;
        private float _centerX = 150;
        private float _centerY = 150;
        private float _minValue = 0;
        private float _maxValue = 120;
        private float _minAngle = -210;
        private float _maxAngle = 30;
        private Color _needleTopLineColor = Color.LightBlue;
        //Needle
        private Color _needleColorFirst = Color.RoyalBlue;
        private Color _needleColorSecond = Color.MidnightBlue;
        private Color _needleColorThird = Color.MidnightBlue;
        private float _needleLength = 100;
        private float _needleBaseLength = 20;

        //Scale and range
        private Color _scaleColor = Color.Gray;
        private float _scaleLargeValueInterval = 20;
        private float _scaleSmallValueInterval = 5;
        private float _scaleInnerRadious = 90;
        private float _scaleOuterRadious = 100;
        private Color _rangeColor = Color.Red;
        private float _rangeMinValue = 40;
        private float _rangeMaxValue = 90;
        //text
        private Color _textColor = Color.Red;
        private float _textRadious = 110;
        //Dials
        private Color _innerDialColor = Color.Gray;
        private Color _outerDialColor = Color.DarkGray;
        private float _innerDialRadious = 120;
        private float _outerDialRadious = 140;
        #endregion

        #region Properties

        [Category("RoundedGauge-Generic")]
        public float Value
        {
            get { return _value; }
            set { _value = value; Refresh();}
        }

        [Category("RoundedGauge-Generic")]
        [Browsable(false)]
        public float CenterX
        {
            get { return _centerX; }
            set { _centerX = value; Refresh();}
        }

        [Category("RoundedGauge-Generic")]
        [Browsable(false)]
        public float CenterY
        {
            get { return _centerY; }
            set { _centerY = value; Refresh();}
        }

        [Category("RoundedGauge-Generic")]
        public float MinValue
        {
            get { return _minValue; }
            set { _minValue = value; Refresh();}
        }

        [Category("RoundedGauge-Generic")]
        public float MaxValue
        {
            get { return _maxValue; }
            set { _maxValue = value; Refresh();}
        }

        [Category("RoundedGauge-Generic")]
        public float MinAngle
        {
            get { return _minAngle; }
            set
            {
                if (value < 0) return;
                _minAngle = value; Refresh();
            }
        }

        [Category("RoundedGauge-Generic")]
        public float MaxAngle
        {
            get { return _maxAngle; }
            set {
                if (value < 0) return;
                _maxAngle = value; Refresh();}
        }

        [Category("RoundedGauge-Needle")]
        public System.Drawing.Color NeedleColorFirst
        {
            get { return _needleColorFirst; }
            set { _needleColorFirst = value; Refresh();}
        }

        [Category("RoundedGauge-Needle")]
        public System.Drawing.Color NeedleColorSecond
        {
            get { return _needleColorSecond; }
            set { _needleColorSecond = value; Refresh();}
        }

        [Category("RoundedGauge-Needle")]
        public System.Drawing.Color NeedleColorThird
        {
            get { return _needleColorThird; }
            set { _needleColorThird = value; Refresh();}
        }

        [Category("RoundedGauge-Needle")]
        public System.Drawing.Color NeedleTopLineColor
        {
            get { return _needleTopLineColor; }
            set { _needleTopLineColor = value; Refresh();}
        }

        [Category("RoundedGauge-Needle")]
        public float NeedleLength
        {
            get { return _needleLength; }
            set { _needleLength = value; Refresh();}
        }

        [Category("RoundedGauge-Needle")]
        public float NeedleBaseLength
        {
            get { return _needleBaseLength; }
            set { _needleBaseLength = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public System.Drawing.Color ScaleColor
        {
            get { return _scaleColor; }
            set { _scaleColor = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public float ScaleLargeValueInterval
        {
            get { return _scaleLargeValueInterval; }
            set { _scaleLargeValueInterval = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public float ScaleSmallValueInterval
        {
            get { return _scaleSmallValueInterval; }
            set { _scaleSmallValueInterval = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public float ScaleInnerRadious
        {
            get { return _scaleInnerRadious; }
            set { _scaleInnerRadious = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public float ScaleOuterRadious
        {
            get { return _scaleOuterRadious; }
            set { _scaleOuterRadious = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public System.Drawing.Color RangeColor
        {
            get { return _rangeColor; }
            set { _rangeColor = value; Refresh();}
        }

        [Category("RoundedGauge-Scales and Range")]
        public float RangeMinValue
        {
            get { return _rangeMinValue; }
            set { _rangeMinValue = value; Refresh();}
        }
        [Category("RoundedGauge-Scales and Range")]

        public float RangeMaxValue
        {
            get { return _rangeMaxValue; }
            set { _rangeMaxValue = value; Refresh();}
        }

        [Category("RoundedGauge-Text")]
        public System.Drawing.Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; Refresh();}
        }

        [Category("RoundedGauge-Text")]
        public float TextRadious
        {
            get { return _textRadious; }
            set { _textRadious = value; Refresh();}
        }

        [Category("RoundedGauge-Dials")]
        public System.Drawing.Color InnerDialColor
        {
            get { return _innerDialColor; }
            set { _innerDialColor = value; Refresh();}
        }

        [Category("RoundedGauge-Dials")]
        public System.Drawing.Color OuterDialColor
        {
            get { return _outerDialColor; }
            set { _outerDialColor = value; Refresh();}
        }

        [Category("RoundedGauge-Dials")]
        public float InnerDialRadious
        {
            get { return _innerDialRadious; }
            set { _innerDialRadious = value; Refresh();}
        }

        [Category("RoundedGauge-Dials")]
        public float OuterDialRadious
        {
            get { return _outerDialRadious; }
            set { _outerDialRadious = value; Refresh();}
        }
        #endregion

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _centerX = Width / 2; 
            _centerY = Height / 2;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // to avoid a design-time error we need to add the following line
            if (e.ClipRectangle.Width == 0)
            {
                return;
            }
            //base.OnPaint(e);
            Bitmap doubleBufferImage = new Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height);
            Graphics g = Graphics.FromImage(doubleBufferImage);
            g.Clear(this.BackColor);
            DrawDialsAndRange(g);
            DrawNeedle(g);
            DrawScales(g);
            DrawText(g);
            e.Graphics.DrawImageUnscaled(doubleBufferImage, 0, 0);
            g.Dispose();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }

        private void DrawDialsAndRange(Graphics g)
        {
            Brush brushOuterDial = new LinearGradientBrush(new PointF(_innerDialRadious, _innerDialRadious), new PointF(_outerDialRadious, _outerDialRadious), _innerDialColor, _outerDialColor);
            Brush brushInnerDial = new SolidBrush(_innerDialColor);
            Brush brushRange = new SolidBrush(_rangeColor);
            Brush brushClear = new SolidBrush(BackColor);
            g.FillEllipse(brushInnerDial, _centerX - _outerDialRadious, _centerY - _outerDialRadious, 2 * _outerDialRadious, 2 * _outerDialRadious);
            g.FillEllipse(brushOuterDial, _centerX - _innerDialRadious, _centerY - _innerDialRadious, 2 * _innerDialRadious, 2 * _innerDialRadious);

            GraphicsPath gpRange = new GraphicsPath();
            float minA = GetAngleFromValue(_rangeMinValue) * (float)57.296;
            float maxA=GetAngleFromValue(_rangeMaxValue)*(float)57.296;
            gpRange.AddPie(_centerX - _scaleInnerRadious, _centerY - _scaleInnerRadious, _scaleInnerRadious * 2, _scaleInnerRadious * 2, minA, maxA - minA);
            gpRange.AddPie(_centerX - _scaleOuterRadious, _centerY - _scaleOuterRadious, _scaleOuterRadious * 2, _scaleOuterRadious * 2, minA, maxA - minA);
            Region rangeRegion = new Region(gpRange);
            g.FillRegion(brushRange, rangeRegion);

            //GraphicsPath gpClear = new GraphicsPath();
            float toleranceValue = (_maxValue - _minValue) / 20;
            maxA = GetAngleFromValue(_maxValue+toleranceValue) * (float)57.296;
            minA = GetAngleFromValue(_minValue-toleranceValue) * (float)57.296;
            //gpRange.AddPie(_centerX - _scaleOuterRadious, _centerY - _scaleOuterRadious, _scaleOuterRadious * 2, _scaleOuterRadious * 2, minA, maxA - minA);
            //Region clearRegion = new Region(gpClear);
            //g.FillRegion(brushClear, clearRegion);
            g.FillPie(brushClear, _centerX - _outerDialRadious, _centerY - _outerDialRadious, _outerDialRadious * 2, _outerDialRadious * 2, maxA, 360 - (maxA - minA));
            
        }

        private void DrawText(Graphics g)
        {
            Brush brushText = new SolidBrush(_textColor);
            for (float v = _minValue; v <= _maxValue; v += _scaleLargeValueInterval)
            {
                float a = GetAngleFromValue(v);
                PointF p = new PointF();
                SizeF sf = g.MeasureString(v.ToString(), this.Font);
                p.X = _centerX + _textRadious * Cos(a)-sf.Width/2;
                p.Y = _centerY + _textRadious * Sin(a)-sf.Height/2;
                g.DrawString(v.ToString(), this.Font, brushText, p);
            }
        }

        private void DrawScales(Graphics g)
        {
            Pen penLarge = new Pen(_scaleColor, 2);
            Pen penSmall = new Pen(_scaleColor, 1);
            for (float v = _minValue; v <= _maxValue; v += _scaleLargeValueInterval)
            {
                float a = GetAngleFromValue(v);
                PointF p1 = new PointF();
                PointF p2 = new PointF();
                p1.X = _centerX + _scaleInnerRadious * Cos(a);
                p1.Y = _centerY + _scaleInnerRadious * Sin(a);
                p2.X = _centerX + _scaleOuterRadious * Cos(a);
                p2.Y = _centerY + _scaleOuterRadious * Sin(a);
                g.DrawLine(penLarge, p1, p2);
            }
            float scaleSmallInnerRadious = (_scaleOuterRadious + _scaleInnerRadious) / 2;
            for (float v = _minValue; v <= _maxValue; v += _scaleSmallValueInterval)
            {
                float a = GetAngleFromValue(v);
                PointF p1 = new PointF();
                PointF p2 = new PointF();
                p1.X = _centerX + scaleSmallInnerRadious * Cos(a);
                p1.Y = _centerY + scaleSmallInnerRadious * Sin(a);
                p2.X = _centerX + _scaleOuterRadious * Cos(a);
                p2.Y = _centerY + _scaleOuterRadious * Sin(a);
                g.DrawLine(penSmall, p1, p2);
            }
        }

        private void DrawNeedle(Graphics g)
        {
            float radian90 = Radian(90);
            Brush brushNeedleFirst = new SolidBrush(_needleColorFirst);
            Brush brushNeedleSecond = new SolidBrush(_needleColorSecond);
            Brush brushNeedleThird = new SolidBrush(_needleColorThird);
            Pen penNeedleTopLine = new Pen(_needleTopLineColor);
            PointF[] poligon01 = new PointF[3];
            PointF[] poligon02 = new PointF[3];
            PointF[] poligon03 = new PointF[3];
            float a = GetAngleFromValue(_value);
            poligon01[0].X = _centerX + _needleLength * Cos(a);
            poligon01[0].Y = _centerY + _needleLength * Sin(a);
            poligon01[1].X = _centerX + _needleBaseLength * Cos(a + radian90);
            poligon01[1].Y = _centerY + _needleBaseLength * Sin(a + radian90);
            poligon01[2].X = _centerX;
            poligon01[2].Y = _centerY;

            poligon02[0].X = poligon01[0].X;
            poligon02[0].Y = poligon01[0].Y;
            poligon02[1].X = _centerX + _needleBaseLength * Cos(a - radian90);
            poligon02[1].Y = _centerY + _needleBaseLength * Sin(a - radian90);
            poligon02[2].X = _centerX;
            poligon02[2].Y = _centerY;

            poligon03[0].X = poligon01[1].X;
            poligon03[0].Y = poligon01[1].Y;
            poligon03[1].X = _centerX + _needleBaseLength * Cos(a - radian90 * 2);
            poligon03[1].Y = _centerY + _needleBaseLength * Sin(a - radian90 * 2);
            poligon03[2].X = poligon02[1].X;
            poligon03[2].Y = poligon02[1].Y;

            g.FillPolygon(brushNeedleFirst, poligon01);
            g.FillPolygon(brushNeedleSecond, poligon02);
            g.FillPolygon(brushNeedleThird, poligon03);
            g.DrawLine(penNeedleTopLine, poligon01[2].X, poligon01[2].Y, poligon01[0].X, poligon01[0].Y);
        }

        private float Radian(double degree)
        {
            return (float)(degree * Math.PI / 180);
        }

        private float GetAngleFromValue(float value)
        {
            return (value - _minValue) / (_maxValue - _minValue) * (Radian(_maxAngle) - Radian(_minAngle)) + Radian(_minAngle);
        }

        private float Cos(float radian)
        {
            return (float)Math.Cos(radian);
        }

        private float Sin(float radian)
        {
            return (float)Math.Sin(radian);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Gauges.Needles
{
    public class Needle 
    {
        public enum NeedleTypeEnum
        {
            Line,
            ThreeTriangle
        }

        #region Fields
        private float _x = 10;
        private float _y = 10;
        private float _outerRadious = 150;
        private float _innerRadious = 20;

        private float _value = 50;
        private float _outerInnerRadiousRatio = 10;
        private float _maxValue = 100;
        private float _minValue = 0;
        private float _minRadian = NeedleHelper.PI * 1 / 4;
        private float _maxRadian = NeedleHelper.PI * 3 / 4;
        private Color _handColor1 = Color.Blue;
        private Color _baseColor = Color.DarkBlue;
        private Color _handColor2 = Color.DarkBlue;
        private NeedleTypeEnum _neddleType = NeedleTypeEnum.ThreeTriangle;
        //private bool _FillNeedle = true;
        #endregion

        #region Properties
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        
        public float Radious
        {
            get
            {
                return _outerRadious;
            }
            set
            {
                _outerRadious = value;
                _innerRadious = _outerRadious / _outerInnerRadiousRatio;
            }
        }

        public float Value
        {
            get { return _value; }
            set
            {
                _value = value;
            }
        }

        public float OuterInnerRadiousRatio
        {
            get { return _outerInnerRadiousRatio; }
            set
            {
                _outerInnerRadiousRatio = value;
            }
        }


        public float MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
            }
        }


        public float MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
            }
        }


        public float MinRadian
        {
            get { return _minRadian; }
            set
            {
                _minRadian = value;
           }
        }


        public float MaxRadian
        {
            get { return _maxRadian; }
            set
            {
                _maxRadian = value;
            }
        }


        public Color HandColor1
        {
            get { return _handColor1; }
            set
            {
                _handColor1 = value;
            }
        }


        public Color HandColor2
        {
            get { return _handColor2; }
            set
            {
                _handColor2 = value;
            }
        }


        public Color BaseColor
        {
            get { return _baseColor; }
            set
            {
                _baseColor = value;
           }
        }

        public NeedleTypeEnum NeddleType
        {
            get { return _neddleType; }
            set { _neddleType = value; }
        }
        #endregion

        public void Draw(Graphics g)
        {
            PointF[] p = new PointF[4];
            p[0] = CreatePointF(_x, _y, _outerRadious, ValueRadian);
            p[1] = CreatePointF(_x, _y, _innerRadious, ValueRadian + NeedleHelper.PI / 2);
            p[2] = CreatePointF(_x, _y, _innerRadious, ValueRadian + NeedleHelper.PI);
            p[3] = CreatePointF(_x, _y, _innerRadious, ValueRadian - NeedleHelper.PI / 2);
            PointF centerPoint = new PointF(_x, _y);
            //Pen pen = new Pen(_handColor1);
            //e.Graphics.DrawPolygon(pen, p);
            //e.Graphics.DrawEllipse(pen, _x - _outerRadious, _y - _outerRadious, _outerRadious * 2, _outerRadious * 2);
            Brush b1 = new SolidBrush(_handColor1);
            Brush b2 = new SolidBrush(_handColor2);
            Brush b3 = new SolidBrush(_baseColor);
            g.FillPolygon(b1, new PointF[] { p[0], p[1], centerPoint });
            g.FillPolygon(b2, new PointF[] { p[0], p[3], centerPoint });
            g.FillPolygon(b3, new PointF[] { p[1], p[3], p[2] });
        }

        private PointF CreatePointF(float x, float y, float r, float radian)
        {
            return new PointF(x + r * NeedleHelper.Cos(radian), y + r * NeedleHelper.Sin(radian));
        }

        private float ValueRadian
        {
            get
            {
                return (_value - _minValue) / (_maxValue - _minValue) * (_maxRadian - _minRadian) + _minRadian;
            }
        }
    }
}
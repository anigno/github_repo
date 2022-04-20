using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace AnignoLibrary.UI.Graphs
{
    public class AutoGraph : Control
    {

		#region Fields (8) 


        private float _minX;
        private float _maxX;
        private float _minY;
        private float _maxY;
        private float _graphScalesFactorPercent = 90;

        private Color _scalesColor = Color.Blue;
        private Color _zeroColor = Color.White;
        private readonly SortedList<float, float> _points = new SortedList<float, float>();

		#endregion Fields 

		#region Constructors (1) 

        public AutoGraph()
        {
            base.BackColor = Color.Gray;
        }

		#endregion Constructors 

		#region Properties (3) 


        [Category(" AutoGraph")]
        public float GraphScalesFactorPercent
        {
            get { return _graphScalesFactorPercent; }
            set
            {
                _graphScalesFactorPercent = value;
                Refresh();
            }
        }


        [Category(" AutoGraph")]
        public Color ScalesColor
        {
            get { return _scalesColor; }
            set
            {
                _scalesColor = value;
                Refresh();
            }
        }

        [Category(" AutoGraph")]
        public Color ZeroColor
        {
            get { return _zeroColor; }
            set
            {
                _zeroColor = value;
                Refresh();
            }
        }


		#endregion Properties 

		#region Overridden Methods (1) 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen=new Pen(ForeColor);
            CalculateMinMax();
            DrawScales(e.Graphics);
            DrawGraphLine(e.Graphics, pen);
            DrawZeroLine(e.Graphics);
        }

		#endregion Overridden Methods 

		#region Private Methods (6) 

        private void CalculateMinMax()
        {
            _minX = float.MaxValue;
            _maxX = float.MinValue;
            _minY = float.MaxValue;
            _maxY = float.MinValue;
            foreach (KeyValuePair<float, float> point in _points)
            {
                if (point.Key < _minX) _minX = point.Key;
                if (point.Key > _maxX) _maxX = point.Key;
                if (point.Value < _minY) _minY = point.Value;
                if (point.Value > _maxY) _maxY = point.Value;
            }
            if (_maxX == _minX) _maxX = _minX + 1;
            if (_maxY==_minY) _maxY = _minY + 1;
        }

        private void DrawGraphLine(Graphics g, Pen pen)
        {
            for (int a = 1; a < _points.Count; a++)
            {
                float x1 = GetDrawValueX(_points.Keys[a - 1]);
                float x2 = GetDrawValueX(_points.Keys[a]);
                float y1 = GetDrawValueY(_points.Values[a - 1]);
                float y2 = GetDrawValueY(_points.Values[a]);
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void DrawScales(Graphics g)
        {
            if(_points.Count<2)return;
            Pen pen = new Pen(ScalesColor);
            //Y scale
            for (float a = _minY; a <= _maxY; a += (_maxY - _minY) / 10)
            {
                g.DrawLine(pen,GetDrawValueX(_minX), GetDrawValueY(a),GetDrawValueX(_maxX), GetDrawValueY(a));
                g.DrawString(a.ToString(), Font, new SolidBrush(ScalesColor), 0, GetDrawValueY(a) - Font.Height / 2f);
            }
            //X scale
            for (float a = _minX; a <= _maxX; a += (_maxX - _minX) / 10)
            {
                g.DrawLine(pen, GetDrawValueX(a),GetDrawValueY(_minY) , GetDrawValueX(a),GetDrawValueY(_maxY));
                g.DrawString(a.ToString(), Font, new SolidBrush(ScalesColor), GetDrawValueX(a), Height - Font.Height);
            }
        }

        private void DrawZeroLine(Graphics g)
        {
            Pen pen = new Pen(ZeroColor);
            g.DrawLine(pen, GetDrawValueX(_minX), GetDrawValueY(0), GetDrawValueX(_maxX), GetDrawValueY(0));
            g.DrawString("0", Font, new SolidBrush(ZeroColor), 0, GetDrawValueY(0) - Font.Height / 2f);
        }

        private float GetDrawValueX(float realValue)
        {
            return (Width * (100 - GraphScalesFactorPercent) / 2 / 100) + Width * (GraphScalesFactorPercent / 100) / (_maxX - _minX) * (realValue - _minX);
        }

        private float GetDrawValueY(float realValue)
        {
            return (Height * (100 - GraphScalesFactorPercent) / 2 / 100)+ Height * (GraphScalesFactorPercent / 100) - Height * (GraphScalesFactorPercent / 100) / (_maxY - _minY) * (realValue - _minY);
        }

		#endregion Private Methods 

		#region Public Methods (2) 

        public void AddPoint(int x, int y)
        {
            _points.Add(x, y);
            Refresh();
        }

        public void RemovePoint(int x)
        {
            _points.Remove(x);
            Refresh();
        }

		#endregion Public Methods 

    }
}

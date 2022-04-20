using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnignoLibrary.Helpers;

namespace AnignoLibrary.UI.Graphs
{
    public partial class GraphDisplay : UserControl
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " GraphDisplay";

		#endregion Const Fields 

		#region Fields (15) 


        private bool _drawGrid = true;
        private bool _drawGridNumbers = true;
        private bool _autoGridScale=true;
        private float xFactor;
        //Scale factore from X axe to display width
        private float yFactor;
        private float _gridMaxY = 100;
        private float _gridMinY = -100;
        //Scale factor from Y axe to display height
        private int _X_GridLines = 10;
        private int _Y_GridLines = 10;

        private Bitmap _backBuffer;
        //Used for drawing in background image
        private Color _colorZeroAxes = Color.White;
        private Color _colorGrid = Color.Gray;
        private PointF minPoint;
        //Minimum point from all input points
        private PointF maxPoint;
        //Maximum point from all input points
        private readonly SortedDictionary<float, PointF> _points = new SortedDictionary<float, PointF>();

		#endregion Fields 

		#region Constructors (1) 

        public GraphDisplay()
        {
            InitializeComponent();
        }

		#endregion Constructors 

		#region Properties (9) 


        [Category(CATEGORY_STRING)]
        public bool DrawGrid
        {
            get { return _drawGrid; }
            set { _drawGrid = value; }
        }

        [Category(CATEGORY_STRING)]
        public bool DrawGridNumbers
        {
            get { return _drawGridNumbers; }
            set { _drawGridNumbers = value; }
        }

        [Category(CATEGORY_STRING)]
        public bool AutoGridScale
        {
            get { return _autoGridScale; }
            set { _autoGridScale = value; }
        }

        [Category(CATEGORY_STRING)]
        public float GridMaxY
        {
            get { return _gridMaxY; }
            set { _gridMaxY = value; }
        }

        [Category(CATEGORY_STRING)]
        public float GridMinY
        {
            get { return _gridMinY; }
            set { _gridMinY = value; }
        }

        [Category(CATEGORY_STRING)]
        public int X_GridLines
        {
            get { return _X_GridLines; }
            set { _X_GridLines = value; }
        }

        [Category(CATEGORY_STRING)]
        public int Y_GridLines
        {
            get { return _Y_GridLines; }
            set { _Y_GridLines = value; }
        }


        [Category(CATEGORY_STRING)]
        public Color ColorZeroAxes
        {
            get { return _colorZeroAxes; }
            set { _colorZeroAxes = value; }
        }

        [Category(CATEGORY_STRING)]
        public Color ColorGrid
        {
            get { return _colorGrid; }
            set { _colorGrid = value; }
        }


		#endregion Properties 

		#region Event Handlers (1) 

        private void GraphDisplay_Load(object sender, EventArgs e)
        {
            _backBuffer = new Bitmap(Width, Height);
        }

		#endregion Event Handlers 

		#region Overridden Methods (2) 

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImageUnscaled(_backBuffer, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            _backBuffer = new Bitmap(Width, Height);
            DrawGraph();
        }

		#endregion Overridden Methods 

		#region Private Methods (6) 

        private float CalcDisplayX(PointF pReal)
        {
            return CalcDisplayX(pReal.X);
        }

        private float CalcDisplayX(float xReal)
        {
            float x = (xReal * xFactor - minPoint.X * xFactor);
            return x + Width * 0.05f;
        }

        private float CalcDisplayY(PointF pReal)
        {
            return CalcDisplayY(pReal.Y);
        }

        private float CalcDisplayY(float yReal)
        {
            float y = (Height - (yReal * yFactor - minPoint.Y * yFactor));
            return y - Height * 0.05f;
        }

        private void DrawDisplayLine(Graphics g, Pen pen, PointF p1, PointF p2)
        {
            float x1 = CalcDisplayX(p1);
            float y1 = CalcDisplayY(p1);
            float x2 = CalcDisplayX(p2);
            float y2 = CalcDisplayY(p2);
            g.DrawLine(pen, x1, y1, x2, y2);
        }

        private void DrawDisplayText(Graphics g, Brush brush, float x, float y, string s)
        {
            float x1 = CalcDisplayX(x);
            float y1 = CalcDisplayY(y);
            g.DrawString(s, Font, brush, x1, y1);
        }

		#endregion Private Methods 

		#region Public Methods (4) 

        public PointF AddPoint(float x, float y)
        {
            PointF p = new PointF(x, y);
            return AddPoint(p);
        }

        public PointF AddPoint(PointF p)
        {
            _points.Add(p.X, p);
            return p;
        }

        public void ClearPoints()
        {
            _points.Clear();
        }

        public void DrawGraph()
        {
            if (_points.Count < 2) return;
            Graphics g = Graphics.FromImage(_backBuffer);
            Pen pen = new Pen(ForeColor);
            Pen penZero = new Pen(ColorZeroAxes);
            Pen penGrid = new Pen(ColorGrid);
            g.Clear(BackColor);
            //Calculate min and max
            minPoint = new PointF(int.MaxValue, int.MaxValue);
            maxPoint = new PointF(int.MinValue, int.MinValue);
            foreach (PointF p in _points.Values)
            {
                if (p.X < minPoint.X) minPoint.X = p.X;
                if (p.Y < minPoint.Y) minPoint.Y = p.Y;
                if (p.X > maxPoint.X) maxPoint.X = p.X;
                if (p.Y > maxPoint.Y) maxPoint.Y = p.Y;
            }
            if (!AutoGridScale)
            {
                minPoint.Y = GridMinY;
                maxPoint.Y = GridMaxY;
            }
            //Calculate display factors
            xFactor = Width * 0.9f / (maxPoint.X - minPoint.X);
            yFactor = Height * 0.9f / (maxPoint.Y - minPoint.Y);
            //DrawGrids
            if (DrawGrid)
            {
                SolidBrush textBrush = new SolidBrush(ColorGrid);
                //X axes and numbers
                for (float f = minPoint.X; f <= maxPoint.X; f += (maxPoint.X - minPoint.X) / X_GridLines)
                {
                    PointF p1 = new PointF(f, minPoint.Y);
                    PointF p2 = new PointF(f, maxPoint.Y);
                    DrawDisplayLine(g, penGrid, p1, p2);
                    float tx = CalcDisplayX(p1.X);
                    f = MathHelper.FixFloat(f);
                    float ty = CalcDisplayY(minPoint.Y) - Font.Height;
                    if (DrawGridNumbers) g.DrawString(f.ToString(), Font, textBrush, tx, ty);
                }
                //Y axes and numbers
                for (float f = minPoint.Y; f <= maxPoint.Y; f += (maxPoint.Y - minPoint.Y) / Y_GridLines)
                {
                    PointF p1 = new PointF(minPoint.X, f);
                    PointF p2 = new PointF(maxPoint.X, f);
                    DrawDisplayLine(g, penGrid, p1, p2);
                    f = MathHelper.FixFloat(f);
                    if (DrawGridNumbers) DrawDisplayText(g, textBrush, p1.X, p1.Y, f.ToString());
                }
            }
            //Draw zero Y
            if (minPoint.Y < 0 && maxPoint.Y > 0)
            {
                PointF p1 = new PointF(minPoint.X, 0);
                PointF p2 = new PointF(maxPoint.X, 0);
                DrawDisplayLine(g, penZero, p1, p2);
            }
            //Draw zero X
            if (minPoint.X < 0 && maxPoint.X > 0)
            {
                PointF p1 = new PointF(0, minPoint.Y);
                PointF p2 = new PointF(0, maxPoint.Y);
                DrawDisplayLine(g, penZero, p1, p2);
            }
            //Draw the graph
            PointF? prevPoint = null;
            foreach (PointF p in _points.Values)
            {
                if(prevPoint==null)prevPoint=p;
                DrawDisplayLine(g, pen, (PointF)prevPoint, p);
                prevPoint = p;
            }
            Refresh();

        }

		#endregion Public Methods 

    }
}
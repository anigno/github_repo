using System;
using System.Collections.Generic; 
using System.Drawing; 
using System.Windows.Forms; 
using System.ComponentModel;

namespace AnignoLibrary.UI.ProgressBars
{
    public class ProgressBarHistoryControl : Control
    {
		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = "   ProgressBarHistoryControl";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private Color graphcolor = Color.White;
        private float minvalue = -100;
        private float maxvalue = 100;
        private Graphics bbGraphics;
        private Image backBuffer;
        private int maxNumberOfPoints = 30;
        private readonly List<float> points = new List<float>();
        private Orientation BarOrientationl = Orientation.Horizontal;

		#endregion (------  Fields  ------)

		#region (------  Properties  ------)

        [Category(CATEGORY_STRING)]
        public Color Graphcolor
        {
            get { return graphcolor; }
            set { graphcolor = value; }
        }

        [Category(CATEGORY_STRING)]
        public float MinValue
        {
            get { return minvalue; }
            set
            {
                if (value == maxvalue) return;
                minvalue = value;
            }
        }

        [Category(CATEGORY_STRING)]
        public float MaxValue
        {
            get { return maxvalue; }
            set
            {
                if (value == minvalue) return;
                maxvalue = value;
            }
        }

        [Category(CATEGORY_STRING)]
        public int MaxNumberOfPoints
        {
            get { return maxNumberOfPoints; }
            set
            {
                if (value < 2) return;
                maxNumberOfPoints = value;
            }
        }

        [Category(CATEGORY_STRING)]
        public Orientation BarOrientation
        {
            get { return BarOrientationl; }
            set { BarOrientationl = value; }
        }

		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawBackBuffer();
            e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            backBuffer = new Bitmap(Width, Height);
            bbGraphics = Graphics.FromImage(backBuffer);
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Public Methods  ------)

        public void AddPoint(float f)
        {
            points.Add(f);
            if (points.Count > MaxNumberOfPoints) points.RemoveAt(0);
            Refresh();
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        private void DrawBackBuffer()
        {
            bbGraphics.FillRectangle(new SolidBrush(BackColor), bbGraphics.ClipBounds);
            if (points.Count > 1)
            {
                PointF[] ps = new PointF[points.Count];
                float heightFactor = (Height - 1) / (MaxValue - MinValue);
                float widthFactor = (Width - 1) / (MaxValue - MinValue); 
                for (int a = 0; a < points.Count; a++)
                {
                    float pDrawvalue = Height - 1 - (points[a] - MinValue) * heightFactor;
                    ps[a] = new PointF(a * Width / (float)(points.Count - 1), pDrawvalue);
                }
                if (BarOrientation == Orientation.Vertical)
                {
                    float drawValueV = Height - 1 - (points[points.Count - 1] - MinValue) * heightFactor;
                    bbGraphics.FillRectangle(new SolidBrush(ForeColor), 0, drawValueV, Width, Height - drawValueV);
                }
                else
                {
                    float drawvalueH = (points[points.Count - 1] - minvalue+1) * widthFactor;
                    bbGraphics.FillRectangle(new SolidBrush(ForeColor), 0, 0, drawvalueH, Height);
                }
                bbGraphics.DrawLines(new Pen(Graphcolor), ps);
            }
        }

		#endregion (------  Private Methods  ------)
    }
}
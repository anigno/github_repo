using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using AnignoLibrary.Helpers;

namespace AnignoLibrary.UI.Gauges.AnignoGauges.GaugeParts
{
    internal class Needle : GaugePartBase
    {

		#region Constructors (1) 

        public Needle()
        {
            BorderColor = Color.DarkGray;
            BackgroundColorSecond = Color.White;
            BackgroundColorFirst = Color.Black;
            Width = 30;
            TailLength = 50;
            HeadLength = 100;
            BorderDraw = true;
            CenterCircleDraw=true;
            CenterCircleRadious = 20;
        }

		#endregion Constructors 

		#region Properties (10) 


        public bool BorderDraw { get; set; }

        public bool CenterCircleDraw { get; set; }

        public float Angle { get; set; }

        public float HeadLength { get; set; }

        public float TailLength { get; set; }

        public float Width { get; set; }

        public float CenterCircleRadious { get; set; }


        public Color BackgroundColorFirst { get; set; }

        public Color BackgroundColorSecond { get; set; }

        public Color BorderColor { get; set; }


		#endregion Properties 

		#region Overridden Methods (1) 

        public override void Draw(Graphics g, PointF centerPoint)
        {
            base.Draw(g,centerPoint);
            PointF pointTopLeft = new PointF(centerPoint.X - HeadLength, centerPoint.Y - HeadLength);
            PointF pointButtonRight = new PointF(centerPoint.X + HeadLength, centerPoint.Y + HeadLength);

            LinearGradientBrush backgroundBrushCircle = new LinearGradientBrush(pointTopLeft, pointButtonRight, BackgroundColorFirst, BackgroundColorFirst);
            LinearGradientBrush backgroundBrushPointer = new LinearGradientBrush(pointTopLeft, pointButtonRight, BackgroundColorSecond, BackgroundColorSecond);
            GraphicsPath gPath = new GraphicsPath();
            Pen pen = new Pen(BorderColor);
            PointF[] pa=new PointF[5];

            pa[0] = new PointF(centerPoint.X+MathHelper.CosA(Angle)*HeadLength, centerPoint.Y + MathHelper.SinA(Angle) * HeadLength);
            pa[1] = new PointF(centerPoint.X + MathHelper.CosA(Angle + 90) * Width/2, centerPoint.Y + MathHelper.SinA(Angle + 90) * Width/2);
            pa[2] = new PointF(centerPoint.X + MathHelper.CosA(Angle + 180) * TailLength, centerPoint.Y + MathHelper.SinA(Angle + 180) * TailLength);
            pa[3] = new PointF(centerPoint.X + MathHelper.CosA(Angle - 90) * Width/2, centerPoint.Y + MathHelper.SinA(Angle - 90) * Width/2);
            pa[4] = pa[0];
            gPath.AddLines(pa);
            g.FillPath(backgroundBrushPointer, gPath);
            if (BorderDraw) g.DrawPath(pen, gPath);
            g.DrawLine(pen, pa[0], pa[2]);
            g.DrawLine(pen, pa[1], pa[3]);
            if (CenterCircleDraw)
            {
                g.FillPie(backgroundBrushCircle, centerPoint.X - CenterCircleRadious, centerPoint.Y - CenterCircleRadious, CenterCircleRadious * 2, CenterCircleRadious * 2, 0, 360);
                g.DrawArc(pen, centerPoint.X - CenterCircleRadious, centerPoint.Y - CenterCircleRadious, CenterCircleRadious * 2, CenterCircleRadious * 2, 0, 360);
            }


        }

		#endregion Overridden Methods 

    }
}
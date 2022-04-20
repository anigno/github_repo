using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AnignoLibrary.UI.Gauges.Needles
{
    public class NeedleTwoTriangles_static
    {
        private static float radian90 = (float)(180 / Math.PI);

        public static void Draw(Graphics g, float radian, float centerX, float centerY, float needleLength, float needleBaseRadious, Color needleColorFirst, Color needleColorSecond, Color needleColorThird, Color needleTopLineColor)
        {
            float a = radian;
            Brush brushNeedleFirst = new SolidBrush(needleColorFirst);
            Brush brushNeedleSecond = new SolidBrush(needleColorSecond);
            Brush brushNeedleThird = new SolidBrush(needleColorThird);
            Pen penNeedleTopLine = new Pen(needleTopLineColor);
            PointF[] poligon01 = new PointF[3];
            PointF[] poligon02 = new PointF[3];
            PointF[] poligon03 = new PointF[3];
            poligon01[0].X = centerX + needleLength * (float)Math.Cos(a);
            poligon01[0].Y = centerY + needleLength * (float)Math.Sin(a);
            poligon01[1].X = centerX + needleBaseRadious * (float)Math.Cos(a + radian90);
            poligon01[1].Y = centerY + needleBaseRadious * (float)Math.Sin(a + radian90);
            poligon01[2].X = centerX;
            poligon01[2].Y = centerY;

            poligon02[0].X = poligon01[0].X;
            poligon02[0].Y = poligon01[0].Y;
            poligon02[1].X = centerX + needleBaseRadious * (float)Math.Cos(a - radian90);
            poligon02[1].Y = centerY + needleBaseRadious * (float)Math.Sin(a - radian90);
            poligon02[2].X = centerX;
            poligon02[2].Y = centerY;

            poligon03[0].X = poligon01[1].X;
            poligon03[0].Y = poligon01[1].Y;
            poligon03[1].X = centerX + needleBaseRadious * (float)Math.Cos(a - radian90 * 2);
            poligon03[1].Y = centerY + needleBaseRadious * (float)Math.Sin(a - radian90 * 2);
            poligon03[2].X = poligon02[1].X;
            poligon03[2].Y = poligon02[1].Y;

            g.FillPolygon(brushNeedleFirst, poligon01);
            g.FillPolygon(brushNeedleSecond, poligon02);
            g.FillPolygon(brushNeedleThird, poligon03);
            g.DrawLine(penNeedleTopLine, poligon01[2].X, poligon01[2].Y, poligon01[0].X, poligon01[0].Y);

        }
    }
}

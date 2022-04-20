using System;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace AnignoLibrary.UI.Misc
{
    public static class UIHelper
    {
        public static readonly Color COLOR_IS_VALID_LIGHT_GREEN = Color.FromArgb(192, 255, 192);
        public static readonly Color COLOR_NOT_VALID_LIGHT_RED = Color.FromArgb(255, 192, 192);
        public static readonly Color COLOR_ACTIVITY_LIGHT_ORANGE = Color.FromArgb(255, 224, 192);

        #region (------  Static Methods  ------)

        public static void DrawStringCenterPoint(string s, Graphics g, Font font, Brush brush, float cx, float cy)
        {
            SizeF textSize = g.MeasureString(s, font);
            g.DrawString(s, font, brush, cx - textSize.Width / 2, cy - textSize.Height / 2);

        }

        public static void FillEllipsePathGradient(Graphics g, Rectangle rect, Color[] colors, float[] positions)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rect);
            FillPathGradient(g, graphicsPath, colors, positions);
        }

        public static void FillLinearGradientRectangle(Graphics g, float x1, float y1, float x2, float y2, Color firstColor, Color secondColor, float gradientAngle)
        {

            RectangleF rect = new RectangleF(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
            LinearGradientBrush brush = new LinearGradientBrush(rect, firstColor, secondColor, gradientAngle);
            g.FillRectangle(brush, rect);
        }

        public static void FillLinearGradientRectangle(Graphics g, PointF p1, PointF p2, Color firstColor, Color secondColor, float gradientAngle, float cornerRadious)
        {
            FillLinearGradientRoundedRectangle(g, p1.X, p1.Y, p2.X, p2.Y, firstColor, secondColor, gradientAngle, cornerRadious);
        }

        //public delegate void ListView_AddItemDelegate(ListView listView,ListViewItem item);
        //public static void ListView_AddItem_Invoked(ListView listView, ListViewItem item)
        //{
        //    if (listView.InvokeRequired)
        //    {
        //        listView.Invoke(new ListView_AddItemDelegate(ListView_AddItem_Invoked), new object[] { listView, item });
        //    }
        //    else
        //    {
        //        listView.Items.Add(item);
        //        item.EnsureVisible();
        //    }
        //}

        public static void FillLinearGradientRoundedRectangle(Graphics g, float x1, float y1, float x2, float y2, Color firstColor, Color secondColor, float gradientAngle, float cornerRadious)
        {

            RectangleF rect = new RectangleF(x1, y1, x2 - x1 + 1, y2 - y1 + 1);
            LinearGradientBrush brush = new LinearGradientBrush(rect, firstColor, secondColor, gradientAngle);
            GraphicsPath path = GetRoundedRectanglePath(x1, y1, x2 - x1, y2 - y1, cornerRadious);
            g.FillPath(brush, path);
        }

        public static void FillPathGradient(Graphics g, GraphicsPath graphicsPath, Color[] colors, float[] positions)
        {
            if (colors.Length != positions.Length) throw new Exception("DrawRectanglePathGradient, colors and positions must have same number of parameters");
            PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
            pathGradientBrush.InterpolationColors = new ColorBlend { Colors = colors, Positions = positions };
            g.FillPath(pathGradientBrush, graphicsPath);
        }

        public static void FillRectanglePathGradient(Graphics g, Rectangle rect, Color[] colors, float[] positions)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddRectangle(rect);
            FillPathGradient(g, graphicsPath, colors, positions);
        }

        public static void FillRoundedGradient(Graphics g, float x1, float y1, float x2, float y2, Color FirstColor, Color SecondColor)
        {
            GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(-5, Height / 2 - 20, Width + 11, Height + 11);
            gp.AddEllipse(x1, y1, x2 - x1, y2 - y1);
            PathGradientBrush pgb = new PathGradientBrush(gp);
            pgb.CenterColor = FirstColor;
            pgb.SurroundColors = new[] { SecondColor };
            g.FillPath(pgb, gp);
        }

        public static Color GetModifiedColor(Color color, int factor, int alpha)
        {
            int newR = color.R + factor;
            if (newR < 0 || newR > 255) newR = color.R;

            int newG = color.G + factor;
            if (newG < 0 || newG > 255) newG = color.R;

            int newB = color.B + factor;
            if (newB < 0 || newB > 255) newB = color.R;
            return Color.FromArgb(alpha, newR, newG, newB);
        }

        public static GraphicsPath GetRoundedRectanglePath(float x, float y, float w, float h, float r)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, r, r, 180, 90);
            gp.AddArc(x + w - r, y, r, r, 270, 90);
            gp.AddArc(x + w - r, y + h - r, r, r, 0, 90);
            gp.AddArc(x, y + h - r, r, r, 90, 90);
            gp.CloseFigure();
            return gp;
        }

        public static GraphicsPath GetRoundedUpperHalfRectanglePath(int x, int y, int w, int h, int r)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(x, y, r, r, 180, 90);
            gp.AddArc(x + w - r, y, r, r, 270, 90);
            gp.AddLine(x + w, y + h / 2, x, y + h / 2);
            gp.CloseFigure();
            return gp;
        }

        public static void FillPieByCenterPoint(Graphics g,float cx,float cy,float w,float h,float startAngle,float endAngle,Color color)
        {
            g.FillPie(new SolidBrush(color),cx-w/2,cy-h/2,w,h,startAngle,endAngle);
        }

        #endregion (------  Static Methods  ------)
    }
}
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnignoLibrary.UI.Gauges.AnignoGauges.GaugeParts
{
    public abstract class GaugePartBase
    {
        public void Draw(Graphics g, float x, float y)
        {
            Draw(g, new PointF(x, y));
        }

        public virtual void Draw(Graphics g, PointF centerPoint)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
        }
    }
}
using System.Drawing;
using System.Drawing.Drawing2D;
using AnignoLibrary.Helpers;
using AnignoLibrary.UI.Misc;

namespace AnignoLibrary.UI.Gauges.AnignoGauges.GaugeParts
{
    internal class Dial : GaugePartBase
    {

		#region Fields (1) 


        public Font DialFont;

		#endregion Fields 

		#region Constructors (1) 

        public Dial(Font font)
        {
            DialFont = font;
            Minimum = 0;
            Maximum = 100;
            MinimumAngle = 150;
            MaximumAngle = 390;
            NumberOfTicks = 10;
            DrawNumbers = true;
            Thickness = 10;
            DialColor = Color.DarkGray;
            TickColor = Color.White;
            DialRadious = 100;
            DialTextRadious = 120;

        }

		#endregion Constructors 

		#region Properties (11) 


        public bool DrawNumbers { get; set; }

        public float Minimum { get; set; }

        public float Maximum { get; set; }

        public float MinimumAngle { get; set; }

        public float MaximumAngle { get; set; }

        public float Thickness { get; set; }

        public float DialRadious { get; set; }

        public float DialTextRadious { get; set; }

        public int NumberOfTicks { get; set; }


        public Color DialColor { get; set; }

        public Color TickColor { get; set; }

        public bool CastToInteger { get; set; }

		#endregion Properties 

		#region Overridden Methods (1) 

        public override void Draw(Graphics g, PointF centerPoint)
        {
            base.Draw(g,centerPoint);
            SolidBrush dialBrush = new SolidBrush(DialColor);
            SolidBrush textBrush = new SolidBrush(TickColor);
            Pen pen = new Pen(TickColor);
            GraphicsPath gp = new GraphicsPath();
            gp.AddPie(centerPoint.X - DialRadious, centerPoint.Y - DialRadious, DialRadious * 2 - 1, DialRadious * 2 - 1, MinimumAngle, MaximumAngle - MinimumAngle);
            gp.AddPie(centerPoint.X - DialRadious + Thickness, centerPoint.Y - DialRadious + Thickness, DialRadious * 2 - 1 - Thickness * 2, DialRadious * 2 - 1 - Thickness * 2, MinimumAngle, MaximumAngle - MinimumAngle);
            g.FillPath(dialBrush, gp);
            float df = (MaximumAngle - MinimumAngle) / (Maximum - Minimum) * ((Maximum - Minimum) / NumberOfTicks);
            float f = MinimumAngle;
            float v = Minimum;
            for (int a = 0; a < NumberOfTicks+1 ; a++)
            {
                g.DrawLine(pen, centerPoint.X + DialRadious * MathHelper.CosA(f), centerPoint.Y + DialRadious * MathHelper.SinA(f), centerPoint.X + (DialRadious - Thickness) * MathHelper.CosA(f), centerPoint.Y + (DialRadious - Thickness) * MathHelper.SinA(f));
                if (DrawNumbers)
                {
                    float vf=v;
                    if (CastToInteger)
                    {
                        vf=(long)vf;
                    }
                    UIHelper.DrawStringCenterPoint(vf.ToString(), g, DialFont, textBrush, centerPoint.X + DialTextRadious*MathHelper.CosA(f), centerPoint.Y + DialTextRadious*MathHelper.SinA(f));
                }
                f += df;
                if (f -360+2 > MinimumAngle) break;
                v += (Maximum - Minimum) / NumberOfTicks;
            }
        }

		#endregion Overridden Methods 

    }
}
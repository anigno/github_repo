using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;
using LoggingProvider;

namespace AnignoLibrary.UI.Gauges.GaugeParts
{
    public class Dial : CircularBase
    {
        Brush _brush = new SolidBrush(Color.Blue);
        private float _thickness = 10;

        [Category(" Dial")]
        public float Thickness
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
                base.OnSizeChanged(new EventArgs());
            }
        }

        public Dial()
        {
            base.OnPropertyChanged += new OnPropertyChangedDelegate(Dial_OnPropertyChanged);
        }

        void Dial_OnPropertyChanged()
        {
            base.Refresh();
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Draw(e.Graphics);
            Logger.Log(SeverityEnum.Debug,"w={0} h={1}",e.ClipRectangle.Height,e.ClipRectangle.Width);
        }

        private void Draw(Graphics g)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddPie(0, 0, Radious - 1, Radious - 1, MinAngle, MaxAngle - MinAngle);
            gp.AddPie(_thickness / 2, _thickness / 2, Radious - _thickness - 1, Radious - _thickness - 1, MinAngle, MaxAngle - MinAngle);
            g.FillPath(_brush, gp);
        }
    }
}
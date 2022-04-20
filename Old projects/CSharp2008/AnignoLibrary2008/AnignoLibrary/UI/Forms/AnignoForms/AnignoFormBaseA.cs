using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.UI.Misc;
using System.ComponentModel;

namespace AnignoLibrary.UI.Forms.AnignoForms
{
    public class AnignoFormBaseA : AnignoFormBaseRoundedCornersGradientBackground
    {
        private const string CATEGORY_STRING = " AnignoFormBaseA";

        private Color _HeaderFirstGradientColor = SystemColors.Control;
        private Color _HeaderSecondGradientColor = SystemColors.ControlLightLight;

        [Category(CATEGORY_STRING)]
        public Color HeaderFirstGradientColor
        {
            get { return _HeaderFirstGradientColor; }
            set
            {
                _HeaderFirstGradientColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color HeaderSecondGradientColor
        {
            get { return _HeaderSecondGradientColor; }
            set
            {
                _HeaderSecondGradientColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float HeaderGradientAngle
        {
            get { return _headerGradientAngle; }
            set
            {
                _headerGradientAngle = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public bool HeaderDrawBorder
        {
            get { return _HeaderDrawBorder; }
            set
            {
                _HeaderDrawBorder = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public bool HeaderDrawBackground
        {
            get { return _headerDrawBackground; }
            set
            {
                _headerDrawBackground = value;
                Refresh();
            }
        }

        private bool _headerDrawBackground=true;


        private float _headerGradientAngle = 30;

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            DrawHeader(e.Graphics);
        }

        override protected bool IsMoveCondition(MouseEventArgs e)
        {
            return (e.Y > BackgroundCornersRadious / 2 && e.Y < BackgroundCornersRadious / 2 + HeaderHeiget);
        }

        private bool _HeaderDrawBorder;

        protected override void DrawHeader(Graphics g)
        {
            //Draw header background
            if (HeaderDrawBackground)
            {
                UIHelper.FillLinearGradientRectangle(g, BackgroundCornersRadious, BackgroundCornersRadious/2, Width - BackgroundCornersRadious, BackgroundCornersRadious/2 + HeaderHeiget, HeaderFirstGradientColor, HeaderSecondGradientColor, HeaderGradientAngle);
            }
            //Draw header border
            if (HeaderDrawBorder)
            {
                Pen penHeaderBorder=new Pen(ForeColor);
                g.DrawRectangle(penHeaderBorder, BackgroundCornersRadious, BackgroundCornersRadious / 2, Width - BackgroundCornersRadious * 2, HeaderHeiget);
            }
            //Draw text
            SolidBrush brushText=new SolidBrush(ForeColor);
            UIHelper.DrawStringCenterPoint(Text, g, Font, brushText, Width / 2f, BackgroundCornersRadious / 2 + HeaderHeiget / 2f);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

        }

    }
}
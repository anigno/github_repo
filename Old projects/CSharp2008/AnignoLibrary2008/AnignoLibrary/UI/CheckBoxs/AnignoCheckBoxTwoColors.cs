using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using AnignoLibrary.UI.Controls;
using System.Drawing;
using AnignoLibrary.UI.Misc;
using System.ComponentModel;

namespace AnignoLibrary.UI.CheckBoxs
{
    [DefaultEvent("OnCheckedChanged")]
    public class AnignoCheckBoxTwoColors : ControlRoundedCorners
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoCheckBoxTwoColors";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private bool _checked;

        private Color _BackgroundColorCheckedFirst = Color.LightGreen;
        private Color _BackgroundColorCheckedSecond = Color.Green;
        private Color _checkColor = Color.White;

		#endregion (------  Fields  ------)

		#region (------  Overridden Properties  ------)

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Refresh();
            }
        }

		#endregion (------  Overridden Properties  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color BackgroundColorCheckedFirst
        {
            get { return _BackgroundColorCheckedFirst; }
            set
            {
                _BackgroundColorCheckedFirst = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BackgroundColorCheckedSecond
        {
            get { return _BackgroundColorCheckedSecond; }
            set
            {
                _BackgroundColorCheckedSecond = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color CheckColor
        {
            get { return _checkColor; }
            set
            {
                _checkColor = value;
                Refresh();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event CheckedChangedEventHandler OnCheckedChanged;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void CheckedChangedEventHandler(AnignoCheckBoxTwoColors sender, bool checkedState);

		#endregion (------  Delegates  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Checked = !Checked;
            if (OnCheckedChanged != null) OnCheckedChanged(this, Checked);
            Refresh();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            DrawCheckBoxTwoColors(pevent.Graphics);
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void DrawCheckBoxTwoColors(Graphics g)
        {
            //If checked, Fill checked background
            if (Checked) UIHelper.FillLinearGradientRoundedRectangle(g, 1, 1, Width-2, Height-2, BackgroundColorCheckedFirst, BackgroundColorCheckedSecond, GradientAngle, CornerRadious);
            //DrawText
            SolidBrush brushText = new SolidBrush(ForeColor);
            SizeF textSize = g.MeasureString(Text, Font);
            UIHelper.DrawStringCenterPoint(Text, g, Font, brushText, Width / 2f, textSize.Height / 2f);
            //DrawCheck
            GraphicsPath CheckPath = UIHelper.GetRoundedRectanglePath(CornerRadious / 2,textSize.Height,Width - CornerRadious,Height - CornerRadious / 2 - textSize.Height,CornerRadious / 2);
            Pen pen = new Pen(CheckColor);
            g.DrawPath(pen, CheckPath);
            if (Checked)
            {
                SolidBrush brushCheck = new SolidBrush(CheckColor);
                g.FillPath(brushCheck, CheckPath);
            }


        }

		#endregion (------  Private Methods  ------)

    }
}
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using AnignoLibrary.UI.Controls;
using AnignoLibrary.UI.Misc;

namespace AnignoLibrary.UI.ProgressBars
{
    public class AnignoProgressBar : ControlRoundedCorners
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoProgressBar";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private float _value = 50;
        private float _minimum;
        private float _maximum = 100;
        private float _barGradientAngle = 30;

        private Color _barColorFirst = Color.White;
        private Color _barColorSecond = Color.Gray;
        private Orientation _orientation = Orientation.Vertical;

		#endregion (------  Fields  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public float Value
        {
            get { return _value; }
            set
            {
                if(value<Minimum || value>Maximum)return;
                _value = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public float BarGradientAngle
        {
            get { return _barGradientAngle; }
            set
            {
                _barGradientAngle = value;
                Refresh();
            }
        }


        [Category(CATEGORY_STRING)]
        public Color BarColorFirst
        {
            get { return _barColorFirst; }
            set
            {
                _barColorFirst = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color BarColorSecond
        {
            get { return _barColorSecond; }
            set
            {
                _barColorSecond = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Orientation BarOrientation
        {
            get { return _orientation; }
            set
            {
                _orientation = value;
                Refresh();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            DrawProgressBar(pevent.Graphics);
        }

        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            Refresh();
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void DrawProgressBar(Graphics g)
        {
            if(Maximum==Minimum)return;
            int borderLength = (int)(CornerRadious / 4);
            PointF p1;
            PointF p2;
            if (BarOrientation == Orientation.Vertical)
            {
                float maxBarHeight = (Height - 2 * borderLength);
                p1 = new PointF(borderLength, (int)(maxBarHeight - (maxBarHeight * (Value - Minimum) / (Maximum - Minimum)) + borderLength));
                p2 = new PointF(Width - borderLength, Height - borderLength);
            }
            else
            {
                float maxBarWidth = Width - 2 * borderLength;
                p1 = new PointF(borderLength, borderLength);
                p2 = new Point((int)((maxBarWidth * (Value - Minimum) / (Maximum - Minimum)) + borderLength), Height - borderLength);
            }
            UIHelper.FillLinearGradientRectangle(g, p1, p2, BarColorFirst, BarColorSecond, BarGradientAngle, CornerRadious);
            SolidBrush textBrush = new SolidBrush(ForeColor);
            SizeF textSize = g.MeasureString(Text, Font);
            g.DrawString(Text, Font, textBrush, Width / 2f - textSize.Width / 2, Height / 2f);
        }

		#endregion (------  Private Methods  ------)

    }
}
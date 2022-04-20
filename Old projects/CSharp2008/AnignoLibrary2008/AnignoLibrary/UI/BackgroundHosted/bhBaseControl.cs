using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace AnignoLibrary.UI.BackgroundHosted
{
    #region Enums
    public enum TextPositionEnum
    {
        Left,
        Right,
        Top
    }
    #endregion

    public class bhBaseControl : Control
    {
        #region Fields
        private const string PROPERY_CATEGORY_STRING = " BackgroundHostedBaseControl";
        private Color _gradientFirstColor = SystemColors.Control;
        private Color _gradientSecondColor = SystemColors.ControlLightLight;
        private float _gradientOrientationAngle = 30;
        private float _cornerRadius = 15;
        private TextPositionEnum _textPosition = TextPositionEnum.Left;
        private Control _hostedControl = null;
        private float _hostedControlBorderWidthPercentage = 80;
        private string _caption = "bhBaseControl";
        #endregion

        #region Public properties
        [Category(PROPERY_CATEGORY_STRING)]
        public Color GradientColorFirst
        {
            get { return _gradientFirstColor; }
            set
            {
                _gradientFirstColor = value;
                Refresh();
            }
        }

        [Category(PROPERY_CATEGORY_STRING)]
        public Color GradientColorSecond
        {
            get { return _gradientSecondColor; }
            set
            {
                _gradientSecondColor = value;
                Refresh();
            }
        }

        [Category(PROPERY_CATEGORY_STRING)]
        public float GradientOrientationAngle
        {
            get { return _gradientOrientationAngle; }
            set
            {
                _gradientOrientationAngle = value;
                Refresh();
            }
        }


        [Category(PROPERY_CATEGORY_STRING)]
        public float CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                Refresh();
            }
        }

        [Category(PROPERY_CATEGORY_STRING)]
        public TextPositionEnum TextPosition
        {
            get { return _textPosition; }
            set
            {
                _textPosition = value;
                Refresh();
            }
        }

        [Category(PROPERY_CATEGORY_STRING)]
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                Refresh();
            }
        }
        #endregion

        #region Protected properties
        [Category(PROPERY_CATEGORY_STRING)]
        protected Control HostedControl
        {
            get { return _hostedControl; }
            set
            {
                _hostedControl = value;
                if (value != null)
                {
                    if (!Controls.Contains(value)) Controls.Add(value);
                    value.AutoSize = false;
                    value.Show();
                }
                Refresh();
            }
        }
        #endregion

        #region CTOR
        public bhBaseControl()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaint(e);
            DrawControlGradientBackground(e.Graphics);
            DrawText(e.Graphics);
            DrawHostedControl(e.Graphics);
        }
        #endregion

        #region Private
        private void DrawHostedControl(Graphics g)
        {
            float hLeft = 0;
            float hTop = 0;
            float hWidth = 0;
            float hHeight = 0;
            switch (TextPosition)
            {
                case TextPositionEnum.Left:
                    hLeft = Width * (100 - _hostedControlBorderWidthPercentage) / 100;
                    hTop = CornerRadius / 2;
                    hWidth = Width * _hostedControlBorderWidthPercentage / 100 - CornerRadius / 2;
                    hHeight = Height - CornerRadius;
                    break;
                case TextPositionEnum.Right:
                    hLeft = CornerRadius / 2;
                    hTop = CornerRadius / 2;
                    hWidth = Width * _hostedControlBorderWidthPercentage / 100 - CornerRadius / 2;
                    hHeight = Height - CornerRadius;
                    break;
                case TextPositionEnum.Top:
                    hLeft = CornerRadius / 2;
                    hTop = CornerRadius * 2;
                    hWidth = Width - CornerRadius;
                    hHeight = Height - CornerRadius * 2.5f;
                    break;
            }
            if (HostedControl != null)
            {
                HostedControl.Left = (int)(hLeft + CornerRadius / 2);
                HostedControl.Top = (int)(hTop + CornerRadius / 2);
                HostedControl.Width = (int)(hWidth - CornerRadius);
                HostedControl.Height = (int)(hHeight - CornerRadius);
                HostedControl.BackColor = GradientColorFirst;
            }
            RectangleF hRect = new RectangleF(hLeft, hTop, hWidth, hHeight);
            GraphicsPath gp = GetRoundRectPath(hRect, CornerRadius / 2);
            SolidBrush sb = new SolidBrush(GradientColorSecond);
            g.FillPath(sb, gp);
        }

        private void DrawText(Graphics g)
        {
            SizeF textSize = g.MeasureString(Text, Font);
            float textLeft = 0;
            float textTop = 0;
            switch (TextPosition)
            {
                case TextPositionEnum.Left:
                    textLeft = CornerRadius / 2;
                    textTop = (Height - textSize.Height) / 2;
                    break;
                case TextPositionEnum.Right:
                    textLeft = Width - CornerRadius / 2 - textSize.Width;
                    textTop = (Height - textSize.Height) / 2;
                    break;
                case TextPositionEnum.Top:
                    textLeft = (Width - textSize.Width) / 2;
                    textTop = CornerRadius / 2;
                    break;
            }
            g.DrawString(Caption, Font, new SolidBrush(ForeColor), textLeft, textTop);
        }

        private void DrawGradientBackground(Graphics g, Rectangle rect)
        {
            LinearGradientBrush lgb = new LinearGradientBrush(rect, GradientColorFirst, GradientColorSecond, GradientOrientationAngle);
            GraphicsPath gp = GetRoundRectPath(rect, CornerRadius);
            g.FillPath(lgb, gp);
        }

        private void DrawControlGradientBackground(Graphics g)
        {
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            DrawGradientBackground(g, rect);
        }

        private GraphicsPath GetRoundRectPath(RectangleF rect, float radius)
        {
            return GetRoundRectPath(rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        private GraphicsPath GetRoundRectPath(float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            return gp;
        }
        #endregion

    }
}
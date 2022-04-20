using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using AnignoLibrary.UI.Misc;

namespace AnignoLibrary.UI.Extenders
{
    public class PanelRoundedContainer : Panel
    {

		#region Constructors (1) 

        public PanelRoundedContainer()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BorderStyle = BorderStyle.None;
        }

		#endregion Constructors 


        #region Fields
        private Color _colorFirst = SystemColors.ControlDark;
        private Color _colorSecond = SystemColors.ControlLight;
        private float _cornersRadious = 20f;
        private float _gradientAngle = 30f;
        #endregion

        #region Properties
        public Color ColorFirst
        {
            get { return _colorFirst; }
            set
            {
                _colorFirst = value;
                Refresh();
            }
        }

        public Color ColorSecond
        {
            get { return _colorSecond; }
            set
            {
                _colorSecond = value;
                Refresh();

            }
        }

        public float CornersRadious
        {
            get { return _cornersRadious; }
            set
            {
                _cornersRadious = value;
                Refresh();

            }
        }

        public float GradientAngle
        {
            get { return _gradientAngle; }
            set
            {
                _gradientAngle = value;
                Refresh();

            }
        }
        #endregion

        #region Override
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (Control c in Controls)
            {
                //c.BackColor = Color.Transparent;
                if (c is ListBox) ((ListBox)c).IntegralHeight = false;
                if (c is ButtonBase)
                {
                    ((ButtonBase)c).FlatStyle = FlatStyle.Flat;
                    ((ButtonBase)c).FlatAppearance.BorderSize = 0;
                    ((ButtonBase)c).FlatAppearance.MouseDownBackColor = ColorFirst;
                    ((ButtonBase)c).FlatAppearance.MouseOverBackColor = ColorSecond;
                }
                c.AutoSize = false;
                c.Left = (int)CornersRadious / 4;
                c.Top = (int)CornersRadious / 4;
                c.Width = Width - (int)CornersRadious / 2;
                c.Height = Height - (int)CornersRadious / 2;
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                LinearGradientBrush lgb = new LinearGradientBrush(rect, ColorFirst, ColorSecond, GradientAngle);
                GraphicsPath gp = UIHelper.GetRoundedRectanglePath(0, 0, Width, Height, CornersRadious);
                e.Graphics.FillPath(lgb, gp);
            }
        }
        #endregion

        #region Private

        #endregion
    }
}
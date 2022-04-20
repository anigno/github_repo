using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.UI.Controls;
using AnignoLibrary.UI.Misc;
using System.Drawing;
using System.ComponentModel;

namespace AnignoLibrary.UI.Labels
{
    public class AnignoLabelButton : ControlRoundedCorners
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoLabelButton";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private bool _isMouseDown;
        private bool _isMouseOver;

        private Color _mouseOverColor = SystemColors.Control;
        private Color _mouseDownColor = SystemColors.ControlLightLight;
        private Color _savedColorFirst;
        private Color _savedColorSecond;

		#endregion (------  Fields  ------)


        #region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public Color MouseOverColor
        {
            get { return _mouseOverColor; }
            set
            {
                _mouseOverColor = value;
                Refresh();
            }
        }

        [Category(CATEGORY_STRING)]
        public Color MouseDownColor
        {
            get { return _mouseDownColor; }
            set
            {
                _mouseDownColor = value;
                Refresh();
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            BackgroundColorFirst = BackgroundColorSecond = MouseDownColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackgroundColorFirst = _savedColorFirst;
            BackgroundColorSecond = _savedColorSecond;
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            BackgroundColorFirst =BackgroundColorSecond= MouseOverColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _savedColorFirst = BackgroundColorFirst;
            _savedColorSecond = BackgroundColorSecond;
            BackgroundColorFirst =BackgroundColorSecond= MouseOverColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            SolidBrush brushText = new SolidBrush(ForeColor);
            UIHelper.DrawStringCenterPoint(Text, pevent.Graphics, Font, brushText, Width / 2f, Height / 2f);
        }

		#endregion (------  Overridden Methods  ------)

    }
}
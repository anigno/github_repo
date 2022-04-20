using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace AnignoLibrary.UI.Labels
{
    public class AnignoSimpleLableButton:Label
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoSimpleLableButton";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private Color _backColorMouseOver = SystemColors.ControlDarkDark;
        private Color _backColorMouseDown = SystemColors.ControlLightLight;
        private Color _backColorBase = SystemColors.Control;

		#endregion (------  Fields  ------)

        #region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public Color BackColorMouseOver
        {
            get { return _backColorMouseOver; }
            set { _backColorMouseOver = value; }
        }

        [Category(CATEGORY_STRING)]
        public Color BackColorMouseDown
        {
            get { return _backColorMouseDown; }
            set { _backColorMouseDown = value; }
        }

        [Category(CATEGORY_STRING)]
        public Color BackColorBase
        {
            get { return _backColorBase; }
            set
            {
                _backColorBase = value;
                BackColor = _backColorBase;
            }
        }


		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            BackColor = BackColorMouseDown;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = BackColorBase;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            BackColor = BackColorMouseOver;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            BackColor = BackColorBase;
        }

		#endregion (------  Overridden Methods  ------)

    }
}

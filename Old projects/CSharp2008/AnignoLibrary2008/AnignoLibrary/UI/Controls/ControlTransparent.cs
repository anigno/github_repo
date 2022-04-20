using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Controls
{
    public class ControlTransparent : Control
    {
        public ControlTransparent()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.BackColor = Color.Transparent;
        }



        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // do nothing
        }

        //protected override void OnMove(EventArgs e)
        //{
        //    RecreateHandle();
        //}



    }
}
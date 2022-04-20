using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Buttons.GlassButtons
{
    internal class TransparentControl : Control
    {

        #region (------  Overridden Methods  ------)

        protected override void OnPaint(PaintEventArgs e) { }

        protected override void OnPaintBackground(PaintEventArgs pevent) { }

        #endregion (------  Overridden Methods  ------)


    }
}

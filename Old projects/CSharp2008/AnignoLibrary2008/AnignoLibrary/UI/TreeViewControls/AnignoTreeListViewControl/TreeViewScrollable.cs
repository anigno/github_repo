using System;
using System.Windows.Forms;
using AnignoLibrary.UI.Misc;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnignoLibrary.UI.TreeViewControls.AnignoTreeListViewControl
{
    public class TreeViewScrollable : TreeView
    {
        [Category(" TreeViewScrollable")]
        public event ScrollEventHandler OnScrolledV;
        [Category(" TreeViewScrollable")]
        public event ScrollEventHandler OnScrolledH;

        protected override void WndProc(ref Message m)
        {
            ScrollEventArgs sargsV = ScrollHelper.IsScrolled(ref m, ScrollOrientation.VerticalScroll);
            ScrollEventArgs sargsH = ScrollHelper.IsScrolled(ref m, ScrollOrientation.HorizontalScroll);
            if (sargsV != null)
            {
                if (OnScrolledV != null) OnScrolledV(this, sargsV);
            }
            if (sargsH != null)
            {
                if (OnScrolledH != null) OnScrolledH(this, sargsH);
            }
            base.WndProc(ref m);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            
            SolidBrush textBrush=new SolidBrush(ForeColor);
            Pen pen=new Pen(ForeColor);
            pen.DashStyle = DashStyle.Dot;
            e.Graphics.DrawString(e.Node.Text, Font, textBrush, e.Bounds);
            e.Graphics.DrawLine(pen,
                e.Bounds.X + e.Bounds.Width,
                e.Bounds.Y + e.Bounds.Height-1,
                Width,
                e.Bounds.Y + e.Bounds.Height-1);
        }

    }
}

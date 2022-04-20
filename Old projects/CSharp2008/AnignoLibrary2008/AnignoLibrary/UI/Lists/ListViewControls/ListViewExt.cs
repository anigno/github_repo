using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;

namespace AnignoLibrary.UI.Lists.ListViewControls
{
    public delegate void SubItemAction(int row, int column, ListViewItem.ListViewSubItem subItem);



    /// <summary>
    /// SubItemClicked event,Scroll event
    /// </summary>
    public class ListViewExt : ListView
    {

        #region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " ListViewExt";
        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;

		#endregion (------  Const Fields  ------)

		#region (------  Constructors  ------)

        public ListViewExt()
        {
            View = View.Details;
            FullRowSelect = true;
        }

        #endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        [Category(CATEGORY_STRING)]
        public int HScrollPos
        {
            get { return GetScrollPos((int)Handle, SB_VERT); }
        }

        [Category(CATEGORY_STRING)]
        public int VScrollPos
        {
            get { return GetScrollPos((int)Handle, SB_HORZ); }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event SubItemAction OnSubItemClicked;

        [Category(CATEGORY_STRING)]
        public event SubItemAction OnSubItemDoubleClicked;

        [Category(CATEGORY_STRING)]
        public event ScrollEventHandler Scroll;

		#endregion (------  Events  ------)

		#region (------  Static Methods  ------)

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetScrollPos(int hWnd, int nBar);

		#endregion (------  Static Methods  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            int columnClicked = GetColumnClicked(e);
            int rowClicked = SelectedIndices[0];
            ListViewItem.ListViewSubItem clickedSubItem=null;
            if( Items[rowClicked].SubItems.Count>=columnClicked+1)clickedSubItem= Items[rowClicked].SubItems[columnClicked];
            if (OnSubItemClicked != null) OnSubItemClicked(rowClicked, columnClicked,clickedSubItem);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            int columnClicked = GetColumnClicked(e);
            int rowClicked = SelectedIndices[0];
            if (OnSubItemDoubleClicked != null) OnSubItemDoubleClicked(rowClicked, columnClicked, Items[rowClicked].SubItems[columnClicked]);
        }

        protected override void WndProc(ref Message m)
        {
            if (Scroll != null)
            {
                switch (m.Msg)
                {
                    case WM_VSCROLL:
                    case WM_HSCROLL:
                        {
                            ScrollEventType t = (ScrollEventType)Enum.Parse(typeof(ScrollEventType), (m.WParam.ToInt32() & 65535).ToString());
                            Scroll(m.HWnd, new ScrollEventArgs(t, ((int)(m.WParam.ToInt64() >> 16)) & 255));
                        }
                        break;

                }
            }
            base.WndProc(ref m);


        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private int GetColumnClicked(MouseEventArgs e)
        {
            int x = 0;
            foreach (ColumnHeader c in Columns)
            {
                if (e.X >= x && e.X <= x + c.Width) return c.Index;
                x += c.Width;
            }
            return -1;
        }

		#endregion (------  Private Methods  ------)

    }
}
using System;
using System.Windows.Forms;

namespace AnignoLibrary.UI.TreeViewControls.AnignoSimpleTreeListViewControl
{
    public class AnignoSimpleTreeListView : ListView
    {
		#region (------  Fields  ------)

        private readonly AnignoSimpleTreeListViewItem mRoot;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoSimpleTreeListView()
        {
            GridLines = true;
            View = View.Details;
            mRoot = new AnignoSimpleTreeListViewItem(null);
        }

		#endregion (------  Constructors  ------)

		#region (------  Static Methods  ------)

        // Private Methods (1)
        private static string GetPathSpaces(AnignoSimpleTreeListViewItem item, string spacesString)
        {
            int a = 0;
            AnignoSimpleTreeListViewItem iterator = item;
            while (iterator.Parent != null)
            {
                iterator = iterator.Parent;
                a++;
            }
            string sRet = " ";
            for (int b = 0; b < a; b++)
            {
                sRet += spacesString;
            }
            return sRet;
        }

        // Internal Methods (1)
        internal static string GetTreeListViewItemText(AnignoSimpleTreeListViewItem item)
        {
            int a = item.Text.IndexOf("] ");
            if (a >= 0) item.Text = item.Text.Substring(a + 2);
            string expendText = " [ ] "; if (item.Children.Count > 0)
            {
                expendText = item.IsExpended ? "[-] " : "[+] ";
            }
            string sRet = GetPathSpaces(item, "   ");
            sRet += expendText + item.Text; return sRet;
        }

		#endregion (------  Static Methods  ------)

		#region (------  Overridden Methods  ------)

        // Protected Methods (1)
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (SelectedItems.Count <= 0) return;
            AnignoSimpleTreeListViewItem item = (AnignoSimpleTreeListViewItem)SelectedItems[0];

            item.IsExpended = !item.IsExpended;
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Public Methods  ------)

        // Public Methods (4)
        public AnignoSimpleTreeListViewItem Addltem(AnignoSimpleTreeListViewItem parent, AnignoSimpleTreeListViewItem item)
        {
            parent.Children.Add(item);
            item.Parent = parent;
            item.Container = this;
            if (item.Parent.IsExpended)
            {
                item.Text = GetTreeListViewItemText(item); int index = item.Parent.Index + 1; Items.Insert(index, item); item.Parent.IsExpended = true;
            }
            item.Parent.Text = GetTreeListViewItemText(item.Parent); return item;
        }

        public AnignoSimpleTreeListViewItem Addltem(AnignoSimpleTreeListViewItem parent, string text)
        {
            AnignoSimpleTreeListViewItem item = new AnignoSimpleTreeListViewItem();
            item.Text = text;
            return Addltem(parent, item);
        }

        public AnignoSimpleTreeListViewItem AddRoot(AnignoSimpleTreeListViewItem item)
        {
            mRoot.Children.Add(item);
            item.Parent = null;
            item.Container = this;
            item.Text = GetTreeListViewItemText(item);
            Items.Add(item);
            return item;
        }

        public AnignoSimpleTreeListViewItem AddRoot(string text)
        {
            AnignoSimpleTreeListViewItem item = new AnignoSimpleTreeListViewItem();
            item.Text = text;
            return AddRoot(item);
        }

		#endregion (------  Public Methods  ------)
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.UI.TreeViewControls.AnignoTreeListViewControl
{
    public class TreeListNode : TreeNode
    {
        private List<string> _subItemsList =new List<string>();

        public ListViewItem ConnectedListViewItem { get; set; } 
        public List<string> SubItemsList
        {
            get { return _subItemsList; }
            set { _subItemsList = value; }
        }
    }
}

using System;
using System.Windows.Forms;
using System.ComponentModel;
using AnignoLibrary.UI.Lists.ListViewControls;
using System.Collections.Generic;

namespace AnignoLibrary.UI.TreeViewControls.TreeListViewControl
{
    public class AnignoTreeListView : ListViewExt
    { 
        private const string EXPENDED_STRING = "[-] ";
        private const string COLLAPSED_STRING = "[+] ";
        private const string NO_CHILDS_STRING = "[ ] ";
        private readonly TreeListNodesCollection mTreeListNodes = new TreeListNodesCollection(null);

        public TreeListNodesCollection TreeListNodes
        {
            get { return mTreeListNodes; }
        }

        public AnignoTreeListView()
        {
            TreeListNodes.OnTreeListNodeAdded += TreeListNodes_OnTreeListNodeAdded;
        }

        void TreeListNodes_OnTreeListNodeAdded(TreeListNode container, TreeListNode treeListNode)
        {
            AddListViewItem(treeListNode);
        }

        private void AddListViewItem(TreeListNode treeListNode)
        {
            ListViewItem lvi = new ListViewItem(NO_CHILDS_STRING+ treeListNode.Text);
            lvi.Name = treeListNode.Key;
            foreach (string subItem in treeListNode.Data)
            {
                lvi.SubItems.Add(subItem);
            }
            Items.Add(lvi);
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.UI.TreeViewControls.TreeListViewControl
{
    public class TreeListNodesCollection : List<TreeListNode>
    {

        public TreeListNodesCollection(TreeListNode containerTreeListNode)
        {
            ContainerTreeListNode = containerTreeListNode;
        }

        private TreeListNode mContainerTreeListNode;
		#region Events (1) 

        public event OnTreeListNodeAddedDelegate OnTreeListNodeAdded;

		#endregion Events 

		#region Delegates (1) 

        public delegate void OnTreeListNodeAddedDelegate(TreeListNode parent,TreeListNode treeListNode);

        public TreeListNode ContainerTreeListNode
        {
            get { return mContainerTreeListNode; }
            set { mContainerTreeListNode = value; }
        }

        #endregion Delegates 

		#region Public Methods (3) 

        public TreeListNode AddTreeListNode(TreeListNode treeListNode)
        {
            Add(treeListNode);
            if (OnTreeListNodeAdded != null) OnTreeListNodeAdded(ContainerTreeListNode ,treeListNode);
            return treeListNode;
        }

        public TreeListNode AddTreeListNode(string text, string key)
        {
            return AddTreeListNode(text, key, null);
        }

        public TreeListNode AddTreeListNode(string text, string key, string[] data)
        {
            TreeListNode node = new TreeListNode(text, key, data);
            return AddTreeListNode(node);
        }

		#endregion Public Methods 

    }
}

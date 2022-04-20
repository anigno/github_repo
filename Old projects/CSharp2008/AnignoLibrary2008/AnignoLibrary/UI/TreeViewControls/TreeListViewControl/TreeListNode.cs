using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AnignoLibrary.UI.TreeViewControls.TreeListViewControl
{
    public class TreeListNode
    {

		#region Enums (1) 

        public enum TreeListViewStateEnum
        {
            Expended,
            Collapsed
        }

		#endregion Enums 

		#region Fields (5) 

        private List<string> mData=new List<string>();
        private TreeListNodesCollection mTreeListNodes;

        private string mText;
        private string mKey;

        private TreeListNode mParent;

		#endregion Fields 

		#region Constructors (2) 

        public TreeListNode(string text, string key,IEnumerable<string> data)
        {
            Text = text;
            Key = key;
            if (data != null)
            {
                Data = new List<string>(data);
            }
            else
            {
                Data=new List<string>();
            }
            TreeListNodes = new TreeListNodesCollection(this);
        }

        public TreeListNode(string text, string key) : this(text,key,null)
        {
        }

		#endregion Constructors 

		#region Properties (5) 


        public List<string> Data
        {
            get { return mData; }
            set { mData = value; }
        }

        public TreeListNodesCollection TreeListNodes
        {
            get { return mTreeListNodes; }
            set { mTreeListNodes = value; }
        }


        public string Text
        {
            get { return mText; }
            set { mText = value; }
        }

        public string Key
        {
            get { return mKey; }
            set { mKey = value; }
        }


        public TreeListNode Parent
        {
            get { return mParent; }
            set { mParent = value; }
        }


		#endregion Properties 



		#region Public Methods (3) 


		#endregion Public Methods 

    }
}

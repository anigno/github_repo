using System.Collections.Generic; using System.Windows.Forms;

namespace AnignoLibrary.UI.TreeViewControls.AnignoSimpleTreeListViewControl
{
    public class AnignoSimpleTreeListViewItem : ListViewItem
    {

		#region Fields (4) 


        private readonly List<AnignoSimpleTreeListViewItem> mChildren = new List<AnignoSimpleTreeListViewItem>();

        private bool mlsExpended;

        private AnignoSimpleTreeListView mContainer;
        private AnignoSimpleTreeListViewItem mParent;

		#endregion Fields 

		#region Constructors (2) 

        public AnignoSimpleTreeListViewItem(AnignoSimpleTreeListViewItem parent)
        {
            Parent = parent;
        }

        public AnignoSimpleTreeListViewItem()
        { }

		#endregion Constructors 

		#region Read only Properties (1) 

        public List<AnignoSimpleTreeListViewItem> Children
        {
            get { return mChildren; }
        }

		#endregion Read only Properties 

		#region Properties (3) 


        public bool IsExpended
        {
            get { return mlsExpended; }
            set
            {
                if (mlsExpended == value) return; mlsExpended = value; if (mlsExpended)
                {
                    foreach (AnignoSimpleTreeListViewItem item in Children)
                    {
                        Container.Items.Insert(Index + 1, item);
                        item.Text = AnignoSimpleTreeListView.GetTreeListViewItemText(item);
                    }
                }
                else
                {
                    foreach (AnignoSimpleTreeListViewItem item in Children)
                    {
                        if (item.IsExpended)
                        {
                            item.IsExpended = false;
                        }
                        Container.Items.RemoveAt(item.Index);
                    }
                } Text = AnignoSimpleTreeListView.GetTreeListViewItemText(this);
            }
        }


        public AnignoSimpleTreeListView Container
        {
            get { return mContainer; }
            set { mContainer = value; }
        }

        public AnignoSimpleTreeListViewItem Parent
        {
            get { return mParent; }
            set { mParent = value; }
        }


		#endregion Properties 

    }
}
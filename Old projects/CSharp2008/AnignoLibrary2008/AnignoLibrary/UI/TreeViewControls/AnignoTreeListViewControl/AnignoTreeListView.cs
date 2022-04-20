using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace AnignoLibrary.UI.TreeViewControls.AnignoTreeListViewControl
{
    public partial class AnignoTreeListView : UserControl
    {

		#region Const Fields (1) 

        private const string CATEGOY_STRING = " AnignoTreeListView";

		#endregion Const Fields 

		#region Fields (1) 


        private int _division = 5;

		#endregion Fields 

		#region Constructors (1) 

        public AnignoTreeListView()
        {
            InitializeComponent();
            listViewMain.Columns.Add("TreeText").Width = 0;
            hScrollBarDivision_ValueChanged(null, null);
            RegisterToEvents();
        }

		#endregion Constructors 

		#region Properties (2) 


        [Category(CATEGOY_STRING)]
        public string Header
        {
            get { return labelHeader.Text; }
            set { labelHeader.Text = value; }
        }


        [Category(CATEGOY_STRING)]
        public int Division
        {
            get { return _division; }
            set
            {
                if(value<0 || value>100)return;
                _division = value;
                //hScrollBarDivision.Value = value;
                Refresh();
            }
        }


		#endregion Properties 

		#region Events (3) 

        [Category(CATEGOY_STRING)]
        public event AnignoTreeListViewEventhandler OnAfterColapsed;

        [Category(CATEGOY_STRING)]
        public event AnignoTreeListViewEventhandler OnAfterExpend;

        [Category(CATEGOY_STRING)]
        public event AnignoTreeListViewEventhandler OnAfterSelect;

		#endregion Events 

		#region Delegates (1) 

        public delegate void AnignoTreeListViewEventhandler(object sender, TreeListNode node);

		#endregion Delegates 

		#region Event Handlers (6) 

        void hScrollBarDivision_ValueChanged(object sender, System.EventArgs e)
        {
            //treeViewScrollableMain.Width = Width * hScrollBarDivision.Value / 100;
            listViewMain.Left = treeViewScrollableMain.Width;
            //listViewMain.Width = Width * (100-hScrollBarDivision.Value) / 100;
        }

        void listViewMain_GotFocus(object sender, System.EventArgs e)
        {
            treeViewScrollableMain.Focus();
        }

        void treeViewMain_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            UpdateListView();
            if (OnAfterColapsed != null) OnAfterColapsed(this, (TreeListNode)e.Node);
        }

        void treeViewMain_AfterExpand(object sender, TreeViewEventArgs e)
        {
            UpdateListView();
            if (OnAfterExpend != null) OnAfterExpend(this, (TreeListNode) e.Node);
        }

        void treeViewScrollableMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (OnAfterSelect != null) OnAfterSelect(this, (TreeListNode) e.Node);
        }

        void treeViewScrollableMain_OnScrolledV(object sender, ScrollEventArgs e)
        {
            UpdateListView();
        }

		#endregion Event Handlers 

		#region Private Methods (2) 

        private void RegisterToEvents()
        {
            treeViewScrollableMain.AfterExpand += treeViewMain_AfterExpand;
            treeViewScrollableMain.AfterCollapse += treeViewMain_AfterCollapse;
            treeViewScrollableMain.OnScrolledV += treeViewScrollableMain_OnScrolledV;
            listViewMain.GotFocus += listViewMain_GotFocus;
            //hScrollBarDivision.ValueChanged += hScrollBarDivision_ValueChanged;
            treeViewScrollableMain.AfterSelect += treeViewScrollableMain_AfterSelect;
            Resize += AnignoTreeListView_Resize;
            BackColorChanged += AnignoTreeListView_BackColorChanged;
            ForeColorChanged += AnignoTreeListView_ForeColorChanged;
        }

        void AnignoTreeListView_ForeColorChanged(object sender, System.EventArgs e)
        {
            //hScrollBarDivision.ForeColor= listViewMain.ForeColor = treeViewScrollableMain.ForeColor = ForeColor;
        }

        void AnignoTreeListView_BackColorChanged(object sender, System.EventArgs e)
        {
            //hScrollBarDivision.BackColor = listViewMain.BackColor = treeViewScrollableMain.BackColor = BackColor;
        }

        void AnignoTreeListView_Resize(object sender, System.EventArgs e)
        {
            hScrollBarDivision_ValueChanged(null, null);
        }

        private void UpdateListView()
        {
            treeViewScrollableMain.ItemHeight = listViewMain.Font.Height + 1;
            if(treeViewScrollableMain.Nodes.Count<1)return;
            TreeListNode node = (TreeListNode) treeViewScrollableMain.Nodes[0];
            listViewMain.Items.Clear();
            bool bColor=false;
            while (node != null)
            {
                if (node.IsVisible)
                {
                    ListViewItem item = listViewMain.Items.Add(node.Text);
                    foreach(string s in node.SubItemsList)
                    {
                        item.SubItems.Add(s);
                    }
                    node.ConnectedListViewItem = item;
                    //item.BackColor= node.BackColor = bColor ? _TextColorFirst : _TextColorSecond;
                    bColor = !bColor;
                }
                node = (TreeListNode)node.NextVisibleNode;
            }
        }

		#endregion Private Methods 

		#region Public Methods (3) 

        public void AddColumn(string columnHeader,int columnWidth)
        {
            listViewMain.Columns.Add(columnHeader, columnWidth);
            UpdateListView();
        }

        public TreeListNode AddTreeListNode(TreeListNode parent, TreeListNode node)
        {
            if (parent == null)
            {
                treeViewScrollableMain.Nodes.Add(node);
            }
            else
            {
                parent.Nodes.Add(node);
            }
            UpdateListView();
            return node;
        }

        public TreeListNode AddTreeListNode(TreeListNode parent, string text)
        {
            TreeListNode node = new TreeListNode();
            node.Text = text;
            return AddTreeListNode(parent, node);
        }

		#endregion Public Methods 

    }
}

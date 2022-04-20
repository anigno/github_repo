using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using AnignoLibrary.IO.NetworkShares;
using System.Collections.Generic;

namespace AnignoLibrary.UI.TreeViewControls
{
    [DefaultEvent("OnAfterSelect")]
    public partial class FilesAndFoldersBrowser : UserControl
    {
		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " TreeViewFilesBrowser";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private string _selectedItem;

		#endregion (------  Fields  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event ItemActionDelegate OnAfterSelect;

        [Category(CATEGORY_STRING)]
        public event ItemActionDelegate OnItemDoubleClick;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        public delegate void ItemActionDelegate(string selectedItem);

		#endregion (------  Delegates  ------)

		#region (------  Constructors  ------)

        public FilesAndFoldersBrowser()
        {
            InitializeComponent();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        [Category(CATEGORY_STRING)]
        public bool CheckBoxes
        {
            get { return treeViewBrowser.CheckBoxes; }
            set { treeViewBrowser.CheckBoxes = value; }
        }

        [Category(CATEGORY_STRING)]
        public bool ShowNetworkShares { get; set; }

        [Category(CATEGORY_STRING)]
        public bool ShowFiles { get; set; }

        [Category(CATEGORY_STRING)]
        [Browsable(false)]
        public string SelectedItem
        {
            get
            {
                lock (treeViewBrowser)
                {
                    return _selectedItem;
                }
            }
        }

        public string[] CheckedFolders
        {
            get { return null; }
        }

        

		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        private void FilesAndFoldersBrowser_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            AddDrives();
        }
        public event TreeViewEventHandler OnAfterCheck;
        private void treeViewBrowser_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(OnAfterCheck!=null)OnAfterCheck(sender, e);
        }

        private void treeViewBrowser_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Collapse();
                node.Nodes.Clear();
            }
        }

        private void treeViewBrowser_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                AddChildrenToNode(node);
            }
        }

        private void treeViewBrowser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lock (treeViewBrowser)
            {
                _selectedItem = e.Node.FullPath;
            }
            if (OnAfterSelect != null) OnAfterSelect(SelectedItem);
        }

        private void treeViewBrowser_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (OnItemDoubleClick != null) OnItemDoubleClick(treeViewBrowser.SelectedNode.FullPath);
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            treeViewBrowser.BackColor = BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            treeViewBrowser.ForeColor = ForeColor;
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void AddChildrenToNode(TreeNode node)
        {
            DirectoryInfo di = new DirectoryInfo(node.FullPath);
            if (!di.Exists) return;
            try
            {
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    node.Nodes.Add(dir.Name, dir.Name, 7, 7);
                }
                if (ShowFiles)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        node.Nodes.Add(file.Name, file.Name, 8, 8);
                    }
                }
            }
            catch(UnauthorizedAccessException)
            {
                //Access denied
            }

        }

        private void AddDrives()
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                TreeNode newNode = treeViewBrowser.Nodes.Add(di.Name, di.Name, (int)di.DriveType, (int)di.DriveType);
                AddChildrenToNode(newNode);
            }
            if (!ShowNetworkShares) return;
            NetworkBrowser nb = new NetworkBrowser();
            foreach (string netComputer in nb.getNetworkComputers())
            {
                foreach (ShareItem sharedResource in ShareCollection.GetShares(netComputer))
                {
                    if (sharedResource.ShareType != ShareTypeEnum.Disk) continue;
                    if (sharedResource.Server == Environment.MachineName) continue;
                    if (sharedResource.Remark == "Printer Drivers") continue;
                    TreeNode newNode = treeViewBrowser.Nodes.Add(sharedResource.Root.ToString(), sharedResource.Root.ToString(), 4, 4);
                    AddChildrenToNode(newNode);
                }
            }
        }


		#endregion (------  Private Methods  ------)
    }
}
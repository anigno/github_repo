using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using AnignoLibrary.IO.NetworkShares;
using LoggingProvider;

namespace AnignoLibrary.UI.TreeViewControls.AnignoTreeViewFilesAndFoldersBrowserControl.cs
{
    public class AnignoTreeViewFilesAndFoldersBrowser : TreeViewExt
    {
		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoTreeViewFilesAndFoldersBrowser";

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private readonly ImageList _imageList=new ImageList();

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoTreeViewFilesAndFoldersBrowser()
        {
            ShowFiles = true;
            ShowNetworkShares=true;
            InitImageList();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        [Category(CATEGORY_STRING)]
        public bool ShowNetworkShares { get; set; }

        [Category(CATEGORY_STRING)]
        public bool ShowFiles { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            base.OnAfterCollapse(e);
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Collapse();
                node.Nodes.Clear();
            }
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);
            foreach (TreeNode node in e.Node.Nodes)
            {
                AddChildrenToNode(node);
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null)
            {
                Nodes.Clear();
                if(!DesignMode)AddDrives();
            }
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void AddChildrenToNode(TreeNode node)
        {
            DirectoryInfo di = new DirectoryInfo(node.FullPath+"\\");
            
            if (!di.Exists) return;
            try
            {
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    node.Nodes.Add(dir.Name, dir.Name, "FOLDER", "FOLDER");
                }
                if (ShowFiles)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        node.Nodes.Add(file.Name, file.Name, "FILE", "FILE");
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                //Access denied, System folders
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void AddDrives()
        {
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                TreeNode newNode = Nodes.Add(di.Name.Substring(0,2), di.Name.Substring(0,2), di.DriveType.ToString(), di.DriveType.ToString());
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
                    TreeNode newNode = Nodes.Add(sharedResource.Root.ToString(), sharedResource.Root.ToString(), DriveType.Network.ToString(), DriveType.Network.ToString());
                    AddChildrenToNode(newNode);
                }
            }
        }

        private void InitImageList()
        {
            _imageList.Images.Add(DriveType.Removable.ToString(),AnignoTreeViewFilesAndFoldersBrowserResource.AlienAqua_USB);
            _imageList.Images.Add(DriveType.CDRom.ToString(),AnignoTreeViewFilesAndFoldersBrowserResource.CD);
            _imageList.Images.Add(DriveType.Fixed.ToString(), AnignoTreeViewFilesAndFoldersBrowserResource.harddisk);
            _imageList.Images.Add(DriveType.Network.ToString(),AnignoTreeViewFilesAndFoldersBrowserResource.harddisk_network);
            _imageList.Images.Add("FOLDER", AnignoTreeViewFilesAndFoldersBrowserResource.folder);
            _imageList.Images.Add("FILE", AnignoTreeViewFilesAndFoldersBrowserResource.form_blue);
            ImageList = _imageList;
        }

		#endregion (------  Private Methods  ------)
    }
}
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System;

namespace AnignoLibrary.UI.TreeViewControls
{
    [Obsolete]
    public class TreeViewDirectoriesBrowser : TreeView
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " TreeViewDirectoriesBrowser";

		#endregion Const Fields 

		#region Fields (1) 


        private string _rootPath = string.Empty;

		#endregion Fields 

		#region Constructors (1) 

        public TreeViewDirectoriesBrowser()
        {
            RootPath = "";
        }

		#endregion Constructors 

		#region Read only Properties (1) 

        [Category(CATEGORY_STRING)]
        [Browsable(false)]
        public string SelectedPath
        {
            get
            {
                if (SelectedNode == null) return string.Empty;
                return SelectedNode.FullPath;
            }
        }

		#endregion Read only Properties 

		#region Properties (1) 


        [Category(CATEGORY_STRING)]
        public string RootPath
        {
            get { return _rootPath; }
            set
            {
                _rootPath = value;
                Nodes.Clear();
                if (DesignMode) return;
                if (_rootPath == string.Empty)
                {
                    //Drives tree
                    
                    foreach (DriveInfo drive in DriveInfo.GetDrives())
                    {
                        try
                        {
                            TreeNode node = new TreeNode(drive.Name);
                            Nodes.Add(node);
                            ExtendTreeNodeChildren(node, 2);
                        }catch(IOException)
                        {
                            //Device not ready
                        }
                    }
                }
                else
                {
                    //Path tree
                    if (!Directory.Exists(_rootPath)) return;
                    TreeNode rootNode = new TreeNode(_rootPath);
                    Nodes.Add(rootNode);
                    ExtendTreeNodeChildren(rootNode, 2);
                    Nodes[0].Expand();
                }
            }
        }


		#endregion Properties 


        #region Override
        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);
            ExtendTreeNodeChildren(e.Node, 2);
        }
        #endregion

        #region Private
        private static void ExtendTreeNodeChildren(TreeNode node, int depth)
        {
            if (depth == 0) return;
            node.Nodes.Clear();
            string nodePath = node.FullPath;
            try
            {
                foreach (string directory in Directory.GetDirectories(nodePath))
                {
                    string directoryName = Path.GetFileName(directory);
                    TreeNode newNode = new TreeNode(directoryName);
                    node.Nodes.Insert(0,newNode);
                    ExtendTreeNodeChildren(newNode, depth - 1);
                }
            }
            catch (UnauthorizedAccessException)
            {
                //System folders exception
            }
        }

        #endregion
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AnignoMobileLibrary.IO
{
    public class TreeViewFolderBrowser : TreeView
    {
        private string _selectedDirectory = string.Empty;

        public string SelectedDirectory
        {
            get { return _selectedDirectory; }
            set { _selectedDirectory = value; }
        }

        public TreeViewFolderBrowser()
        {
            InitTreeViewFolders();
            this.AfterSelect += treeView_AfterSelect;
            this.AfterExpand += treeView_AfterExpand;
        }

        private void InitTreeViewFolders()
        {
            try
            {
                string[] dirs = Directory.GetDirectories("\\");
                foreach (string dir in dirs)
                {
                    TreeNode node = new TreeNode(dir);
                    this.Nodes.Add(node);
                    AddNextLevel(node);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AddNextLevel(TreeNode node)
        {
            string path = node.FullPath;
            string[] dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                string dirName = GetLastDirectoryName(dir);
                TreeNode n = new TreeNode(dirName);
                node.Nodes.Add(n);
            }
        }

        private string GetLastDirectoryName(string directory)
        {
            int b = 0;
            for (int a = 0; a >= 0; a = directory.IndexOf("\\", a + 1)) b = a;
            return directory.Substring(b + 1);
        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            try
            {
                foreach (TreeNode node in e.Node.Nodes)
                {
                    if (node.Nodes.Count == 0)
                    {
                        AddNextLevel(node);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selectedDirectory = e.Node.FullPath;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnignoLibrary.UI.TreeViewControls;
using AnignoLibrary.UI.TreeViewControls.AnignoTreeViewFilesAndFoldersBrowserControl.cs;

namespace AnignoBackupToEmail
{
    public class FilesAndFoldersBrowser : AnignoTreeViewFilesAndFoldersBrowser  
    {
        public FilesAndFoldersBrowser()
        {
            ShowFiles=false;
            ShowNetworkShares=false;
        }
        protected override void OnAfterCheck(System.Windows.Forms.TreeViewEventArgs e)
        {
            base.OnAfterCheck(e);
            if (IsAnyParentChecked(e.Node)) e.Node.Checked = false;
            if(IsAnyChildChecked(e.Node))SetCheckAllChildNodes(e.Node,false);
        }
        protected override void OnAfterCollapse(System.Windows.Forms.TreeViewEventArgs e)
        {
            base.OnAfterCollapse(e);
        }


        
    }
}

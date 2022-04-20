using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnignoLibrary.Helpers.InvocationHelpers;
using AnignoLibrary.IO;
using AnignoLibrary.UI.Forms;
using LoggingProvider;
using System.IO;

namespace AnignoSimpleDuplicateFilesFinder
{
    public partial class FormMain : formGradientBase
    {

		#region (------  Fields  ------)


        private int mDuplicatesFound;

        private readonly DuplicateChecker mMainData=new DuplicateChecker();
        private readonly FileSystemWalker fsw=new FileSystemWalker();
        private long mExtraSize;                                            //Sum the size that occupied by extra files
        private bool _isSearching;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FormMain()
        {
            InitializeComponent();
            fsw.OnFileSystemWalkerEndedMultiple += fsw_OnFileSystemWalkerEndedMultiple;
            fsw.OnFileSystemWalkerExceptionThrown += fsw_OnFileSystemWalkerExceptionThrown;
            mMainData.OnDuplicateFileFound += mMainData_OnDuplicateFileFound;
            fsw.OnFileSystemWalkerFileFound += fsw_OnFileSystemWalkerFileFound;
        }

		#endregion (------  Constructors  ------)

		#region (------  Event Handlers  ------)

        private void buttonRoundedGlowDelete_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            try
            {
                if (listViewCopies.CheckedItems.Count <= 0) return;
                string message = "";
                foreach (ListViewItem item in listViewCopies.CheckedItems)
                {
                    message += item.Text + "\n\r";
                }
                if (MessageBox.Show("Are you sure you want to delete: " + message, "", MessageBoxButtons.YesNo) == DialogResult.No) return;
                foreach (ListViewItem item in listViewCopies.CheckedItems)
                {
                    Logger.LogDebug("Delete: " + item.Text);
                    File.Delete(item.Text);
                    listViewCopies.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("", ex);
            }
        }

        private void buttonRoundedGlowStart_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Logger.Log();
            mMainData.AllFilesDictionary.Clear();
            listViewResults.Items.Clear();
            listViewCopies.Items.Clear();
            mDuplicatesFound = 0;
            mExtraSize = 0;
            buttonRoundedGlowStart.Visible = false;
            buttonRoundedGlowStop.Visible=true;
            string[] selectedDirectories = GetSelectedDirectories();
            fsw.Start(selectedDirectories);
            _isSearching=true;
        }

        private void buttonRoundedGlowStop_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            Logger.Log();
            buttonRoundedGlowStart.Visible = true;
            buttonRoundedGlowStop.Visible = false;
            fsw.Stop();
            _isSearching=false;
        }

        void fsw_OnFileSystemWalkerEndedMultiple()
        {
            Logger.Log();
            ListViewInvocationHelper.ListView_ItemsClear_Invoked(listViewResults, ControlInvocationHelper.InvokationTypeEnum.Synch);

            foreach (KeyValuePair<string,List<FileInfo>> pair in mMainData.AllFilesDictionary)
            {
                if (pair.Value.Count <= 1) continue;
                ListViewItem item = new ListViewItem(new[] {pair.Key, pair.Value.Count.ToString()});
                item.Tag = pair;
                ListViewInvocationHelper.ListView_ItemAdd_Invoked(listViewResults, ControlInvocationHelper.InvokationTypeEnum.Synch, item, false);
            }
            ControlInvocationHelper.SetVisible(buttonRoundedGlowStop, ControlInvocationHelper.InvokationTypeEnum.Synch, false);
            ControlInvocationHelper.SetVisible(buttonRoundedGlowStart, ControlInvocationHelper.InvokationTypeEnum.Synch, true);
            _isSearching=false;
        }

        static void fsw_OnFileSystemWalkerExceptionThrown(DirectoryInfo dirInfo, Exception ex)
        {
            //Nothing
        }

        void fsw_OnFileSystemWalkerFileFound(FileInfo fileInfo)
        {
            ControlInvocationHelper.SetText(labelCurrentFile,ControlInvocationHelper.InvokationTypeEnum.Synch,fileInfo.FullName);
            mMainData.CheckAndAddFile(fileInfo,checkBoxBySize.Checked,checkBoxByName.Checked);
        }

        private void listViewResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listViewResults.SelectedItems.Count<=0)return;
            listViewCopies.Items.Clear();
            KeyValuePair<string, List<FileInfo>> pair = (KeyValuePair<string, List<FileInfo>>)listViewResults.SelectedItems[0].Tag;
            foreach (FileInfo fileInfo in pair.Value)
            {
                if (File.Exists(fileInfo.FullName))
                {
                    ListViewItem item = new ListViewItem(new[] {fileInfo.FullName, fileInfo.Length.ToString("{0,0} bytes"),fileInfo.LastWriteTime.ToString()});
                    listViewCopies.Items.Add(item);
                }
            }
        }

        void mMainData_OnDuplicateFileFound(string filePath,FileInfo fileInfo, List<FileInfo> duplicatesList)
        {
            mDuplicatesFound++;
            mExtraSize += fileInfo.Length;
            ControlInvocationHelper.SetText(labelDuplicatesFound, ControlInvocationHelper.InvokationTypeEnum.Synch, mDuplicatesFound.ToString("0,0 files"));
            ControlInvocationHelper.SetText(labelExtraSize, ControlInvocationHelper.InvokationTypeEnum.Synch, (mExtraSize/1024).ToString("0,0 MB"));
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Static Methods  ------)

        private static void GetSelectedDirectoriesRecurse(TreeNode node,ICollection<string> selectedDirectoriesList)
        {
            if (node.Checked)
            {
                selectedDirectoriesList.Add(node.FullPath);
            }
            else
            {
                foreach (TreeNode childNode in node.Nodes)
                {
                    GetSelectedDirectoriesRecurse(childNode,selectedDirectoriesList);
                }
            }
        }

		#endregion (------  Static Methods  ------)

		#region (------  Private Methods  ------)

        private string[] GetSelectedDirectories()
        {
            List<string> selectedDirectoriesList=new List<string>();
            foreach (TreeNode rootNode in treeViewDirectoriesBrowserDirectories.Nodes)
            {
                GetSelectedDirectoriesRecurse(rootNode,selectedDirectoriesList);
            }
            return selectedDirectoriesList.ToArray();
        }

		#endregion (------  Private Methods  ------)

        private void buttonRoundedGlowDeleteAllOlder_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            if(_isSearching)return;
            if(mMainData.AllFilesDictionary.Count==0)return;
            if (MessageBox.Show("Are you sure you want to delete all old duplicates found?", "Anigno Simple Duplicate Files Finder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)return;
            new FormDeleteAllOlderFiles(mMainData.AllFilesDictionary).ShowDialog();
        }

    }
}

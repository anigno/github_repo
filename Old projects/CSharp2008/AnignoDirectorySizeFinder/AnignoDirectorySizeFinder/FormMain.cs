using System.Windows.Forms;
using System.Threading;
using System.IO;
using AnignoLibrary.Helpers.InvocationHelpers;

namespace AnignoDirectorySizeFinder
{
    public partial class FormMain : Form
    {

		#region Fields (1) 


        private Thread mDirectoryWalkerThread;

		#endregion Fields 

		#region Constructors (1) 

        public FormMain()
        {
            InitializeComponent();
        }

		#endregion Constructors 

		#region Event Handlers (4) 

        private void buttonRoundedGlowStart_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            listViewResults.Items.Clear();
            mDirectoryWalkerThread = new Thread(DirectoryWalkerThreadStart);
            mDirectoryWalkerThread.Start();
        }

        private void buttonRoundedGlowStop_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            AbortSearch();
            ControlInvocationHelper.SetEnabled(buttonRoundedGlowStart, ControlInvocationHelper.InvokationTypeEnum.Synch, true);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            AbortSearch();
        }

        private void listViewResults_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listViewResults.SelectedItems.Count <= 0) return;
            textBoxSelectedPath.Text = listViewResults.SelectedItems[0].Text;
        }

		#endregion Event Handlers 

		#region Private Methods (3) 

        private void AbortSearch()
        {
            if (mDirectoryWalkerThread != null)
            {
                mDirectoryWalkerThread.Abort();
            }
        }

        private void DirectoryWalkerThreadStart()
        {
            if (!textBoxFileFolderBrowseRoot.IsExist) return;
            ControlInvocationHelper.SetEnabled(buttonRoundedGlowStart, ControlInvocationHelper.InvokationTypeEnum.Synch, false);
            DirectoryInfo dirInfo = new DirectoryInfo(textBoxFileFolderBrowseRoot.Data);
            long files;
            long size;
            DirectoryWalkRecurse(dirInfo,out files,out size);
            ControlInvocationHelper.SetEnabled(buttonRoundedGlowStart, ControlInvocationHelper.InvokationTypeEnum.Synch, true);
        }

        private void DirectoryWalkRecurse(DirectoryInfo dirInfo,out long files,out long size)
        {
            ControlInvocationHelper.SetText(labelCurrentPath, ControlInvocationHelper.InvokationTypeEnum.Async, dirInfo.FullName);
            files = 0;
            size = 0;
            if (dirInfo.Name == "System Volume Information") return;
            foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
            {
                long subFiles;
                long subSize;
                DirectoryWalkRecurse(subDirInfo, out subFiles, out subSize);
                files += subFiles;
                size += subSize;
            }
            foreach (FileInfo subFileInfo in dirInfo.GetFiles())
            {
                if (!subFileInfo.Exists) continue;
                files += 1;
                size += subFileInfo.Length;
            }
            long sizeMB = size / 1024 / 1024;
            if (sizeMB <= (long)numericUpDownMinSize.Value) return;
            ListViewItem item = new ListViewItem(new[] { dirInfo.FullName,string.Format("{0:#,#}", files), string.Format("{0:#,#} MB", sizeMB) });
            ListViewInvocationHelper.ListView_ItemAdd_Invoked(listViewResults, ControlInvocationHelper.InvokationTypeEnum.Synch, item, true);
        }

		#endregion Private Methods 

    }
}

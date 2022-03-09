using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using LoggingProvider;

namespace AnignoSimpleDuplicateFilesFinder
{
    [TestFixture]
    public partial class FormDeleteAllOlderFiles : Form
    {

		#region (------  Fields  ------)


        private  Dictionary<string, List<FileInfo>> _allFiles = new Dictionary<string, List<FileInfo>>();

		#endregion (------  Fields  ------)

		#region (------  Tests  ------)

        [Test]
        public void Test_GetDirectoryNameExt()
        {
            string path = @"D:\My Documents\_Anigno Documents\Programing\CSharp2008\AnignoSimpleDuplicateFilesFinderSolution\AnignoSimpleDuplicateFilesFinder\bin\Debug\AnignoSimpleDuplicateFilesFinder.exe";
            string dir=GetDirectoryNameExt(path);
            Assert.AreEqual(Path.GetDirectoryName(path),dir);
        }

		#endregion (------  Tests  ------)

		#region (------  Constructors  ------)

        public FormDeleteAllOlderFiles(Dictionary<string, List<FileInfo>> allFiles)
        {
            _allFiles=allFiles;
            InitializeComponent();
        }

        public FormDeleteAllOlderFiles()
        {
        }

		#endregion (------  Constructors  ------)

		#region (------  Event Handlers  ------)
        
        private void buttonRoundedGlowStart_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            if(!textBoxFileFolderBrowseBackupPath.IsExist)return;
            long SumSizeSaved = 0;
            int sumFiles = 0;
            foreach (List<FileInfo> duplicatesList in _allFiles.Values)
            {
                if (duplicatesList.Count < 2) continue;
                IOrderedEnumerable<FileInfo> duplicatesOrdered = from FileInfo fi in duplicatesList orderby fi.LastWriteTime select fi;
                FileInfo[] fiArray = duplicatesOrdered.ToArray();
                for (int a = 0; a < fiArray.Length - 1;a++)
                {
                    string sourceFile = fiArray[a].FullName;
                    try
                    {
                        string destFile = textBoxFileFolderBrowseBackupPath.Data + "\\" + GetPathWithoutDrive(sourceFile);
                        string sourceDir = GetDirectoryNameExt(sourceFile);
                        string destDir = GetDirectoryNameExt(destFile);
                        if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);
                    try
                    {
                        if (sourceFile.Length > 254) sourceFile = sourceFile.Substring(0, 254);
                        if (destFile.Length > 254) destFile = destFile.Substring(0, 254);
                        File.Move(sourceFile, destFile);
                        listViewLog.Items.Add(new ListViewItem(new string[] { Path.GetFileName(sourceFile), "Moved to: "+destDir }));
                        SumSizeSaved += fiArray[a].Length;
                        sumFiles++;
                    }
                    catch (Exception ex)
                    {
                        listViewLog.Items.Add(new ListViewItem(new string[] { sourceFile, ex.Message }));
                        Logger.LogWarning(sourceFile+" "+ex.Message);
                    }
                    try
                    {
                        if (Directory.GetFiles(sourceDir).Length == 0 && Directory.GetDirectories(sourceDir).Length == 0)
                        {
                            Directory.Delete(sourceDir);
                            listViewLog.Items.Add(new ListViewItem(new string[] { sourceDir, "Empty and deleted" }));
                        }
                    }
                    catch (Exception ex)
                    {
                        listViewLog.Items.Add(new ListViewItem(new string[] { sourceDir, ex.Message }));
                        Logger.LogWarning(sourceFile + " " + ex.Message);
                    }
                    Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        listViewLog.Items.Add(new ListViewItem(new string[] { sourceFile,ex.Message }));
                        Logger.LogWarning(sourceFile + " " + ex.Message);
                        throw;
                    }
                }
            }
            listViewLog.Items.Add(new ListViewItem(new string[] { "Summery", "Files moved: " + sumFiles }));
            listViewLog.Items.Add(new ListViewItem(new string[] { "Summery", "Total size: " + (SumSizeSaved / 1024).ToString("0,0") + " MB" })).EnsureVisible();

        }

        private void buttonRoundedGlowStop_OnButtonRoundedGlowMouseClick(AnignoLibrary.UI.Buttons.ButtonRoundedGlow sender)
        {
            buttonRoundedGlowStart.Enabled=false;
            Close();
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private string GetDirectoryNameExt(string path)
        {
            int a = path.LastIndexOf("\\");
            if(a<0)return path;
            return path.Substring(0, a);
        }

        private string GetPathWithoutDrive(string path)
        {
            return path.Substring(3);
        }

		#endregion (------  Private Methods  ------)

    }
}

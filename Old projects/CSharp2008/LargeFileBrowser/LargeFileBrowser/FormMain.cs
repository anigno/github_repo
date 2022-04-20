using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LargeFileBrowser
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }


        private void RunFile(string filepath)
        {
            Process p=new Process();
            p.StartInfo.FileName = filepath;
            p.Start();
        }

        private void filesAndFoldersBrowser1_OnItemDoubleClick(string selectedItem)
        {
            if(File.Exists(selectedItem))RunFile(selectedItem);

        }
    }
}

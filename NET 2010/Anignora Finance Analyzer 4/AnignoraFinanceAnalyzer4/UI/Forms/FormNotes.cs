using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoraFinanceAnalyzer4.UI.Forms
{
    public partial class FormNotes : Form
    {
        private const string NOTES_FILE_NAME = @"Data\Notes\notes.txt";
        public FormNotes()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNotes_Load(object sender, EventArgs e)
        {
            string s=File.ReadAllText(NOTES_FILE_NAME);
            richTextBoxNote.Text = s;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            string s = richTextBoxNote.Text;
            File.WriteAllText(NOTES_FILE_NAME, s);
            base.OnClosing(e);
        }
    }
}

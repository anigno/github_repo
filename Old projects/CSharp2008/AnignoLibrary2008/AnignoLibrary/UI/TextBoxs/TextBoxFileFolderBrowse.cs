using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AnignoLibrary.UI.TextBoxs
{
    public enum BrowseTypeEnum
    {
        BrowseForFolder,
        BrowseForFile
    }

    public partial class TextBoxFileFolderBrowse : UserControl
    {
        private const string PROPERTY_CATEGORY = " TextBoxFileFolderBrowse";
        private static readonly Color EXIST_COLOR = Color.LightGreen;
        private static readonly Color NOT_EXIST_COLOR = Color.FromArgb(255, 150, 150);
        private BrowseTypeEnum _browseType = BrowseTypeEnum.BrowseForFile;

        #region Properties
        [Category(PROPERTY_CATEGORY)]
        public BrowseTypeEnum BrowseType
        {
            get { return _browseType; }
            set
            {
                _browseType = value;
                if (value == BrowseTypeEnum.BrowseForFile)
                {
                    buttonBrowse.Text = "***";
                }
                else
                {
                    buttonBrowse.Text = @"\\";
                }
            }
        }

        /// <summary>
        /// Returns true if the file or path exists, else returns false
        /// </summary>
        [Category(PROPERTY_CATEGORY)]
        public bool IsExist
        {
            get
            {
                if (BrowseType == BrowseTypeEnum.BrowseForFolder)
                {
                    return Directory.Exists(textBoxData.Text);
                }
                else
                {
                    return File.Exists(textBoxData.Text);
                }
            }
        }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [Category(PROPERTY_CATEGORY)]
        public string Data
        {
            get { return textBoxData.Text; }
            set { textBoxData.Text = value; }
        }

            #endregion

        #region CTOR
        public TextBoxFileFolderBrowse()
        {
            InitializeComponent();
            SetExistColor();
        }
        #endregion

        private void SetExistColor()
        {
            textBoxData.BackColor = IsExist ? EXIST_COLOR : NOT_EXIST_COLOR;
        }

        private void TextBoxFileFolderBrowse_SizeChanged(object sender, EventArgs e)
        {
            textBoxData.Width = Width - buttonBrowse.Width+1;
            Height = textBoxData.Height;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (BrowseType == BrowseTypeEnum.BrowseForFile)
            {
                using (OpenFileDialog f = new OpenFileDialog())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        textBoxData.Text = f.FileName;
                    }
                }
            }
            else
            {
                using (FolderBrowserDialog f = new FolderBrowserDialog())
                {
                    f.ShowNewFolderButton=true;
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        textBoxData.Text = f.SelectedPath;
                    }
                }
            }
        }

        private void textBoxData_TextChanged(object sender, EventArgs e)
        {
            SetExistColor();
        }
    }
}

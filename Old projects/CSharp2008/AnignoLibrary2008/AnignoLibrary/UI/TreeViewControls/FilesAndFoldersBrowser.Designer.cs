namespace AnignoLibrary.UI.TreeViewControls
{
    partial class FilesAndFoldersBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesAndFoldersBrowser));
            this.treeViewBrowser = new TreeViewExt();
            this.imageListDrives = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeViewBrowser
            // 
            this.treeViewBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewBrowser.HideSelection = false;
            this.treeViewBrowser.ImageIndex = 0;
            this.treeViewBrowser.ImageList = this.imageListDrives;
            this.treeViewBrowser.Location = new System.Drawing.Point(0, 0);
            this.treeViewBrowser.Name = "treeViewBrowser";
            this.treeViewBrowser.SelectedImageKey = "Hard Drive - e.png";
            this.treeViewBrowser.ShowNodeToolTips = true;
            this.treeViewBrowser.Size = new System.Drawing.Size(220, 296);
            this.treeViewBrowser.TabIndex = 0;
            this.treeViewBrowser.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterCheck);
            this.treeViewBrowser.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewBrowser_MouseDoubleClick);
            this.treeViewBrowser.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterCollapse);
            this.treeViewBrowser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterSelect);
            this.treeViewBrowser.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewBrowser_AfterExpand);
            // 
            // imageListDrives
            // 
            this.imageListDrives.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDrives.ImageStream")));
            this.imageListDrives.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDrives.Images.SetKeyName(0, "hdd bleu.png");
            this.imageListDrives.Images.SetKeyName(1, "hdd bleu 2.png");
            this.imageListDrives.Images.SetKeyName(2, "Hard Drive - a.png");
            this.imageListDrives.Images.SetKeyName(3, "Hard Drive - e.png");
            this.imageListDrives.Images.SetKeyName(4, "Internet Connection Tools.png");
            this.imageListDrives.Images.SetKeyName(5, "CD - a.png");
            this.imageListDrives.Images.SetKeyName(6, "Memory Card - SD b.png");
            this.imageListDrives.Images.SetKeyName(7, "Folder.png");
            this.imageListDrives.Images.SetKeyName(8, "file_doc.png");
            // 
            // FilesAndFoldersBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.treeViewBrowser);
            this.Name = "FilesAndFoldersBrowser";
            this.Size = new System.Drawing.Size(220, 296);
            this.Load += new System.EventHandler(this.FilesAndFoldersBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewExt treeViewBrowser;
        private System.Windows.Forms.ImageList imageListDrives;
    }
}

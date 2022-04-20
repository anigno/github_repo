namespace LargeFileBrowser
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.filesAndFoldersBrowser1 = new AnignoLibrary.UI.TreeViewControls.FilesAndFoldersBrowser();
            this.SuspendLayout();
            // 
            // filesAndFoldersBrowser1
            // 
            this.filesAndFoldersBrowser1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filesAndFoldersBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesAndFoldersBrowser1.Location = new System.Drawing.Point(0, 0);
            this.filesAndFoldersBrowser1.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.filesAndFoldersBrowser1.Name = "filesAndFoldersBrowser1";
            this.filesAndFoldersBrowser1.ShowNetworkShares = true;
            this.filesAndFoldersBrowser1.Size = new System.Drawing.Size(742, 523);
            this.filesAndFoldersBrowser1.TabIndex = 2;
            this.filesAndFoldersBrowser1.OnItemDoubleClick += new AnignoLibrary.UI.TreeViewControls.FilesAndFoldersBrowser.ItemActionDelegate(this.filesAndFoldersBrowser1_OnItemDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 523);
            this.Controls.Add(this.filesAndFoldersBrowser1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "FormMain";
            this.Text = "Large Files Browser";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibrary.UI.TreeViewControls.FilesAndFoldersBrowser filesAndFoldersBrowser1;

    }
}


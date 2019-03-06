namespace LogViewer
{
    partial class formLogSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogSelection));
            this.listBoxApplicationLogPath = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxLogFiles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripLogPath = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddLogPath = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveLogPath = new System.Windows.Forms.ToolStripButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.toolStripLogPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxApplicationLogPath
            // 
            this.listBoxApplicationLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxApplicationLogPath.FormattingEnabled = true;
            this.listBoxApplicationLogPath.HorizontalScrollbar = true;
            this.listBoxApplicationLogPath.Location = new System.Drawing.Point(12, 25);
            this.listBoxApplicationLogPath.Name = "listBoxApplicationLogPath";
            this.listBoxApplicationLogPath.Size = new System.Drawing.Size(350, 316);
            this.listBoxApplicationLogPath.TabIndex = 0;
            this.listBoxApplicationLogPath.SelectedIndexChanged += new System.EventHandler(this.listBoxApplicationLogPath_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application log path:";
            // 
            // listBoxLogFiles
            // 
            this.listBoxLogFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLogFiles.FormattingEnabled = true;
            this.listBoxLogFiles.HorizontalScrollbar = true;
            this.listBoxLogFiles.Location = new System.Drawing.Point(368, 25);
            this.listBoxLogFiles.Name = "listBoxLogFiles";
            this.listBoxLogFiles.Size = new System.Drawing.Size(276, 316);
            this.listBoxLogFiles.TabIndex = 2;
            this.listBoxLogFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxLogFiles_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Application log path:";
            // 
            // toolStripLogPath
            // 
            this.toolStripLogPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStripLogPath.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripLogPath.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripLogPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddLogPath,
            this.toolStripButtonRemoveLogPath});
            this.toolStripLogPath.Location = new System.Drawing.Point(15, 360);
            this.toolStripLogPath.Name = "toolStripLogPath";
            this.toolStripLogPath.Size = new System.Drawing.Size(49, 25);
            this.toolStripLogPath.TabIndex = 4;
            this.toolStripLogPath.Text = "toolStrip1";
            // 
            // toolStripButtonAddLogPath
            // 
            this.toolStripButtonAddLogPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddLogPath.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddLogPath.Image")));
            this.toolStripButtonAddLogPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddLogPath.Name = "toolStripButtonAddLogPath";
            this.toolStripButtonAddLogPath.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddLogPath.Text = "toolStripButton1";
            this.toolStripButtonAddLogPath.Click += new System.EventHandler(this.toolStripButtonAddLogPath_Click);
            // 
            // toolStripButtonRemoveLogPath
            // 
            this.toolStripButtonRemoveLogPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveLogPath.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveLogPath.Image")));
            this.toolStripButtonRemoveLogPath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveLogPath.Name = "toolStripButtonRemoveLogPath";
            this.toolStripButtonRemoveLogPath.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRemoveLogPath.Text = "toolStripButton2";
            this.toolStripButtonRemoveLogPath.Click += new System.EventHandler(this.toolStripButtonRemoveLogPath_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(569, 359);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(488, 359);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // formLogSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 394);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.toolStripLogPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxLogFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxApplicationLogPath);
            this.Name = "formLogSelection";
            this.Text = "Log selection";
            this.toolStripLogPath.ResumeLayout(false);
            this.toolStripLogPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxApplicationLogPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxLogFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip toolStripLogPath;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddLogPath;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveLogPath;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
    }
}
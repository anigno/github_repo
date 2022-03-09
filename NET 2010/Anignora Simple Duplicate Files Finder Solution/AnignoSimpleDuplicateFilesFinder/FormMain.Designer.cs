namespace AnignoSimpleDuplicateFilesFinder
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
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.checkBoxBySize = new System.Windows.Forms.CheckBox();
            this.checkBoxByName = new System.Windows.Forms.CheckBox();
            this.buttonRoundedGlowStart = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.treeViewDirectoriesBrowserDirectories = new AnignoLibrary.UI.TreeViewControls.TreeViewDirectoriesBrowser();
            this.buttonRoundedGlowDelete = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowStop = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDuplicatesFound = new System.Windows.Forms.Label();
            this.listViewCopies = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.labelExtraSize = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRoundedGlowDeleteAllOlder = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewResults
            // 
            this.listViewResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(0, 0);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(746, 222);
            this.listViewResults.TabIndex = 2;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.SelectedIndexChanged += new System.EventHandler(this.listViewResults_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File";
            this.columnHeader1.Width = 455;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Found copies";
            this.columnHeader2.Width = 81;
            // 
            // checkBoxBySize
            // 
            this.checkBoxBySize.AutoSize = true;
            this.checkBoxBySize.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxBySize.Checked = true;
            this.checkBoxBySize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBySize.Location = new System.Drawing.Point(369, 49);
            this.checkBoxBySize.Name = "checkBoxBySize";
            this.checkBoxBySize.Size = new System.Drawing.Size(59, 17);
            this.checkBoxBySize.TabIndex = 5;
            this.checkBoxBySize.Text = "By size";
            this.checkBoxBySize.UseVisualStyleBackColor = false;
            // 
            // checkBoxByName
            // 
            this.checkBoxByName.AutoSize = true;
            this.checkBoxByName.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxByName.Checked = true;
            this.checkBoxByName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxByName.Location = new System.Drawing.Point(369, 72);
            this.checkBoxByName.Name = "checkBoxByName";
            this.checkBoxByName.Size = new System.Drawing.Size(67, 17);
            this.checkBoxByName.TabIndex = 6;
            this.checkBoxByName.Text = "By name";
            this.checkBoxByName.UseVisualStyleBackColor = false;
            // 
            // buttonRoundedGlowStart
            // 
            this.buttonRoundedGlowStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowStart.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStart.BackgroundColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonRoundedGlowStart.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowStart.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowStart.BorderVisible = true;
            this.buttonRoundedGlowStart.ButtonText = "Start";
            this.buttonRoundedGlowStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowStart.GlowAlpha = 200;
            this.buttonRoundedGlowStart.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStart.Location = new System.Drawing.Point(4, 4);
            this.buttonRoundedGlowStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowStart.Name = "buttonRoundedGlowStart";
            this.buttonRoundedGlowStart.RoundedCornersRadious = 15;
            this.buttonRoundedGlowStart.Size = new System.Drawing.Size(75, 23);
            this.buttonRoundedGlowStart.TabIndex = 12;
            this.buttonRoundedGlowStart.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowStart_OnButtonRoundedGlowMouseClick);
            // 
            // treeViewDirectoriesBrowserDirectories
            // 
            this.treeViewDirectoriesBrowserDirectories.CheckBoxes = true;
            this.treeViewDirectoriesBrowserDirectories.Location = new System.Drawing.Point(12, 12);
            this.treeViewDirectoriesBrowserDirectories.Name = "treeViewDirectoriesBrowserDirectories";
            this.treeViewDirectoriesBrowserDirectories.RootPath = "";
            this.treeViewDirectoriesBrowserDirectories.Size = new System.Drawing.Size(351, 159);
            this.treeViewDirectoriesBrowserDirectories.TabIndex = 9;
            // 
            // buttonRoundedGlowDelete
            // 
            this.buttonRoundedGlowDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoundedGlowDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowDelete.BackgroundColorFirst = System.Drawing.Color.Navy;
            this.buttonRoundedGlowDelete.BackgroundColorSecond = System.Drawing.Color.Blue;
            this.buttonRoundedGlowDelete.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowDelete.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowDelete.BorderVisible = true;
            this.buttonRoundedGlowDelete.ButtonText = "Delete Specific";
            this.buttonRoundedGlowDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRoundedGlowDelete.GlowAlpha = 200;
            this.buttonRoundedGlowDelete.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowDelete.Location = new System.Drawing.Point(635, 4);
            this.buttonRoundedGlowDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowDelete.Name = "buttonRoundedGlowDelete";
            this.buttonRoundedGlowDelete.RoundedCornersRadious = 15;
            this.buttonRoundedGlowDelete.Size = new System.Drawing.Size(107, 19);
            this.buttonRoundedGlowDelete.TabIndex = 4;
            this.buttonRoundedGlowDelete.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowDelete_OnButtonRoundedGlowMouseClick);
            // 
            // buttonRoundedGlowStop
            // 
            this.buttonRoundedGlowStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowStop.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStop.BackgroundColorSecond = System.Drawing.Color.Red;
            this.buttonRoundedGlowStop.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowStop.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowStop.BorderVisible = true;
            this.buttonRoundedGlowStop.ButtonText = "Stop";
            this.buttonRoundedGlowStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowStop.GlowAlpha = 200;
            this.buttonRoundedGlowStop.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStop.Location = new System.Drawing.Point(87, 4);
            this.buttonRoundedGlowStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowStop.Name = "buttonRoundedGlowStop";
            this.buttonRoundedGlowStop.RoundedCornersRadious = 15;
            this.buttonRoundedGlowStop.Size = new System.Drawing.Size(75, 23);
            this.buttonRoundedGlowStop.TabIndex = 13;
            this.buttonRoundedGlowStop.Visible = false;
            this.buttonRoundedGlowStop.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowStop_OnButtonRoundedGlowMouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.buttonRoundedGlowStart);
            this.flowLayoutPanel1.Controls.Add(this.buttonRoundedGlowStop);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(369, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(167, 31);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentFile.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrentFile.Location = new System.Drawing.Point(12, 174);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(750, 23);
            this.labelCurrentFile.TabIndex = 15;
            this.labelCurrentFile.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(366, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Duplicates found:";
            // 
            // labelDuplicatesFound
            // 
            this.labelDuplicatesFound.AutoSize = true;
            this.labelDuplicatesFound.BackColor = System.Drawing.Color.Transparent;
            this.labelDuplicatesFound.Location = new System.Drawing.Point(462, 92);
            this.labelDuplicatesFound.Name = "labelDuplicatesFound";
            this.labelDuplicatesFound.Size = new System.Drawing.Size(13, 13);
            this.labelDuplicatesFound.TabIndex = 17;
            this.labelDuplicatesFound.Text = "0";
            // 
            // listViewCopies
            // 
            this.listViewCopies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewCopies.CheckBoxes = true;
            this.listViewCopies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewCopies.FullRowSelect = true;
            this.listViewCopies.GridLines = true;
            this.listViewCopies.HideSelection = false;
            this.listViewCopies.Location = new System.Drawing.Point(3, 3);
            this.listViewCopies.Name = "listViewCopies";
            this.listViewCopies.Size = new System.Drawing.Size(625, 86);
            this.listViewCopies.TabIndex = 18;
            this.listViewCopies.UseCompatibleStateImageBehavior = false;
            this.listViewCopies.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File";
            this.columnHeader3.Width = 419;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Size";
            this.columnHeader4.Width = 86;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last write time";
            this.columnHeader5.Width = 107;
            // 
            // labelExtraSize
            // 
            this.labelExtraSize.AutoSize = true;
            this.labelExtraSize.BackColor = System.Drawing.Color.Transparent;
            this.labelExtraSize.Location = new System.Drawing.Point(462, 109);
            this.labelExtraSize.Name = "labelExtraSize";
            this.labelExtraSize.Size = new System.Drawing.Size(13, 13);
            this.labelExtraSize.TabIndex = 19;
            this.labelExtraSize.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(366, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Extra size:";
            // 
            // buttonRoundedGlowDeleteAllOlder
            // 
            this.buttonRoundedGlowDeleteAllOlder.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowDeleteAllOlder.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRoundedGlowDeleteAllOlder.BackgroundColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowDeleteAllOlder.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowDeleteAllOlder.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowDeleteAllOlder.BorderVisible = true;
            this.buttonRoundedGlowDeleteAllOlder.ButtonText = "Delete All older";
            this.buttonRoundedGlowDeleteAllOlder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowDeleteAllOlder.ForeColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowDeleteAllOlder.GlowAlpha = 200;
            this.buttonRoundedGlowDeleteAllOlder.GlowColor = System.Drawing.Color.White;
            this.buttonRoundedGlowDeleteAllOlder.Location = new System.Drawing.Point(367, 151);
            this.buttonRoundedGlowDeleteAllOlder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowDeleteAllOlder.Name = "buttonRoundedGlowDeleteAllOlder";
            this.buttonRoundedGlowDeleteAllOlder.RoundedCornersRadious = 15;
            this.buttonRoundedGlowDeleteAllOlder.Size = new System.Drawing.Size(118, 19);
            this.buttonRoundedGlowDeleteAllOlder.TabIndex = 21;
            this.buttonRoundedGlowDeleteAllOlder.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowDeleteAllOlder_OnButtonRoundedGlowMouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 200);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewResults);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewCopies);
            this.splitContainer1.Panel2.Controls.Add(this.buttonRoundedGlowDelete);
            this.splitContainer1.Size = new System.Drawing.Size(750, 326);
            this.splitContainer1.SplitterDistance = 226;
            this.splitContainer1.TabIndex = 22;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 538);
            this.Color1 = System.Drawing.SystemColors.Control;
            this.Color2 = System.Drawing.SystemColors.ControlLightLight;
            this.ColorAngle = 90F;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonRoundedGlowDeleteAllOlder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelExtraSize);
            this.Controls.Add(this.labelDuplicatesFound);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCurrentFile);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.treeViewDirectoriesBrowserDirectories);
            this.Controls.Add(this.checkBoxByName);
            this.Controls.Add(this.checkBoxBySize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Anigno Duplicate Files Finder V1.1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowDelete;
        private System.Windows.Forms.CheckBox checkBoxBySize;
        private System.Windows.Forms.CheckBox checkBoxByName;
        private AnignoLibrary.UI.TreeViewControls.TreeViewDirectoriesBrowser treeViewDirectoriesBrowserDirectories;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowStart;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowStop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDuplicatesFound;
        private System.Windows.Forms.ListView listViewCopies;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label labelExtraSize;
        private System.Windows.Forms.Label label3;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowDeleteAllOlder;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}


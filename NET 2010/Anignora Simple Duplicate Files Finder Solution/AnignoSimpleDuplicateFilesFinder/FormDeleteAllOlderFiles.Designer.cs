namespace AnignoSimpleDuplicateFilesFinder
{
    partial class FormDeleteAllOlderFiles
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
            this.textBoxFileFolderBrowseBackupPath = new AnignoLibrary.UI.TextBoxs.TextBoxFileFolderBrowse();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRoundedGlowStart = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.buttonRoundedGlowStop = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.SuspendLayout();
            // 
            // textBoxFileFolderBrowseBackupPath
            // 
            this.textBoxFileFolderBrowseBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileFolderBrowseBackupPath.BrowseType = AnignoLibrary.UI.TextBoxs.BrowseTypeEnum.BrowseForFolder;
            this.textBoxFileFolderBrowseBackupPath.Data = "";
            this.textBoxFileFolderBrowseBackupPath.Location = new System.Drawing.Point(108, 9);
            this.textBoxFileFolderBrowseBackupPath.Name = "textBoxFileFolderBrowseBackupPath";
            this.textBoxFileFolderBrowseBackupPath.Size = new System.Drawing.Size(375, 20);
            this.textBoxFileFolderBrowseBackupPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Backup directory:";
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
            this.buttonRoundedGlowStart.Location = new System.Drawing.Point(12, 39);
            this.buttonRoundedGlowStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowStart.Name = "buttonRoundedGlowStart";
            this.buttonRoundedGlowStart.RoundedCornersRadious = 15;
            this.buttonRoundedGlowStart.Size = new System.Drawing.Size(75, 23);
            this.buttonRoundedGlowStart.TabIndex = 13;
            this.buttonRoundedGlowStart.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowStart_OnButtonRoundedGlowMouseClick);
            // 
            // listViewLog
            // 
            this.listViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewLog.GridLines = true;
            this.listViewLog.Location = new System.Drawing.Point(12, 69);
            this.listViewLog.MultiSelect = false;
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.ShowItemToolTips = true;
            this.listViewLog.Size = new System.Drawing.Size(471, 227);
            this.listViewLog.TabIndex = 14;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 162;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message";
            this.columnHeader2.Width = 299;
            // 
            // buttonRoundedGlowStop
            // 
            this.buttonRoundedGlowStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowStop.BackgroundColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStop.BackgroundColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonRoundedGlowStop.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowStop.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowStop.BorderVisible = true;
            this.buttonRoundedGlowStop.ButtonText = "Stop";
            this.buttonRoundedGlowStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonRoundedGlowStop.GlowAlpha = 200;
            this.buttonRoundedGlowStop.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStop.Location = new System.Drawing.Point(95, 39);
            this.buttonRoundedGlowStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRoundedGlowStop.Name = "buttonRoundedGlowStop";
            this.buttonRoundedGlowStop.RoundedCornersRadious = 15;
            this.buttonRoundedGlowStop.Size = new System.Drawing.Size(75, 23);
            this.buttonRoundedGlowStop.TabIndex = 15;
            this.buttonRoundedGlowStop.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowStop_OnButtonRoundedGlowMouseClick);
            // 
            // FormDeleteAllOlderFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 308);
            this.Controls.Add(this.buttonRoundedGlowStop);
            this.Controls.Add(this.listViewLog);
            this.Controls.Add(this.buttonRoundedGlowStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileFolderBrowseBackupPath);
            this.Name = "FormDeleteAllOlderFiles";
            this.Text = "Delete all older duplicates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnignoLibrary.UI.TextBoxs.TextBoxFileFolderBrowse textBoxFileFolderBrowseBackupPath;
        private System.Windows.Forms.Label label1;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowStart;
        private System.Windows.Forms.ListView listViewLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowStop;
    }
}
namespace AnignoDirectorySizeFinder
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSelectedPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentPath = new System.Windows.Forms.Label();
            this.numericUpDownMinSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.textBoxFileFolderBrowseRoot = new AnignoLibrary.UI.TextBoxs.TextBoxFileFolderBrowse();
            this.buttonRoundedGlowStop = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.buttonRoundedGlowStart = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinSize)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 457);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Root path:";
            // 
            // textBoxSelectedPath
            // 
            this.textBoxSelectedPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSelectedPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSelectedPath.Location = new System.Drawing.Point(180, 479);
            this.textBoxSelectedPath.Name = "textBoxSelectedPath";
            this.textBoxSelectedPath.Size = new System.Drawing.Size(621, 20);
            this.textBoxSelectedPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Selected path:";
            // 
            // labelCurrentPath
            // 
            this.labelCurrentPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentPath.BackColor = System.Drawing.SystemColors.Window;
            this.labelCurrentPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrentPath.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentPath.Name = "labelCurrentPath";
            this.labelCurrentPath.Size = new System.Drawing.Size(789, 16);
            this.labelCurrentPath.TabIndex = 7;
            this.labelCurrentPath.Text = "\\\\";
            // 
            // numericUpDownMinSize
            // 
            this.numericUpDownMinSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDownMinSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownMinSize.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownMinSize.Location = new System.Drawing.Point(180, 453);
            this.numericUpDownMinSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMinSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownMinSize.Name = "numericUpDownMinSize";
            this.numericUpDownMinSize.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownMinSize.TabIndex = 8;
            this.numericUpDownMinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownMinSize.ThousandsSeparator = true;
            this.numericUpDownMinSize.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numericUpDownMinSize.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Minimum size:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "MB";
            // 
            // listViewResults
            // 
            this.listViewResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.GridLines = true;
            this.listViewResults.Location = new System.Drawing.Point(12, 28);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(789, 419);
            this.listViewResults.TabIndex = 11;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.SelectedIndexChanged += new System.EventHandler(this.listViewResults_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Directory";
            this.columnHeader1.Width = 499;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Files";
            this.columnHeader2.Width = 144;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size (MB)";
            this.columnHeader3.Width = 148;
            // 
            // textBoxFileFolderBrowseRoot
            // 
            this.textBoxFileFolderBrowseRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileFolderBrowseRoot.BrowseType = AnignoLibrary.UI.TextBoxs.BrowseTypeEnum.BrowseForFolder;
            this.textBoxFileFolderBrowseRoot.Data = "";
            this.textBoxFileFolderBrowseRoot.Location = new System.Drawing.Point(342, 453);
            this.textBoxFileFolderBrowseRoot.Name = "textBoxFileFolderBrowseRoot";
            this.textBoxFileFolderBrowseRoot.Size = new System.Drawing.Size(459, 20);
            this.textBoxFileFolderBrowseRoot.TabIndex = 3;
            // 
            // buttonRoundedGlowStop
            // 
            this.buttonRoundedGlowStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRoundedGlowStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowStop.BackgroundColorFirst = System.Drawing.Color.Gray;
            this.buttonRoundedGlowStop.BackgroundColorSecond = System.Drawing.Color.Black;
            this.buttonRoundedGlowStop.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowStop.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowStop.BorderVisible = true;
            this.buttonRoundedGlowStop.ButtonText = "Stop";
            this.buttonRoundedGlowStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlowStop.GlowAlpha = 200;
            this.buttonRoundedGlowStop.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.buttonRoundedGlowStop.Location = new System.Drawing.Point(12, 479);
            this.buttonRoundedGlowStop.Name = "buttonRoundedGlowStop";
            this.buttonRoundedGlowStop.RoundedCornersRadious = 15;
            this.buttonRoundedGlowStop.Size = new System.Drawing.Size(80, 20);
            this.buttonRoundedGlowStop.TabIndex = 2;
            this.buttonRoundedGlowStop.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowStop_OnButtonRoundedGlowMouseClick);
            // 
            // buttonRoundedGlowStart
            // 
            this.buttonRoundedGlowStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRoundedGlowStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlowStart.BackgroundColorFirst = System.Drawing.Color.Gray;
            this.buttonRoundedGlowStart.BackgroundColorSecond = System.Drawing.Color.Black;
            this.buttonRoundedGlowStart.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlowStart.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlowStart.BorderVisible = true;
            this.buttonRoundedGlowStart.ButtonText = "Start";
            this.buttonRoundedGlowStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonRoundedGlowStart.GlowAlpha = 200;
            this.buttonRoundedGlowStart.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.buttonRoundedGlowStart.Location = new System.Drawing.Point(12, 453);
            this.buttonRoundedGlowStart.Name = "buttonRoundedGlowStart";
            this.buttonRoundedGlowStart.RoundedCornersRadious = 15;
            this.buttonRoundedGlowStart.Size = new System.Drawing.Size(80, 20);
            this.buttonRoundedGlowStart.TabIndex = 1;
            this.buttonRoundedGlowStart.OnButtonRoundedGlowMouseClick += new AnignoLibrary.UI.Buttons.OnButtonRoundedGlowMouseClickDelegate(this.buttonRoundedGlowStart_OnButtonRoundedGlowMouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 511);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownMinSize);
            this.Controls.Add(this.labelCurrentPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSelectedPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxFileFolderBrowseRoot);
            this.Controls.Add(this.buttonRoundedGlowStop);
            this.Controls.Add(this.buttonRoundedGlowStart);
            this.Controls.Add(this.label4);
            this.Name = "FormMain";
            this.Text = "Anigno Directory Size Filnder V1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowStart;
        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlowStop;
        private AnignoLibrary.UI.TextBoxs.TextBoxFileFolderBrowse textBoxFileFolderBrowseRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSelectedPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentPath;
        private System.Windows.Forms.NumericUpDown numericUpDownMinSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}


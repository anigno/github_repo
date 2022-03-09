namespace Say_It_2012
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listViewVoices = new System.Windows.Forms.ListView();
            this.columnHeaderVoiceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.numericUpDownRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxMonitorClipboard = new System.Windows.Forms.CheckBox();
            this.timerCheckClipboard = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewVoices
            // 
            this.listViewVoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewVoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderVoiceName});
            this.listViewVoices.HideSelection = false;
            this.listViewVoices.Location = new System.Drawing.Point(0, 12);
            this.listViewVoices.Name = "listViewVoices";
            this.listViewVoices.Size = new System.Drawing.Size(228, 110);
            this.listViewVoices.TabIndex = 0;
            this.listViewVoices.UseCompatibleStateImageBehavior = false;
            this.listViewVoices.View = System.Windows.Forms.View.Details;
            this.listViewVoices.SelectedIndexChanged += new System.EventHandler(this.listViewVoices_SelectedIndexChanged);
            // 
            // columnHeaderVoiceName
            // 
            this.columnHeaderVoiceName.Text = "Voice Name";
            this.columnHeaderVoiceName.Width = 206;
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInput.AutoWordSelection = true;
            this.richTextBoxInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInput.HideSelection = false;
            this.richTextBoxInput.Location = new System.Drawing.Point(0, 128);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.ShowSelectionMargin = true;
            this.richTextBoxInput.Size = new System.Drawing.Size(557, 230);
            this.richTextBoxInput.TabIndex = 1;
            this.richTextBoxInput.Text = "";
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonSaveToFile.Location = new System.Drawing.Point(342, 12);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(23, 23);
            this.buttonSaveToFile.TabIndex = 5;
            this.buttonSaveToFile.Text = "F";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // numericUpDownRate
            // 
            this.numericUpDownRate.Location = new System.Drawing.Point(270, 41);
            this.numericUpDownRate.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownRate.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            -2147483648});
            this.numericUpDownRate.Name = "numericUpDownRate";
            this.numericUpDownRate.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownRate.TabIndex = 6;
            this.numericUpDownRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRate.ValueChanged += new System.EventHandler(this.numericUpDownRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rate:";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Location = new System.Drawing.Point(271, 67);
            this.numericUpDownFontSize.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(43, 20);
            this.numericUpDownFontSize.TabIndex = 8;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Font:";
            // 
            // checkBoxMonitorClipboard
            // 
            this.checkBoxMonitorClipboard.AutoSize = true;
            this.checkBoxMonitorClipboard.Checked = true;
            this.checkBoxMonitorClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMonitorClipboard.Location = new System.Drawing.Point(320, 68);
            this.checkBoxMonitorClipboard.Name = "checkBoxMonitorClipboard";
            this.checkBoxMonitorClipboard.Size = new System.Drawing.Size(108, 17);
            this.checkBoxMonitorClipboard.TabIndex = 10;
            this.checkBoxMonitorClipboard.Text = "Monitor Clipboard";
            this.checkBoxMonitorClipboard.UseVisualStyleBackColor = true;
            this.checkBoxMonitorClipboard.CheckedChanged += new System.EventHandler(this.checkBoxMonitorClipboard_CheckedChanged);
            // 
            // timerCheckClipboard
            // 
            this.timerCheckClipboard.Enabled = true;
            this.timerCheckClipboard.Interval = 2000;
            this.timerCheckClipboard.Tick += new System.EventHandler(this.timerCheckClipboard_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.BackgroundImage = global::Say_It_2012.Properties.Resources.PauseDisabled;
            this.buttonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonPause.Location = new System.Drawing.Point(306, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(30, 23);
            this.buttonPause.TabIndex = 4;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackgroundImage = global::Say_It_2012.Properties.Resources.Stop1NormalBlue;
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonStop.Location = new System.Drawing.Point(270, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(30, 23);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::Say_It_2012.Properties.Resources.Play1Hot;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonPlay.Location = new System.Drawing.Point(234, 12);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(30, 23);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 358);
            this.Controls.Add(this.checkBoxMonitorClipboard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownRate);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.richTextBoxInput);
            this.Controls.Add(this.listViewVoices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Say It 2012";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewVoices;
        private System.Windows.Forms.ColumnHeader columnHeaderVoiceName;
        private System.Windows.Forms.RichTextBox richTextBoxInput;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.NumericUpDown numericUpDownRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxMonitorClipboard;
        private System.Windows.Forms.Timer timerCheckClipboard;
    }
}


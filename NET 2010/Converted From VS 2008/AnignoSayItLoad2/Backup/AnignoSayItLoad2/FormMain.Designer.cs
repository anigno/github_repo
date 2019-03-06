namespace AnignoSayItLoad2
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
            this.listBoxVoices = new System.Windows.Forms.ListBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxClipboard = new System.Windows.Forms.CheckBox();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.numericUpDownRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.timerClipboard = new System.Windows.Forms.Timer(this.components);
            this.buttonPlayToFile = new System.Windows.Forms.Button();
            this.labelTimedMessageMain = new AnignoLibrary.UI.Labels.LabelTimedMessage();
            this.buttonPause = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRate)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxVoices
            // 
            this.listBoxVoices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxVoices.FormattingEnabled = true;
            this.listBoxVoices.IntegralHeight = false;
            this.listBoxVoices.Location = new System.Drawing.Point(12, 12);
            this.listBoxVoices.Name = "listBoxVoices";
            this.listBoxVoices.Size = new System.Drawing.Size(120, 75);
            this.listBoxVoices.TabIndex = 0;
            this.listBoxVoices.SelectedIndexChanged += new System.EventHandler(this.listBoxVoices_SelectedIndexChanged);
            // 
            // buttonPlay
            // 
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Location = new System.Drawing.Point(138, 12);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(27, 23);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = ">";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(204, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(27, 23);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "[]";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxClipboard
            // 
            this.checkBoxClipboard.AutoSize = true;
            this.checkBoxClipboard.Location = new System.Drawing.Point(138, 70);
            this.checkBoxClipboard.Name = "checkBoxClipboard";
            this.checkBoxClipboard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxClipboard.Size = new System.Drawing.Size(107, 17);
            this.checkBoxClipboard.TabIndex = 3;
            this.checkBoxClipboard.Text = "Clipboard monitor";
            this.checkBoxClipboard.UseVisualStyleBackColor = true;
            this.checkBoxClipboard.CheckedChanged += new System.EventHandler(this.checkBoxClipboard_CheckedChanged);
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBoxMain.HideSelection = false;
            this.richTextBoxMain.Location = new System.Drawing.Point(12, 93);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(318, 68);
            this.richTextBoxMain.TabIndex = 4;
            this.richTextBoxMain.Text = "Say it loud 2. Text to speech application.";
            // 
            // numericUpDownRate
            // 
            this.numericUpDownRate.Location = new System.Drawing.Point(290, 67);
            this.numericUpDownRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.numericUpDownRate.Name = "numericUpDownRate";
            this.numericUpDownRate.Size = new System.Drawing.Size(39, 20);
            this.numericUpDownRate.TabIndex = 6;
            this.numericUpDownRate.ValueChanged += new System.EventHandler(this.numericUpDownRate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(251, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rate:";
            // 
            // timerClipboard
            // 
            this.timerClipboard.Interval = 1000;
            // 
            // buttonPlayToFile
            // 
            this.buttonPlayToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayToFile.Location = new System.Drawing.Point(138, 41);
            this.buttonPlayToFile.Name = "buttonPlayToFile";
            this.buttonPlayToFile.Size = new System.Drawing.Size(93, 23);
            this.buttonPlayToFile.TabIndex = 8;
            this.buttonPlayToFile.Text = "Play to file x30";
            this.buttonPlayToFile.UseVisualStyleBackColor = true;
            this.buttonPlayToFile.Click += new System.EventHandler(this.buttonPlayToFile_Click);
            // 
            // labelTimedMessageMain
            // 
            this.labelTimedMessageMain.AutoSize = true;
            this.labelTimedMessageMain.Location = new System.Drawing.Point(237, 12);
            this.labelTimedMessageMain.Name = "labelTimedMessageMain";
            this.labelTimedMessageMain.Size = new System.Drawing.Size(50, 13);
            this.labelTimedMessageMain.TabIndex = 5;
            this.labelTimedMessageMain.Text = "Message";
            this.labelTimedMessageMain.Visible = false;
            this.labelTimedMessageMain.VisibleTime = 8000;
            // 
            // buttonPause
            // 
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Location = new System.Drawing.Point(171, 12);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(27, 23);
            this.buttonPause.TabIndex = 9;
            this.buttonPause.Text = "| |";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelState.Location = new System.Drawing.Point(237, 41);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(52, 15);
            this.labelState.TabIndex = 10;
            this.labelState.Text = "Initialized";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Anigno SayItLoud2";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.Click += new System.EventHandler(this.notifyIconMain_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 173);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.numericUpDownRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxVoices);
            this.Controls.Add(this.buttonPlayToFile);
            this.Controls.Add(this.checkBoxClipboard);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.labelTimedMessageMain);
            this.Controls.Add(this.richTextBoxMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 200);
            this.Name = "FormMain";
            this.ShowInTaskbar = false;
            this.Text = "Anigno SayItLoud2";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxVoices;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxClipboard;
        private System.Windows.Forms.RichTextBox richTextBoxMain;
        private AnignoLibrary.UI.Labels.LabelTimedMessage labelTimedMessageMain;
        private System.Windows.Forms.NumericUpDown numericUpDownRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerClipboard;
        private System.Windows.Forms.Button buttonPlayToFile;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
    }
}


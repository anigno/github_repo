namespace AnignoSayItLoud
{
    partial class formConsole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConsole));
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxEngines = new System.Windows.Forms.ListBox();
            this.buttonSpeak = new System.Windows.Forms.Button();
            this.rtfTextToSpeak = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.progressBarVolume = new System.Windows.Forms.ProgressBar();
            this.trackBarRate = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxClipboardCapture = new System.Windows.Forms.CheckBox();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.timerClipboardMonitor = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installed speech engines:";
            // 
            // listBoxEngines
            // 
            this.listBoxEngines.FormattingEnabled = true;
            this.listBoxEngines.HorizontalScrollbar = true;
            this.listBoxEngines.Location = new System.Drawing.Point(12, 25);
            this.listBoxEngines.Name = "listBoxEngines";
            this.listBoxEngines.Size = new System.Drawing.Size(325, 95);
            this.listBoxEngines.TabIndex = 1;
            this.listBoxEngines.SelectedIndexChanged += new System.EventHandler(this.listBoxEngines_SelectedIndexChanged);
            // 
            // buttonSpeak
            // 
            this.buttonSpeak.Location = new System.Drawing.Point(343, 25);
            this.buttonSpeak.Name = "buttonSpeak";
            this.buttonSpeak.Size = new System.Drawing.Size(75, 23);
            this.buttonSpeak.TabIndex = 2;
            this.buttonSpeak.Text = "Speak";
            this.buttonSpeak.UseVisualStyleBackColor = true;
            this.buttonSpeak.Click += new System.EventHandler(this.buttonSpeak_Click);
            // 
            // rtfTextToSpeak
            // 
            this.rtfTextToSpeak.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfTextToSpeak.Location = new System.Drawing.Point(12, 139);
            this.rtfTextToSpeak.Name = "rtfTextToSpeak";
            this.rtfTextToSpeak.Size = new System.Drawing.Size(601, 353);
            this.rtfTextToSpeak.TabIndex = 3;
            this.rtfTextToSpeak.Text = "Say it loud text to speech application.\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Text to speak:";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(343, 83);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 5;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // progressBarVolume
            // 
            this.progressBarVolume.Location = new System.Drawing.Point(427, 25);
            this.progressBarVolume.MarqueeAnimationSpeed = 10;
            this.progressBarVolume.Name = "progressBarVolume";
            this.progressBarVolume.Size = new System.Drawing.Size(140, 19);
            this.progressBarVolume.Step = 1;
            this.progressBarVolume.TabIndex = 7;
            // 
            // trackBarRate
            // 
            this.trackBarRate.AutoSize = false;
            this.trackBarRate.Location = new System.Drawing.Point(463, 50);
            this.trackBarRate.Minimum = -10;
            this.trackBarRate.Name = "trackBarRate";
            this.trackBarRate.Size = new System.Drawing.Size(104, 27);
            this.trackBarRate.SmallChange = 2;
            this.trackBarRate.TabIndex = 8;
            this.trackBarRate.TickFrequency = 2;
            this.trackBarRate.Scroll += new System.EventHandler(this.trackBarRate_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rate:";
            // 
            // checkBoxClipboardCapture
            // 
            this.checkBoxClipboardCapture.AutoSize = true;
            this.checkBoxClipboardCapture.Location = new System.Drawing.Point(427, 83);
            this.checkBoxClipboardCapture.Name = "checkBoxClipboardCapture";
            this.checkBoxClipboardCapture.Size = new System.Drawing.Size(109, 17);
            this.checkBoxClipboardCapture.TabIndex = 10;
            this.checkBoxClipboardCapture.Text = "Clipboard capture";
            this.checkBoxClipboardCapture.UseVisualStyleBackColor = true;
            this.checkBoxClipboardCapture.CheckedChanged += new System.EventHandler(this.checkBoxClipboardCapture_CheckedChanged);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(343, 54);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToFile.TabIndex = 11;
            this.buttonSaveToFile.Text = "Save to file";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // timerClipboardMonitor
            // 
            this.timerClipboardMonitor.Interval = 1000;
            this.timerClipboardMonitor.Tick += new System.EventHandler(this.timerClipboardMonitor_Tick);
            // 
            // formConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 504);
            this.Controls.Add(this.buttonSaveToFile);
            this.Controls.Add(this.checkBoxClipboardCapture);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarRate);
            this.Controls.Add(this.progressBarVolume);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtfTextToSpeak);
            this.Controls.Add(this.buttonSpeak);
            this.Controls.Add(this.listBoxEngines);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formConsole";
            this.Text = "Say it loud";
            this.Load += new System.EventHandler(this.formConsole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxEngines;
        private System.Windows.Forms.Button buttonSpeak;
        private System.Windows.Forms.RichTextBox rtfTextToSpeak;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ProgressBar progressBarVolume;
        private System.Windows.Forms.TrackBar trackBarRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxClipboardCapture;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.Timer timerClipboardMonitor;
    }
}


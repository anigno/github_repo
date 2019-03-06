namespace SoundsManager
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
            SoundsManager.TimeInterval timeInterval1 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval2 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval3 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval4 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval5 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval6 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval7 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval8 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval9 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval10 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval11 = new SoundsManager.TimeInterval();
            SoundsManager.TimeInterval timeInterval12 = new SoundsManager.TimeInterval();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.radioButtonPlaying = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxSounds = new System.Windows.Forms.CheckedListBox();
            this.mp3PlayerMciControlMain = new AnignoraMultimedia.Mp3Playing.Mp3Players.Mp3PlayerMciControl();
            this.buttonIntervalNone = new System.Windows.Forms.Button();
            this.buttonIntervalAll = new System.Windows.Forms.Button();
            this.buttonSoundsAll = new System.Windows.Forms.Button();
            this.buttonSoundsNone = new System.Windows.Forms.Button();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.comboBoxSilence = new System.Windows.Forms.ComboBox();
            this.labelDateTimeNowMain = new SoundsManager.LabelDateTimeNow();
            this.checkedListBoxInterval = new SoundsManager.CheckedListBoxInterval();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonPlaying
            // 
            this.radioButtonPlaying.AutoSize = true;
            this.radioButtonPlaying.Enabled = false;
            this.radioButtonPlaying.Location = new System.Drawing.Point(147, 5);
            this.radioButtonPlaying.Name = "radioButtonPlaying";
            this.radioButtonPlaying.Size = new System.Drawing.Size(93, 17);
            this.radioButtonPlaying.TabIndex = 2;
            this.radioButtonPlaying.TabStop = true;
            this.radioButtonPlaying.Text = "Within Interval";
            this.radioButtonPlaying.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time Intervals:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sounds:";
            // 
            // checkedListBoxSounds
            // 
            this.checkedListBoxSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxSounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxSounds.CheckOnClick = true;
            this.checkedListBoxSounds.FormattingEnabled = true;
            this.checkedListBoxSounds.IntegralHeight = false;
            this.checkedListBoxSounds.Location = new System.Drawing.Point(144, 68);
            this.checkedListBoxSounds.Name = "checkedListBoxSounds";
            this.checkedListBoxSounds.Size = new System.Drawing.Size(456, 209);
            this.checkedListBoxSounds.TabIndex = 5;
            // 
            // mp3PlayerMciControlMain
            // 
            this.mp3PlayerMciControlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mp3PlayerMciControlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mp3PlayerMciControlMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.mp3PlayerMciControlMain.Location = new System.Drawing.Point(290, 5);
            this.mp3PlayerMciControlMain.Name = "mp3PlayerMciControlMain";
            this.mp3PlayerMciControlMain.Size = new System.Drawing.Size(181, 57);
            this.mp3PlayerMciControlMain.SongFileName = "";
            this.mp3PlayerMciControlMain.TabIndex = 6;
            // 
            // buttonIntervalNone
            // 
            this.buttonIntervalNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonIntervalNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIntervalNone.Location = new System.Drawing.Point(65, 278);
            this.buttonIntervalNone.Name = "buttonIntervalNone";
            this.buttonIntervalNone.Size = new System.Drawing.Size(47, 23);
            this.buttonIntervalNone.TabIndex = 7;
            this.buttonIntervalNone.Text = "None";
            this.buttonIntervalNone.UseVisualStyleBackColor = true;
            this.buttonIntervalNone.Click += new System.EventHandler(this.buttonIntervalNoneClick);
            // 
            // buttonIntervalAll
            // 
            this.buttonIntervalAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonIntervalAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIntervalAll.Location = new System.Drawing.Point(12, 278);
            this.buttonIntervalAll.Name = "buttonIntervalAll";
            this.buttonIntervalAll.Size = new System.Drawing.Size(47, 23);
            this.buttonIntervalAll.TabIndex = 8;
            this.buttonIntervalAll.Text = "All";
            this.buttonIntervalAll.UseVisualStyleBackColor = true;
            this.buttonIntervalAll.Click += new System.EventHandler(this.buttonIntervalAllClick);
            // 
            // buttonSoundsAll
            // 
            this.buttonSoundsAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSoundsAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSoundsAll.Location = new System.Drawing.Point(144, 278);
            this.buttonSoundsAll.Name = "buttonSoundsAll";
            this.buttonSoundsAll.Size = new System.Drawing.Size(47, 23);
            this.buttonSoundsAll.TabIndex = 10;
            this.buttonSoundsAll.Text = "All";
            this.buttonSoundsAll.UseVisualStyleBackColor = true;
            this.buttonSoundsAll.Click += new System.EventHandler(this.buttonSoundsAllClick);
            // 
            // buttonSoundsNone
            // 
            this.buttonSoundsNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSoundsNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSoundsNone.Location = new System.Drawing.Point(197, 278);
            this.buttonSoundsNone.Name = "buttonSoundsNone";
            this.buttonSoundsNone.Size = new System.Drawing.Size(47, 23);
            this.buttonSoundsNone.TabIndex = 9;
            this.buttonSoundsNone.Text = "None";
            this.buttonSoundsNone.UseVisualStyleBackColor = true;
            this.buttonSoundsNone.Click += new System.EventHandler(this.buttonSoundsNoneClick);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxActive.Location = new System.Drawing.Point(477, 5);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(80, 28);
            this.checkBoxActive.TabIndex = 11;
            this.checkBoxActive.Text = "Active";
            this.checkBoxActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.LargeChange = 100;
            this.trackBarVolume.Location = new System.Drawing.Point(563, 9);
            this.trackBarVolume.Maximum = 1000;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(34, 53);
            this.trackBarVolume.SmallChange = 100;
            this.trackBarVolume.TabIndex = 12;
            this.trackBarVolume.TickFrequency = 250;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarVolume.Value = 1000;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolumeScroll);
            // 
            // comboBoxSilence
            // 
            this.comboBoxSilence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSilence.FormattingEnabled = true;
            this.comboBoxSilence.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "15",
            "20",
            "30",
            "60"});
            this.comboBoxSilence.Location = new System.Drawing.Point(514, 41);
            this.comboBoxSilence.Name = "comboBoxSilence";
            this.comboBoxSilence.Size = new System.Drawing.Size(43, 21);
            this.comboBoxSilence.TabIndex = 13;
            // 
            // labelDateTimeNowMain
            // 
            this.labelDateTimeNowMain.AutoSize = true;
            this.labelDateTimeNowMain.DateTimeFormat = null;
            this.labelDateTimeNowMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDateTimeNowMain.Location = new System.Drawing.Point(144, 25);
            this.labelDateTimeNowMain.Name = "labelDateTimeNowMain";
            this.labelDateTimeNowMain.Size = new System.Drawing.Size(140, 17);
            this.labelDateTimeNowMain.TabIndex = 1;
            this.labelDateTimeNowMain.Text = "18/12/2010 19:04:02";
            this.labelDateTimeNowMain.Tick += new System.Action<SoundsManager.LabelDateTimeNow, System.DateTime>(this.onLabelDateTimeNowMainTick);
            // 
            // checkedListBoxInterval
            // 
            this.checkedListBoxInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxInterval.CheckOnClick = true;
            this.checkedListBoxInterval.DateTimeFormat = "HH:mm";
            this.checkedListBoxInterval.FormattingEnabled = true;
            this.checkedListBoxInterval.IntegralHeight = false;
            this.checkedListBoxInterval.Interval = System.TimeSpan.Parse("02:00:00");
            this.checkedListBoxInterval.Items.AddRange(new object[] {
            timeInterval1,
            timeInterval2,
            timeInterval3,
            timeInterval4,
            timeInterval5,
            timeInterval6,
            timeInterval7,
            timeInterval8,
            timeInterval9,
            timeInterval10,
            timeInterval11,
            timeInterval12});
            this.checkedListBoxInterval.Location = new System.Drawing.Point(12, 25);
            this.checkedListBoxInterval.Name = "checkedListBoxInterval";
            this.checkedListBoxInterval.Size = new System.Drawing.Size(126, 252);
            this.checkedListBoxInterval.TabIndex = 0;
            this.checkedListBoxInterval.TimeMax = new System.DateTime(2010, 12, 1, 23, 0, 0, 0);
            this.checkedListBoxInterval.TimeMinimum = new System.DateTime(2010, 12, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "SLN:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 313);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSilence);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.checkBoxActive);
            this.Controls.Add(this.buttonSoundsAll);
            this.Controls.Add(this.buttonSoundsNone);
            this.Controls.Add(this.buttonIntervalAll);
            this.Controls.Add(this.buttonIntervalNone);
            this.Controls.Add(this.mp3PlayerMciControlMain);
            this.Controls.Add(this.checkedListBoxSounds);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonPlaying);
            this.Controls.Add(this.labelDateTimeNowMain);
            this.Controls.Add(this.checkedListBoxInterval);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(620, 340);
            this.Name = "FormMain";
            this.Text = "Sounds Manager";
            this.Load += new System.EventHandler(this.formMainLoad);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckedListBoxInterval checkedListBoxInterval;
        private LabelDateTimeNow labelDateTimeNowMain;
        private System.Windows.Forms.RadioButton radioButtonPlaying;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxSounds;
        private AnignoraMultimedia.Mp3Playing.Mp3Players.Mp3PlayerMciControl mp3PlayerMciControlMain;
        private System.Windows.Forms.Button buttonIntervalNone;
        private System.Windows.Forms.Button buttonIntervalAll;
        private System.Windows.Forms.Button buttonSoundsAll;
        private System.Windows.Forms.Button buttonSoundsNone;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ComboBox comboBoxSilence;
        private System.Windows.Forms.Label label3;

    }
}


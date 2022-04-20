namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControl
{
    partial class irrKlangMp3Player_old
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
            this.labelTime = new System.Windows.Forms.Label();
            this.labelSongName = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.progressBarPosition = new System.Windows.Forms.ProgressBar();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTime.Location = new System.Drawing.Point(39, 45);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 13);
            this.labelTime.TabIndex = 35;
            this.labelTime.Text = "0:00 / 0:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSongName
            // 
            this.labelSongName.AutoSize = true;
            this.labelSongName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSongName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelSongName.Location = new System.Drawing.Point(3, 0);
            this.labelSongName.Name = "labelSongName";
            this.labelSongName.Size = new System.Drawing.Size(47, 13);
            this.labelSongName.TabIndex = 34;
            this.labelSongName.Text = "No song";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Enabled = false;
            this.trackBarVolume.Location = new System.Drawing.Point(343, 0);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(34, 70);
            this.trackBarVolume.SmallChange = 5;
            this.trackBarVolume.TabIndex = 33;
            this.trackBarVolume.TabStop = false;
            this.trackBarVolume.TickFrequency = 20;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.ValueChanged += new System.EventHandler(this.trackBarVolume_ValueChanged);
            // 
            // progressBarPosition
            // 
            this.progressBarPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarPosition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.progressBarPosition.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.progressBarPosition.Location = new System.Drawing.Point(0, 16);
            this.progressBarPosition.Name = "progressBarPosition";
            this.progressBarPosition.Size = new System.Drawing.Size(337, 14);
            this.progressBarPosition.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarPosition.TabIndex = 31;
            this.progressBarPosition.Value = 60;
            this.progressBarPosition.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBarPosition_MouseClick);
            // 
            // buttonForward
            // 
            this.buttonForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForward.BackColor = System.Drawing.Color.Transparent;
            this.buttonForward.BackgroundImage = global::AnignoLibrary.Properties.Resources.forward;
            this.buttonForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForward.FlatAppearance.BorderSize = 0;
            this.buttonForward.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonForward.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForward.Location = new System.Drawing.Point(307, 36);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(30, 30);
            this.buttonForward.TabIndex = 30;
            this.buttonForward.TabStop = false;
            this.buttonForward.UseVisualStyleBackColor = false;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.BackgroundImage = global::AnignoLibrary.Properties.Resources.play_256x256;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPlay.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Location = new System.Drawing.Point(235, 36);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(30, 30);
            this.buttonPlay.TabIndex = 29;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 250;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // buttonPause
            // 
            this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPause.BackColor = System.Drawing.Color.Transparent;
            this.buttonPause.BackgroundImage = global::AnignoLibrary.Properties.Resources.pause;
            this.buttonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPause.FlatAppearance.BorderSize = 0;
            this.buttonPause.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonPause.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Location = new System.Drawing.Point(199, 36);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(30, 30);
            this.buttonPause.TabIndex = 28;
            this.buttonPause.TabStop = false;
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonRewind
            // 
            this.buttonRewind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRewind.BackColor = System.Drawing.Color.Transparent;
            this.buttonRewind.BackgroundImage = global::AnignoLibrary.Properties.Resources.rewind;
            this.buttonRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRewind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRewind.FlatAppearance.BorderSize = 0;
            this.buttonRewind.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonRewind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonRewind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRewind.Location = new System.Drawing.Point(271, 36);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(30, 30);
            this.buttonRewind.TabIndex = 27;
            this.buttonRewind.TabStop = false;
            this.buttonRewind.UseVisualStyleBackColor = false;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonStop.BackgroundImage = global::AnignoLibrary.Properties.Resources.stop;
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(3, 36);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(30, 30);
            this.buttonStop.TabIndex = 26;
            this.buttonStop.TabStop = false;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // irrKlangMp3Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelSongName);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.progressBarPosition);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonRewind);
            this.Controls.Add(this.buttonStop);
            this.Name = "irrKlangMp3Player";
            this.Size = new System.Drawing.Size(383, 74);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelSongName;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.ProgressBar progressBarPosition;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Button buttonStop;
    }
}

namespace AnignoLibrary.UI.Multimedia.Mp3Players.irrKlangMp3PlayerControls
{
    partial class AnignoIrrKlangMp3PlayerControl
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
            this.labelTime = new System.Windows.Forms.Label();
            this.labelSongName = new System.Windows.Forms.Label();
            this.trackBarVolumeMax = new System.Windows.Forms.TrackBar();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.progressBarPosition = new AnignoLibrary.UI.ProgressBars.AnignoProgressBarFlat();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeMax)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelTime.Location = new System.Drawing.Point(43, 57);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 13);
            this.labelTime.TabIndex = 44;
            this.labelTime.Text = "0:00 / 0:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSongName
            // 
            this.labelSongName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSongName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelSongName.Location = new System.Drawing.Point(3, 0);
            this.labelSongName.Name = "labelSongName";
            this.labelSongName.Size = new System.Drawing.Size(343, 20);
            this.labelSongName.TabIndex = 43;
            this.labelSongName.Text = "No song";
            // 
            // trackBarVolumeMax
            // 
            this.trackBarVolumeMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolumeMax.Location = new System.Drawing.Point(352, 3);
            this.trackBarVolumeMax.Maximum = 100;
            this.trackBarVolumeMax.Name = "trackBarVolumeMax";
            this.trackBarVolumeMax.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolumeMax.Size = new System.Drawing.Size(34, 75);
            this.trackBarVolumeMax.SmallChange = 5;
            this.trackBarVolumeMax.TabIndex = 42;
            this.trackBarVolumeMax.TabStop = false;
            this.trackBarVolumeMax.TickFrequency = 20;
            this.trackBarVolumeMax.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarVolumeMax.Value = 100;
            this.trackBarVolumeMax.Scroll += new System.EventHandler(this.trackBarVolumeMax_Scroll);
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
            this.buttonForward.Location = new System.Drawing.Point(316, 48);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(30, 30);
            this.buttonForward.TabIndex = 40;
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
            this.buttonPlay.Location = new System.Drawing.Point(244, 48);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(30, 30);
            this.buttonPlay.TabIndex = 39;
            this.buttonPlay.TabStop = false;
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
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
            this.buttonPause.Location = new System.Drawing.Point(208, 48);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(30, 30);
            this.buttonPause.TabIndex = 38;
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
            this.buttonRewind.Location = new System.Drawing.Point(280, 48);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(30, 30);
            this.buttonRewind.TabIndex = 37;
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
            this.buttonStop.Location = new System.Drawing.Point(7, 48);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(30, 30);
            this.buttonStop.TabIndex = 36;
            this.buttonStop.TabStop = false;
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // progressBarPosition
            // 
            this.progressBarPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarPosition.BackColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBarPosition.BackColorSecond = System.Drawing.Color.Silver;
            this.progressBarPosition.ColorMainFirst = System.Drawing.Color.LightSteelBlue;
            this.progressBarPosition.ColorMainGradientAngle = 0F;
            this.progressBarPosition.ColorMainSecond = System.Drawing.Color.SteelBlue;
            this.progressBarPosition.ColorMaximumRange = System.Drawing.Color.Red;
            this.progressBarPosition.ColorMinimumRange = System.Drawing.Color.LightSteelBlue;
            this.progressBarPosition.DrawBorder = false;
            this.progressBarPosition.GradientAngle = 0F;
            this.progressBarPosition.Location = new System.Drawing.Point(3, 23);
            this.progressBarPosition.Maximum = 180F;
            this.progressBarPosition.MaximumRange = 170F;
            this.progressBarPosition.Minimum = 0F;
            this.progressBarPosition.MinimumRange = 10F;
            this.progressBarPosition.Name = "progressBarPosition";
            this.progressBarPosition.ProgressBarOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.progressBarPosition.ProgressBarText = "0:00";
            this.progressBarPosition.ProgressBarTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.progressBarPosition.Size = new System.Drawing.Size(343, 19);
            this.progressBarPosition.TabIndex = 45;
            this.progressBarPosition.Text = "0:00";
            this.progressBarPosition.Value = 180F;
            this.progressBarPosition.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBarPosition_MouseClick);
            // 
            // AnignoIrrKlangMp3PlayerControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.progressBarPosition);
            this.Controls.Add(this.trackBarVolumeMax);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelSongName);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonRewind);
            this.Controls.Add(this.buttonStop);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Name = "AnignoIrrKlangMp3PlayerControl";
            this.Size = new System.Drawing.Size(389, 86);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolumeMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelSongName;
        private System.Windows.Forms.TrackBar trackBarVolumeMax;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Button buttonStop;
        private AnignoLibrary.UI.ProgressBars.AnignoProgressBarFlat progressBarPosition;
    }
}
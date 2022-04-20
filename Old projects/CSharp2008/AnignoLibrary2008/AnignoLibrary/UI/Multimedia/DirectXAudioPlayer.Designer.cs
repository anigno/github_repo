namespace AnignoLibrary.UI.Multimedia
{
    partial class DirectXAudioPlayer
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
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.trackBarBallance = new System.Windows.Forms.TrackBar();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.labelSongFile = new System.Windows.Forms.Label();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonRewind = new System.Windows.Forms.Button();
            this.labelDuretion = new System.Windows.Forms.Label();
            this.timerDuretion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBallance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.LargeChange = 10;
            this.trackBarVolume.Location = new System.Drawing.Point(3, 56);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarVolume.Size = new System.Drawing.Size(34, 40);
            this.trackBarVolume.TabIndex = 0;
            this.trackBarVolume.TabStop = false;
            this.trackBarVolume.TickFrequency = 50;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // trackBarBallance
            // 
            this.trackBarBallance.Location = new System.Drawing.Point(43, 56);
            this.trackBarBallance.Minimum = -10;
            this.trackBarBallance.Name = "trackBarBallance";
            this.trackBarBallance.Size = new System.Drawing.Size(80, 34);
            this.trackBarBallance.SmallChange = 2;
            this.trackBarBallance.TabIndex = 1;
            this.trackBarBallance.TabStop = false;
            this.trackBarBallance.TickFrequency = 5;
            this.trackBarBallance.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarBallance.Scroll += new System.EventHandler(this.trackBarBallance_Scroll);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPosition.Location = new System.Drawing.Point(-1, 16);
            this.trackBarPosition.Maximum = 300;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(355, 34);
            this.trackBarPosition.TabIndex = 2;
            this.trackBarPosition.TickFrequency = 60;
            this.trackBarPosition.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarPosition.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);
            // 
            // labelSongFile
            // 
            this.labelSongFile.AutoSize = true;
            this.labelSongFile.Location = new System.Drawing.Point(81, -1);
            this.labelSongFile.Name = "labelSongFile";
            this.labelSongFile.Size = new System.Drawing.Size(49, 13);
            this.labelSongFile.TabIndex = 3;
            this.labelSongFile.Text = "No Song";
            // 
            // buttonForward
            // 
            this.buttonForward.BackgroundImage = global::AnignoLibrary.Properties.Resources.forward;
            this.buttonForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonForward.FlatAppearance.BorderSize = 0;
            this.buttonForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForward.Location = new System.Drawing.Point(299, 56);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(34, 34);
            this.buttonForward.TabIndex = 8;
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackgroundImage = global::AnignoLibrary.Properties.Resources.stop;
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(129, 56);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(34, 34);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.BackgroundImage = global::AnignoLibrary.Properties.Resources.pause;
            this.buttonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPause.FlatAppearance.BorderSize = 0;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Location = new System.Drawing.Point(169, 56);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(34, 34);
            this.buttonPause.TabIndex = 6;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::AnignoLibrary.Properties.Resources.play_256x256;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.FlatAppearance.BorderSize = 0;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Location = new System.Drawing.Point(249, 56);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(44, 34);
            this.buttonPlay.TabIndex = 5;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonRewind
            // 
            this.buttonRewind.BackgroundImage = global::AnignoLibrary.Properties.Resources.rewind;
            this.buttonRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRewind.FlatAppearance.BorderSize = 0;
            this.buttonRewind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRewind.Location = new System.Drawing.Point(209, 56);
            this.buttonRewind.Name = "buttonRewind";
            this.buttonRewind.Size = new System.Drawing.Size(34, 34);
            this.buttonRewind.TabIndex = 4;
            this.buttonRewind.UseVisualStyleBackColor = true;
            this.buttonRewind.Click += new System.EventHandler(this.buttonRewind_Click);
            // 
            // labelDuretion
            // 
            this.labelDuretion.AutoSize = true;
            this.labelDuretion.Location = new System.Drawing.Point(3, 0);
            this.labelDuretion.Name = "labelDuretion";
            this.labelDuretion.Size = new System.Drawing.Size(72, 13);
            this.labelDuretion.TabIndex = 9;
            this.labelDuretion.Text = "00:00 / 00:00";
            // 
            // timerDuretion
            // 
            this.timerDuretion.Enabled = true;
            this.timerDuretion.Interval = 250;
            this.timerDuretion.Tick += new System.EventHandler(this.timerDuretion_Tick);
            // 
            // DirectXAudioPlayer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelDuretion);
            this.Controls.Add(this.buttonForward);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonRewind);
            this.Controls.Add(this.labelSongFile);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.trackBarBallance);
            this.Controls.Add(this.trackBarVolume);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Name = "DirectXAudioPlayer";
            this.Size = new System.Drawing.Size(353, 97);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirectXAudioPlayer_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DirectXAudioPlayer_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBallance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.TrackBar trackBarBallance;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Label labelSongFile;
        private System.Windows.Forms.Button buttonRewind;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Label labelDuretion;
        private System.Windows.Forms.Timer timerDuretion;
    }
}

namespace AnignoHardDriveStatus
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
            this.timerSampler = new System.Windows.Forms.Timer(this.components);
            this.comboBoxDrives = new System.Windows.Forms.ComboBox();
            this.anignoRoundGaugeDrive = new AnignoLibrary.UI.Gauges.AnignoGauges.AnignoRoundGauge();
            this.SuspendLayout();
            // 
            // timerSampler
            // 
            this.timerSampler.Enabled = true;
            this.timerSampler.Interval = 10000;
            // 
            // comboBoxDrives
            // 
            this.comboBoxDrives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxDrives.FormattingEnabled = true;
            this.comboBoxDrives.Location = new System.Drawing.Point(12, 12);
            this.comboBoxDrives.Name = "comboBoxDrives";
            this.comboBoxDrives.Size = new System.Drawing.Size(209, 21);
            this.comboBoxDrives.TabIndex = 2;
            this.comboBoxDrives.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrives_SelectedIndexChanged);
            // 
            // anignoRoundGaugeDrive
            // 
            this.anignoRoundGaugeDrive.Dial_CastToInteger = true;
            this.anignoRoundGaugeDrive.Dial_Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.anignoRoundGaugeDrive.Dial_DrawNumbers = true;
            this.anignoRoundGaugeDrive.Dial_Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.anignoRoundGaugeDrive.Dial_NumberOfTicks = 10;
            this.anignoRoundGaugeDrive.Dial_Radious = 70F;
            this.anignoRoundGaugeDrive.Dial_TextRadious = 75F;
            this.anignoRoundGaugeDrive.Dial_Thickness = 5F;
            this.anignoRoundGaugeDrive.Dial_TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.anignoRoundGaugeDrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.anignoRoundGaugeDrive.Location = new System.Drawing.Point(39, 51);
            this.anignoRoundGaugeDrive.Maximum = 100F;
            this.anignoRoundGaugeDrive.MaximumAngle = 390F;
            this.anignoRoundGaugeDrive.Minimum = 0F;
            this.anignoRoundGaugeDrive.MinimumAngle = 150F;
            this.anignoRoundGaugeDrive.Name = "anignoRoundGaugeDrive";
            this.anignoRoundGaugeDrive.Needle_BackgroundColorFirst = System.Drawing.Color.Black;
            this.anignoRoundGaugeDrive.Needle_BackgroundColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.anignoRoundGaugeDrive.Needle_BorderColor = System.Drawing.Color.DarkGray;
            this.anignoRoundGaugeDrive.Needle_BorderDraw = true;
            this.anignoRoundGaugeDrive.Needle_CenterCircleDraw = true;
            this.anignoRoundGaugeDrive.Needle_CenterCircleRadious = 7F;
            this.anignoRoundGaugeDrive.Needle_HeadLength = 65F;
            this.anignoRoundGaugeDrive.Needle_TailLength = 20F;
            this.anignoRoundGaugeDrive.Needle_Width = 20F;
            this.anignoRoundGaugeDrive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.anignoRoundGaugeDrive.Size = new System.Drawing.Size(162, 162);
            this.anignoRoundGaugeDrive.TabIndex = 1;
            this.anignoRoundGaugeDrive.Text = "DriveName";
            this.anignoRoundGaugeDrive.TextPositionFromCenterX = 0F;
            this.anignoRoundGaugeDrive.TextPositionFromCenterY = 30F;
            this.anignoRoundGaugeDrive.Value = 0F;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(240, 242);
            this.Controls.Add(this.comboBoxDrives);
            this.Controls.Add(this.anignoRoundGaugeDrive);
            this.ForeColor = System.Drawing.Color.Yellow;
            this.Name = "FormMain";
            this.Text = "HardDrive free space";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibrary.UI.Gauges.AnignoGauges.AnignoRoundGauge anignoRoundGaugeDrive;
        private System.Windows.Forms.Timer timerSampler;
        private System.Windows.Forms.ComboBox comboBoxDrives;
    }
}


namespace MainTester
{
    partial class Form1
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
            this.buttonRoundedGlow1 = new AnignoLibrary.UI.Buttons.ButtonRoundedGlow();
            this.glassButton1 = new AnignoLibrary.UI.Buttons.GlassButtons.GlassButton();
            this.progressBarHistoryControl1 = new AnignoLibrary.UI.ProgressBars.ProgressBarHistoryControl();
            this.vistaButton1 = new AnignoLibrary.UI.Buttons.VistaButtons.VistaButton();
            this.SuspendLayout();
            // 
            // buttonRoundedGlow1
            // 
            this.buttonRoundedGlow1.BackColor = System.Drawing.Color.Transparent;
            this.buttonRoundedGlow1.BackgroundColorFirst = System.Drawing.Color.Gray;
            this.buttonRoundedGlow1.BackgroundColorSecond = System.Drawing.Color.Black;
            this.buttonRoundedGlow1.BackgroundGradientAngle = 90F;
            this.buttonRoundedGlow1.BorderColor = System.Drawing.Color.Black;
            this.buttonRoundedGlow1.BorderVisible = true;
            this.buttonRoundedGlow1.ButtonText = "fhdfhfd";
            this.buttonRoundedGlow1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonRoundedGlow1.GlowAlpha = 200;
            this.buttonRoundedGlow1.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.buttonRoundedGlow1.Location = new System.Drawing.Point(106, 253);
            this.buttonRoundedGlow1.Name = "buttonRoundedGlow1";
            this.buttonRoundedGlow1.RoundedCornersRadious = 15;
            this.buttonRoundedGlow1.Size = new System.Drawing.Size(167, 66);
            this.buttonRoundedGlow1.TabIndex = 9;
            // 
            // glassButton1
            // 
            this.glassButton1.Location = new System.Drawing.Point(398, 279);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(172, 77);
            this.glassButton1.TabIndex = 16;
            this.glassButton1.Text = "glassButton1";
            // 
            // progressBarHistoryControl1
            // 
            this.progressBarHistoryControl1.BarOrientation = System.Windows.Forms.Orientation.Horizontal;
            this.progressBarHistoryControl1.Graphcolor = System.Drawing.Color.White;
            this.progressBarHistoryControl1.Location = new System.Drawing.Point(83, 351);
            this.progressBarHistoryControl1.MaxNumberOfPoints = 30;
            this.progressBarHistoryControl1.MaxValue = 100F;
            this.progressBarHistoryControl1.MinValue = -100F;
            this.progressBarHistoryControl1.Name = "progressBarHistoryControl1";
            this.progressBarHistoryControl1.Size = new System.Drawing.Size(190, 90);
            this.progressBarHistoryControl1.TabIndex = 1;
            this.progressBarHistoryControl1.Text = "progressBarHistoryControl1";
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonText = "jjfgjf";
            this.vistaButton1.Location = new System.Drawing.Point(403, 430);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(100, 32);
            this.vistaButton1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 586);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.progressBarHistoryControl1);
            this.Controls.Add(this.glassButton1);
            this.Controls.Add(this.buttonRoundedGlow1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibrary.UI.Buttons.ButtonRoundedGlow buttonRoundedGlow1;
        private AnignoLibrary.UI.Buttons.GlassButtons.GlassButton glassButton1;
        private AnignoLibrary.UI.ProgressBars.ProgressBarHistoryControl progressBarHistoryControl1;
        private AnignoLibrary.UI.Buttons.VistaButtons.VistaButton vistaButton1;




    }
}
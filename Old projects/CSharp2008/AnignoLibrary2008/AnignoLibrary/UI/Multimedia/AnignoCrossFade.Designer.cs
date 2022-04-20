namespace AnignoLibrary.UI.Multimedia
{
    partial class AnignoCrossFade
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
            this.trackBarSlider = new System.Windows.Forms.TrackBar();
            this.buttonFullLeft = new System.Windows.Forms.Button();
            this.buttonCenter = new System.Windows.Forms.Button();
            this.buttonFullRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarSlider
            // 
            this.trackBarSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.trackBarSlider.LargeChange = 1;
            this.trackBarSlider.Location = new System.Drawing.Point(-1, -1);
            this.trackBarSlider.Maximum = 100;
            this.trackBarSlider.Name = "trackBarSlider";
            this.trackBarSlider.Size = new System.Drawing.Size(122, 34);
            this.trackBarSlider.TabIndex = 0;
            this.trackBarSlider.TickFrequency = 25;
            this.trackBarSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarSlider.Value = 50;
            this.trackBarSlider.ValueChanged += new System.EventHandler(this.trackBarSlider_ValueChanged);
            // 
            // buttonFullLeft
            // 
            this.buttonFullLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFullLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullLeft.ForeColor = System.Drawing.Color.Silver;
            this.buttonFullLeft.Location = new System.Drawing.Point(3, 37);
            this.buttonFullLeft.Name = "buttonFullLeft";
            this.buttonFullLeft.Size = new System.Drawing.Size(30, 24);
            this.buttonFullLeft.TabIndex = 1;
            this.buttonFullLeft.Text = "<";
            this.buttonFullLeft.UseVisualStyleBackColor = true;
            this.buttonFullLeft.Click += new System.EventHandler(this.buttonFullLeft_Click);
            // 
            // buttonCenter
            // 
            this.buttonCenter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCenter.ForeColor = System.Drawing.Color.Silver;
            this.buttonCenter.Location = new System.Drawing.Point(45, 37);
            this.buttonCenter.Name = "buttonCenter";
            this.buttonCenter.Size = new System.Drawing.Size(30, 24);
            this.buttonCenter.TabIndex = 3;
            this.buttonCenter.Text = "0";
            this.buttonCenter.UseVisualStyleBackColor = true;
            this.buttonCenter.Click += new System.EventHandler(this.buttonCenter_Click);
            // 
            // buttonFullRight
            // 
            this.buttonFullRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFullRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullRight.ForeColor = System.Drawing.Color.Silver;
            this.buttonFullRight.Location = new System.Drawing.Point(87, 37);
            this.buttonFullRight.Name = "buttonFullRight";
            this.buttonFullRight.Size = new System.Drawing.Size(30, 24);
            this.buttonFullRight.TabIndex = 2;
            this.buttonFullRight.Text = ">";
            this.buttonFullRight.UseVisualStyleBackColor = true;
            this.buttonFullRight.Click += new System.EventHandler(this.buttonFullRight_Click);
            // 
            // AnignoCrossFade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonCenter);
            this.Controls.Add(this.buttonFullRight);
            this.Controls.Add(this.buttonFullLeft);
            this.Controls.Add(this.trackBarSlider);
            this.Name = "AnignoCrossFade";
            this.Size = new System.Drawing.Size(120, 64);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarSlider;
        private System.Windows.Forms.Button buttonFullLeft;
        private System.Windows.Forms.Button buttonCenter;
        private System.Windows.Forms.Button buttonFullRight;

    }
}

namespace Anignora_Video_Overlay
{
    partial class FormVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVideo));
            this.labelScroll = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.timerScroll = new System.Windows.Forms.Timer(this.components);
            this.labelVideoName = new System.Windows.Forms.Label();
            this.labelSpecialText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelScroll
            // 
            this.labelScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScroll.AutoSize = true;
            this.labelScroll.BackColor = System.Drawing.Color.White;
            this.labelScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelScroll.ForeColor = System.Drawing.Color.Black;
            this.labelScroll.Location = new System.Drawing.Point(162, 410);
            this.labelScroll.Name = "labelScroll";
            this.labelScroll.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelScroll.Size = new System.Drawing.Size(168, 39);
            this.labelScroll.TabIndex = 0;
            this.labelScroll.Text = "ערב טוב !!!";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(41, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 60);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // timerScroll
            // 
            this.timerScroll.Enabled = true;
            this.timerScroll.Interval = 1;
            this.timerScroll.Tick += new System.EventHandler(this.timerScroll_Tick);
            // 
            // labelVideoName
            // 
            this.labelVideoName.AutoSize = true;
            this.labelVideoName.BackColor = System.Drawing.Color.Black;
            this.labelVideoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelVideoName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelVideoName.Location = new System.Drawing.Point(233, 0);
            this.labelVideoName.Name = "labelVideoName";
            this.labelVideoName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelVideoName.Size = new System.Drawing.Size(63, 25);
            this.labelVideoName.TabIndex = 2;
            this.labelVideoName.Text = "Video";
            // 
            // labelSpecialText
            // 
            this.labelSpecialText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSpecialText.BackColor = System.Drawing.Color.Transparent;
            this.labelSpecialText.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSpecialText.ForeColor = System.Drawing.Color.White;
            this.labelSpecialText.Location = new System.Drawing.Point(12, 136);
            this.labelSpecialText.Name = "labelSpecialText";
            this.labelSpecialText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelSpecialText.Size = new System.Drawing.Size(610, 172);
            this.labelSpecialText.TabIndex = 3;
            this.labelSpecialText.Text = "הודעה מיוחדת !!!";
            this.labelSpecialText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSpecialText.Visible = false;
            // 
            // FormVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(634, 458);
            this.Controls.Add(this.labelSpecialText);
            this.Controls.Add(this.labelScroll);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelVideoName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVideo";
            this.ShowInTaskbar = false;
            this.Text = "Video";
            this.Load += new System.EventHandler(this.FormVideo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelScroll;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Timer timerScroll;
        private System.Windows.Forms.Label labelVideoName;
        private System.Windows.Forms.Label labelSpecialText;
    }
}
namespace DivesManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDivingClubs = new System.Windows.Forms.Button();
            this.buttonDivePlanning = new System.Windows.Forms.Button();
            this.pictureBoxPutskerLogo = new System.Windows.Forms.PictureBox();
            this.labelAutoSize2 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.buttonTextPad = new System.Windows.Forms.Button();
            this.pictureBoxDA = new System.Windows.Forms.PictureBox();
            this.pictureBoxPadi = new System.Windows.Forms.PictureBox();
            this.linkLabelAbout = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(216, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(21, 20);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = " X";
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDivingClubs
            // 
            this.buttonDivingClubs.ForeColor = System.Drawing.Color.Navy;
            this.buttonDivingClubs.Location = new System.Drawing.Point(3, 27);
            this.buttonDivingClubs.Name = "buttonDivingClubs";
            this.buttonDivingClubs.Size = new System.Drawing.Size(107, 20);
            this.buttonDivingClubs.TabIndex = 5;
            this.buttonDivingClubs.Text = "Diving clubs";
            this.buttonDivingClubs.Click += new System.EventHandler(this.buttonDivingClubs_Click);
            // 
            // buttonDivePlanning
            // 
            this.buttonDivePlanning.ForeColor = System.Drawing.Color.Navy;
            this.buttonDivePlanning.Location = new System.Drawing.Point(3, 53);
            this.buttonDivePlanning.Name = "buttonDivePlanning";
            this.buttonDivePlanning.Size = new System.Drawing.Size(107, 20);
            this.buttonDivePlanning.TabIndex = 6;
            this.buttonDivePlanning.Text = "Dive planning";
            this.buttonDivePlanning.Click += new System.EventHandler(this.buttonDivePlanning_Click);
            // 
            // pictureBoxPutskerLogo
            // 
            this.pictureBoxPutskerLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPutskerLogo.Image")));
            this.pictureBoxPutskerLogo.Location = new System.Drawing.Point(3, 212);
            this.pictureBoxPutskerLogo.Name = "pictureBoxPutskerLogo";
            this.pictureBoxPutskerLogo.Size = new System.Drawing.Size(178, 105);
            this.pictureBoxPutskerLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // labelAutoSize2
            // 
            this.labelAutoSize2.AutoSize = true;
            this.labelAutoSize2.ForeColor = System.Drawing.Color.Silver;
            this.labelAutoSize2.Location = new System.Drawing.Point(3, 194);
            this.labelAutoSize2.Name = "labelAutoSize2";
            this.labelAutoSize2.Size = new System.Drawing.Size(87, 15);
            this.labelAutoSize2.Text = "Contributed to:";
            // 
            // buttonTextPad
            // 
            this.buttonTextPad.ForeColor = System.Drawing.Color.Navy;
            this.buttonTextPad.Location = new System.Drawing.Point(3, 79);
            this.buttonTextPad.Name = "buttonTextPad";
            this.buttonTextPad.Size = new System.Drawing.Size(107, 20);
            this.buttonTextPad.TabIndex = 10;
            this.buttonTextPad.Text = "Text pad";
            this.buttonTextPad.Click += new System.EventHandler(this.buttonTextPad_Click);
            // 
            // pictureBoxDA
            // 
            this.pictureBoxDA.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDA.Image")));
            this.pictureBoxDA.Location = new System.Drawing.Point(187, 211);
            this.pictureBoxDA.Name = "pictureBoxDA";
            this.pictureBoxDA.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxDA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBoxPadi
            // 
            this.pictureBoxPadi.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPadi.Image")));
            this.pictureBoxPadi.Location = new System.Drawing.Point(187, 267);
            this.pictureBoxPadi.Name = "pictureBoxPadi";
            this.pictureBoxPadi.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxPadi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // linkLabelAbout
            // 
            this.linkLabelAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.linkLabelAbout.Location = new System.Drawing.Point(3, 139);
            this.linkLabelAbout.Name = "linkLabelAbout";
            this.linkLabelAbout.Size = new System.Drawing.Size(45, 20);
            this.linkLabelAbout.TabIndex = 14;
            this.linkLabelAbout.Text = "About";
            this.linkLabelAbout.Click += new System.EventHandler(this.linkLabelAbout_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelVersion.Location = new System.Drawing.Point(3, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(207, 20);
            this.labelVersion.Text = "Anigno Dives Manager";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.linkLabelAbout);
            this.Controls.Add(this.pictureBoxPadi);
            this.Controls.Add(this.pictureBoxDA);
            this.Controls.Add(this.buttonTextPad);
            this.Controls.Add(this.labelAutoSize2);
            this.Controls.Add(this.pictureBoxPutskerLogo);
            this.Controls.Add(this.buttonDivePlanning);
            this.Controls.Add(this.buttonDivingClubs);
            this.Controls.Add(this.buttonExit);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonDivingClubs;
        private System.Windows.Forms.Button buttonDivePlanning;
        private System.Windows.Forms.PictureBox pictureBoxPutskerLogo;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize2;
        private System.Windows.Forms.Button buttonTextPad;
        private System.Windows.Forms.PictureBox pictureBoxDA;
        private System.Windows.Forms.PictureBox pictureBoxPadi;
        private System.Windows.Forms.LinkLabel linkLabelAbout;
        private System.Windows.Forms.Label labelVersion;
    }
}
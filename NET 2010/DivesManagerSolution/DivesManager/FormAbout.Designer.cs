namespace DivesManager
{
    partial class FormAbout
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
            this.labelAutoSizeVersion = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize1 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize2 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelAutoSize3 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelAutoSize4 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.labelDeviceId = new System.Windows.Forms.Label();
            this.labelKeyValid = new System.Windows.Forms.Label();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.SuspendLayout();
            // 
            // labelAutoSizeVersion
            // 
            this.labelAutoSizeVersion.AutoSize = true;
            this.labelAutoSizeVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelAutoSizeVersion.Location = new System.Drawing.Point(3, 0);
            this.labelAutoSizeVersion.Name = "labelAutoSizeVersion";
            this.labelAutoSizeVersion.Size = new System.Drawing.Size(86, 14);
            this.labelAutoSizeVersion.Text = "Version";
            // 
            // labelAutoSize1
            // 
            this.labelAutoSize1.AutoSize = true;
            this.labelAutoSize1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelAutoSize1.Location = new System.Drawing.Point(4, 32);
            this.labelAutoSize1.Name = "labelAutoSize1";
            this.labelAutoSize1.Size = new System.Drawing.Size(109, 15);
            this.labelAutoSize1.Text = "Created by Anigno.";
            // 
            // labelAutoSize2
            // 
            this.labelAutoSize2.AutoSize = true;
            this.labelAutoSize2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.labelAutoSize2.Location = new System.Drawing.Point(4, 47);
            this.labelAutoSize2.Name = "labelAutoSize2";
            this.labelAutoSize2.Size = new System.Drawing.Size(108, 15);
            this.labelAutoSize2.Text = "anigno@gmail.com";
            // 
            // labelAutoSize3
            // 
            this.labelAutoSize3.AutoSize = true;
            this.labelAutoSize3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelAutoSize3.Location = new System.Drawing.Point(3, 120);
            this.labelAutoSize3.Name = "labelAutoSize3";
            this.labelAutoSize3.Size = new System.Drawing.Size(87, 15);
            this.labelAutoSize3.Text = "Restration key:";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(3, 141);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(108, 21);
            this.textBoxKey.TabIndex = 7;
            this.textBoxKey.TextChanged += new System.EventHandler(this.textBoxKey_TextChanged);
            // 
            // labelAutoSize4
            // 
            this.labelAutoSize4.AutoSize = true;
            this.labelAutoSize4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelAutoSize4.Location = new System.Drawing.Point(4, 79);
            this.labelAutoSize4.Name = "labelAutoSize4";
            this.labelAutoSize4.Size = new System.Drawing.Size(62, 15);
            this.labelAutoSize4.Text = "Device ID:";
            // 
            // labelDeviceId
            // 
            this.labelDeviceId.ForeColor = System.Drawing.Color.White;
            this.labelDeviceId.Location = new System.Drawing.Point(4, 97);
            this.labelDeviceId.Name = "labelDeviceId";
            this.labelDeviceId.Size = new System.Drawing.Size(233, 20);
            this.labelDeviceId.Text = "12345";
            // 
            // labelKeyValid
            // 
            this.labelKeyValid.ForeColor = System.Drawing.Color.Red;
            this.labelKeyValid.Location = new System.Drawing.Point(117, 142);
            this.labelKeyValid.Name = "labelKeyValid";
            this.labelKeyValid.Size = new System.Drawing.Size(37, 20);
            this.labelKeyValid.Text = "X";
            // 
            // inputPanel1
            // 
            this.inputPanel1.Enabled = true;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.labelKeyValid);
            this.Controls.Add(this.labelDeviceId);
            this.Controls.Add(this.labelAutoSize4);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.labelAutoSize3);
            this.Controls.Add(this.labelAutoSize2);
            this.Controls.Add(this.labelAutoSize1);
            this.Controls.Add(this.labelAutoSizeVersion);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Name = "FormAbout";
            this.Text = "Dives Manager";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAbout_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSizeVersion;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize1;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize2;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize3;
        private System.Windows.Forms.TextBox textBoxKey;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize4;
        private System.Windows.Forms.Label labelDeviceId;
        private System.Windows.Forms.Label labelKeyValid;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
    }
}
namespace AnignoLibrary.UI.Buttons
{
    partial class ButtonOnOff_Images
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
            this.buttonMain = new System.Windows.Forms.Button();
            this.buttonOff = new System.Windows.Forms.Button();
            this.buttonOn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMain
            // 
            this.buttonMain.BackgroundImage = global::AnignoLibrary.Properties.Resources.PwrBtnBlue;
            this.buttonMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMain.FlatAppearance.BorderSize = 0;
            this.buttonMain.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonMain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMain.Location = new System.Drawing.Point(0, 0);
            this.buttonMain.Name = "buttonMain";
            this.buttonMain.Size = new System.Drawing.Size(150, 150);
            this.buttonMain.TabIndex = 0;
            this.buttonMain.UseVisualStyleBackColor = true;
            this.buttonMain.MouseLeave += new System.EventHandler(this.buttonMain_MouseLeave);
            this.buttonMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonMain_MouseMove);
            this.buttonMain.Click += new System.EventHandler(this.buttonMain_Click);
            // 
            // buttonOff
            // 
            this.buttonOff.BackgroundImage = global::AnignoLibrary.Properties.Resources.PwrBtnRed;
            this.buttonOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOff.FlatAppearance.BorderSize = 0;
            this.buttonOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOff.Location = new System.Drawing.Point(3, 103);
            this.buttonOff.Name = "buttonOff";
            this.buttonOff.Size = new System.Drawing.Size(55, 44);
            this.buttonOff.TabIndex = 1;
            this.buttonOff.UseVisualStyleBackColor = true;
            this.buttonOff.Visible = false;
            // 
            // buttonOn
            // 
            this.buttonOn.BackgroundImage = global::AnignoLibrary.Properties.Resources.PwrBtnBlue;
            this.buttonOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOn.FlatAppearance.BorderSize = 0;
            this.buttonOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOn.Location = new System.Drawing.Point(64, 103);
            this.buttonOn.Name = "buttonOn";
            this.buttonOn.Size = new System.Drawing.Size(55, 44);
            this.buttonOn.TabIndex = 2;
            this.buttonOn.UseVisualStyleBackColor = true;
            this.buttonOn.Visible = false;
            // 
            // ButtonOnOff_Images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonOn);
            this.Controls.Add(this.buttonOff);
            this.Controls.Add(this.buttonMain);
            this.Name = "ButtonOnOff_Images";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMain;
        private System.Windows.Forms.Button buttonOff;
        private System.Windows.Forms.Button buttonOn;

    }
}

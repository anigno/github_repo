namespace DivesManager
{
    partial class FormTextPad
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
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.textBoxTextPad = new System.Windows.Forms.TextBox();
            this.labelAutoSize1 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.buttonToMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inputPanel1
            // 
            this.inputPanel1.Enabled = true;
            this.inputPanel1.EnabledChanged += new System.EventHandler(this.inputPanel_EnabledChanged);
            // 
            // textBoxTextPad
            // 
            this.textBoxTextPad.Location = new System.Drawing.Point(3, 17);
            this.textBoxTextPad.Multiline = true;
            this.textBoxTextPad.Name = "textBoxTextPad";
            this.textBoxTextPad.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTextPad.Size = new System.Drawing.Size(234, 171);
            this.textBoxTextPad.TabIndex = 0;
            this.textBoxTextPad.TextChanged += new System.EventHandler(this.textBoxTextPad_TextChanged);
            // 
            // labelAutoSize1
            // 
            this.labelAutoSize1.AutoSize = true;
            this.labelAutoSize1.Location = new System.Drawing.Point(3, 0);
            this.labelAutoSize1.Name = "labelAutoSize1";
            this.labelAutoSize1.Size = new System.Drawing.Size(52, 15);
            this.labelAutoSize1.Text = "Text pad";
            // 
            // buttonToMain
            // 
            this.buttonToMain.Location = new System.Drawing.Point(165, 194);
            this.buttonToMain.Name = "buttonToMain";
            this.buttonToMain.Size = new System.Drawing.Size(72, 20);
            this.buttonToMain.TabIndex = 2;
            this.buttonToMain.Text = "Main -->";
            this.buttonToMain.Click += new System.EventHandler(this.buttonToMain_Click);
            // 
            // FormTextPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.buttonToMain);
            this.Controls.Add(this.labelAutoSize1);
            this.Controls.Add(this.textBoxTextPad);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormTextPad";
            this.Text = "FormTextPad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.TextBox textBoxTextPad;
        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize1;
        private System.Windows.Forms.Button buttonToMain;
    }
}
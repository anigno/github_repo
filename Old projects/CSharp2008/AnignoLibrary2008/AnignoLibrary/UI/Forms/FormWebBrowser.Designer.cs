namespace AnignoLibrary.UI.Forms
{
    partial class FormWebBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebBrowser));
            this.webBrowserMain = new System.Windows.Forms.WebBrowser();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonNavigateTo = new System.Windows.Forms.Button();
            this.buttonNavigateForward = new System.Windows.Forms.Button();
            this.buttonNavigateBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowserMain
            // 
            this.webBrowserMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserMain.Location = new System.Drawing.Point(12, 38);
            this.webBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMain.Name = "webBrowserMain";
            this.webBrowserMain.Size = new System.Drawing.Size(828, 629);
            this.webBrowserMain.TabIndex = 0;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(104, 12);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(690, 20);
            this.textBoxAddress.TabIndex = 3;
            // 
            // buttonNavigateTo
            // 
            this.buttonNavigateTo.BackgroundImage = global::AnignoLibrary.Properties.Resources.apply;
            this.buttonNavigateTo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNavigateTo.FlatAppearance.BorderSize = 0;
            this.buttonNavigateTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNavigateTo.Location = new System.Drawing.Point(800, 1);
            this.buttonNavigateTo.Name = "buttonNavigateTo";
            this.buttonNavigateTo.Size = new System.Drawing.Size(40, 40);
            this.buttonNavigateTo.TabIndex = 4;
            this.buttonNavigateTo.UseVisualStyleBackColor = true;
            this.buttonNavigateTo.Click += new System.EventHandler(this.buttonNavigateTo_Click);
            // 
            // buttonNavigateForward
            // 
            this.buttonNavigateForward.BackgroundImage = global::AnignoLibrary.Properties.Resources._2rightarrow;
            this.buttonNavigateForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNavigateForward.FlatAppearance.BorderSize = 0;
            this.buttonNavigateForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNavigateForward.Location = new System.Drawing.Point(58, 1);
            this.buttonNavigateForward.Name = "buttonNavigateForward";
            this.buttonNavigateForward.Size = new System.Drawing.Size(40, 40);
            this.buttonNavigateForward.TabIndex = 2;
            this.buttonNavigateForward.UseVisualStyleBackColor = true;
            this.buttonNavigateForward.Click += new System.EventHandler(this.buttonNavigateForward_Click);
            // 
            // buttonNavigateBack
            // 
            this.buttonNavigateBack.BackgroundImage = global::AnignoLibrary.Properties.Resources._2leftarrow;
            this.buttonNavigateBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonNavigateBack.FlatAppearance.BorderSize = 0;
            this.buttonNavigateBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNavigateBack.Location = new System.Drawing.Point(12, 1);
            this.buttonNavigateBack.Name = "buttonNavigateBack";
            this.buttonNavigateBack.Size = new System.Drawing.Size(40, 40);
            this.buttonNavigateBack.TabIndex = 1;
            this.buttonNavigateBack.UseVisualStyleBackColor = true;
            this.buttonNavigateBack.Click += new System.EventHandler(this.buttonNavigateBack_Click);
            // 
            // FormWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 679);
            this.Controls.Add(this.webBrowserMain);
            this.Controls.Add(this.buttonNavigateTo);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.buttonNavigateForward);
            this.Controls.Add(this.buttonNavigateBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWebBrowser";
            this.ShowInTaskbar = false;
            this.Text = "Web Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserMain;
        private System.Windows.Forms.Button buttonNavigateBack;
        private System.Windows.Forms.Button buttonNavigateForward;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonNavigateTo;
    }
}
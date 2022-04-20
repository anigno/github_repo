namespace HTMLExtractor
{
    partial class formConsole
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
            this.buttonExtract = new System.Windows.Forms.Button();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBoxCurrentLink = new System.Windows.Forms.TextBox();
            this.buttonFwd = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.listViewLinks = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // buttonExtract
            // 
            this.buttonExtract.Location = new System.Drawing.Point(12, 12);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(75, 23);
            this.buttonExtract.TabIndex = 0;
            this.buttonExtract.Text = "Extract";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(93, 15);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(280, 20);
            this.textBoxURL.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(262, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(676, 632);
            this.webBrowser1.TabIndex = 4;
            // 
            // textBoxCurrentLink
            // 
            this.textBoxCurrentLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentLink.Location = new System.Drawing.Point(449, 15);
            this.textBoxCurrentLink.Name = "textBoxCurrentLink";
            this.textBoxCurrentLink.Size = new System.Drawing.Size(489, 20);
            this.textBoxCurrentLink.TabIndex = 5;
            // 
            // buttonFwd
            // 
            this.buttonFwd.Location = new System.Drawing.Point(423, 15);
            this.buttonFwd.Name = "buttonFwd";
            this.buttonFwd.Size = new System.Drawing.Size(20, 23);
            this.buttonFwd.TabIndex = 6;
            this.buttonFwd.Text = ">";
            this.buttonFwd.UseVisualStyleBackColor = true;
            this.buttonFwd.Click += new System.EventHandler(this.buttonFwd_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(397, 15);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(20, 23);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "<";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // listViewLinks
            // 
            this.listViewLinks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewLinks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewLinks.FullRowSelect = true;
            this.listViewLinks.HideSelection = false;
            this.listViewLinks.Location = new System.Drawing.Point(12, 41);
            this.listViewLinks.MultiSelect = false;
            this.listViewLinks.Name = "listViewLinks";
            this.listViewLinks.ShowItemToolTips = true;
            this.listViewLinks.Size = new System.Drawing.Size(244, 632);
            this.listViewLinks.TabIndex = 8;
            this.listViewLinks.UseCompatibleStateImageBehavior = false;
            this.listViewLinks.View = System.Windows.Forms.View.Details;
            this.listViewLinks.SelectedIndexChanged += new System.EventHandler(this.listViewLinks_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 27;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Link";
            this.columnHeader2.Width = 212;
            // 
            // formConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 685);
            this.Controls.Add(this.listViewLinks);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonFwd);
            this.Controls.Add(this.textBoxCurrentLink);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.buttonExtract);
            this.Name = "formConsole";
            this.Text = "Html Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBoxCurrentLink;
        private System.Windows.Forms.Button buttonFwd;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ListView listViewLinks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}


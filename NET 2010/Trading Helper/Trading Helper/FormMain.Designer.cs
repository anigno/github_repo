namespace Trading_Helper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBoxPercentage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewPecentage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataGridViewRss = new System.Windows.Forms.DataGridView();
            this.webBrowserMain = new System.Windows.Forms.WebBrowser();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageRSS = new System.Windows.Forms.TabPage();
            this.tabPageUtils = new System.Windows.Forms.TabPage();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.ColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRss)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageRSS.SuspendLayout();
            this.tabPageUtils.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPercentage
            // 
            this.textBoxPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPercentage.Location = new System.Drawing.Point(6, 19);
            this.textBoxPercentage.Name = "textBoxPercentage";
            this.textBoxPercentage.Size = new System.Drawing.Size(189, 20);
            this.textBoxPercentage.TabIndex = 1;
            this.textBoxPercentage.TextChanged += new System.EventHandler(this.textBoxPercentage_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listViewPecentage);
            this.groupBox1.Controls.Add(this.textBoxPercentage);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 322);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Percentage Calculate";
            // 
            // listViewPecentage
            // 
            this.listViewPecentage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPecentage.BackColor = System.Drawing.SystemColors.Control;
            this.listViewPecentage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewPecentage.Location = new System.Drawing.Point(6, 45);
            this.listViewPecentage.Name = "listViewPecentage";
            this.listViewPecentage.Size = new System.Drawing.Size(189, 271);
            this.listViewPecentage.TabIndex = 2;
            this.listViewPecentage.UseCompatibleStateImageBehavior = false;
            this.listViewPecentage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Per";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ch";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tot";
            // 
            // dataGridViewRss
            // 
            this.dataGridViewRss.AllowUserToAddRows = false;
            this.dataGridViewRss.AllowUserToDeleteRows = false;
            this.dataGridViewRss.AllowUserToOrderColumns = true;
            this.dataGridViewRss.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRss.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTime,
            this.ColumnSource,
            this.ColumnDescription,
            this.ColumnLink});
            this.dataGridViewRss.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewRss.EnableHeadersVisualStyles = false;
            this.dataGridViewRss.Location = new System.Drawing.Point(8, 6);
            this.dataGridViewRss.Name = "dataGridViewRss";
            this.dataGridViewRss.ReadOnly = true;
            this.dataGridViewRss.RowHeadersVisible = false;
            this.dataGridViewRss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRss.Size = new System.Drawing.Size(860, 286);
            this.dataGridViewRss.TabIndex = 3;
            this.dataGridViewRss.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRss_CellClick);
            // 
            // webBrowserMain
            // 
            this.webBrowserMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserMain.Location = new System.Drawing.Point(8, 298);
            this.webBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMain.Name = "webBrowserMain";
            this.webBrowserMain.Size = new System.Drawing.Size(860, 169);
            this.webBrowserMain.TabIndex = 4;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageRSS);
            this.tabControlMain.Controls.Add(this.tabPageUtils);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(884, 501);
            this.tabControlMain.TabIndex = 5;
            // 
            // tabPageRSS
            // 
            this.tabPageRSS.Controls.Add(this.dataGridViewRss);
            this.tabPageRSS.Controls.Add(this.webBrowserMain);
            this.tabPageRSS.Location = new System.Drawing.Point(4, 22);
            this.tabPageRSS.Name = "tabPageRSS";
            this.tabPageRSS.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRSS.Size = new System.Drawing.Size(876, 475);
            this.tabPageRSS.TabIndex = 0;
            this.tabPageRSS.Text = "RSS";
            this.tabPageRSS.UseVisualStyleBackColor = true;
            // 
            // tabPageUtils
            // 
            this.tabPageUtils.Controls.Add(this.groupBox1);
            this.tabPageUtils.Location = new System.Drawing.Point(4, 22);
            this.tabPageUtils.Name = "tabPageUtils";
            this.tabPageUtils.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUtils.Size = new System.Drawing.Size(876, 475);
            this.tabPageUtils.TabIndex = 1;
            this.tabPageUtils.Text = "Utils";
            this.tabPageUtils.UseVisualStyleBackColor = true;
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Trading Helper";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.BalloonTipClicked += new System.EventHandler(this.notifyIconMain_BalloonTipClicked);
            // 
            // ColumnTime
            // 
            this.ColumnTime.HeaderText = "Local Time";
            this.ColumnTime.Name = "ColumnTime";
            this.ColumnTime.ReadOnly = true;
            this.ColumnTime.Width = 120;
            // 
            // ColumnSource
            // 
            this.ColumnSource.HeaderText = "Source";
            this.ColumnSource.Name = "ColumnSource";
            this.ColumnSource.ReadOnly = true;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Width = 600;
            // 
            // ColumnLink
            // 
            this.ColumnLink.HeaderText = "Link";
            this.ColumnLink.Name = "ColumnLink";
            this.ColumnLink.ReadOnly = true;
            this.ColumnLink.Visible = false;
            this.ColumnLink.Width = 50;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(884, 501);
            this.Controls.Add(this.tabControlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Trading Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRss)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageRSS.ResumeLayout(false);
            this.tabPageUtils.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPercentage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewPecentage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.DataGridView dataGridViewRss;
        private System.Windows.Forms.WebBrowser webBrowserMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageRSS;
        private System.Windows.Forms.TabPage tabPageUtils;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewLinkColumn ColumnLink;
    }
}


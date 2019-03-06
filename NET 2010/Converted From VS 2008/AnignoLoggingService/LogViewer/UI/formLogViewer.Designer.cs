namespace LogViewer
{
    partial class formLogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogViewer));
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.columnHeaderNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClass = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAssembly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderThread = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFilters = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewSeverityFilters = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripFilters = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.checkBoxFiltersActivate = new System.Windows.Forms.CheckBox();
            this.listViewPages = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxText = new System.Windows.Forms.RichTextBox();
            this.toolStripFiles = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenExe = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxReadInterval = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxSeverity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxThread = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAssembly = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxMethod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewLastPage = new System.Windows.Forms.ListView();
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerLogFileRead = new System.Windows.Forms.Timer(this.components);
            this.groupBoxFilters.SuspendLayout();
            this.toolStripFilters.SuspendLayout();
            this.toolStripFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMessages
            // 
            this.listViewMessages.AllowColumnReorder = true;
            this.listViewMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNumber,
            this.columnHeaderTime,
            this.columnHeaderText,
            this.columnHeaderMethod,
            this.columnHeaderClass,
            this.columnHeaderAssembly,
            this.columnHeaderThread,
            this.columnHeaderSeverity});
            this.listViewMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessages.FullRowSelect = true;
            this.listViewMessages.GridLines = true;
            this.listViewMessages.HideSelection = false;
            this.listViewMessages.Location = new System.Drawing.Point(0, 0);
            this.listViewMessages.MultiSelect = false;
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.ShowItemToolTips = true;
            this.listViewMessages.Size = new System.Drawing.Size(766, 350);
            this.listViewMessages.TabIndex = 0;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            this.listViewMessages.SelectedIndexChanged += new System.EventHandler(this.listViewMessages_SelectedIndexChanged);
            // 
            // columnHeaderNumber
            // 
            this.columnHeaderNumber.Text = "#";
            this.columnHeaderNumber.Width = 47;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            this.columnHeaderTime.Width = 111;
            // 
            // columnHeaderText
            // 
            this.columnHeaderText.Text = "Text";
            this.columnHeaderText.Width = 179;
            // 
            // columnHeaderMethod
            // 
            this.columnHeaderMethod.Text = "Method";
            this.columnHeaderMethod.Width = 136;
            // 
            // columnHeaderClass
            // 
            this.columnHeaderClass.Text = "Class";
            this.columnHeaderClass.Width = 116;
            // 
            // columnHeaderAssembly
            // 
            this.columnHeaderAssembly.Text = "Assembly";
            this.columnHeaderAssembly.Width = 65;
            // 
            // columnHeaderThread
            // 
            this.columnHeaderThread.Text = "Thread";
            // 
            // columnHeaderSeverity
            // 
            this.columnHeaderSeverity.Text = "Severity";
            this.columnHeaderSeverity.Width = 84;
            // 
            // listViewFilters
            // 
            this.listViewFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFilters.CheckBoxes = true;
            this.listViewFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader9,
            this.columnHeader7});
            this.listViewFilters.FullRowSelect = true;
            this.listViewFilters.GridLines = true;
            this.listViewFilters.HideSelection = false;
            this.listViewFilters.Location = new System.Drawing.Point(6, 51);
            this.listViewFilters.MultiSelect = false;
            this.listViewFilters.Name = "listViewFilters";
            this.listViewFilters.ShowItemToolTips = true;
            this.listViewFilters.Size = new System.Drawing.Size(185, 395);
            this.listViewFilters.TabIndex = 1;
            this.listViewFilters.UseCompatibleStateImageBehavior = false;
            this.listViewFilters.View = System.Windows.Forms.View.Details;
            this.listViewFilters.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewFilters_ItemChecked);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Active";
            this.columnHeader10.Width = 43;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            this.columnHeader9.Width = 49;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "WildCard";
            this.columnHeader7.Width = 65;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilters.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxFilters.Controls.Add(this.label5);
            this.groupBoxFilters.Controls.Add(this.listViewSeverityFilters);
            this.groupBoxFilters.Controls.Add(this.toolStripFilters);
            this.groupBoxFilters.Controls.Add(this.checkBoxFiltersActivate);
            this.groupBoxFilters.Controls.Add(this.listViewFilters);
            this.groupBoxFilters.Location = new System.Drawing.Point(3, 38);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(196, 549);
            this.groupBoxFilters.TabIndex = 3;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Severity filters:";
            // 
            // listViewSeverityFilters
            // 
            this.listViewSeverityFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSeverityFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSeverityFilters.CheckBoxes = true;
            this.listViewSeverityFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23});
            this.listViewSeverityFilters.GridLines = true;
            this.listViewSeverityFilters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewSeverityFilters.Location = new System.Drawing.Point(6, 467);
            this.listViewSeverityFilters.Name = "listViewSeverityFilters";
            this.listViewSeverityFilters.Size = new System.Drawing.Size(119, 73);
            this.listViewSeverityFilters.TabIndex = 11;
            this.listViewSeverityFilters.UseCompatibleStateImageBehavior = false;
            this.listViewSeverityFilters.View = System.Windows.Forms.View.Details;
            this.listViewSeverityFilters.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewSeverityFilters_ItemChecked);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Width = 19;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Width = 70;
            // 
            // toolStripFilters
            // 
            this.toolStripFilters.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFilters.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFilters.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripFilters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddFilter,
            this.toolStripButtonEditFilter,
            this.toolStripButtonRemoveFilter,
            this.toolStripButtonSearch});
            this.toolStripFilters.Location = new System.Drawing.Point(6, 16);
            this.toolStripFilters.Name = "toolStripFilters";
            this.toolStripFilters.Size = new System.Drawing.Size(119, 32);
            this.toolStripFilters.TabIndex = 10;
            this.toolStripFilters.Text = "Filters";
            // 
            // toolStripButtonAddFilter
            // 
            this.toolStripButtonAddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFilter.Image")));
            this.toolStripButtonAddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFilter.Name = "toolStripButtonAddFilter";
            this.toolStripButtonAddFilter.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonAddFilter.Text = "Add filter";
            this.toolStripButtonAddFilter.Click += new System.EventHandler(this.toolStripButtonAddFilter_Click);
            // 
            // toolStripButtonEditFilter
            // 
            this.toolStripButtonEditFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditFilter.Enabled = false;
            this.toolStripButtonEditFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEditFilter.Image")));
            this.toolStripButtonEditFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditFilter.Name = "toolStripButtonEditFilter";
            this.toolStripButtonEditFilter.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonEditFilter.Text = "Edit filter";
            // 
            // toolStripButtonRemoveFilter
            // 
            this.toolStripButtonRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRemoveFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveFilter.Image")));
            this.toolStripButtonRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveFilter.Name = "toolStripButtonRemoveFilter";
            this.toolStripButtonRemoveFilter.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonRemoveFilter.Text = "RemoveFilter";
            this.toolStripButtonRemoveFilter.Click += new System.EventHandler(this.toolStripButtonRemoveFilter_Click);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Enabled = false;
            this.toolStripButtonSearch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSearch.Image")));
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonSearch.Text = "Search";
            // 
            // checkBoxFiltersActivate
            // 
            this.checkBoxFiltersActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxFiltersActivate.AutoSize = true;
            this.checkBoxFiltersActivate.Checked = true;
            this.checkBoxFiltersActivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFiltersActivate.Location = new System.Drawing.Point(171, 452);
            this.checkBoxFiltersActivate.Name = "checkBoxFiltersActivate";
            this.checkBoxFiltersActivate.Size = new System.Drawing.Size(65, 17);
            this.checkBoxFiltersActivate.TabIndex = 4;
            this.checkBoxFiltersActivate.Text = "Activate";
            this.checkBoxFiltersActivate.UseVisualStyleBackColor = true;
            this.checkBoxFiltersActivate.CheckedChanged += new System.EventHandler(this.checkBoxFiltersActivate_CheckedChanged);
            // 
            // listViewPages
            // 
            this.listViewPages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewPages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader16});
            this.listViewPages.FullRowSelect = true;
            this.listViewPages.GridLines = true;
            this.listViewPages.HideSelection = false;
            this.listViewPages.Location = new System.Drawing.Point(310, 53);
            this.listViewPages.MultiSelect = false;
            this.listViewPages.Name = "listViewPages";
            this.listViewPages.Size = new System.Drawing.Size(456, 212);
            this.listViewPages.TabIndex = 6;
            this.listViewPages.UseCompatibleStateImageBehavior = false;
            this.listViewPages.View = System.Windows.Forms.View.Details;
            this.listViewPages.SelectedIndexChanged += new System.EventHandler(this.listViewPages_SelectedIndexChanged);
            this.listViewPages.Click += new System.EventHandler(this.listViewPages_Click);
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "#";
            this.columnHeader11.Width = 40;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Start time";
            this.columnHeader12.Width = 150;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "End time";
            this.columnHeader13.Width = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Errors";
            this.columnHeader14.Width = 40;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Warnings";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Old pages:";
            // 
            // richTextBoxText
            // 
            this.richTextBoxText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxText.Location = new System.Drawing.Point(4, 159);
            this.richTextBoxText.Name = "richTextBoxText";
            this.richTextBoxText.Size = new System.Drawing.Size(300, 106);
            this.richTextBoxText.TabIndex = 8;
            this.richTextBoxText.Text = "";
            // 
            // toolStripFiles
            // 
            this.toolStripFiles.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripFiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFiles.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpenFolder,
            this.toolStripButtonOpenExe,
            this.toolStripButtonStart,
            this.toolStripButtonStop});
            this.toolStripFiles.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripFiles.Location = new System.Drawing.Point(9, 3);
            this.toolStripFiles.Name = "toolStripFiles";
            this.toolStripFiles.Size = new System.Drawing.Size(117, 32);
            this.toolStripFiles.Stretch = true;
            this.toolStripFiles.TabIndex = 11;
            this.toolStripFiles.Text = "Files";
            // 
            // toolStripButtonOpenFolder
            // 
            this.toolStripButtonOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripButtonOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpenFolder.Image")));
            this.toolStripButtonOpenFolder.ImageTransparentColor = System.Drawing.Color.Maroon;
            this.toolStripButtonOpenFolder.Name = "toolStripButtonOpenFolder";
            this.toolStripButtonOpenFolder.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonOpenFolder.Text = "Select log directory";
            this.toolStripButtonOpenFolder.Click += new System.EventHandler(this.toolStripButtonOpenFolder_Click);
            // 
            // toolStripButtonOpenExe
            // 
            this.toolStripButtonOpenExe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenExe.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpenExe.Image")));
            this.toolStripButtonOpenExe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenExe.Name = "toolStripButtonOpenExe";
            this.toolStripButtonOpenExe.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonOpenExe.Text = "Select EXE file";
            this.toolStripButtonOpenExe.Click += new System.EventHandler(this.toolStripButtonOpenExe_Click);
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonStart.Text = "Start";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(29, 29);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Location = new System.Drawing.Point(1, 4);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.label3);
            this.splitContainerMain.Panel1.Controls.Add(this.comboBoxReadInterval);
            this.splitContainerMain.Panel1.Controls.Add(this.toolStripFiles);
            this.splitContainerMain.Panel1.Controls.Add(this.groupBoxFilters);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerMain.Size = new System.Drawing.Size(979, 636);
            this.splitContainerMain.SplitterDistance = 205;
            this.splitContainerMain.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Refresh:";
            // 
            // comboBoxReadInterval
            // 
            this.comboBoxReadInterval.FormattingEnabled = true;
            this.comboBoxReadInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxReadInterval.Location = new System.Drawing.Point(129, 14);
            this.comboBoxReadInterval.Name = "comboBoxReadInterval";
            this.comboBoxReadInterval.Size = new System.Drawing.Size(47, 21);
            this.comboBoxReadInterval.TabIndex = 10;
            this.comboBoxReadInterval.Text = "1";
            this.comboBoxReadInterval.SelectedIndexChanged += new System.EventHandler(this.comboBoxReadInterval_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewMessages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxSeverity);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxThread);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxAssembly);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxMethod);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxClass);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxTime);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.listViewLastPage);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxText);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.listViewPages);
            this.splitContainer1.Size = new System.Drawing.Size(770, 636);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 10;
            // 
            // textBoxSeverity
            // 
            this.textBoxSeverity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSeverity.Location = new System.Drawing.Point(63, 107);
            this.textBoxSeverity.Name = "textBoxSeverity";
            this.textBoxSeverity.Size = new System.Drawing.Size(156, 20);
            this.textBoxSeverity.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Severity:";
            // 
            // textBoxThread
            // 
            this.textBoxThread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxThread.Location = new System.Drawing.Point(63, 81);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.Size = new System.Drawing.Size(225, 20);
            this.textBoxThread.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Thread:";
            // 
            // textBoxAssembly
            // 
            this.textBoxAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAssembly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAssembly.Location = new System.Drawing.Point(63, 55);
            this.textBoxAssembly.Name = "textBoxAssembly";
            this.textBoxAssembly.Size = new System.Drawing.Size(225, 20);
            this.textBoxAssembly.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Assembly:";
            // 
            // textBoxMethod
            // 
            this.textBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMethod.Location = new System.Drawing.Point(63, 3);
            this.textBoxMethod.Name = "textBoxMethod";
            this.textBoxMethod.Size = new System.Drawing.Size(225, 20);
            this.textBoxMethod.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Method:";
            // 
            // textBoxClass
            // 
            this.textBoxClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClass.Location = new System.Drawing.Point(63, 27);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(225, 20);
            this.textBoxClass.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Class:";
            // 
            // textBoxTime
            // 
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTime.Location = new System.Drawing.Point(63, 133);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(156, 20);
            this.textBoxTime.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Time:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current page:";
            // 
            // listViewLastPage
            // 
            this.listViewLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewLastPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLastPage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.listViewLastPage.FullRowSelect = true;
            this.listViewLastPage.GridLines = true;
            this.listViewLastPage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewLastPage.HideSelection = false;
            this.listViewLastPage.Location = new System.Drawing.Point(310, 16);
            this.listViewLastPage.MultiSelect = false;
            this.listViewLastPage.Name = "listViewLastPage";
            this.listViewLastPage.Size = new System.Drawing.Size(456, 18);
            this.listViewLastPage.TabIndex = 10;
            this.listViewLastPage.UseCompatibleStateImageBehavior = false;
            this.listViewLastPage.View = System.Windows.Forms.View.Details;
            this.listViewLastPage.Click += new System.EventHandler(this.listViewLastPage_Click);
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "#";
            this.columnHeader17.Width = 40;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Start time";
            this.columnHeader18.Width = 150;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "End time";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Errors";
            this.columnHeader20.Width = 40;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Warnings";
            // 
            // timerLogFileRead
            // 
            this.timerLogFileRead.Enabled = true;
            this.timerLogFileRead.Interval = 2171;
            // 
            // formLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 641);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formLogViewer";
            this.Text = "Log Viewer 2011.03.05";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formLogViewer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formLogViewer_FormClosed);
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.toolStripFilters.ResumeLayout(false);
            this.toolStripFilters.PerformLayout();
            this.toolStripFiles.ResumeLayout(false);
            this.toolStripFiles.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader columnHeaderNumber;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderSeverity;
        private System.Windows.Forms.ColumnHeader columnHeaderClass;
        private System.Windows.Forms.ColumnHeader columnHeaderMethod;
        private System.Windows.Forms.ColumnHeader columnHeaderText;
        private System.Windows.Forms.ListView listViewFilters;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeaderThread;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.CheckBox checkBoxFiltersActivate;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView listViewPages;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxText;
        private System.Windows.Forms.ToolStrip toolStripFilters;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveFilter;
        private System.Windows.Forms.ToolStrip toolStripFiles;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenFolder;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenExe;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditFilter;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ColumnHeader columnHeaderAssembly;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.Timer timerLogFileRead;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ComboBox comboBoxReadInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ListView listViewLastPage;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ListView listViewSeverityFilters;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMethod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSeverity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxThread;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAssembly;
        private System.Windows.Forms.Label label10;
    }
}


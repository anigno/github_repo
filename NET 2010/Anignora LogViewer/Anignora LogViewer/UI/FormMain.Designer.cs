namespace Anignora_LogViewer.UI
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
            this.listViewHistory = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewLines = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLineNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxUpdateInterval = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonSelectExe = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelectLogFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFilterEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRemoveFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelCurrentLogFile = new System.Windows.Forms.ToolStripLabel();
            this.groupBoxLineData = new System.Windows.Forms.GroupBox();
            this.textBoxThread = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.textBoxMethod = new System.Windows.Forms.TextBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxLogger = new System.Windows.Forms.TextBox();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.listViewFilters = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStripMain.SuspendLayout();
            this.groupBoxLineData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewHistory
            // 
            this.listViewHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.listViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewHistory.FullRowSelect = true;
            this.listViewHistory.GridLines = true;
            this.listViewHistory.HideSelection = false;
            this.listViewHistory.Location = new System.Drawing.Point(0, 0);
            this.listViewHistory.Margin = new System.Windows.Forms.Padding(4);
            this.listViewHistory.MultiSelect = false;
            this.listViewHistory.Name = "listViewHistory";
            this.listViewHistory.ShowItemToolTips = true;
            this.listViewHistory.Size = new System.Drawing.Size(527, 253);
            this.listViewHistory.TabIndex = 0;
            this.listViewHistory.UseCompatibleStateImageBehavior = false;
            this.listViewHistory.View = System.Windows.Forms.View.Details;
            this.listViewHistory.SelectedIndexChanged += new System.EventHandler(this.onListViewHistorySelectedIndexChanged);
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "#";
            this.columnHeader14.Width = 36;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Warns";
            this.columnHeader15.Width = 47;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Errors";
            this.columnHeader16.Width = 44;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Fatals";
            this.columnHeader17.Width = 43;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Start";
            this.columnHeader18.Width = 173;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "End";
            this.columnHeader19.Width = 139;
            // 
            // listViewLines
            // 
            this.listViewLines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnLineNumber});
            this.listViewLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLines.FullRowSelect = true;
            this.listViewLines.GridLines = true;
            this.listViewLines.HideSelection = false;
            this.listViewLines.Location = new System.Drawing.Point(0, 0);
            this.listViewLines.Margin = new System.Windows.Forms.Padding(4);
            this.listViewLines.MultiSelect = false;
            this.listViewLines.Name = "listViewLines";
            this.listViewLines.ShowItemToolTips = true;
            this.listViewLines.Size = new System.Drawing.Size(925, 275);
            this.listViewLines.TabIndex = 2;
            this.listViewLines.UseCompatibleStateImageBehavior = false;
            this.listViewLines.View = System.Windows.Forms.View.Details;
            this.listViewLines.SelectedIndexChanged += new System.EventHandler(this.onListViewLinesSelectedIndexChanged);
            this.listViewLines.Click += new System.EventHandler(this.onListViewLinesClick);
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 1;
            this.columnHeader7.Text = "Time";
            this.columnHeader7.Width = 142;
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 2;
            this.columnHeader8.Text = "Level";
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 3;
            this.columnHeader9.Text = "Logger";
            // 
            // columnHeader10
            // 
            this.columnHeader10.DisplayIndex = 4;
            this.columnHeader10.Text = "Type";
            this.columnHeader10.Width = 99;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 5;
            this.columnHeader11.Text = "Method";
            this.columnHeader11.Width = 99;
            // 
            // columnHeader12
            // 
            this.columnHeader12.DisplayIndex = 6;
            this.columnHeader12.Text = "Message";
            this.columnHeader12.Width = 300;
            // 
            // columnHeader13
            // 
            this.columnHeader13.DisplayIndex = 7;
            this.columnHeader13.Text = "Thread";
            // 
            // columnLineNumber
            // 
            this.columnLineNumber.DisplayIndex = 0;
            this.columnLineNumber.Text = "Line#";
            this.columnLineNumber.Width = 44;
            // 
            // toolStripMain
            // 
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStop,
            this.toolStripButtonStart,
            this.toolStripComboBoxUpdateInterval,
            this.toolStripButtonSelectExe,
            this.toolStripButtonSelectLogFile,
            this.toolStripButtonAddFilter,
            this.toolStripButtonFilterEdit,
            this.toolStripButtonRemoveFilter,
            this.toolStripLabelCurrentLogFile});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1098, 31);
            this.toolStripMain.TabIndex = 3;
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonStop.Click += new System.EventHandler(this.onToolStripButtonStopClick);
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripButtonStart.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonStart.Click += new System.EventHandler(this.onToolStripButtonStartClick);
            // 
            // toolStripComboBoxUpdateInterval
            // 
            this.toolStripComboBoxUpdateInterval.AutoSize = false;
            this.toolStripComboBoxUpdateInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxUpdateInterval.DropDownWidth = 50;
            this.toolStripComboBoxUpdateInterval.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.toolStripComboBoxUpdateInterval.MaxDropDownItems = 6;
            this.toolStripComboBoxUpdateInterval.Name = "toolStripComboBoxUpdateInterval";
            this.toolStripComboBoxUpdateInterval.Size = new System.Drawing.Size(52, 28);
            this.toolStripComboBoxUpdateInterval.DropDownClosed += new System.EventHandler(this.onToolStripComboBoxUpdatelntervalDropDownClosed);
            // 
            // toolStripButtonSelectExe
            // 
            this.toolStripButtonSelectExe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSelectExe.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectExe.Image")));
            this.toolStripButtonSelectExe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectExe.Name = "toolStripButtonSelectExe";
            this.toolStripButtonSelectExe.Size = new System.Drawing.Size(38, 28);
            this.toolStripButtonSelectExe.Text = "EXE";
            this.toolStripButtonSelectExe.ToolTipText = "Select Exe File";
            this.toolStripButtonSelectExe.Click += new System.EventHandler(this.onToolStripButtonSelectExeClick);
            // 
            // toolStripButtonSelectLogFile
            // 
            this.toolStripButtonSelectLogFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSelectLogFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectLogFile.Image")));
            this.toolStripButtonSelectLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectLogFile.Name = "toolStripButtonSelectLogFile";
            this.toolStripButtonSelectLogFile.Size = new System.Drawing.Size(38, 28);
            this.toolStripButtonSelectLogFile.Text = "Log";
            this.toolStripButtonSelectLogFile.ToolTipText = "Select Log File";
            this.toolStripButtonSelectLogFile.Click += new System.EventHandler(this.onToolStripButtonSelectLogFileClick);
            // 
            // toolStripButtonAddFilter
            // 
            this.toolStripButtonAddFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddFilter.Image")));
            this.toolStripButtonAddFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddFilter.Name = "toolStripButtonAddFilter";
            this.toolStripButtonAddFilter.Size = new System.Drawing.Size(30, 28);
            this.toolStripButtonAddFilter.Text = "F+";
            this.toolStripButtonAddFilter.Click += new System.EventHandler(this.onToolStripButtonAddFilterClick);
            // 
            // toolStripButtonFilterEdit
            // 
            this.toolStripButtonFilterEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFilterEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFilterEdit.Image")));
            this.toolStripButtonFilterEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFilterEdit.Name = "toolStripButtonFilterEdit";
            this.toolStripButtonFilterEdit.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonFilterEdit.Text = "FE";
            this.toolStripButtonFilterEdit.Click += new System.EventHandler(this.onToolStripButtonFilterEditClick);
            // 
            // toolStripButtonRemoveFilter
            // 
            this.toolStripButtonRemoveFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRemoveFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRemoveFilter.Image")));
            this.toolStripButtonRemoveFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRemoveFilter.Name = "toolStripButtonRemoveFilter";
            this.toolStripButtonRemoveFilter.Size = new System.Drawing.Size(26, 28);
            this.toolStripButtonRemoveFilter.Text = "F-";
            this.toolStripButtonRemoveFilter.Click += new System.EventHandler(this.toolStripButtonRemoveFilterClick);
            // 
            // toolStripLabelCurrentLogFile
            // 
            this.toolStripLabelCurrentLogFile.Name = "toolStripLabelCurrentLogFile";
            this.toolStripLabelCurrentLogFile.Size = new System.Drawing.Size(56, 28);
            this.toolStripLabelCurrentLogFile.Text = "No File";
            // 
            // groupBoxLineData
            // 
            this.groupBoxLineData.Controls.Add(this.textBoxThread);
            this.groupBoxLineData.Controls.Add(this.textBoxMessage);
            this.groupBoxLineData.Controls.Add(this.textBoxMethod);
            this.groupBoxLineData.Controls.Add(this.textBoxType);
            this.groupBoxLineData.Controls.Add(this.textBoxLogger);
            this.groupBoxLineData.Controls.Add(this.textBoxLevel);
            this.groupBoxLineData.Controls.Add(this.textBoxTime);
            this.groupBoxLineData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLineData.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLineData.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxLineData.Name = "groupBoxLineData";
            this.groupBoxLineData.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxLineData.Size = new System.Drawing.Size(558, 253);
            this.groupBoxLineData.TabIndex = 4;
            this.groupBoxLineData.TabStop = false;
            // 
            // textBoxThread
            // 
            this.textBoxThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxThread.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxThread.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxThread.Location = new System.Drawing.Point(462, 23);
            this.textBoxThread.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.ReadOnly = true;
            this.textBoxThread.Size = new System.Drawing.Size(90, 22);
            this.textBoxThread.TabIndex = 7;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMessage.Location = new System.Drawing.Point(8, 87);
            this.textBoxMessage.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.ReadOnly = true;
            this.textBoxMessage.Size = new System.Drawing.Size(544, 161);
            this.textBoxMessage.TabIndex = 6;
            // 
            // textBoxMethod
            // 
            this.textBoxMethod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMethod.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMethod.Location = new System.Drawing.Point(308, 55);
            this.textBoxMethod.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMethod.Name = "textBoxMethod";
            this.textBoxMethod.ReadOnly = true;
            this.textBoxMethod.Size = new System.Drawing.Size(244, 22);
            this.textBoxMethod.TabIndex = 5;
            // 
            // textBoxType
            // 
            this.textBoxType.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxType.Location = new System.Drawing.Point(8, 55);
            this.textBoxType.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(291, 22);
            this.textBoxType.TabIndex = 4;
            // 
            // textBoxLogger
            // 
            this.textBoxLogger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogger.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLogger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLogger.Location = new System.Drawing.Point(308, 23);
            this.textBoxLogger.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLogger.Name = "textBoxLogger";
            this.textBoxLogger.ReadOnly = true;
            this.textBoxLogger.Size = new System.Drawing.Size(145, 22);
            this.textBoxLogger.TabIndex = 3;
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLevel.Location = new System.Drawing.Point(209, 23);
            this.textBoxLevel.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.ReadOnly = true;
            this.textBoxLevel.Size = new System.Drawing.Size(90, 22);
            this.textBoxLevel.TabIndex = 2;
            // 
            // textBoxTime
            // 
            this.textBoxTime.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTime.Location = new System.Drawing.Point(8, 23);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(193, 22);
            this.textBoxTime.TabIndex = 1;
            // 
            // listViewFilters
            // 
            this.listViewFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewFilters.CheckBoxes = true;
            this.listViewFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.listViewFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFilters.FullRowSelect = true;
            this.listViewFilters.GridLines = true;
            this.listViewFilters.Location = new System.Drawing.Point(0, 0);
            this.listViewFilters.Margin = new System.Windows.Forms.Padding(4);
            this.listViewFilters.MultiSelect = false;
            this.listViewFilters.Name = "listViewFilters";
            this.listViewFilters.Size = new System.Drawing.Size(160, 275);
            this.listViewFilters.TabIndex = 5;
            this.listViewFilters.UseCompatibleStateImageBehavior = false;
            this.listViewFilters.View = System.Windows.Forms.View.Details;
            this.listViewFilters.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.onListViewFiltersItemChecked);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Filter Name";
            this.columnHeader6.Width = 150;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1098, 541);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.listViewFilters);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listViewLines);
            this.splitContainer3.Size = new System.Drawing.Size(1098, 279);
            this.splitContainer3.SplitterDistance = 164;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxLineData);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewHistory);
            this.splitContainer2.Size = new System.Drawing.Size(1098, 257);
            this.splitContainer2.SplitterDistance = 562;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1098, 572);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Anignora Log Viewer";
            this.Load += new System.EventHandler(this.onFormMainLoad);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.groupBoxLineData.ResumeLayout(false);
            this.groupBoxLineData.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewHistory;
        private System.Windows.Forms.ListView listViewLines;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxUpdateInterval;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectExe;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectLogFile;
        private System.Windows.Forms.GroupBox groupBoxLineData;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.TextBox textBoxMethod;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxLogger;
        private System.Windows.Forms.TextBox textBoxLevel;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxThread;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonRemoveFilter;
        private System.Windows.Forms.ListView listViewFilters;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelCurrentLogFile;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripButton toolStripButtonFilterEdit;
        private System.Windows.Forms.ColumnHeader columnLineNumber;
    }
}


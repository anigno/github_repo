namespace FinanceAnalizer3.UI
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
            this.panelControls = new System.Windows.Forms.Panel();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.buttonTestStocks = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHistoryHeader = new System.Windows.Forms.Label();
            this.numericUpDownHistoryLength = new System.Windows.Forms.NumericUpDown();
            this.buttonRemoveStock = new System.Windows.Forms.Button();
            this.buttonAddStocks = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFomSignalSammeryPer = new System.Windows.Forms.Label();
            this.labelStockUpdated = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.anignoGraphDisplay = new AnignoLibrary.UI.Graphs.AnignoGraphDisplay();
            this.ucStocksDataGridViewStocksNames = new FinanceAnalizer3.UI.ucStocksDataGridView();
            this.ucStocksDataGridViewStockHistory = new FinanceAnalizer3.UI.ucStocksDataGridView();
            this.timerTimeDisplay = new System.Windows.Forms.Timer(this.components);
            this.ucStocksDataGridViewActiveStocks = new FinanceAnalizer3.UI.ucStocksDataGridView();
            this.labelStocksNames = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelStocksUpdateCounter = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControlData = new System.Windows.Forms.TabControl();
            this.tabPageStockData = new System.Windows.Forms.TabPage();
            this.tabPageGoogleSnP = new System.Windows.Forms.TabPage();
            this.webBrowserFinexoStatus = new System.Windows.Forms.WebBrowser();
            this.tabPageStatusWeb = new System.Windows.Forms.TabPage();
            this.ucBrowserSimpleStatus = new FinanceAnalizer3.UI.ucBrowserSimple();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ucBrowserSimple_A = new FinanceAnalizer3.UI.ucBrowserSimple();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucBrowserSimple_B = new FinanceAnalizer3.UI.ucBrowserSimple();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDailySammeryPer = new System.Windows.Forms.Label();
            this.panelControls.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistoryLength)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControlData.SuspendLayout();
            this.tabPageStockData.SuspendLayout();
            this.tabPageGoogleSnP.SuspendLayout();
            this.tabPageStatusWeb.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.buttonSimulate);
            this.panelControls.Controls.Add(this.buttonTestStocks);
            this.panelControls.Controls.Add(this.buttonReports);
            this.panelControls.Controls.Add(this.buttonSettings);
            this.panelControls.Controls.Add(this.panel1);
            this.panelControls.Controls.Add(this.buttonRemoveStock);
            this.panelControls.Controls.Add(this.buttonAddStocks);
            this.panelControls.Location = new System.Drawing.Point(3, 3);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(167, 90);
            this.panelControls.TabIndex = 5;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.BackgroundImage = global::FinanceAnalizer3.Properties.Resources.calculator;
            this.buttonSimulate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSimulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimulate.Location = new System.Drawing.Point(85, 46);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(35, 38);
            this.buttonSimulate.TabIndex = 22;
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // buttonTestStocks
            // 
            this.buttonTestStocks.BackgroundImage = global::FinanceAnalizer3.Properties.Resources.CMS_Indemnity_OD_B_calc;
            this.buttonTestStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonTestStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTestStocks.Location = new System.Drawing.Point(126, 3);
            this.buttonTestStocks.Name = "buttonTestStocks";
            this.buttonTestStocks.Size = new System.Drawing.Size(35, 38);
            this.buttonTestStocks.TabIndex = 21;
            this.buttonTestStocks.UseVisualStyleBackColor = true;
            this.buttonTestStocks.Click += new System.EventHandler(this.buttonTestStocks_Click);
            // 
            // buttonReports
            // 
            this.buttonReports.BackgroundImage = global::FinanceAnalizer3.Properties.Resources.Text_Document;
            this.buttonReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReports.Location = new System.Drawing.Point(85, 2);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(35, 38);
            this.buttonReports.TabIndex = 20;
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImage = global::FinanceAnalizer3.Properties.Resources.utils22;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Location = new System.Drawing.Point(126, 46);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(35, 38);
            this.buttonSettings.TabIndex = 19;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelHistoryHeader);
            this.panel1.Controls.Add(this.numericUpDownHistoryLength);
            this.panel1.Location = new System.Drawing.Point(3, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 38);
            this.panel1.TabIndex = 17;
            // 
            // labelHistoryHeader
            // 
            this.labelHistoryHeader.AutoSize = true;
            this.labelHistoryHeader.Location = new System.Drawing.Point(16, 0);
            this.labelHistoryHeader.Name = "labelHistoryHeader";
            this.labelHistoryHeader.Size = new System.Drawing.Size(42, 13);
            this.labelHistoryHeader.TabIndex = 16;
            this.labelHistoryHeader.Text = "History:";
            // 
            // numericUpDownHistoryLength
            // 
            this.numericUpDownHistoryLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDownHistoryLength.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.Location = new System.Drawing.Point(10, 16);
            this.numericUpDownHistoryLength.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.Name = "numericUpDownHistoryLength";
            this.numericUpDownHistoryLength.Size = new System.Drawing.Size(55, 16);
            this.numericUpDownHistoryLength.TabIndex = 15;
            this.numericUpDownHistoryLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownHistoryLength.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownHistoryLength.ValueChanged += new System.EventHandler(this.numericUpDownHistoryLength_ValueChanged);
            // 
            // buttonRemoveStock
            // 
            this.buttonRemoveStock.BackgroundImage = global::FinanceAnalizer3.Properties.Resources.db_remove;
            this.buttonRemoveStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRemoveStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveStock.Location = new System.Drawing.Point(44, 2);
            this.buttonRemoveStock.Name = "buttonRemoveStock";
            this.buttonRemoveStock.Size = new System.Drawing.Size(35, 38);
            this.buttonRemoveStock.TabIndex = 1;
            this.buttonRemoveStock.UseVisualStyleBackColor = true;
            this.buttonRemoveStock.Click += new System.EventHandler(this.buttonRemoveStock_Click);
            // 
            // buttonAddStocks
            // 
            this.buttonAddStocks.BackgroundImage = global::FinanceAnalizer3.Properties.Resources.db_add;
            this.buttonAddStocks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddStocks.Location = new System.Drawing.Point(3, 2);
            this.buttonAddStocks.Name = "buttonAddStocks";
            this.buttonAddStocks.Size = new System.Drawing.Size(35, 38);
            this.buttonAddStocks.TabIndex = 0;
            this.buttonAddStocks.UseVisualStyleBackColor = true;
            this.buttonAddStocks.Click += new System.EventHandler(this.buttonAddStocks_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(145, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Total Pos Sum:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFomSignalSammeryPer
            // 
            this.labelFomSignalSammeryPer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelFomSignalSammeryPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFomSignalSammeryPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelFomSignalSammeryPer.Location = new System.Drawing.Point(141, 63);
            this.labelFomSignalSammeryPer.Name = "labelFomSignalSammeryPer";
            this.labelFomSignalSammeryPer.Size = new System.Drawing.Size(121, 21);
            this.labelFomSignalSammeryPer.TabIndex = 22;
            this.labelFomSignalSammeryPer.Text = "000.00 %";
            this.labelFomSignalSammeryPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelStockUpdated
            // 
            this.labelStockUpdated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelStockUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelStockUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelStockUpdated.Location = new System.Drawing.Point(201, 2);
            this.labelStockUpdated.Name = "labelStockUpdated";
            this.labelStockUpdated.Size = new System.Drawing.Size(61, 34);
            this.labelStockUpdated.TabIndex = 20;
            this.labelStockUpdated.Text = "- - - - -";
            this.labelStockUpdated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTime
            // 
            this.labelTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Location = new System.Drawing.Point(3, 2);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(192, 34);
            this.labelTime.TabIndex = 18;
            this.labelTime.Text = "00/00/0000 00:00:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anignoGraphDisplay
            // 
            this.anignoGraphDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoGraphDisplay.AutoGridScale = true;
            this.anignoGraphDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoGraphDisplay.ColorGrid = System.Drawing.Color.Gray;
            this.anignoGraphDisplay.ColorZeroAxes = System.Drawing.Color.White;
            this.anignoGraphDisplay.DrawGrid = true;
            this.anignoGraphDisplay.DrawGridNumbers = false;
            this.anignoGraphDisplay.GridMaxY = 100F;
            this.anignoGraphDisplay.GridMinY = -100F;
            this.anignoGraphDisplay.Location = new System.Drawing.Point(447, 3);
            this.anignoGraphDisplay.Name = "anignoGraphDisplay";
            this.anignoGraphDisplay.Size = new System.Drawing.Size(121, 90);
            this.anignoGraphDisplay.TabIndex = 13;
            this.anignoGraphDisplay.X_GridLines = 10;
            this.anignoGraphDisplay.Y_GridLines = 5;
            // 
            // ucStocksDataGridViewStocksNames
            // 
            this.ucStocksDataGridViewStocksNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucStocksDataGridViewStocksNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucStocksDataGridViewStocksNames.Location = new System.Drawing.Point(3, 16);
            this.ucStocksDataGridViewStocksNames.Name = "ucStocksDataGridViewStocksNames";
            this.ucStocksDataGridViewStocksNames.Size = new System.Drawing.Size(262, 537);
            this.ucStocksDataGridViewStocksNames.TabIndex = 14;
            this.ucStocksDataGridViewStocksNames.SelectionChanged += new System.EventHandler(this.ucStocksDataGridViewStocksNames_SelectionChanged);
            // 
            // ucStocksDataGridViewStockHistory
            // 
            this.ucStocksDataGridViewStockHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucStocksDataGridViewStockHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStocksDataGridViewStockHistory.Location = new System.Drawing.Point(3, 3);
            this.ucStocksDataGridViewStockHistory.Name = "ucStocksDataGridViewStockHistory";
            this.ucStocksDataGridViewStockHistory.Size = new System.Drawing.Size(561, 199);
            this.ucStocksDataGridViewStockHistory.TabIndex = 15;
            // 
            // timerTimeDisplay
            // 
            this.timerTimeDisplay.Enabled = true;
            this.timerTimeDisplay.Interval = 1000;
            this.timerTimeDisplay.Tick += new System.EventHandler(this.timerTimeDisplay_Tick);
            // 
            // ucStocksDataGridViewActiveStocks
            // 
            this.ucStocksDataGridViewActiveStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucStocksDataGridViewActiveStocks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucStocksDataGridViewActiveStocks.Location = new System.Drawing.Point(3, 16);
            this.ucStocksDataGridViewActiveStocks.Name = "ucStocksDataGridViewActiveStocks";
            this.ucStocksDataGridViewActiveStocks.Size = new System.Drawing.Size(570, 215);
            this.ucStocksDataGridViewActiveStocks.TabIndex = 16;
            this.ucStocksDataGridViewActiveStocks.SelectionChanged += new System.EventHandler(this.ucStocksDataGridViewActiveStocks_SelectionChanged);
            // 
            // labelStocksNames
            // 
            this.labelStocksNames.AutoSize = true;
            this.labelStocksNames.BackColor = System.Drawing.Color.Transparent;
            this.labelStocksNames.Location = new System.Drawing.Point(3, 0);
            this.labelStocksNames.Name = "labelStocksNames";
            this.labelStocksNames.Size = new System.Drawing.Size(109, 13);
            this.labelStocksNames.TabIndex = 17;
            this.labelStocksNames.Text = "Stocks Last Updates:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Active Stocks:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelStocksUpdateCounter);
            this.splitContainer1.Panel1.Controls.Add(this.labelStocksNames);
            this.splitContainer1.Panel1.Controls.Add(this.ucStocksDataGridViewStocksNames);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(866, 581);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 20;
            // 
            // labelStocksUpdateCounter
            // 
            this.labelStocksUpdateCounter.AutoSize = true;
            this.labelStocksUpdateCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelStocksUpdateCounter.Location = new System.Drawing.Point(118, 0);
            this.labelStocksUpdateCounter.Name = "labelStocksUpdateCounter";
            this.labelStocksUpdateCounter.Size = new System.Drawing.Size(48, 13);
            this.labelStocksUpdateCounter.TabIndex = 18;
            this.labelStocksUpdateCounter.Text = "000/000";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Location = new System.Drawing.Point(3, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.ucStocksDataGridViewActiveStocks);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControlData);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.anignoGraphDisplay);
            this.splitContainer2.Panel2.Controls.Add(this.panelControls);
            this.splitContainer2.Size = new System.Drawing.Size(580, 574);
            this.splitContainer2.SplitterDistance = 238;
            this.splitContainer2.TabIndex = 22;
            // 
            // tabControlData
            // 
            this.tabControlData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlData.Controls.Add(this.tabPageStockData);
            this.tabControlData.Controls.Add(this.tabPageGoogleSnP);
            this.tabControlData.Controls.Add(this.tabPageStatusWeb);
            this.tabControlData.Controls.Add(this.tabPage1);
            this.tabControlData.Controls.Add(this.tabPage2);
            this.tabControlData.Location = new System.Drawing.Point(3, 99);
            this.tabControlData.Name = "tabControlData";
            this.tabControlData.SelectedIndex = 0;
            this.tabControlData.Size = new System.Drawing.Size(575, 231);
            this.tabControlData.TabIndex = 21;
            // 
            // tabPageStockData
            // 
            this.tabPageStockData.Controls.Add(this.ucStocksDataGridViewStockHistory);
            this.tabPageStockData.Location = new System.Drawing.Point(4, 22);
            this.tabPageStockData.Name = "tabPageStockData";
            this.tabPageStockData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStockData.Size = new System.Drawing.Size(567, 205);
            this.tabPageStockData.TabIndex = 0;
            this.tabPageStockData.Text = "Stock Data";
            this.tabPageStockData.UseVisualStyleBackColor = true;
            // 
            // tabPageGoogleSnP
            // 
            this.tabPageGoogleSnP.Controls.Add(this.webBrowserFinexoStatus);
            this.tabPageGoogleSnP.Location = new System.Drawing.Point(4, 22);
            this.tabPageGoogleSnP.Name = "tabPageGoogleSnP";
            this.tabPageGoogleSnP.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGoogleSnP.Size = new System.Drawing.Size(567, 205);
            this.tabPageGoogleSnP.TabIndex = 1;
            this.tabPageGoogleSnP.Text = "S&P";
            this.tabPageGoogleSnP.UseVisualStyleBackColor = true;
            // 
            // webBrowserFinexoStatus
            // 
            this.webBrowserFinexoStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserFinexoStatus.Location = new System.Drawing.Point(3, 3);
            this.webBrowserFinexoStatus.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserFinexoStatus.Name = "webBrowserFinexoStatus";
            this.webBrowserFinexoStatus.Size = new System.Drawing.Size(561, 199);
            this.webBrowserFinexoStatus.TabIndex = 23;
            this.webBrowserFinexoStatus.Url = new System.Uri("http://www.google.com/finance?q=INDEXSP:.INX", System.UriKind.Absolute);
            // 
            // tabPageStatusWeb
            // 
            this.tabPageStatusWeb.Controls.Add(this.ucBrowserSimpleStatus);
            this.tabPageStatusWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatusWeb.Name = "tabPageStatusWeb";
            this.tabPageStatusWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatusWeb.Size = new System.Drawing.Size(567, 205);
            this.tabPageStatusWeb.TabIndex = 2;
            this.tabPageStatusWeb.Text = "Status";
            this.tabPageStatusWeb.UseVisualStyleBackColor = true;
            // 
            // ucBrowserSimpleStatus
            // 
            this.ucBrowserSimpleStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBrowserSimpleStatus.HomePage = "https://www.onlinewebconnect.com/webconnect/WebLogin.aspx";
            this.ucBrowserSimpleStatus.Location = new System.Drawing.Point(3, 3);
            this.ucBrowserSimpleStatus.Name = "ucBrowserSimpleStatus";
            this.ucBrowserSimpleStatus.Size = new System.Drawing.Size(561, 199);
            this.ucBrowserSimpleStatus.TabIndex = 1;
            this.ucBrowserSimpleStatus.Url = "https://www.onlinewebconnect.com/webconnect/WebLogin.aspx";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucBrowserSimple_A);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(567, 205);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Browser A";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ucBrowserSimple_A
            // 
            this.ucBrowserSimple_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBrowserSimple_A.HomePage = "www.google.com";
            this.ucBrowserSimple_A.Location = new System.Drawing.Point(3, 3);
            this.ucBrowserSimple_A.Name = "ucBrowserSimple_A";
            this.ucBrowserSimple_A.Size = new System.Drawing.Size(561, 199);
            this.ucBrowserSimple_A.TabIndex = 0;
            this.ucBrowserSimple_A.Url = "www.google.com";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucBrowserSimple_B);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(567, 205);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Browser B";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucBrowserSimple_B
            // 
            this.ucBrowserSimple_B.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBrowserSimple_B.HomePage = "www.google.com";
            this.ucBrowserSimple_B.Location = new System.Drawing.Point(3, 3);
            this.ucBrowserSimple_B.Name = "ucBrowserSimple_B";
            this.ucBrowserSimple_B.Size = new System.Drawing.Size(561, 199);
            this.ucBrowserSimple_B.TabIndex = 1;
            this.ucBrowserSimple_B.Url = "www.google.com";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelDailySammeryPer);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelTime);
            this.panel2.Controls.Add(this.labelFomSignalSammeryPer);
            this.panel2.Controls.Add(this.labelStockUpdated);
            this.panel2.Location = new System.Drawing.Point(176, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 90);
            this.panel2.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Daily Pos Changes:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDailySammeryPer
            // 
            this.labelDailySammeryPer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDailySammeryPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDailySammeryPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelDailySammeryPer.Location = new System.Drawing.Point(3, 63);
            this.labelDailySammeryPer.Name = "labelDailySammeryPer";
            this.labelDailySammeryPer.Size = new System.Drawing.Size(121, 21);
            this.labelDailySammeryPer.TabIndex = 23;
            this.labelDailySammeryPer.Text = "000.00 %";
            this.labelDailySammeryPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 605);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Anignora Finance Analizer 3";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.panelControls.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHistoryLength)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControlData.ResumeLayout(false);
            this.tabPageStockData.ResumeLayout(false);
            this.tabPageGoogleSnP.ResumeLayout(false);
            this.tabPageStatusWeb.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button buttonRemoveStock;
        private System.Windows.Forms.Button buttonAddStocks;
        private AnignoLibrary.UI.Graphs.AnignoGraphDisplay anignoGraphDisplay;
        private System.Windows.Forms.NumericUpDown numericUpDownHistoryLength;
        private System.Windows.Forms.Label labelHistoryHeader;
        private System.Windows.Forms.Panel panel1;
        private ucStocksDataGridView ucStocksDataGridViewStocksNames;
        private ucStocksDataGridView ucStocksDataGridViewStockHistory;
        private System.Windows.Forms.Timer timerTimeDisplay;
        private ucStocksDataGridView ucStocksDataGridViewActiveStocks;
        private System.Windows.Forms.Label labelStocksNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelStockUpdated;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelFomSignalSammeryPer;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonTestStocks;
        private System.Windows.Forms.Label labelDailySammeryPer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Label labelStocksUpdateCounter;
        private System.Windows.Forms.TabControl tabControlData;
        private System.Windows.Forms.TabPage tabPageStockData;
        private System.Windows.Forms.TabPage tabPageGoogleSnP;
        private System.Windows.Forms.WebBrowser webBrowserFinexoStatus;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabPage tabPageStatusWeb;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ucBrowserSimple ucBrowserSimple_A;
        private ucBrowserSimple ucBrowserSimple_B;
        private ucBrowserSimple ucBrowserSimpleStatus;
    }
}
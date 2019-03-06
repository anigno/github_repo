using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.GeneralSymbols;

namespace AnignoraFinanceAnalyzer5.UI.Forms
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.flowLayoutPanelHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.labelExtractor = new System.Windows.Forms.Label();
            this.buttonProfitsCalculation = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewAutoActiveSymbolsMain = new AnignoraUI.Grids.DataGridViewAuto.DataGridViewAuto();
            this.userControlGeneralSymbolsMain = new UserControlGeneralSymbols();
            this.tabControlColorsActiveResults = new AnignoraUI.TabControls.TabControlColors();
            this.labelPingMain = new AnignoraUI.Labels.LabelPing();
            this.labelDateTimeMain = new AnignoraUI.Labels.LabelDateTime();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoActiveSymbolsMain)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelHeader
            // 
            this.flowLayoutPanelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelHeader.Location = new System.Drawing.Point(308, 1);
            this.flowLayoutPanelHeader.Name = "flowLayoutPanelHeader";
            this.flowLayoutPanelHeader.Size = new System.Drawing.Size(826, 42);
            this.flowLayoutPanelHeader.TabIndex = 4;
            // 
            // labelExtractor
            // 
            this.labelExtractor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelExtractor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelExtractor.Location = new System.Drawing.Point(12, 27);
            this.labelExtractor.Name = "labelExtractor";
            this.labelExtractor.Size = new System.Drawing.Size(124, 21);
            this.labelExtractor.TabIndex = 1;
            this.labelExtractor.Text = "XXXX XXXX";
            this.labelExtractor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonProfitsCalculation
            // 
            this.buttonProfitsCalculation.BackgroundImage = global::AnignoraFinanceAnalyzer5.Properties.Resources.Calculator;
            this.buttonProfitsCalculation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonProfitsCalculation.FlatAppearance.BorderSize = 0;
            this.buttonProfitsCalculation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfitsCalculation.Location = new System.Drawing.Point(253, 4);
            this.buttonProfitsCalculation.Name = "buttonProfitsCalculation";
            this.buttonProfitsCalculation.Size = new System.Drawing.Size(38, 38);
            this.buttonProfitsCalculation.TabIndex = 0;
            this.buttonProfitsCalculation.UseVisualStyleBackColor = true;
            this.buttonProfitsCalculation.Click += new System.EventHandler(this.onButtonProfitsCalculationClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(1, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlColorsActiveResults);
            this.splitContainer1.Size = new System.Drawing.Size(1133, 596);
            this.splitContainer1.SplitterDistance = 431;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewAutoActiveSymbolsMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.userControlGeneralSymbolsMain);
            this.splitContainer2.Size = new System.Drawing.Size(431, 596);
            this.splitContainer2.SplitterDistance = 232;
            this.splitContainer2.TabIndex = 1;
            // 
            // dataGridViewAutoActiveSymbolsMain
            // 
            this.dataGridViewAutoActiveSymbolsMain.AllowUserToAddRows = false;
            this.dataGridViewAutoActiveSymbolsMain.AllowUserToDeleteRows = false;
            this.dataGridViewAutoActiveSymbolsMain.AllowUserToOrderColumns = true;
            this.dataGridViewAutoActiveSymbolsMain.AllowUserToResizeRows = false;
            this.dataGridViewAutoActiveSymbolsMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAutoActiveSymbolsMain.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewAutoActiveSymbolsMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Miriam", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAutoActiveSymbolsMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAutoActiveSymbolsMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Miriam", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAutoActiveSymbolsMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAutoActiveSymbolsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAutoActiveSymbolsMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAutoActiveSymbolsMain.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewAutoActiveSymbolsMain.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAutoActiveSymbolsMain.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewAutoActiveSymbolsMain.Name = "dataGridViewAutoActiveSymbolsMain";
            this.dataGridViewAutoActiveSymbolsMain.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewAutoActiveSymbolsMain.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAutoActiveSymbolsMain.RowTemplate.Height = 24;
            this.dataGridViewAutoActiveSymbolsMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAutoActiveSymbolsMain.Size = new System.Drawing.Size(427, 228);
            this.dataGridViewAutoActiveSymbolsMain.TabIndex = 6;
            // 
            // userControlGeneralSymbolsMain
            // 
            this.userControlGeneralSymbolsMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userControlGeneralSymbolsMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userControlGeneralSymbolsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControlGeneralSymbolsMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.userControlGeneralSymbolsMain.Location = new System.Drawing.Point(0, 0);
            this.userControlGeneralSymbolsMain.Margin = new System.Windows.Forms.Padding(4);
            this.userControlGeneralSymbolsMain.Name = "userControlGeneralSymbolsMain";
            this.userControlGeneralSymbolsMain.Size = new System.Drawing.Size(427, 356);
            this.userControlGeneralSymbolsMain.TabIndex = 3;
            // 
            // tabControlColorsActiveResults
            // 
            this.tabControlColorsActiveResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlColorsActiveResults.Location = new System.Drawing.Point(0, 0);
            this.tabControlColorsActiveResults.Multiline = true;
            this.tabControlColorsActiveResults.Name = "tabControlColorsActiveResults";
            this.tabControlColorsActiveResults.SelectedIndex = 0;
            this.tabControlColorsActiveResults.Size = new System.Drawing.Size(694, 592);
            this.tabControlColorsActiveResults.TabControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(52)))));
            this.tabControlColorsActiveResults.TabControlBorderColor = System.Drawing.Color.White;
            this.tabControlColorsActiveResults.TabControlSelectedBackColor = System.Drawing.Color.Gray;
            this.tabControlColorsActiveResults.TabIndex = 3;
            // 
            // labelPingMain
            // 
            this.labelPingMain.Active = true;
            this.labelPingMain.AutoSize = true;
            this.labelPingMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPingMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelPingMain.ColorConnected = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPingMain.ColorDisconnected = System.Drawing.Color.Red;
            this.labelPingMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPingMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPingMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelPingMain.Location = new System.Drawing.Point(142, 31);
            this.labelPingMain.Name = "labelPingMain";
            this.labelPingMain.PingHost = "www.google.co.il";
            this.labelPingMain.PingIntervalMs = 10000;
            this.labelPingMain.Size = new System.Drawing.Size(38, 19);
            this.labelPingMain.TabIndex = 5;
            this.labelPingMain.Text = "NET";
            this.labelPingMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDateTimeMain
            // 
            this.labelDateTimeMain.AutoSize = true;
            this.labelDateTimeMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelDateTimeMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelDateTimeMain.FormatString = null;
            this.labelDateTimeMain.Location = new System.Drawing.Point(2, 5);
            this.labelDateTimeMain.Name = "labelDateTimeMain";
            this.labelDateTimeMain.Size = new System.Drawing.Size(214, 25);
            this.labelDateTimeMain.TabIndex = 2;
            this.labelDateTimeMain.Text = "25/12/2012 18:32:06";
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1134, 652);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labelPingMain);
            this.Controls.Add(this.buttonProfitsCalculation);
            this.Controls.Add(this.labelExtractor);
            this.Controls.Add(this.flowLayoutPanelHeader);
            this.Controls.Add(this.labelDateTimeMain);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Anignora Finance Analyzer";
            this.Load += new System.EventHandler(this.onFormMainLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutoActiveSymbolsMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControlGeneralSymbols userControlGeneralSymbolsMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHeader;
        private System.Windows.Forms.Label labelExtractor;
        private AnignoraUI.Labels.LabelDateTime labelDateTimeMain;
        private System.Windows.Forms.Button buttonProfitsCalculation;
        private AnignoraUI.Labels.LabelPing labelPingMain;
        private AnignoraUI.Grids.DataGridViewAuto.DataGridViewAuto dataGridViewAutoActiveSymbolsMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private AnignoraUI.TabControls.TabControlColors tabControlColorsActiveResults;


    }
}


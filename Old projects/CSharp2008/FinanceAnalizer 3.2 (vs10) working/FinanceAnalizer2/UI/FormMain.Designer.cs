namespace FinanceAnalizer2.UI
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
            this.dataGridViewStockData = new System.Windows.Forms.DataGridView();
            this.dataGridViewStocks = new System.Windows.Forms.DataGridView();
            this.buttonAddStocks = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonRemoveStock = new System.Windows.Forms.Button();
            this.anignoGraphDisplay = new AnignoLibrary.UI.Graphs.AnignoGraphDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocks)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStockData
            // 
            this.dataGridViewStockData.AllowUserToAddRows = false;
            this.dataGridViewStockData.AllowUserToDeleteRows = false;
            this.dataGridViewStockData.AllowUserToOrderColumns = true;
            this.dataGridViewStockData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStockData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStockData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStockData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewStockData.Location = new System.Drawing.Point(12, 359);
            this.dataGridViewStockData.Name = "dataGridViewStockData";
            this.dataGridViewStockData.ReadOnly = true;
            this.dataGridViewStockData.RowHeadersVisible = false;
            this.dataGridViewStockData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockData.Size = new System.Drawing.Size(948, 302);
            this.dataGridViewStockData.TabIndex = 2;
            // 
            // dataGridViewStocks
            // 
            this.dataGridViewStocks.AllowUserToAddRows = false;
            this.dataGridViewStocks.AllowUserToDeleteRows = false;
            this.dataGridViewStocks.AllowUserToOrderColumns = true;
            this.dataGridViewStocks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStocks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewStocks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewStocks.MultiSelect = false;
            this.dataGridViewStocks.Name = "dataGridViewStocks";
            this.dataGridViewStocks.ReadOnly = true;
            this.dataGridViewStocks.RowHeadersVisible = false;
            this.dataGridViewStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStocks.Size = new System.Drawing.Size(526, 341);
            this.dataGridViewStocks.TabIndex = 3;
            this.dataGridViewStocks.SelectionChanged += new System.EventHandler(this.dataGridViewStocks_SelectionChanged);
            // 
            // buttonAddStocks
            // 
            this.buttonAddStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddStocks.Location = new System.Drawing.Point(3, 3);
            this.buttonAddStocks.Name = "buttonAddStocks";
            this.buttonAddStocks.Size = new System.Drawing.Size(108, 23);
            this.buttonAddStocks.TabIndex = 0;
            this.buttonAddStocks.Text = "Add Stocks";
            this.buttonAddStocks.UseVisualStyleBackColor = true;
            this.buttonAddStocks.Click += new System.EventHandler(this.buttonAddStocks_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonReport);
            this.panel1.Controls.Add(this.buttonRemoveStock);
            this.panel1.Controls.Add(this.buttonAddStocks);
            this.panel1.Location = new System.Drawing.Point(544, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 59);
            this.panel1.TabIndex = 4;
            // 
            // buttonReport
            // 
            this.buttonReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReport.Location = new System.Drawing.Point(3, 32);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(108, 23);
            this.buttonReport.TabIndex = 2;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonRemoveStock
            // 
            this.buttonRemoveStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveStock.Location = new System.Drawing.Point(117, 3);
            this.buttonRemoveStock.Name = "buttonRemoveStock";
            this.buttonRemoveStock.Size = new System.Drawing.Size(108, 23);
            this.buttonRemoveStock.TabIndex = 1;
            this.buttonRemoveStock.Text = "Remove Stock";
            this.buttonRemoveStock.UseVisualStyleBackColor = true;
            this.buttonRemoveStock.Click += new System.EventHandler(this.buttonRemoveStock_Click);
            // 
            // anignoGraphDisplay
            // 
            this.anignoGraphDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.anignoGraphDisplay.AutoGridScale = true;
            this.anignoGraphDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.anignoGraphDisplay.ColorGrid = System.Drawing.Color.Gray;
            this.anignoGraphDisplay.ColorZeroAxes = System.Drawing.Color.White;
            this.anignoGraphDisplay.DrawGrid = true;
            this.anignoGraphDisplay.DrawGridNumbers = false;
            this.anignoGraphDisplay.GridMaxY = 100F;
            this.anignoGraphDisplay.GridMinY = -100F;
            this.anignoGraphDisplay.Location = new System.Drawing.Point(544, 77);
            this.anignoGraphDisplay.Name = "anignoGraphDisplay";
            this.anignoGraphDisplay.Size = new System.Drawing.Size(416, 276);
            this.anignoGraphDisplay.TabIndex = 12;
            this.anignoGraphDisplay.X_GridLines = 10;
            this.anignoGraphDisplay.Y_GridLines = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 673);
            this.Color1 = System.Drawing.SystemColors.Control;
            this.Color2 = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.anignoGraphDisplay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewStocks);
            this.Controls.Add(this.dataGridViewStockData);
            this.MinimumSize = new System.Drawing.Size(980, 700);
            this.Name = "FormMain";
            this.Text = "Finance Analizer";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStocks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStockData;
        private System.Windows.Forms.DataGridView dataGridViewStocks;
        private System.Windows.Forms.Button buttonAddStocks;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRemoveStock;
        private System.Windows.Forms.Button buttonReport;
        private AnignoLibrary.UI.Graphs.AnignoGraphDisplay anignoGraphDisplay;

    }
}
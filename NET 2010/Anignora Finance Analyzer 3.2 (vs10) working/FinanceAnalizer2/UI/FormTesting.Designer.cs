namespace FinanceAnalizer2.UI
{
    partial class FormTesting
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockData)).BeginInit();
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
            this.dataGridViewStockData.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewStockData.Name = "dataGridViewStockData";
            this.dataGridViewStockData.ReadOnly = true;
            this.dataGridViewStockData.RowHeadersVisible = false;
            this.dataGridViewStockData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStockData.Size = new System.Drawing.Size(1072, 486);
            this.dataGridViewStockData.TabIndex = 3;
            // 
            // FormTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 609);
            this.Controls.Add(this.dataGridViewStockData);
            this.Name = "FormTesting";
            this.Text = "FormTesting";
            this.Load += new System.EventHandler(this.FormTesting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStockData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewStockData;
    }
}
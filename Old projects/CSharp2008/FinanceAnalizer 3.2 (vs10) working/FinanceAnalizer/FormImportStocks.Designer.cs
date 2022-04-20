namespace FinanceAnalizer
{
    partial class FormImportStocks
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
            this.RtfStockList = new System.Windows.Forms.RichTextBox();
            this.buttonStartImport = new System.Windows.Forms.Button();
            this.listBoxStocks = new System.Windows.Forms.ListBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RtfStockList
            // 
            this.RtfStockList.Location = new System.Drawing.Point(12, 25);
            this.RtfStockList.Name = "RtfStockList";
            this.RtfStockList.Size = new System.Drawing.Size(446, 439);
            this.RtfStockList.TabIndex = 0;
            this.RtfStockList.Text = "";
            // 
            // buttonStartImport
            // 
            this.buttonStartImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartImport.Location = new System.Drawing.Point(491, 470);
            this.buttonStartImport.Name = "buttonStartImport";
            this.buttonStartImport.Size = new System.Drawing.Size(93, 23);
            this.buttonStartImport.TabIndex = 7;
            this.buttonStartImport.Text = "Start Import";
            this.buttonStartImport.UseVisualStyleBackColor = true;
            this.buttonStartImport.Click += new System.EventHandler(this.buttonStartImport_Click);
            // 
            // listBoxStocks
            // 
            this.listBoxStocks.FormattingEnabled = true;
            this.listBoxStocks.IntegralHeight = false;
            this.listBoxStocks.Location = new System.Drawing.Point(464, 25);
            this.listBoxStocks.Name = "listBoxStocks";
            this.listBoxStocks.Size = new System.Drawing.Size(120, 439);
            this.listBoxStocks.TabIndex = 8;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.Location = new System.Drawing.Point(12, 470);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(93, 23);
            this.buttonCalculate.TabIndex = 9;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Excel column paste:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Stocks found:";
            // 
            // FormImportStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.listBoxStocks);
            this.Controls.Add(this.buttonStartImport);
            this.Controls.Add(this.RtfStockList);
            this.Name = "FormImportStocks";
            this.Text = "FormImportStocks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox RtfStockList;
        private System.Windows.Forms.Button buttonStartImport;
        private System.Windows.Forms.ListBox listBoxStocks;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
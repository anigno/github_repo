namespace SnpDataExtractor
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
            this.buttonExport = new AnignoraUI.Buttons.ButtonGradientGlow();
            this.labelLastRead = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.graphTimeToFloat1 = new AnignoraUI.Graphs.GraphTimeToFloat();
            this.SuspendLayout();
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExport.BackColor = System.Drawing.Color.Black;
            this.buttonExport.CornerSize = 3;
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.GlowColor = System.Drawing.Color.Blue;
            this.buttonExport.GlowIntensity = ((uint)(100u));
            this.buttonExport.GradientAngle = 270;
            this.buttonExport.GradientColorFirst = System.Drawing.Color.Black;
            this.buttonExport.GradientColorSecond = System.Drawing.Color.Gray;
            this.buttonExport.Location = new System.Drawing.Point(12, 346);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(116, 33);
            this.buttonExport.TabIndex = 0;
            this.buttonExport.Text = "Export To CSV";
            this.buttonExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelLastRead
            // 
            this.labelLastRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelLastRead.AutoSize = true;
            this.labelLastRead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelLastRead.Location = new System.Drawing.Point(134, 366);
            this.labelLastRead.Name = "labelLastRead";
            this.labelLastRead.Size = new System.Drawing.Size(95, 13);
            this.labelLastRead.TabIndex = 1;
            this.labelLastRead.Text = "00/00/0000 00:00";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(134, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Read:";
            // 
            // graphTimeToFloat1
            // 
            this.graphTimeToFloat1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.graphTimeToFloat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.graphTimeToFloat1.GraphColor = System.Drawing.Color.Magenta;
            this.graphTimeToFloat1.GridsColor = System.Drawing.Color.Gray;
            this.graphTimeToFloat1.GridsHorizontal = ((uint)(10u));
            this.graphTimeToFloat1.GridsTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.graphTimeToFloat1.GridsVertical = ((uint)(12u));
            this.graphTimeToFloat1.GridTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.graphTimeToFloat1.Location = new System.Drawing.Point(12, 12);
            this.graphTimeToFloat1.Name = "graphTimeToFloat1";
            this.graphTimeToFloat1.ShowGrids = true;
            this.graphTimeToFloat1.Size = new System.Drawing.Size(667, 331);
            this.graphTimeToFloat1.TabIndex = 3;
            this.graphTimeToFloat1.ZeroLineColor = System.Drawing.Color.White;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(691, 388);
            this.Controls.Add(this.graphTimeToFloat1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelLastRead);
            this.Controls.Add(this.buttonExport);
            this.Name = "FormMain";
            this.Text = "Snp Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnignoraUI.Buttons.ButtonGradientGlow buttonExport;
        private System.Windows.Forms.Label labelLastRead;
        private System.Windows.Forms.Label label2;
        private AnignoraUI.Graphs.GraphTimeToFloat graphTimeToFloat1;

    }
}


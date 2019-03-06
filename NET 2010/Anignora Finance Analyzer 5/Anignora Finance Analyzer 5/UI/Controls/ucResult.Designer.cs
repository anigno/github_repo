namespace AnignoraFinanceAnalyzer5.UI.Controls
{
    partial class ucResult
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ucNumPerLongs = new ucNumPer();
            this.ucNumPerTotal = new ucNumPer();
            this.ucNumPerShorts = new ucNumPer();
            this.SuspendLayout();
            // 
            // ucNumPerLongs
            // 
            this.ucNumPerLongs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucNumPerLongs.Location = new System.Drawing.Point(3, 3);
            this.ucNumPerLongs.Name = "ucNumPerLongs";
            this.ucNumPerLongs.Number = 0;
            this.ucNumPerLongs.Percentage = 0F;
            this.ucNumPerLongs.Size = new System.Drawing.Size(125, 23);
            this.ucNumPerLongs.TabIndex = 0;
            // 
            // ucNumPerTotal
            // 
            this.ucNumPerTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucNumPerTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ucNumPerTotal.Location = new System.Drawing.Point(3, 61);
            this.ucNumPerTotal.Name = "ucNumPerTotal";
            this.ucNumPerTotal.Number = 0;
            this.ucNumPerTotal.Percentage = 0F;
            this.ucNumPerTotal.Size = new System.Drawing.Size(125, 23);
            this.ucNumPerTotal.TabIndex = 1;
            // 
            // ucNumPerShorts
            // 
            this.ucNumPerShorts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucNumPerShorts.Location = new System.Drawing.Point(3, 32);
            this.ucNumPerShorts.Name = "ucNumPerShorts";
            this.ucNumPerShorts.Number = 0;
            this.ucNumPerShorts.Percentage = 0F;
            this.ucNumPerShorts.Size = new System.Drawing.Size(125, 23);
            this.ucNumPerShorts.TabIndex = 2;
            // 
            // ucResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ucNumPerShorts);
            this.Controls.Add(this.ucNumPerTotal);
            this.Controls.Add(this.ucNumPerLongs);
            this.Name = "ucResult";
            this.Size = new System.Drawing.Size(131, 88);
            this.ResumeLayout(false);

        }

        #endregion

        private ucNumPer ucNumPerLongs;
        private ucNumPer ucNumPerTotal;
        private ucNumPer ucNumPerShorts;

    }
}

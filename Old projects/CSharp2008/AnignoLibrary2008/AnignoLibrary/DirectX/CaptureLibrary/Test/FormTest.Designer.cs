namespace AnignoLibrary.DirectX.CaptureLibrary.Test
{
    partial class FormTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAudioCompressors = new System.Windows.Forms.ListBox();
            this.listBoxAudioInputDevices = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxVideoInputDevices = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxVideoCompressors = new System.Windows.Forms.ListBox();
            this.labelVideoCompressors = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Audio Compressors:";
            // 
            // listBoxAudioCompressors
            // 
            this.listBoxAudioCompressors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAudioCompressors.FormattingEnabled = true;
            this.listBoxAudioCompressors.IntegralHeight = false;
            this.listBoxAudioCompressors.Location = new System.Drawing.Point(12, 25);
            this.listBoxAudioCompressors.Name = "listBoxAudioCompressors";
            this.listBoxAudioCompressors.Size = new System.Drawing.Size(153, 205);
            this.listBoxAudioCompressors.TabIndex = 2;
            // 
            // listBoxAudioInputDevices
            // 
            this.listBoxAudioInputDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAudioInputDevices.FormattingEnabled = true;
            this.listBoxAudioInputDevices.IntegralHeight = false;
            this.listBoxAudioInputDevices.Location = new System.Drawing.Point(330, 25);
            this.listBoxAudioInputDevices.Name = "listBoxAudioInputDevices";
            this.listBoxAudioInputDevices.Size = new System.Drawing.Size(153, 93);
            this.listBoxAudioInputDevices.TabIndex = 4;
            this.listBoxAudioInputDevices.SelectedIndexChanged += new System.EventHandler(this.listBoxAudioInputDevices_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Audio Input Devices:";
            // 
            // listBoxVideoInputDevices
            // 
            this.listBoxVideoInputDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxVideoInputDevices.FormattingEnabled = true;
            this.listBoxVideoInputDevices.IntegralHeight = false;
            this.listBoxVideoInputDevices.Location = new System.Drawing.Point(330, 137);
            this.listBoxVideoInputDevices.Name = "listBoxVideoInputDevices";
            this.listBoxVideoInputDevices.Size = new System.Drawing.Size(153, 93);
            this.listBoxVideoInputDevices.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Video Input Devices:";
            // 
            // listBoxVideoCompressors
            // 
            this.listBoxVideoCompressors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxVideoCompressors.FormattingEnabled = true;
            this.listBoxVideoCompressors.IntegralHeight = false;
            this.listBoxVideoCompressors.Location = new System.Drawing.Point(171, 25);
            this.listBoxVideoCompressors.Name = "listBoxVideoCompressors";
            this.listBoxVideoCompressors.Size = new System.Drawing.Size(153, 205);
            this.listBoxVideoCompressors.TabIndex = 6;
            // 
            // labelVideoCompressors
            // 
            this.labelVideoCompressors.AutoSize = true;
            this.labelVideoCompressors.Location = new System.Drawing.Point(168, 9);
            this.labelVideoCompressors.Name = "labelVideoCompressors";
            this.labelVideoCompressors.Size = new System.Drawing.Size(100, 13);
            this.labelVideoCompressors.TabIndex = 5;
            this.labelVideoCompressors.Text = "Video Compressors:";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 547);
            this.Controls.Add(this.listBoxVideoInputDevices);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxVideoCompressors);
            this.Controls.Add(this.labelVideoCompressors);
            this.Controls.Add(this.listBoxAudioInputDevices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxAudioCompressors);
            this.Controls.Add(this.label1);
            this.Name = "FormTest";
            this.Text = "FormTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAudioCompressors;
        private System.Windows.Forms.ListBox listBoxAudioInputDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxVideoInputDevices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxVideoCompressors;
        private System.Windows.Forms.Label labelVideoCompressors;
    }
}
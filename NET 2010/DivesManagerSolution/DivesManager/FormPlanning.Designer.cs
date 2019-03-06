using ucDivePlan=DivesManagerLibrary.ucDivePlan;

namespace DivesManager
{
    partial class FormPlanning
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
            this.labelPlace = new System.Windows.Forms.Label();
            this.buttonData = new System.Windows.Forms.Button();
            this.labelAutoSize1 = new AnignoLibraryMobile.UI.Labels.LabelAutoSize();
            this.ucDivePlan3 = new DivesManagerLibrary.ucDivePlan();
            this.ucDivePlan2 = new DivesManagerLibrary.ucDivePlan();
            this.ucDivePlan1 = new DivesManagerLibrary.ucDivePlan();
            this.SuspendLayout();
            // 
            // labelPlace
            // 
            this.labelPlace.Location = new System.Drawing.Point(88, 0);
            this.labelPlace.Name = "labelPlace";
            this.labelPlace.Size = new System.Drawing.Size(149, 20);
            this.labelPlace.Text = "Place";
            // 
            // buttonData
            // 
            this.buttonData.Location = new System.Drawing.Point(165, 297);
            this.buttonData.Name = "buttonData";
            this.buttonData.Size = new System.Drawing.Size(72, 20);
            this.buttonData.TabIndex = 5;
            this.buttonData.Text = "Data -->";
            this.buttonData.Click += new System.EventHandler(this.buttonData_Click);
            // 
            // labelAutoSize1
            // 
            this.labelAutoSize1.AutoSize = true;
            this.labelAutoSize1.Location = new System.Drawing.Point(3, 0);
            this.labelAutoSize1.Name = "labelAutoSize1";
            this.labelAutoSize1.Size = new System.Drawing.Size(79, 15);
            this.labelAutoSize1.Text = "Dive planning";
            // 
            // ucDivePlan3
            // 
            this.ucDivePlan3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDivePlan3.Depth = 3;
            this.ucDivePlan3.IsFirstDive = false;
            this.ucDivePlan3.Location = new System.Drawing.Point(3, 180);
            this.ucDivePlan3.Name = "ucDivePlan3";
            this.ucDivePlan3.RestingTime = 5;
            this.ucDivePlan3.Size = new System.Drawing.Size(234, 90);
            this.ucDivePlan3.TabIndex = 10;
            this.ucDivePlan3.Time = 5;
            this.ucDivePlan3.OnPropertyChanged += new DivesManagerLibrary.OnPropertyChangedDelegate(this.ucDivePlan3_OnPropertyChanged);
            // 
            // ucDivePlan2
            // 
            this.ucDivePlan2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDivePlan2.Depth = 3;
            this.ucDivePlan2.IsFirstDive = false;
            this.ucDivePlan2.Location = new System.Drawing.Point(3, 84);
            this.ucDivePlan2.Name = "ucDivePlan2";
            this.ucDivePlan2.RestingTime = 5;
            this.ucDivePlan2.Size = new System.Drawing.Size(234, 90);
            this.ucDivePlan2.TabIndex = 9;
            this.ucDivePlan2.Time = 5;
            this.ucDivePlan2.OnPropertyChanged += new DivesManagerLibrary.OnPropertyChangedDelegate(this.ucDivePlan2_OnPropertyChanged);
            // 
            // ucDivePlan1
            // 
            this.ucDivePlan1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDivePlan1.Depth = 3;
            this.ucDivePlan1.IsFirstDive = true;
            this.ucDivePlan1.Location = new System.Drawing.Point(3, 18);
            this.ucDivePlan1.Name = "ucDivePlan1";
            this.ucDivePlan1.RestingTime = 5;
            this.ucDivePlan1.Size = new System.Drawing.Size(234, 60);
            this.ucDivePlan1.TabIndex = 7;
            this.ucDivePlan1.Time = 5;
            this.ucDivePlan1.OnPropertyChanged += new DivesManagerLibrary.OnPropertyChangedDelegate(this.ucDivePlan1_OnPropertyChanged);
            // 
            // FormPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.ucDivePlan3);
            this.Controls.Add(this.ucDivePlan2);
            this.Controls.Add(this.ucDivePlan1);
            this.Controls.Add(this.buttonData);
            this.Controls.Add(this.labelPlace);
            this.Controls.Add(this.labelAutoSize1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FormPlanning";
            this.Text = "FormPlanning";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private AnignoLibraryMobile.UI.Labels.LabelAutoSize labelAutoSize1;
        private System.Windows.Forms.Label labelPlace;
        private System.Windows.Forms.Button buttonData;
        private ucDivePlan ucDivePlan1;
        private ucDivePlan ucDivePlan2;
        private ucDivePlan ucDivePlan3;




    }
}
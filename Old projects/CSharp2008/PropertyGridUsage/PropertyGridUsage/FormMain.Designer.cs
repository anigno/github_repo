namespace PropertyGridUsage
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
            PropertyGridUsage.Driver driver1 = new PropertyGridUsage.Driver();
            PropertyGridUsage.Driver driver2 = new PropertyGridUsage.Driver();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.car1 = new PropertyGridUsage.Car();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(443, 500);
            this.propertyGrid1.TabIndex = 0;
            // 
            // car1
            // 
            this.car1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.car1.BodyColor = System.Drawing.Color.Empty;
            this.car1.CarSize = new System.Drawing.Size(0, 0);
            driver1.Name = "Ami";
            driver1.Role = PropertyGridUsage.Driver.RoleEnum.Manager;
            driver2.Name = null;
            driver2.Role = PropertyGridUsage.Driver.RoleEnum.Manager;
            this.car1.Drivers = new PropertyGridUsage.Driver[] {
        driver1,
        driver2};
            this.car1.Location = new System.Drawing.Point(541, 139);
            this.car1.Name = "car1";
            this.car1.PlateNumber = null;
            this.car1.Price = ((uint)(0u));
            this.car1.Size = new System.Drawing.Size(75, 23);
            this.car1.TabIndex = 1;
            this.car1.Text = "car1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 591);
            this.Controls.Add(this.car1);
            this.Controls.Add(this.propertyGrid1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private Car car1;
    }
}


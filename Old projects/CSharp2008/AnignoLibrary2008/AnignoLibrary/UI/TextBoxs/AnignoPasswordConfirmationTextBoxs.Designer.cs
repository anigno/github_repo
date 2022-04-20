namespace AnignoLibrary.UI.TextBoxs
{
    partial class AnignoPasswordConfirmationTextBoxs
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
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxConfirmation = new System.Windows.Forms.TextBox();
            this.labelContext = new System.Windows.Forms.Label();
            this.labelContextConfirm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(125, 3);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(190, 20);
            this.textBoxPassword.TabIndex = 0;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxConfirmation
            // 
            this.textBoxConfirmation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxConfirmation.Location = new System.Drawing.Point(125, 29);
            this.textBoxConfirmation.Name = "textBoxConfirmation";
            this.textBoxConfirmation.PasswordChar = '*';
            this.textBoxConfirmation.Size = new System.Drawing.Size(190, 20);
            this.textBoxConfirmation.TabIndex = 1;
            this.textBoxConfirmation.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // labelContext
            // 
            this.labelContext.AutoSize = true;
            this.labelContext.Location = new System.Drawing.Point(3, 5);
            this.labelContext.Name = "labelContext";
            this.labelContext.Size = new System.Drawing.Size(56, 13);
            this.labelContext.TabIndex = 2;
            this.labelContext.Text = "Password:";
            // 
            // labelContextConfirm
            // 
            this.labelContextConfirm.AutoSize = true;
            this.labelContextConfirm.Location = new System.Drawing.Point(3, 31);
            this.labelContextConfirm.Name = "labelContextConfirm";
            this.labelContextConfirm.Size = new System.Drawing.Size(116, 13);
            this.labelContextConfirm.TabIndex = 3;
            this.labelContextConfirm.Text = "Password confirmation:";
            // 
            // AnignoPasswordConfirmationTextBoxs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelContextConfirm);
            this.Controls.Add(this.labelContext);
            this.Controls.Add(this.textBoxConfirmation);
            this.Controls.Add(this.textBoxPassword);
            this.Name = "AnignoPasswordConfirmationTextBoxs";
            this.Size = new System.Drawing.Size(318, 54);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxConfirmation;
        private System.Windows.Forms.Label labelContext;
        private System.Windows.Forms.Label labelContextConfirm;
    }
}

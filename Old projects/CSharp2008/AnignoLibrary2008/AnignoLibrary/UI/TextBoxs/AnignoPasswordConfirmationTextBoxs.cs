using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System;

namespace AnignoLibrary.UI.TextBoxs
{
    [DefaultEvent("PasswordChanged")]
    public partial class AnignoPasswordConfirmationTextBoxs : UserControl
    {
		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoPasswordConfirmationTextBoxs";

		#endregion (------  Const Fields  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event EventHandler PasswordChanged;

		#endregion (------  Events  ------)

		#region (------  Constructors  ------)

        public AnignoPasswordConfirmationTextBoxs()
        {
            InitializeComponent();
            SetValidityColors();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        [Category(CATEGORY_STRING),Browsable(false)]
        public bool IsValid
        {
            get { return textBoxPassword.Text == textBoxConfirmation.Text; }
        }

        [Category(CATEGORY_STRING)]
        public char PasswordChar
        {
            get { return textBoxPassword.PasswordChar; }
            set { textBoxPassword.PasswordChar = textBoxConfirmation.PasswordChar = value; }
        }

        [Category(CATEGORY_STRING)]
        public string Context
        {
            get { return labelContext.Text; }
            set
            {
                labelContext.Text = value;
                labelContextConfirm.Text = value + " confirmation";
                textBoxPassword.Left = textBoxConfirmation.Left = labelContextConfirm.Left + labelContextConfirm.Width + 5;
                textBoxPassword.Width = textBoxConfirmation.Width = Width - labelContextConfirm.Width - 5 - 6;
            }
        }

        [Category(CATEGORY_STRING)]
        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = textBoxConfirmation.Text = Text = value; }
        }

		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            SetValidityColors();
            if(IsValid && PasswordChanged!=null)PasswordChanged(this,new EventArgs());
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Private Methods  ------)

        private void SetValidityColors()
        {
            textBoxPassword.BackColor = textBoxConfirmation.BackColor = Color.FromArgb(192, 255, 192);
            if (!IsValid)
            {
                textBoxPassword.BackColor = textBoxConfirmation.BackColor = Color.FromArgb(255, 192, 192);
            }

        }

		#endregion (------  Private Methods  ------)
    }
}
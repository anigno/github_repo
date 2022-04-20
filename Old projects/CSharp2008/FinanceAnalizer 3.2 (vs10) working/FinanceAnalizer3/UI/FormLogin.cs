using System;
using System.Windows.Forms;
using FinanceAnalizer3.Data;

namespace FinanceAnalizer3.UI
{
    public partial class FormLogin : Form
    {
		#region (------------------  Constructors  ------------------)
        public FormLogin()
        {
            InitializeComponent();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Event Handlers  ------------------)
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)CheckPassword();
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void CheckPassword()
        {
            //if (DataManager.Instance.LoginPassword == textBoxPassword.Text)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}

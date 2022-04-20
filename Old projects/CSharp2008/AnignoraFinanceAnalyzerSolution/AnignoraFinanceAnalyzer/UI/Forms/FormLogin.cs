using System;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer.Data;

namespace AnignoraFinanceAnalyzer.UI.Forms
{
    public partial class FormLogin : FormBase
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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)CheckLogin();
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = CommonParams.ApplicationHeader;
        }

		#endregion (------------------  Overridden Methods  ------------------)


		#region (------------------  Private Methods  ------------------)
        private void CheckLogin()
        {
            if (textBoxPassword.Text == DataManager.Instance.LoginPassword)
            {
                DialogResult = DialogResult.OK;
            }
        }
		#endregion (------------------  Private Methods  ------------------)
    }
}

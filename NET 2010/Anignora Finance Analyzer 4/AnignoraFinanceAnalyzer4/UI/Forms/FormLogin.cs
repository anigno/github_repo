using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer4.Data;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.UI.Forms
{
    public partial class FormLogin : Form
    {
		#region (------  Constructors  ------)

        public FormLogin()
        {
            Logger.Log();
            InitializeComponent();
            Username = "";
            Password = 0;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public int Password { get; set; }

        public string Username { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Private Methods  ------)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Password = 0;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Logger.Log();
            Username = textBoxUsername.Text;
            int i;
            bool parsed = int.TryParse(textBoxPassword.Text, out i);
            if (parsed) Password = i;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Text = DataManager.Instance.GetFormHeaderString();
            if (Environment.GetCommandLineArgs().Length >= 3)
            {
                textBoxUsername.Text = Environment.GetCommandLineArgs()[1];
                textBoxPassword.Text = Environment.GetCommandLineArgs()[2];
                buttonOk_Click(null, null);
            }
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) buttonOk_Click(null,null);
        }

		#endregion (------  Private Methods  ------)
    }
}

using System;
using System.ComponentModel;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraIO;
using log4net;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    public partial class FormLogin : Form
    {
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region (------  Constructors  ------)
        public FormLogin()
        {
            InitializeComponent();
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public int AuthenticationCode { get; private set; }

        public int Key { get; private set; }

        public string Username { get; private set; }
		#endregion (------  Properties  ------)

		#region (------  Events Handlers  ------)
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Username = textBoxUsername.Text;
            int parsedKey = 0;
            int.TryParse(textBoxKey.Text, out parsedKey);
            Key = parsedKey;
            AuthenticationCode = authenticate(Username, Key);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Username = "";
            Key = 0;
            AuthenticationCode = -99;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Close();
            string[] commandlineArray = Environment.GetCommandLineArgs();
            if (commandlineArray.Length >= 3)
            {
                string username = commandlineArray[1];
                int key = 0;
                int.TryParse(commandlineArray[2], out key);
                AuthenticationCode = authenticate(username, key);
                if (AuthenticationCode == 0)
                {
                    Username = username;
                    Key = key;
                    Close();
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (AuthenticationCode != 0)
            {
                MessageBox.Show("Authentication Faild, Code=" + AuthenticationCode, "AFA 5", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Private Methods  ------)
        private int authenticate(string p_username, int p_key)
        {
            s_logger.DebugFormat("Authentication Username: {0}",p_username);
            int authenticationCode = MainManager.VerifyUsernameAndKey(p_username, p_key);
            return authenticationCode;
        }
		#endregion (------  Private Methods  ------)
    }
}
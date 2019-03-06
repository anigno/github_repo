using System.ComponentModel;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific;
using log4net;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    public partial class FormSystem : Form
    {
		#region (------  Fields  ------)
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public FormSystem(string p_systemName):this()
        {
            base.Text = p_systemName;   
        }

        public FormSystem()
        {
            InitializeComponent();
        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public UserControlSystem TheSystemControl
        {
            get { return userControlSystemMain; }
        }
		#endregion (------  Properties  ------)

		#region (------  Events Handlers  ------)
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            TheSystemControl.UnregisterEvents();
        }

        private void onFormSystemSizeChanged(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                WindowState = FormWindowState.Minimized;
                Activate();
                s_logger.DebugFormat("After WindowState:{0}", WindowState);
            }
        }
		#endregion (------  Events Handlers  ------)
    }
}
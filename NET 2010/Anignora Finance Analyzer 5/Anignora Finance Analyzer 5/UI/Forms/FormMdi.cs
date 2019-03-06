using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.Configurators;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using log4net;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    public partial class FormMdi : Form
    {
		#region (------  Fields  ------)
        CommonConfigurator m_commonConfigurator;
        private readonly FormMain m_formMain;
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public FormMdi()
        {
            m_formMain = new FormMain();
            InitializeComponent();
            m_formMain.MdiParent = this;
            s_logger.Debug("MDI form created");
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            m_commonConfigurator = new CommonConfigurator(CommonConstants.COMMON_CONFIGURATION_FILENAME);
            m_commonConfigurator.Load();

            base.Text += string.Format(" {0}.{1} [{2}]", Application.ProductVersion, FirstAnalyzerProtector.GetLicensedDate().ToString(), m_commonConfigurator.Configuration.ExtractionOrder);
            s_logger.InfoFormat("{0}",base.Text);
            m_formMain.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            s_logger.Info("MDI form is closing, application will be terminated");
            //Thread.Sleep(200);
            Application.Exit();
            Environment.Exit(-1);
            //base.OnClosing(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            m_formMain.Location=new Point(0,0);
            m_formMain.Size = new Size(this.ClientRectangle.Width-10, this.ClientRectangle.Height-10);
        }
		#endregion (------  Events Handlers  ------)
    }
}

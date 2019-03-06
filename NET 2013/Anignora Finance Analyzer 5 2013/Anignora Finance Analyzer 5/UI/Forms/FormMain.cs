using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific;
using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.ActiveSymbols;
using AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.HistorySymbols;
using AnignoraIO;
using AnignoraUI.Common;
using AnignoraUI.Grids.DataGridViewAuto;
using AnignoraUI.Labels;
using log4net;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    public partial class FormMain : AfaBaseForm
    {
		#region (------  Fields  ------)
        private MainManager m_mainManager;
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public FormMain()
        {
            InitializeComponent();
            dataGridViewAutoActiveSymbolsMain.SetGridRowItemType(typeof(ActiveSymbolItemMain));
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)
        private void onFormMainLoad(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            if (formLogin.AuthenticationCode != 0)
            {
                s_logger.ErrorFormat("Login failed: {0}", formLogin.AuthenticationCode);
                Environment.Exit(formLogin.AuthenticationCode);
            }
            createMainManager(formLogin.Username, formLogin.Key);
            //string[] userAndKey = UsbKeyFinder.GetKey();
            //string username = userAndKey[0];
            //int key = int.Parse(userAndKey[1]);
            //createMainManager(username,key);
            s_logger.Debug("MainFrom loaded");
        }
       
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            s_logger.Debug("FormMain is closing, application will be terminated");
            m_mainManager.Stop();
            Application.Exit();
            Environment.Exit(-1);
        }
        void onMainManagerSystemAdded(AfaSystemBase p_system)
        {
            userControlGeneralSymbolsMain.RegisterSystem(p_system);
            //Add active symbols control to Tab control
            //UserControlActiveSymbols systemActiveSymbolsControl = new UserControlActiveSymbols();
            TabPage newTabPage=new TabPage(p_system.SystemName);
            tabControlColorsActiveResults.TabPages.Add(newTabPage);
            newTabPage.BackColor = tabControlColorsActiveResults.TabControlBackColor;
            //newTabPage.Controls.Add(systemActiveSymbolsControl);
            //systemActiveSymbolsControl.Dock=DockStyle.Fill;

            //systemActiveSymbolsControl.RegisterSystem(p_system);
            //Add button to open system form
            //ButtonSystemOpen buttonSystemOpen=new ButtonSystemOpen(p_system);
            //flowLayoutPanelHeader.Controls.Add(buttonSystemOpen);
            //buttonSystemOpen.MouseClick += labelAsButtonShowSystemMouseClick;

            //Create system's forms
            //FormSystem formSystem = new FormSystem(p_system.SystemName);
            //formSystem.MdiParent=MdiParent;
            //formSystem.TheSystemControl.RegisterEvents(p_system);
            //formSystem.TheSystemControl.SetHistoryAutoGridRowItemType(typeof(AfaSystemFirstHistorySymbolGridRow));
            //formSystem.Show();
            //formSystem.WindowState=FormWindowState.Minimized;
            //m_systemForms.Add(p_system.SystemName,formSystem);
            p_system.SystemActiveSymbolAdded += p_system_SystemActiveSymbolAdded;
            p_system.SystemActiveSymbolRemoved += p_system_SystemActiveSymbolRemoved;
            p_system.SystemActiveSymbolUpdated += p_system_SystemActiveSymbolUpdated;

            UserControlSystem ucSystem=new UserControlSystem();
            ucSystem.RegisterEvents(p_system);
            ucSystem.SetHistoryAutoGridRowItemType(typeof(AfaSystemFirstHistorySymbolGridRow));
            newTabPage.Controls.Add(ucSystem);
            ucSystem.Dock=DockStyle.Fill;
            tabControlColorsActiveResults.SelectTab(newTabPage);
        }

        void p_system_SystemActiveSymbolUpdated(AfaSystemBase p_system, Systems.SystemFirst.AfaFirstCalculator.FirstCalculatorResult p_result)
        {
            addUpdateActiveResult(p_system,p_result);
        }

        void p_system_SystemActiveSymbolRemoved(AfaSystemBase p_system, Systems.SystemFirst.AfaFirstCalculator.FirstCalculatorResult p_result)
        {
            if (!p_system.ProfitSymbol.Contains(p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName)) return;
            string valueToSearch = p_system.SystemName + p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName + p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
            CrossThreadActivities.Do(this, p_main =>
                {
                    dataGridViewAutoActiveSymbolsMain.RemoveRow(valueToSearch, onRowKeyFunc);
                });
        }

        void p_system_SystemActiveSymbolAdded(AfaSystemBase p_system, Systems.SystemFirst.AfaFirstCalculator.FirstCalculatorResult p_result)
        {
            CrossThreadActivities.Do(this, p_main =>
                                               {
                                                   addUpdateActiveResult(p_system, p_result);
                                               });
        }

        private void addUpdateActiveResult(AfaSystemBase p_system, Systems.SystemFirst.AfaFirstCalculator.FirstCalculatorResult p_result)
        {
            if (!p_system.ProfitSymbol.Contains(p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName)) return;
            ActiveSymbolItemMain item = new ActiveSymbolItemMain();
            item.SystemName = p_system.SystemName;
            item.ProfitCut = p_result.ProfitCut;
            item.LossCut = p_result.LossCut;
            item.SymbolName = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName;
            item.DailyChangeRecent = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DailyChangePerRecent;
            item.SignalType = p_result.SignalType;
            item.SignalWeight = p_result.SignalWeight;
            item.Profit = p_result.ProfitPer;
            item.SignalDate = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
            item.SignalResult = p_result.SignalResult;
            item.ClosedDate = p_result.DateClose;
            item.DaysToClose = p_result.DaysToClose;
            dataGridViewAutoActiveSymbolsMain.AddUpdateRow(item,onRowKeyFunc);
        }

        private object onRowKeyFunc(IDataGridViewAutoRowItem p_item)
        {
            return ((ActiveSymbolItemMain) p_item).SystemName + ((ActiveSymbolItemMain) p_item).SymbolName + ((ActiveSymbolItemMain) p_item).SignalDate.ToString();
        }

        protected override void OnActivated(EventArgs e)
        {
            //Prevent this main form from becoming top most in mdi container
            base.OnActivated(e);
            foreach (FormSystem formSystem in m_systemForms.Values)
            {
                formSystem.Activate();
            }
            if(m_formSystemsCalculate!=null)m_formSystemsCalculate.Activate();

        }
        private readonly Dictionary<string,FormSystem> m_systemForms=new Dictionary<string, FormSystem>();

        void labelAsButtonShowSystemMouseClick(object sender, MouseEventArgs e)
        {
            //Show system form
            LabelAsButton labelAsButton=(LabelAsButton)sender;
            AfaSystemBase system = (AfaSystemBase)labelAsButton.Tag;
            FormSystem formSystem = m_systemForms[system.SystemName];
            formSystem.WindowState=formSystem.WindowState==FormWindowState.Minimized?FormWindowState.Normal : FormWindowState.Minimized;
            OnActivated(null);
        }


		#endregion (------  Events Handlers  ------)

		#region (------  Private Methods  ------)
        private void createMainManager(string p_username, int p_key)
        {
            m_mainManager = new MainManager(p_username, p_key);
            m_mainManager.SymbolCalculated += onMainManagerSymbolCalculated;
            m_mainManager.SystemAdded += onMainManagerSystemAdded;
            m_mainManager.RegisterSystemsAndEvents();
            m_mainManager.Start();
        }

        void onMainManagerSymbolCalculated(string p_symbolWebName, Systems.SystemFirst.AfaFirstCalculator.FirstCalculatorResult[] p_calculatedData, bool p_succeeded)
        {
            CrossThreadActivities.Do(this, delegate
                                               {
                                                   labelExtractor.Text = p_symbolWebName;

                                               }
                );
        }

      
		#endregion (------  Private Methods  ------)

        private FormSystemsCalculate m_formSystemsCalculate;

        private void onButtonProfitsCalculationClick(object sender, EventArgs e)
        {
            if (m_formSystemsCalculate == null)
            {
                m_formSystemsCalculate=new FormSystemsCalculate( m_mainManager.ReportsCreatorItem);
                m_formSystemsCalculate.MdiParent = MdiParent;
                m_formSystemsCalculate.Closing += onFormSystemsCalculateClosing;
            }
            m_formSystemsCalculate.Show();
        }

        void onFormSystemsCalculateClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_formSystemsCalculate = null;
        }
    }
}

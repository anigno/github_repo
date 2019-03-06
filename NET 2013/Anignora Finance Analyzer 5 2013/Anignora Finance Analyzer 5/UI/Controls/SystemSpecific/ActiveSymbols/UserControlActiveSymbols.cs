using System;
using System.Drawing;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraUI.Common;
using log4net;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.ActiveSymbols
{
    public partial class UserControlActiveSymbols : UserControl
    {
		#region (------  Constructors  ------)
        public UserControlActiveSymbols()
        {
            InitializeComponent();
            dataGridViewAutoActiveSymbols.SetGridRowItemType(typeof(ActiveSymbolItem));
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)

        void onSystemSystemActiveSymbolRemoved(AfaSystemBase p_system, FirstCalculatorResult p_result)
        {
            CrossThreadActivities.Do(dataGridViewAutoActiveSymbols, delegate
            {
                s_log.DebugFormat("Removing active symbol: {0} signalResult: {1}",p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName,p_result.SignalResult);
                dataGridViewAutoActiveSymbols.RemoveRow(p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName + p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead, p_item => ((ActiveSymbolItem)p_item).SymbolName + ((ActiveSymbolItem)p_item).SignalDate);
            });
        }

        void onSystemSystemActiveSymbolAdded(AfaSystemBase p_system, FirstCalculatorResult p_result)
        {
            CrossThreadActivities.Do(dataGridViewAutoActiveSymbols, delegate
            {
                s_log.DebugFormat("Adding active symbol: {0} signalResult: {1}", p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.WebName, p_result.SignalResult);
                addUpdateActiveSymbolItem(p_result);
            });
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Public Methods  ------)
        public void RegisterSystem(AfaSystemBase p_system)
        {
            labelSystemName.Text = p_system.SystemName;
            p_system.SystemActiveSymbolAdded += onSystemSystemActiveSymbolAdded;
            p_system.SystemActiveSymbolRemoved += onSystemSystemActiveSymbolRemoved;
            p_system.SystemActiveSymbolUpdated += onSystemSystemActiveSymbolUpdated;
        }

        void onSystemSystemActiveSymbolUpdated(AfaSystemBase p_system, FirstCalculatorResult p_result)
        {
            addUpdateActiveSymbolItem(p_result);
        }

        public void UnRegisterSystem()
        {
            //Nothing to do
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private void addUpdateActiveSymbolItem(FirstCalculatorResult p_result)
        {
            
            CrossThreadActivities.Do(this, p_userControlActiveSymbols =>
                {
                    ActiveSymbolItem item = new ActiveSymbolItem();
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
                    dataGridViewAutoActiveSymbols.AddUpdateRow(item, p_item => ((ActiveSymbolItem)p_item).SymbolName + ((ActiveSymbolItem)p_item).SignalDate.ToString());
                });
            //calculate totals
            float dailyTotal = 0;
            float profitTotal = 0;
            foreach (DataGridViewRow row in dataGridViewAutoActiveSymbols.Rows)
            {
                ActiveSymbolItem item = (ActiveSymbolItem)row.Tag;
                //Do not take today in count
                if (item.SignalDate.Date == DateTime.Now.Date) continue;
                float signalMul = item.SignalType == SignalTypeEnum.Short ? -1 : 1;
                dailyTotal += item.DailyChangeRecent * signalMul * item.SignalWeight;
                profitTotal += item.Profit * item.SignalWeight;
            }
            CrossThreadActivities.Do(this, p_userControlActiveSymbols =>
                                               {
                                                   setLabelValueAndColor(labelDailyChange, dailyTotal);
                                                   setLabelValueAndColor(labelProfit, profitTotal);
                                               });
        }

        private void setLabelValueAndColor(Label p_label, float p_value)
        {
            CrossThreadActivities.Do(this, p_userControlActiveSymbols =>
                                               {
                                                   p_label.Text = p_value.ToString("0.00%");
                                                   p_label.ForeColor = p_value < 0 ? Color.Pink : Color.LightGreen;
                                               });
        }

        #endregion (------  Private Methods  ------)
        private static readonly ILog s_log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

       
    }
}

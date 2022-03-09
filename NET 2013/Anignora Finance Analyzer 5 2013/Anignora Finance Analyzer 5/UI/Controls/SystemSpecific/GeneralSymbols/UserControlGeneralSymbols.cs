using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraUI.Common;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.GeneralSymbols
{
    public partial class UserControlGeneralSymbols : UserControl
    {

        #region (------  Fields  ------)
        //private AfaSystemBase m_system;
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public UserControlGeneralSymbols()
        {
            InitializeComponent();
            dataGridViewAutoSymbols.SetGridRowItemType(typeof (GeneralSymbolItem));
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)
        void onSystemProcessingEnded(string p_symbolName, AfaSystemBase p_system, FirstCalculatorResult[] p_results)
        {
            //Generate list of extracted data from calculated results
            //SymbolExtractedData[] symbolExtractedDataArray = p_results.Select(p => p.AnalyzerResult.SymbolExtractedDataItem).ToArray();
            UpdateSymbol(p_symbolName,p_results);
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Public Methods  ------)
        public void RegisterSystem(AfaSystemBase p_system)
        {
            //m_system = p_system;
            p_system.ProcessingEnded += onSystemProcessingEnded;
        }

        // public void UnregisterSystem()
        //{
        //    //m_system.ProcessingEnded -= onSystemProcessingEnded;
        //}

         public void UpdateSymbol(string p_symbolWebName, FirstCalculatorResult[] p_firstCalculatorResults)
         {
             CrossThreadActivities.Do(
                 this, delegate
                           {
                               GeneralSymbolItem generalSymbolItem = new GeneralSymbolItem();
                               generalSymbolItem.DailyChange = (p_firstCalculatorResults[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.Close / p_firstCalculatorResults[1].FirstAnalyzeResultItem.SymbolExtractedDataItem.Close - 1);
                               generalSymbolItem.Close = p_firstCalculatorResults[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                               generalSymbolItem.SymbolName = p_symbolWebName;
                               generalSymbolItem.ReadDate = p_firstCalculatorResults[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                               generalSymbolItem.R1 = p_firstCalculatorResults[0].FirstAnalyzeResultItem.AnalyzedOne;
                               generalSymbolItem.R2Per = p_firstCalculatorResults[0].FirstAnalyzeResultItem.AnalyzedTwoPer;
                               
                               dataGridViewAutoSymbols.AddUpdateRow(generalSymbolItem, p => ((GeneralSymbolItem) p).SymbolName);

                               float dailyTotal = 0;
                               foreach (DataGridViewRow row in dataGridViewAutoSymbols.Rows)
                               {
                                   generalSymbolItem = (GeneralSymbolItem) row.Tag;
                                   dailyTotal += generalSymbolItem.DailyChange;
                               }
                               labelDailyChange.Text = dailyTotal.ToString("0.00%");
                           });
         }

        #endregion (------  Public Methods  ------)

     
         public delegate void SelectionChangedDelegate(GeneralSymbolItem p_generalSymbolItem);
         public event SelectionChangedDelegate SelectedSymbolChanged = delegate { };

         private void dataGridViewAutoSymbols_Click(object sender, System.EventArgs e)
         {
             if (dataGridViewAutoSymbols.SelectedRows.Count == 0) return;
             GeneralSymbolItem item = (GeneralSymbolItem)dataGridViewAutoSymbols.SelectedRows[0].Tag;
             SelectedSymbolChanged(item);
         } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.UI.Controls.SystemSpecific.HistorySymbols
{
    public partial class UserControlHystorySymbols : UserControl
    {
		#region (------  Fields  ------)
        private readonly Dictionary<string,IHistoryGridRowItem[]> m_historyItemsDictionary=new Dictionary<string, IHistoryGridRowItem[]>();
        private string m_lastSymbolNameSelected = null;
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public UserControlHystorySymbols()
        {
            InitializeComponent();
        }
		#endregion (------  Constructors  ------)

		#region (------  Events Handlers  ------)
        void p_system_ProcessingEnded(string p_symbolName, AfaSystemBase p_system, FirstCalculatorResult[] p_results)
        {
            lock (m_historyItemsDictionary)
            {
                AfaSystemFirstHistorySymbolGridRow[] afaSystemFirstHistorySymbolGridRows = p_results.Select(p_calculatorResult => new AfaSystemFirstHistorySymbolGridRow(p_calculatorResult)).ToArray();
                if (!m_historyItemsDictionary.ContainsKey(p_symbolName))
                {
                    m_historyItemsDictionary.Add(p_symbolName, new IHistoryGridRowItem[0]);
                }
                m_historyItemsDictionary[p_symbolName] = afaSystemFirstHistorySymbolGridRows;
            }
        }
        private void onNumericUpDownHistoryLengthValueChanged(object sender, EventArgs e)
        {
            dataGridViewAutoHistory.Rows.Clear();
            UpdateHistoryDisplayedData();
        }
		#endregion (------  Events Handlers  ------)

		#region (------  Public Methods  ------)
        public void RegisterSystem(AfaSystemBase p_system)
        {
            p_system.ProcessingEnded += p_system_ProcessingEnded;
        }

        /// <summary>
        /// Set the row item for the DataGridViewAuto control. Item's type must implement IHistoryGridRowItem
        /// </summary>
        public void SetAutoGridItemType(Type p_type)
        {
            dataGridViewAutoHistory.SetGridRowItemType(p_type);
        }

        public void UpdateHistoryDisplayedData(string p_symbolName=null)
        {
            if (p_symbolName != null)
            {
                m_lastSymbolNameSelected = p_symbolName;
            }
            labelMessage.Text = m_lastSymbolNameSelected;
            if (m_lastSymbolNameSelected == null) return;
            if (!m_historyItemsDictionary.ContainsKey(m_lastSymbolNameSelected)) return;
            IHistoryGridRowItem[] symbolHistoryDataArray = m_historyItemsDictionary[m_lastSymbolNameSelected];
            int requestedDays = (int) numericUpDownHistoryLength.Value;
            int nDays = symbolHistoryDataArray.Length < requestedDays ? symbolHistoryDataArray.Length : requestedDays;
            graphDateToFloatHistory.ClearAllPoints();
            for (int a = 0; a < nDays; a++)
            {
                IHistoryGridRowItem rowItem=symbolHistoryDataArray[a];
                dataGridViewAutoHistory.AddUpdateRow(rowItem, p_item => ((IHistoryGridRowItem) p_item).ReadDate);
                graphDateToFloatHistory.AddPointDateFloat(rowItem.ReadDate,rowItem.Close);
            }
            graphDateToFloatHistory.RedrawGraph();
        }
		#endregion (------  Public Methods  ------)
    }
}

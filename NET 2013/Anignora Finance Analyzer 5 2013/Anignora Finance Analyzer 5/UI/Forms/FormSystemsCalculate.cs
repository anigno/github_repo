using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems;
using log4net;

namespace AnignoraFinanceAnalyzer5.UI.Forms
{
    public partial class FormSystemsCalculate : Form
    {
        #region (------  Fields  ------)

        private readonly ReportsCreator m_reportsCreator;
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion (------  Fields  ------)

        #region (------  Constructors  ------)

        public FormSystemsCalculate(ReportsCreator p_reportsCreator)
        {
            m_reportsCreator = p_reportsCreator;
            //m_mainManager = p_mainManager;
            InitializeComponent();
            buildSystemsTree(p_reportsCreator.Systems);

        }

        #endregion (------  Constructors  ------)

        #region (------  Events Handlers  ------)

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (WindowState == FormWindowState.Maximized)
            {
                Close();
            }
        }

        #endregion (------  Events Handlers  ------)

        #region (------  Private Methods  ------)

        private void buildSystemsTree(AfaSystemBase[] p_systems)
        {
            s_logger.Debug("");
            TreeNode treeNodeSystems = treeViewSymbols.Nodes.Add("Systems", "Systems");
            foreach (AfaSystemBase system in p_systems)
            {
                TreeNode treeNodeSystem = treeNodeSystems.Nodes.Add(system.SystemName, system.SystemName);
                treeNodeSystem.Tag = system;
                foreach (string symbolName in system.SymbolsWebNames)
                {
                    TreeNode symbolNode = treeNodeSystem.Nodes.Add(symbolName, symbolName);
                    symbolNode.Tag = symbolName;
                    if (system.ProfitSymbol.Contains(symbolName )) symbolNode.Checked = true;
                }
            }
            treeNodeSystems.ExpandAll();
        }

        private List<SystemSymbolPair> collectSystemSymbolPairs()
        {
            List<SystemSymbolPair> systemSymbolPairs = new List<SystemSymbolPair>();
            //Build SystemSymbolPair[] for selected symbols
            TreeNodeCollection systemsNodes = treeViewSymbols.Nodes[0].Nodes;
            foreach (TreeNode systemNode in systemsNodes)
            {
                AfaSystemBase system = (AfaSystemBase)systemNode.Tag;
                foreach (TreeNode symbolNode in systemNode.Nodes)
                {
                    if (!symbolNode.Checked) continue;
                    string symbolName = (string)symbolNode.Tag;
                    systemSymbolPairs.Add(new SystemSymbolPair(system, symbolName));
                }
            }
            return systemSymbolPairs;
        }

        private void buttonCalculateClick(object sender, EventArgs e)
        {
            List<SystemSymbolPair> systemSymbolPairs = collectSystemSymbolPairs();
            ProfitCalculationItem[] profitCalculationItems = m_reportsCreator.CalculateProfit(systemSymbolPairs.ToArray(), checkBoxSymbolsReport.Checked);
            //All systems symbols data is set, calculate totals
            updateUi(profitCalculationItems);
            //Create report
            m_reportsCreator.CreateTotalProfitReport(profitCalculationItems);
        }

        private void buttonCreateDebugClick(object sender, EventArgs e)
        {
            List<SystemSymbolPair> systemSymbolPairs = collectSystemSymbolPairs();
            foreach (SystemSymbolPair pair in systemSymbolPairs)
            {
                m_reportsCreator.CreateDebugReport(pair);
            }
        }

        private void recursiveCheckUnCheck(TreeNode p_node)
        {
            foreach (TreeNode node in p_node.Nodes)
            {
                recursiveCheckUnCheck(node);
                node.Checked = p_node.Checked;
            }
        }

        private void treeViewSymbolsAfterCheck(object sender, TreeViewEventArgs e)
        {
            recursiveCheckUnCheck(e.Node);
        }

        private void treeViewSymbolsAfterCollapse(object sender, TreeViewEventArgs e)
        {
            treeViewSymbols.ExpandAll();
        }

        private void updateUi(ProfitCalculationItem[] p_orderedCalculationItems)
        {
            graphDateToFloatHistory.ClearAllPoints();
            ProfitCalculationItem totals = new ProfitCalculationItem(DateTime.Now);
            foreach (ProfitCalculationItem item in p_orderedCalculationItems)
            {
                if (item.DateRead < dateTimePickerFrom.Value) continue;
                if (item.DateRead > dateTimePickerTo.Value) continue;

                totals.ProfitDaily += item.ProfitDaily;

                totals.LongHits += item.LongHits;
                totals.LongHitsProfit += item.LongHitsProfit;
                totals.LongMisses += item.LongMisses;
                totals.LongMissesProfit += item.LongMissesProfit;

                totals.ShortHits += item.ShortHits;
                totals.ShortHitsProfit += item.ShortHitsProfit;
                totals.ShortMisses += item.ShortMisses;
                totals.ShortMissesProfit += item.ShortMissesProfit;

                graphDateToFloatHistory.AddPointDateFloat(item.DateRead, totals.ProfitDaily);
            }
            graphDateToFloatHistory.RedrawGraph();

            ucResultHits.Longs.Number = totals.LongHits;
            ucResultHits.Longs.Percentage = totals.LongHitsProfit;
            ucResultHits.Shorts.Number = totals.ShortHits;
            ucResultHits.Shorts.Percentage = totals.ShortHitsProfit;
            ucResultHits.Total.Number = totals.LongHits + totals.ShortHits;
            ucResultHits.Total.Percentage = totals.LongHitsProfit + totals.ShortHitsProfit;

            ucResultMisses.Longs.Number = totals.LongMisses;
            ucResultMisses.Longs.Percentage = totals.LongMissesProfit;
            ucResultMisses.Shorts.Number = totals.ShortMisses;
            ucResultMisses.Shorts.Percentage = totals.ShortMissesProfit;
            ucResultMisses.Total.Number = totals.LongMisses + totals.ShortMisses;
            ucResultMisses.Total.Percentage = totals.LongMissesProfit + totals.ShortMissesProfit;

            ucResultTotal.Longs.Number = totals.LongHits + totals.LongMisses;
            ucResultTotal.Longs.Percentage = totals.LongHitsProfit + totals.LongMissesProfit;
            ucResultTotal.Shorts.Number = totals.ShortHits + totals.ShortMisses;
            ucResultTotal.Shorts.Percentage = totals.ShortHitsProfit + totals.ShortMissesProfit;
            ucResultTotal.Total.Number = totals.LongHits + totals.ShortHits + totals.LongMisses + totals.ShortMisses;
            ucResultTotal.Total.Percentage = totals.LongHitsProfit + totals.ShortHitsProfit + totals.LongMissesProfit + totals.ShortMissesProfit;



        }

        #endregion (------  Private Methods  ------)


       
    }
}
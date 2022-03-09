using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraUI;
using AnignoraUI.Common;

namespace SnpDataExtractor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            DataManager.Instance.LoadData();
            DataManager.Instance.OnDataExtracted += Manager_OnDataExtracted;
            DataManager.Instance.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            DataManager.Instance.Stop();
            DataManager.Instance.OnDataExtracted -= Manager_OnDataExtracted;
            DataManager.Instance.SaveData();
        }

        void Manager_OnDataExtracted(DateTime receivedDateTime)
        {
            IEnumerable<SymbolDailyData> v = DataManager.Instance.GetRecentDateData();
            CrossThreadActivities.Do(labelLastRead,l=>l.Text=DateTime.Now.ToString());
            graphTimeToFloat1.ClearAllPoints();
            foreach(SymbolDailyData d in v)
            {
                graphTimeToFloat1.AddPointTimeFloat(d.ReadDate,d.Close);
            }
            CrossThreadActivities.Do(graphTimeToFloat1,g=>g.RedrawGraph());
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            DataManager.Instance.ExportToCsv();
        }

     
    }
}

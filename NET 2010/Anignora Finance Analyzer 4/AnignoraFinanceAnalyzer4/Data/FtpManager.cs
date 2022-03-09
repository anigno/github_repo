using System;
using System.Text;
using System.Windows.Forms;
using AnignoraCommunication.FTP;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;

namespace AnignoraFinanceAnalyzer4.Data
{
    public class FtpManager
    {
        private readonly AnignoFtpClient m_ftpClient = new AnignoFtpClient(DataManager.Instance.ApplicationDataItem.FtpServerName, DataManager.Instance.ApplicationDataItem.FtpUsername, DataManager.Instance.ApplicationDataItem.FtpPassword);

        public void FtpUpdate()
        {
            SymbolDailyDataAnalyzed[] activeSymbols = DataManager.Instance.GetActiveSymbols();

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<head><title>Anignora Finance Analyzer</title></head>");
            sb.Append("<BODY bgcolor=\"#000000\" text=\"#FFFFFF\" link=\"#FFFFFF\" vlink=\"#FFFFFF\">");
            sb.Append(DateTime.Now + "<BR>");
            sb.Append("Anignora Finance Analyzer " + Application.ProductVersion + "<BR>");
            sb.Append("<TABLE border=1>");
            sb.Append("<TR><TD>Name</TD><TD>Date</TD><TD>Signal Type</TD><TD>Signal%</TD><TD>Signal HitMiss</TD><TD>Conditioned Date</TD><TD>Doubler Date</TD><TD>Daily Change%</TD></TR>");
            foreach (SymbolDailyDataAnalyzed symbolData in activeSymbols)
            {
                sb.Append("<TR>");
                string s = string.Format(
                    "<TD>{0}</TD><TD>{1}</TD><TD>{2}</TD><TD>{3}</TD><TD>{4}</TD><TD>{5}</TD><TD>{6}</TD><TD>{7}</TD>",
                    symbolData.Descriptor,
                    symbolData.ReadDate.ToShortDateString(),
                    symbolData.SignalType,
                    (symbolData.SignalToDateChangePer * 100).ToString("0.00"),
                    symbolData.SignalHitMiss == SymbolDailyDataAnalyzed.SignalHitMissEnum.None ? "" : symbolData.SignalHitMiss.ToString(),
                    symbolData.ConditionedDate == DateTime.MinValue ? "" : symbolData.ConditionedDate.ToShortDateString(),
                    symbolData.DoublerFirstDate.ToShortDateString(),
                    (symbolData.DailyChangePerRecent * 100).ToString("0.00")
                    );
                sb.Append(s);
                sb.Append("</TR>");
            }
            sb.Append("</TABLE><BR>");
            sb.Append("Daily change: " + (DataManager.Instance.ActiveDailyChangePer*100).ToString("0.00") + "<BR>");
            sb.Append("Signal Change: "+(DataManager.Instance.ActiveSignalChangePer*100).ToString("0.00")+"<BR>");
            sb.Append("<BR>");
            sb.Append(DataManager.Instance.ApplicationDataItem.Username);
            sb.Append("<BR>");
            sb.Append("<body>");
            sb.Append("</html>");
            
            m_ftpClient.UploadString(sb.ToString(), DataManager.Instance.ApplicationDataItem.Username+@"_index.html");
        }
    }
}
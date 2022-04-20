using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System;
using FinanceAnalyzerData.Data;

namespace FinanceAnalizer3.Data
{
    [Serializable]
    public class ApplicationData
    {
		#region (------------------  Fields  ------------------)
        internal readonly Dictionary<string, List<DayChangeDataAnalyzed>> stocksData = new Dictionary<string, List<DayChangeDataAnalyzed>>();
        internal readonly List<string> stocksInHeader = new List<string>();
        private string loginPassword = "anignora";
        private int positionsSum=10000;
        private int positionsDevider=1;
        private string browserAHomePage = "www.google.com";
        private string browserBHomePage = "www.google.com";
        #endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        internal ApplicationData()
        {
            VersionSaved = Application.ProductVersion;
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        internal string VersionSaved { get; private set; }

        public string LoginPassword
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }

        public int PositionsSum
        {
            get { return positionsSum; }
            set { positionsSum = value; }
        }

        public int PositionsDevider
        {
            get { return positionsDevider; }
            set { positionsDevider = value; }
        }

        public string BrowserAHomePage
        {
            get { return browserAHomePage; }
            set { browserAHomePage = value; }
        }

        public string BrowserBHomePage
        {
            get { return browserBHomePage; }
            set { browserBHomePage = value; }
        }

        #endregion (------------------  Properties  ------------------)


		#region (------------------  Methods  ------------------)
        internal string[] GetStocksNamesArray()
        {
            return stocksData.Keys.ToArray();
        }

        internal bool IsStockExists(string stockName)
        {
            return stocksData.Keys.Contains(stockName);
        }
		#endregion (------------------  Methods  ------------------)
    }
}

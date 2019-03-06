using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LoggingProvider;

namespace FinanceAnalizer.Data
{
    public class ApplicationData
    {
		#region (------------------  Const Fields  ------------------)
        public const string CONNECTION_STRING = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=FinanceAnalizerDB.mdb";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private DateTime lastRun = DateTime.MinValue;
        private int maxStockUpdateList = 200;
        private int updatesIntervalInMinutes=5;
        private List<StockData> stockDataList = new List<StockData>();
        private readonly object _syncRoot = new object();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Properties  ------------------)
        public DateTime LastRun
        {
            get
            {
                lock (_syncRoot)
                {
                    return lastRun;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    lastRun = value;
                }
            }
        }

        public int MaxStockUpdateList
        {
            get
            {
                lock (_syncRoot)
                {
                    return maxStockUpdateList;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    maxStockUpdateList = value;
                }
            }
        }

        public int UpdatesIntervalInMinutes
        {
            get { return updatesIntervalInMinutes; }
            set { updatesIntervalInMinutes = value; }
        }

        public List<StockData> StockDataList
        {
            get
            {
                lock (_syncRoot)
                {
                    return stockDataList;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    stockDataList = value;
                }
            }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Public Methods  ------------------)
        public bool ContainsStockName(string stockName)
        {
            return GetStockData(stockName) != null;
        }

        public StockData GetNextStockToUpdate()
        {
            lock (_syncRoot)
            {
                DateTime dateLast = DateTime.MaxValue;
                StockData stockToUpdate = null;
                foreach (StockData stockData in StockDataList)
                {
                    if (stockData.LastUpdated < dateLast)
                    {
                        stockToUpdate = stockData;
                        dateLast = stockData.LastUpdated;
                    }
                }
                return stockToUpdate;
            }
        }

        public StockData GetStockData(string stockName)
        {
            lock (_syncRoot)
            {
                foreach (StockData data in StockDataList)
                {
                    if (data.Name.ToUpper() == stockName.ToUpper()) return data;
                }
                return null;
            }
        }

        public void StockDataListAdd(StockData stockData)
        {
            lock (_syncRoot)
            {
                StockDataList.Add(stockData);
            }
        }

        public void StockDataListRemove(StockData stockData)
        {
            lock (_syncRoot)
            {
                StockDataList.Remove(stockData);
            }
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using System.IO;
using System.Timers;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraFinanceAnalyzer4.WebExtractors;

namespace SnpDataExtractor
{
    public class DataManager
    {
		#region (------  Const Fields  ------)

        private const string DATA_FILE_NAME = "SnpData.dat";
        private const string INDEX_SYMBOL = "^GSPC";
        private const double PERIODIC_INTERVAL = 1000 * 60;

		#endregion (------  Const Fields  ------)

		#region (------  Static Fields  ------)

        private static DataManager _instance = null;

		#endregion (------  Static Fields  ------)

		#region (------  Fields  ------)

        private readonly object _syncRoot=new object();
        private readonly BinaryFormatter bf = new BinaryFormatter();
        public List<AnignoraFinanceAnalyzer4.Data.SymbolsDataItems.SymbolDailyData> DailyData = new List<SymbolDailyData>();
        private readonly AnignoraFinanceAnalyzer4.WebExtractors.ExtractorBase extractor = new ExtractorFromYahooOnly();
        private readonly Random RND=new Random(DateTime.Now.Millisecond);
        private readonly Timer timerPeriodic = new Timer(PERIODIC_INTERVAL);

		#endregion (------  Fields  ------)

		#region (------  Properties  ------)

        public static DataManager Instance
        {
            get
            {
                if (_instance == null) _instance = new DataManager();
                return _instance;
            }
        }

		#endregion (------  Properties  ------)

		#region (------  Delegates  ------)

        public delegate void OnDataExtractedDelegate(DateTime receivedDateTime);

		#endregion (------  Delegates  ------)

		#region (------  Events  ------)

        public event OnDataExtractedDelegate OnDataExtracted;

		#endregion (------  Events  ------)

		#region (------  Event Handlers  ------)

        void timerPeriodic_Elapsed(object sender, ElapsedEventArgs e)
        {
            timerPeriodic.Stop();
            SymbolDailyData receivedDailyData=extractor.GetRealTimeData(INDEX_SYMBOL);
            receivedDailyData.ReadDate = receivedDailyData.ReadDate.AddHours(DateTime.Now.Hour);
            receivedDailyData.ReadDate = receivedDailyData.ReadDate.AddMinutes(DateTime.Now.Minute);
            receivedDailyData.ReadDate = receivedDailyData.ReadDate.AddSeconds(DateTime.Now.Second);
            lock (_syncRoot)
            {
                SymbolDailyData recentData;
                if (DailyData.Count > 0)
                {
                    recentData = DailyData[DailyData.Count - 1];
                }
                else
                {
                    recentData = new SymbolDailyData(INDEX_SYMBOL);
                }
                if (
                    recentData.Open != receivedDailyData.Open ||
                    recentData.Close != receivedDailyData.Close ||
                    recentData.High != receivedDailyData.High ||
                    recentData.Low != receivedDailyData.Low
                    )
                {
                    DailyData.Add(receivedDailyData);
                    if (OnDataExtracted != null) OnDataExtracted(receivedDailyData.ReadDate);
                }
            }
            timerPeriodic.Start();
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Constructors  ------)

        private DataManager()
        {
            //Singleton requirement
        }

		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)

        public void AddTestData()
        {
            SymbolDailyData receivedDailyData=new SymbolDailyData(INDEX_SYMBOL);
            receivedDailyData.Close = RND.Next(-10, 10);
            receivedDailyData.ReadDate = DateTime.Now;
            DailyData.Add(receivedDailyData);
            if (OnDataExtracted != null) OnDataExtracted(receivedDailyData.ReadDate);
        }

        public void ExportToCsv()
        {
            lock(_syncRoot)
            {
                TextWriter tw = new StreamWriter("Snp_" + DateTime.Now.ToFileTime()+".csv");
                tw.WriteLine("ReadDate,Open,Close,High,Low");
                foreach (SymbolDailyData d in DailyData)
                {
                    tw.WriteLine("{0},{1},{2},{3},{4}",d.ReadDate,d.Open,d.Close,d.High,d.Low);
                }
                tw.Close();
            }
        }

        public IEnumerable<AnignoraFinanceAnalyzer4.Data.SymbolsDataItems.SymbolDailyData> GetRecentDateData()
        {
            lock(_syncRoot)
            {
                DateTime recentDate = DailyData[DailyData.Count - 1].ReadDate;
                IEnumerable<SymbolDailyData> v = DailyData.Where(n => n.ReadDate.Date == recentDate.Date).ToList();
                return v;
            }
        }

        public void LoadData()
        {
            lock (_syncRoot)
            {
                if (!File.Exists(DATA_FILE_NAME)) SaveData();
                FileStream fs = new FileStream(DATA_FILE_NAME, FileMode.Open);
                DailyData = (List<SymbolDailyData>) bf.Deserialize(fs);
                fs.Close();
            }
        }

        public void SaveData()
        {
            lock (_syncRoot)
            {
                FileStream fs = new FileStream(DATA_FILE_NAME, FileMode.Create);
                bf.Serialize(fs, DailyData);
                fs.Close();
            }
        }

        public void Start()
        {
            timerPeriodic.Elapsed += timerPeriodic_Elapsed;
            timerPeriodic.Start();
        }

        public void Stop()
        {
            timerPeriodic.Stop();
            timerPeriodic.Elapsed -= timerPeriodic_Elapsed;
        }

		#endregion (------  Public Methods  ------)
    }
}
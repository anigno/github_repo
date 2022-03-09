using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Xml.Serialization;
using AnignoraCommunication.Email;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace AnignoraFinanceAnalyzer4.Data
{
    public class DataManager
    {
		#region (------  Fields  ------)

        private const string APPLICATION_DATA_FILE = "Data\\ApplicationData.xml";
        public const string INDEX_SYMBOL = "^GSPC";
        private float m_activeDailyChangePer;
        private float m_activeSignalChangePer;
        private readonly Dictionary<string, SymbolDailyDataAnalyzed> m_activeSymbolsDictionary = new Dictionary<string, SymbolDailyDataAnalyzed>();
        private readonly EmailSendingService m_emailService=new EmailSendingService();
        private int m_longsShorts;
        private readonly SmtpClientByGmail m_smtpClient;
        private readonly Dictionary<string, SymbolData> m_symbolsDataDictionary = new Dictionary<string, SymbolData>();
        private readonly Timer m_timerSendEmail=new Timer(60000);
        private static DataManager s_instance;
        private const string SYMBOLS_TEXT_FILE = "Data\\Symbols.txt";
        private static readonly object SYNC_ROOT_OBJECT = new object();

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        //Singleton pattern ctor
        private DataManager()
        {
            Logger.Log();
            LoadSymbols();
            LoadApplicationData();
            m_smtpClient = new SmtpClientByGmail(ApplicationDataItem.SenderEmail, ApplicationDataItem.SenderEmailPassword, 10000);
            m_timerSendEmail.Elapsed += onTimerSendEmailElapsed;
            m_timerSendEmail.Start();
            m_emailService.Start();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public float ActiveDailyChangePer
        {
            get
            {
                lock (SYNC_ROOT_OBJECT)
                {
                    return m_activeDailyChangePer;
                }
            }
            private set { m_activeDailyChangePer = value; }
        }

        public float ActiveSignalChangePer
        {
            get
            {
                lock (SYNC_ROOT_OBJECT)
                {
                    return m_activeSignalChangePer;
                }
            }
            private set { m_activeSignalChangePer = value; }
        }

        public ApplicationData ApplicationDataItem { get; private set; }

        public static DataManager Instance
        {
            get
            {
                lock (SYNC_ROOT_OBJECT)
                {
                    if (s_instance == null)
                    {
                        s_instance = new DataManager();
                    }
                    return s_instance;
                }
            }
        }

        public int LongsMinusShorts
        {
            get
            {
                lock (SYNC_ROOT_OBJECT)
                {
                    return m_longsShorts;
                }
            }
            private set
            {
                lock (SYNC_ROOT_OBJECT)
                {
                    m_longsShorts = value;
                }
            }
        }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

        public void AddUpdateActiveSymbol(SymbolDailyDataAnalyzed p_symbolData)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                string key = p_symbolData.Descriptor + p_symbolData.ReadDate.ToShortDateString();
                if (m_activeSymbolsDictionary.ContainsKey(key))
                {
                    //Update
                    m_activeSymbolsDictionary[key] = p_symbolData;
                }
                else
                {
                    //Add
                    m_activeSymbolsDictionary.Add(key, p_symbolData);
                }
            }
        }

        public void AddUpdateSymbolData(string p_descriptor, SymbolDailyDataAnalyzed[] p_receivedData)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                p_receivedData = p_receivedData.OrderByDescending(p_item => p_item.ReadDate).ToArray();

                SymbolData knownSymbolData = m_symbolsDataDictionary[p_descriptor];
                for (int receivedIndex = p_receivedData.Length - 1; receivedIndex >= 0; receivedIndex--)
                {
                    SymbolDailyDataAnalyzed dailyDataReceived = p_receivedData[receivedIndex];
                    SymbolDailyDataAnalyzed dailyData = GetSymbolDailyDataAnalyzed(p_descriptor, dailyDataReceived.ReadDate);
                    //Check if data date exists or new
                    if (dailyData == null)
                    {
                        //new data received
                        knownSymbolData.DailyDataList.Insert(0, dailyDataReceived);
                        //Verifies last added is real trade
                        if (knownSymbolData.DailyDataList.Count > 2)
                        {
                            if (IsNoTrade(knownSymbolData.DailyDataList[0], knownSymbolData.DailyDataList[1]))
                            {
                                //No trade, last added will be removed
                                knownSymbolData.DailyDataList.RemoveAt(0);
                            }
                        }
                    }
                    else
                    {
                        //known data received
                        dailyData.Update(dailyDataReceived);
                    }
                }
                //Sort known data
                knownSymbolData.DailyDataList = knownSymbolData.DailyDataList.OrderByDescending(p_item => p_item.ReadDate).ToList();
            }
        }

        public void CloseServices()
        {
            Logger.Log();
            SaveApplicationData();
            m_emailService.Stop();
            m_timerSendEmail.Stop();
        }

        public static SymbolDailyDataAnalyzed[] ConvertSymbolExtractedDataToEmptyAnalyzedData(SymbolDailyData[] symbolDailyDataArray)
        {
            SymbolDailyDataAnalyzed[] symbolDailyDataAnalyzedArray = new SymbolDailyDataAnalyzed[symbolDailyDataArray.Length];
            for (int i = 0; i < symbolDailyDataArray.Length; i++)
            {
                symbolDailyDataAnalyzedArray[i] = new SymbolDailyDataAnalyzed(symbolDailyDataArray[i].Descriptor, symbolDailyDataArray[i]);
            }
            return symbolDailyDataAnalyzedArray;
        }

        public SymbolDailyDataAnalyzed[] GetActiveSymbols()
        {
            lock (SYNC_ROOT_OBJECT)
            {
                SymbolDailyDataAnalyzed[] ret = new SymbolDailyDataAnalyzed[m_activeSymbolsDictionary.Values.Count];
                m_activeSymbolsDictionary.Values.CopyTo(ret, 0);
                return ret;
            }
        }

        public static string GetLongsShortsString(int longsShorts)
        {
            string snpString = longsShorts > 0 ? " Longs" : " Shorts";
            if (longsShorts == 0) return "None";
            return Math.Abs(longsShorts) + snpString;
        }

        public string GetMostOffdatedSymbol()
        {
            lock (SYNC_ROOT_OBJECT)
            {
                string retDescriptor = "";
                DateTime minDateTime = DateTime.MaxValue;
                foreach (SymbolData symbolData in m_symbolsDataDictionary.Values)
                {
                    if (symbolData.LastUpdateTryTime < minDateTime)
                    {
                        retDescriptor = symbolData.Descriptor;
                        minDateTime = symbolData.LastUpdateTryTime;
                    }
                }
                //Set to Now, so it won't be selected again until all other symbols were selected
                m_symbolsDataDictionary[retDescriptor].LastUpdateTryTime = DateTime.Now;
                return retDescriptor;
            }
        }

        public SymbolDailyDataAnalyzed[] GetSymbolDailyDataAnalyzed(string descriptor)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                return m_symbolsDataDictionary[descriptor].DailyDataList.ToArray();
            }
        }

        public SymbolDailyDataAnalyzed[] GetSymbolDailyDataAnalyzed(string descriptor, int nItems)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                if (descriptor == null) return new SymbolDailyDataAnalyzed[0];
                SymbolData symbolData = m_symbolsDataDictionary[descriptor];
                if (symbolData.DailyDataList.Count < nItems)
                {
                    Logger.LogWarning("Requested:{0} nItems:{1} but exists:{2}",descriptor,nItems,symbolData.DailyDataList.Count);
                    return symbolData.DailyDataList.ToArray();
                }
                return symbolData.DailyDataList.GetRange(0, nItems).ToArray();
            }
        }

        public SymbolDailyDataAnalyzed GetSymbolDailyDataAnalyzed(string descriptor, DateTime date)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                date = date.Date;
                SymbolData symbolData = m_symbolsDataDictionary[descriptor];
                return GetSymbolDailyDataAnalyzed(symbolData.DailyDataList, date);
            }
        }

        public SymbolDailyDataAnalyzed GetSymbolDailyDataAnalyzed(List<SymbolDailyDataAnalyzed> p_dailyDataList,DateTime p_date)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                p_date = p_date.Date;
                foreach (SymbolDailyDataAnalyzed dailyData in p_dailyDataList)
                {
                    if (dailyData.ReadDate == p_date) return dailyData;
                }
                return null;
            }
        }

        public DateTime GetSymbolRecentDate(string descriptor)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                if (m_symbolsDataDictionary[descriptor].DailyDataList.Count == 0) return SymbolDailyData.MINIMUM_DATE;
                return m_symbolsDataDictionary[descriptor].DailyDataList[0].ReadDate;
            }
        }

        public int GetSymbolsCount()
        {
            return m_symbolsDataDictionary.Count;
        }

        public string[] GetSymbolsDescriptors()
        {
            string[] saRet=new string[m_symbolsDataDictionary.Count];
            m_symbolsDataDictionary.Keys.CopyTo(saRet,0);
            return saRet;
        }

        public int GetUpdatedSymbolsCount()
        {
            int i = 0;
            lock(SYNC_ROOT_OBJECT)
            {
                foreach(SymbolData data in m_symbolsDataDictionary.Values)
                {
                    if (data.DailyDataList.Count > 0) i++;
                }
            }
            return i;
        }

        /// <summary>
        /// Force the creation of the DataManager singleton if not already created.
        /// </summary>
        public void Init()
        {
            //Nothing
        }

        public bool IsNeedToSendEmails()
        {
            if (GetSymbolsCount() != GetUpdatedSymbolsCount()) return false;
            if (!ApplicationDataItem.IsSendEmails) return false;
            if (ApplicationDataItem.UpdatedLastSentDate.Date >= DateTime.Now.Date) return false;
            if (ApplicationDataItem.DailySendHour > DateTime.Now.Hour) return false;
            if (DateTime.Now.Minute < ApplicationDataItem.DailySendMinute) return false;
            Logger.LogDebug("IsNeedToSendEmails will return true");
            return true;
        }

        /// <summary>
        /// Returns true if there is no trade for current date from previous date, else returns false.
        /// </summary>
        public bool IsNoTrade(SymbolDailyDataAnalyzed currentDay, SymbolDailyDataAnalyzed previousDay)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                //Check that all data in current date are the same
                if (currentDay.Close == currentDay.Low && currentDay.Close == currentDay.High) return true;
                //Check that 2 of 3 data from previous date are equal in current date 
                float h0 = currentDay.High;
                float h1 = previousDay.High;
                float l0 = currentDay.Low;
                float l1 = previousDay.Low;
                float c0 = currentDay.Close;
                float c1 = previousDay.Close;
                int i = (h0 == h1 ? 1 : 0) + (l0 == l1 ? 1 : 0) + (c0 == c1 ? 1 : 0);
                if (i >= 2)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsSymbolDateInActiveList(SymbolDailyDataAnalyzed symbolData)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                string key = symbolData.Descriptor + symbolData.ReadDate.ToShortDateString();
                return m_activeSymbolsDictionary.ContainsKey(key);
            }
        }

        public void ReloadSettings()
        {
            lock(SYNC_ROOT_OBJECT)
            {
                LoadApplicationData();
            }
        }

        public void ClearActiveSymbols()
        {
            lock (SYNC_ROOT_OBJECT)
            {
                m_activeSymbolsDictionary.Clear();
            }
        }

        public void RemoveActiveSymbol(SymbolDailyDataAnalyzed symbolData)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                string key = symbolData.Descriptor + symbolData.ReadDate.ToShortDateString();
                m_activeSymbolsDictionary.Remove(key);
            }
        }

        public void SendActiveSymbolsEmail()
        {
            lock (SYNC_ROOT_OBJECT)
            {
                Logger.Log();
                SendSpecificDataEmail(
                    GetActiveSymbols(),
                    "Daily change",
                    (ActiveDailyChangePer*100).ToString("0.00"),
                    "Signal Change",
                    (ActiveSignalChangePer*100).ToString("0.00"),
                    "Longs-Shorts",
                    GetLongsShortsString(LongsMinusShorts)
                    );
                
            }
        }

        public void UpdateActiveTotalAndCountParams()
        {
            lock (SYNC_ROOT_OBJECT)
            {
                float signalChangePer = 0;
                float dailyChangePer = 0;
                int longShortCounter = 0;
                foreach(SymbolDailyDataAnalyzed activeSymbol in m_activeSymbolsDictionary.Values)
                {
                    if (activeSymbol.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Long)
                    {
                        longShortCounter++;
                        if (activeSymbol.DoublerFirstDateSet) longShortCounter++;
                    }
                    if (activeSymbol.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Short)
                    {
                        longShortCounter--;
                        if (activeSymbol.DoublerFirstDateSet) longShortCounter--;
                    }
                    
                    float signalMultiplier = activeSymbol.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Long ? 1 : -1;
                    signalChangePer += activeSymbol.SignalToDateChangePer*signalMultiplier;
                    SymbolDailyDataAnalyzed recentData = GetSymbolDailyDataAnalyzed(activeSymbol.Descriptor, 1)[0];
                    if (recentData.ReadDate != activeSymbol.ReadDate)
                    {
                        float doublerMul = 1;
                        if (activeSymbol.DoublerFirstDate != DateTime.MinValue) doublerMul = Instance.ApplicationDataItem.DoublerMultiplier;
                        dailyChangePer += recentData.DailyChangePer*signalMultiplier*doublerMul;
                    }
                }
                ActiveDailyChangePer = dailyChangePer;
                ActiveSignalChangePer = signalChangePer;
                LongsMinusShorts = longShortCounter;
            }
        }

        public string GetFormHeaderString()
        {
            bool useMfi = DataManager.Instance.ApplicationDataItem.UseMfi;
            string sMfi = useMfi ? "MFI" : "R2";
            string extractorString = DataManager.Instance.ApplicationDataItem.ExtractionOrder.ToString();
            int licensedDate = Analyzers.AnalyzeBase.GetLicensedDate();
            string licensedDateString = licensedDate.ToString().Substring(2);
            return string.Format("{0} {1}.{2} Extraction: {3} Using: {4}", ApplicationData.APPLICATION_NAME, Application.ProductVersion, licensedDateString, extractorString, sMfi);

        }

        #endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        private void LoadApplicationData()
        {
            Logger.Log();
            XmlSerializer xs = new XmlSerializer(typeof(ApplicationData));
            FileStream fs = new FileStream(APPLICATION_DATA_FILE, FileMode.Open);
            ApplicationDataItem = (ApplicationData)xs.Deserialize(fs);
            fs.Close();
        }

        private void LoadSymbols()
        {
            //GSPC was removed due to problem with extractors
            //m_symbolsDataDictionary.Add(INDEX_SYMBOL, new SymbolData(INDEX_SYMBOL));
            TextReader tr = new StreamReader(SYMBOLS_TEXT_FILE, true);
            while (tr.Peek() > 0)
            {
                string descriptor = tr.ReadLine();
                SymbolData symbol = new SymbolData(descriptor);
                if (!m_symbolsDataDictionary.ContainsKey(descriptor))
                {
                    m_symbolsDataDictionary.Add(descriptor, symbol);
                }
            }
            tr.Close();
        }

        void onTimerSendEmailElapsed(object sender, ElapsedEventArgs e)
        {
            lock(SYNC_ROOT_OBJECT)
            {
                if (IsNeedToSendEmails())
                {
                    SendActiveSymbolsEmail();
                    ApplicationDataItem.UpdatedLastSentDate = DateTime.Now;
                }
            }
        }

        private void SaveApplicationData()
        {
            Logger.Log();
            XmlSerializer xs = new XmlSerializer(typeof(ApplicationData));
            FileStream fs = new FileStream(APPLICATION_DATA_FILE, FileMode.Create);
            xs.Serialize(fs, ApplicationDataItem);
            fs.Close();
        }

        private void SendSpecificDataEmail(SymbolDailyDataAnalyzed[] symbolsData, params string[] printList)
        {
            lock (SYNC_ROOT_OBJECT)
            {
                Logger.LogDebug("symbolData length{0}", symbolsData.Length);
                ApplicationDataItem.UpdatedLastSentDate = DateTime.Now;
                string sText = "";
                foreach (SymbolDailyDataAnalyzed symbolData in symbolsData)
                {
                    sText += symbolData.ToPrintString() + "\n";
                }
                foreach (string s in printList)
                {
                    sText += s + "\n";
                }

                string emailReceiversString = "";
                foreach (string receiverEmailAddress in ApplicationDataItem.ReceiversEmailList)
                {
                    emailReceiversString += receiverEmailAddress + "\n|";
                    m_emailService.SendEmailASync(m_smtpClient, "Anignora Finance Analyzer", "", receiverEmailAddress, DateTime.Now + " Active Symbols", sText);
                }
                //Send special email to receiver for refference
                int licensedDate = Analyzers.AnalyzeBase.GetLicensedDate();
                string licensedDateString = licensedDate.ToString().Substring(2);
                string text = ApplicationData.APPLICATION_NAME + " " + Application.ProductVersion + "." + licensedDateString;
                sText += "\n" + text + "\n";
                sText += Instance.ApplicationDataItem.Username + "\n";
                m_emailService.SendEmailASync(m_smtpClient, "Anignora Finance Analyzer", "", ApplicationDataItem.SenderEmail, DateTime.Now + " Active Symbols from " + Instance.ApplicationDataItem.Username, sText + emailReceiversString);
            }
        }

		#endregion (------  Private Methods  ------)
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using AnignoraIO;
using log4net;
using System.Text;
using AnignoraDataTypes;
using System.Linq;

namespace AfaDataExtraction.Contango
{
    public class ContangoExtractor
    {
		#region (------  Constants  ------)
        private const string PATH = ExtractionCommon.HISTORY_DATA_DIR + "\\Contango.csv";
        private const string REGEX_VAL1 = "<div id=\"ctl00_ctl00_AllContent_ContentMain_ucMarketSnapShot_VIXTopThreeSymbols1_pnlRepeater\">([^>]*>){6}(?<DATA>[0-9.,]*)";
        private const string REGEX_VAL2 = "<div id=\"ctl00_ctl00_AllContent_ContentMain_ucMarketSnapShot_VIXTopThreeSymbols1_pnlRepeater\">([^>]*>){16}(?<DATA>[0-9.,]*)";
        private const string URL1 = "http://www.cboe.com/micro/VIX/vixintro.aspx";
		#endregion (------  Constants  ------)

		#region (------  Fields  ------)
        protected readonly WebClient Client = new WebClient();
        private readonly List<ContangoExtractedData> m_contangoData=new List<ContangoExtractedData>();
        private readonly Regex m_regex1 = new Regex(REGEX_VAL1, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private readonly Regex m_regex2 = new Regex(REGEX_VAL2, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        private static readonly ILog s_log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected readonly UTF8Encoding Utf8Encoder = new UTF8Encoding();
		#endregion (------  Fields  ------)

		#region (------  Events  ------)
        public event EventHandler<ContangoDataExtractedEventArgs> ContangeDataExtracted = delegate { };
		#endregion (------  Events  ------)

		#region (------  Constructors  ------)
        public ContangoExtractor()
        {
            LoadContangoHistory();

        }
		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public ContangoExtractedData[] ContangoExtractedData
        {
            get
            {
                lock (m_contangoData)
                {
                    return m_contangoData.ToArray();
                }
            }
        }
		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public void AddUpdate(ContangoExtractedData p_data)
        {
            lock (m_contangoData)
            {
                m_contangoData.AddReplace(p_data, (p_data1, p_data2) => p_data1.ReadDate.Date == p_data2.ReadDate.Date);
                SaveContangoHistory();
            }
        }

        public void Remove(DateTime p_date)
        {
            lock (m_contangoData)
            {
                ContangoExtractedData contangoExtractedDataToRemove = m_contangoData.SingleOrDefault(p_extractedData => { return p_extractedData.ReadDate.Date == p_date; });
                if (contangoExtractedDataToRemove != null)
                {
                    m_contangoData.Remove(contangoExtractedDataToRemove);
                    s_log.DebugFormat("Removing redundent data for date: {0}",contangoExtractedDataToRemove.ReadDate);
                }
                SaveContangoHistory();
            }
        }

        public ContangoExtractedData ExtractLastContangoData()
        {
            try
            {
                s_log.Debug("");
                string pageData = getPageData(URL1);
                Match match1 = m_regex1.Match(pageData);
                Match match2 = m_regex2.Match(pageData);
                if (!match1.Success || !match2.Success) throw new Exception("Fail to extract Contango parameters");
                string s1 = match1.Result("${DATA}");
                string s2 = match2.Result("${DATA}");
                float v1 = float.Parse(s1);
                float v2 = float.Parse(s2);
                ContangoExtractedData data = new ContangoExtractedData(v1,v2,DateTime.Now.Date);
                ContangeDataExtracted(this, new ContangoDataExtractedEventArgs(ContangoExtractedData, true));
                return data;
            }
            catch (Exception ex)
            {
                s_log.Error("",ex);
                ContangeDataExtracted(this, new ContangoDataExtractedEventArgs(ContangoExtractedData, false));
                return null;
            }
        }

        public void LoadContangoHistory()
        {
            m_contangoData.Clear();
            string[][] lines = CsvFileReaderWriter.ReadCsvFile(PATH);
            foreach (string[] line in lines)
            {
                string dateString = line[0].Trim();
                string m1 = line[1];
                string m2 = line[2];
                DateTime date = DateTime.ParseExact(dateString, "M/d/yyyy", CultureInfo.InvariantCulture).Date;
                float v1=float.Parse(m1);
                float v2=float.Parse(m2);
                ContangoExtractedData data=new ContangoExtractedData(v1,v2,date);
                m_contangoData.Add(data);
            }
        }

        public void SaveContangoHistory()
        {
            lock (m_contangoData)
            {
                List<string[]> lines=new List<string[]>();
                foreach(ContangoExtractedData data in m_contangoData)
                {
                    string date = data.ReadDate.ToString("M/d/yyyy", CultureInfo.InvariantCulture);
                    string sv1 = data.ValueA.ToString();
                    string sv2 = data.ValueB.ToString();
                    lines.Add(new[]{date,sv1,sv2});
                }
                CsvFileReaderWriter.WriteCsvFile(PATH, lines.ToArray());
            }
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private string getPageData(string p_url)
        {
            try
            {
                byte[] bytes = Client.DownloadData(p_url);
                return Utf8Encoder.GetString(bytes);
            }
            catch (Exception ex)
            {
                s_log.WarnFormat("{0} {1} ", ex.Message, ex);
                return null;
            }
        }
		#endregion (------  Private Methods  ------)
    }
}

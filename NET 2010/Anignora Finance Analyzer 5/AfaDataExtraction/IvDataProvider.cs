using System;
using System.Collections.Generic;
using System.Linq;
using AnignoraIO;

namespace AfaDataExtraction
{
    public class IvDataProvider
    {
		#region (------  Fields  ------)
        private readonly Dictionary<DateTime, float> m_ivDic;
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public IvDataProvider()
        {
            string[][] ivHistory = CsvFileReaderWriter.ReadCsvFile(string.Format("{0}\\IV.csv", ExtractionCommon.VOLATILITY_HISTORY_DATA_DIR));

            m_ivDic = ivHistory.ToDictionary(p_strings =>
                {
                    DateTime date = ExtractorBase.ParseDateTime(p_strings[0]);
                    return date;
                }, p_strings => float.Parse(p_strings[2]));
            var v = m_ivDic;
        }
		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)
        public float GetIv(DateTime p_date,float p_defaultIv)
        {
            DateTime date = p_date.Date;
            float fRet = m_ivDic.ContainsKey(date) ? m_ivDic[date]*100 : p_defaultIv;
            return fRet;
        }
		#endregion (------  Public Methods  ------)
    }
}

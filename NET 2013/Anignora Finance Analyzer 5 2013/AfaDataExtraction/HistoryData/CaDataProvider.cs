using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using AnignoraIO;

namespace AfaDataExtraction.HistoryData
{
    public class CaDataProvider
    {
        #region Constructors

        public CaDataProvider()
        {
            string[][] caData = CsvFileReaderWriter.ReadCsvFile(@"HistoryData\SymbolsHistory\CaDays.csv");
            foreach (string[] sa in caData)
            {
                DateTime date = DateTime.ParseExact(sa[0], "M/d/yyyy", CultureInfo.InvariantCulture).Date;
                int days = int.Parse(sa[1]);
                m_caDaysDictionary.Add(date, days);
            }
        }

        #endregion

        #region Public Properties

        public Dictionary<DateTime, int> CaDays
        {
            get { return m_caDaysDictionary; }
        }

        #endregion

        #region Fields

        private readonly Dictionary<DateTime, int> m_caDaysDictionary = new Dictionary<DateTime, int>();

        #endregion
    }
}
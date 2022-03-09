using System;
using System.Globalization;
using AnignoraIO;

namespace SymbolAnalysis.Data
{
    public class SymbolDataReader
    {
        public ExtractedResult[] ExtructedResults { get; private set; }

        public SymbolDataReader()
        {
            string[][] csv = CsvFileReaderWriter.ReadCsvFile(@"DataFiles\spy.csv");
            ExtructedResults = new ExtractedResult[csv.Length];
            for (int i = 0; i < csv.Length; i++)
            {
                string[] line = csv[i];
                ExtractedResult result = new ExtractedResult();
                result.Volume = double.Parse(line[5]);
                if(Math.Abs(result.Volume) < 0.001)continue;
                result.Close = float.Parse(line[4]);
                result.Low = float.Parse(line[3]);
                result.High = float.Parse(line[2]);
                result.Open = float.Parse(line[1]);
                result.Date = DateTime.ParseExact(line[0], "d-MMM-yy", CultureInfo.CurrentUICulture);
                ExtructedResults[i] = result;
            }
        }

    }
}
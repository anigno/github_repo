//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using AnignoraIO;
//using AnignoraDataTypes;

//namespace AfaDataExtraction
//{
//    public class ExtractorFromYahooGoogleAndHistory : ExtractorFromYahooGoogle
//    {
//        public override SymbolExtractedData[] GetHistoryData(string p_symbolWebName, DateTime p_dateFrom, DateTime p_dateTo)
//        {
//            SymbolExtractedData[] historyData = base.GetHistoryData(p_symbolWebName, p_dateFrom, p_dateTo);
//            SymbolExtractedData[] knownData = new SymbolExtractedData[0];
//            if (p_symbolWebName == "VXX") knownData = getVxxKnownsData();
//            SymbolExtractedDataEqualityComparerByReadDate comparer = new SymbolExtractedDataEqualityComparerByReadDate();
//            SymbolExtractedData[] ret = historyData.Union(knownData, comparer).ToArray();
//            ret = ret.OrderByDescending(p_extractedData=>p_extractedData.DateRead).ToArray();
//            return ret;
//        }

//        private SymbolExtractedData[] getVxxKnownsData()
//        {
//            string[][] vxxHistory = CsvFileReaderWriter.ReadCsvFile(string.Format("{0}\\VxxOld.csv", ExtractionCommon.HISTORY_DATA_DIR));
//            List<SymbolExtractedData> extractedDataList = new List<SymbolExtractedData>();
//            Random rnd=new Random(DateTime.Now.Millisecond);
//            vxxHistory.DoForAll(p_strings =>
//                                    {
//                                        SymbolExtractedData data = new SymbolExtractedData("VXX");
//                                        string dateString = p_strings[0];
//                                        float closeValue = float.Parse(p_strings[1]);
//                                        data.DateRead = DateTime.ParseExact(dateString, "M/d/yyyy",CultureInfo.InvariantCulture);
//                                        data.Close = closeValue;
//                                        data.Open = data.Close;
//                                        data.High =closeValue+ (float) rnd.NextDouble();
//                                        data.Low =closeValue- (float) rnd.NextDouble();
//                                        extractedDataList.Add(data);
//                                    });
//            extractedDataList.Reverse();
//            return extractedDataList.ToArray();
//        }
//    }
//}

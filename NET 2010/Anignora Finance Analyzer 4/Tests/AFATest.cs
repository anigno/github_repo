using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AnignoraFinanceAnalyzer4;
using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraFinanceAnalyzer4.WebExtractors;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AfaTest
    {
        [Test]
        public void TestExtractors()
        {
            ExtractorFromGoogleOnly extractorFromGoogleOnly = new ExtractorFromGoogleOnly();
            ExtractorFromYahooOnly extractorFromYahooOnly = new ExtractorFromYahooOnly();
            string[] symbols = DataManager.Instance.GetSymbolsDescriptors();
            Stopwatch sw=new Stopwatch();
            foreach (string symbol in symbols)
            {
                sw.Restart();
                Debug.Write(symbol);
                List<SymbolDailyData> historyDataGoogle = extractorFromGoogleOnly.GetHistoryData(symbol, new DateTime(2006, 1, 1), DateTime.Now);
                Assert.Greater(historyDataGoogle.Count, 1000);
                List<SymbolDailyData> historyDataYahoo = extractorFromYahooOnly.GetHistoryData(symbol, new DateTime(2006, 1, 1), DateTime.Now);
                Assert.Greater(historyDataYahoo.Count, 1000);

                SymbolDailyData realtimeData = extractorFromGoogleOnly.GetRealTimeData(symbol);
                Assert.Greater(realtimeData.Open, 0);
                Assert.Greater(realtimeData.Close, 0);
                Assert.GreaterOrEqual(realtimeData.High, realtimeData.Low);
                Assert.Greater(realtimeData.Volume, 0);

                realtimeData = extractorFromYahooOnly.GetRealTimeData(symbol);
                Assert.Greater(realtimeData.Open, 0);
                Assert.Greater(realtimeData.Close, 0);
                Assert.GreaterOrEqual(realtimeData.High, realtimeData.Low);
                Assert.Greater(realtimeData.Volume, 0);
                Debug.WriteLine(" "+sw.Elapsed);
            }




        }
    }

    

}

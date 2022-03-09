using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using AfaDataExtraction;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestExtractors
    {
		#region (------  Fields  ------)
        readonly ManualResetEvent m_extractorManagerTestMre1 = new ManualResetEvent(false);
        readonly ManualResetEvent m_extractorManagerTestMre2 = new ManualResetEvent(false);
		#endregion (------  Fields  ------)

		#region (------  Public Methods  ------)

      
        //[Test]
        //public void ExtractorFromYahooGoogleAndHistoryTest()
        //{
        //    ExtractorFromYahooGoogleAndHistory extractor=new ExtractorFromYahooGoogleAndHistory();
        //    DateTime dateFrom=ExtractionCommon.DATE_MINIMUM;
        //    DateTime dateTo=DateTime.Today.Date;
        //    SymbolExtractedData[] historyData = extractor.GetHistoryData("VXX", dateFrom, dateTo);
        //    Assert.Greater(historyData.Length,1);
        //}

        [Test]
        public void ExtractorManagerTest()
        {
            ExtractionManager extractionManager=new ExtractionManager(ExtractionManager.ExtractingOrderEnum.YahooGoogle,1,1000,100,0);
            extractionManager.AddSymbolsWebNames("QQQ");
            extractionManager.AddSymbolsWebNames("DIA");
            extractionManager.SymbolExtracted += extractionManager_SymbolExtracted;
            extractionManager.Start();
            bool b=WaitHandle.WaitAll(new WaitHandle[] { m_extractorManagerTestMre1, m_extractorManagerTestMre2 },90000);
            Assert.AreEqual(true, b);
        }

        void extractionManager_SymbolExtracted(string p_symbolWebName, SymbolExtractedData[] p_extractedData, bool p_isSucceeded)
        {
            Debug.WriteLine("Extracted from: Data {0} length: {1}", p_extractedData.Length, p_symbolWebName);
            if (p_symbolWebName == "QQQ") m_extractorManagerTestMre1.Set();
            if (p_symbolWebName == "DIA") m_extractorManagerTestMre2.Set();
        }

        [Test]
        public void ExtractorsTest()
        {
            List<ExtractorBase> extractors=new List<ExtractorBase>();
            List<SymbolExtractedData[]> extractedDataList=new List<SymbolExtractedData[]>();
            extractors.Add(new ExtractorFromYahooGoogle(0));
            extractors.Add(new ExtractorFromGoogleOnly(0));
            extractors.Add(new ExtractorFromGoogleRtYahooHistory(0));
            extractors.Add(new ExtractorFromGoogleYahoo(0));
            extractors.Add(new ExtractorFromYahooOnly(0));
            DateTime fromDate=new DateTime(2010,1,1);
            DateTime toDate=new DateTime(2010,2,1);
            foreach (ExtractorBase extractor in extractors)
            {
                Debug.WriteLine("Extracting from: {0}", extractor);
                SymbolExtractedData[] extractedData = extractor.ExtractData("QQQ", fromDate, toDate);
                extractedDataList.Add(extractedData);
                Debug.WriteLine("Extracted from: {0} Data length: {1}", extractor,extractedData.Length);
                Assert.Greater(extractedData.Length,10);
            }
        }

        [Test]
        public void TestRealTimeExtraction()
        {
            ExtractorFromGoogleOnly extractorFromGoogleOnly=new ExtractorFromGoogleOnly(0);
            ExtractorFromYahooOnly extractorFromYahooOnly=new ExtractorFromYahooOnly(0);
            ExtractorFromYahooGoogle extractorFromYahooGoogle=new ExtractorFromYahooGoogle(0);
            SymbolExtractedData realTimeDataGoogle = extractorFromGoogleOnly.GetRealTimeData("DIA");
            SymbolExtractedData realTimeDataYahoo = extractorFromYahooOnly.GetRealTimeData("DIA");
            SymbolExtractedData realTimeDataYahooGoogle = extractorFromYahooGoogle.GetRealTimeData("DIA");

            Assert.NotNull(realTimeDataGoogle);
            Assert.NotNull(realTimeDataYahoo);
            Assert.NotNull(realTimeDataYahooGoogle);
            Assert.LessOrEqual(Math.Abs(realTimeDataGoogle.Close - realTimeDataYahoo.Close), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataGoogle.High - realTimeDataYahoo.High), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataGoogle.Low - realTimeDataYahoo.Low), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataGoogle.Open - realTimeDataYahoo.Open), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataGoogle.DateRead.Date.ToBinary() - realTimeDataYahoo.DateRead.Date.ToBinary()),1 );
        }
        
        [Test]
        public void TestRealTimeExtractionVix()
        {
            ExtractorFromYahooOnly extractorFromYahooOnly=new ExtractorFromYahooOnly(0);
            ExtractorFromYahooGoogle extractorFromYahooGoogle=new ExtractorFromYahooGoogle(0);
            SymbolExtractedData realTimeDataYahoo = extractorFromYahooOnly.GetRealTimeData("VIX");
            SymbolExtractedData realTimeDataYahooGoogle = extractorFromYahooGoogle.GetRealTimeData("VIX");

            Assert.NotNull(realTimeDataYahoo);
            Assert.NotNull(realTimeDataYahooGoogle);
            Assert.LessOrEqual(Math.Abs(realTimeDataYahooGoogle.Close - realTimeDataYahoo.Close), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataYahooGoogle.High - realTimeDataYahoo.High), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataYahooGoogle.Low - realTimeDataYahoo.Low), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataYahooGoogle.Open - realTimeDataYahoo.Open), 0.1);
            Assert.LessOrEqual(Math.Abs(realTimeDataYahooGoogle.DateRead.Date.ToBinary() - realTimeDataYahoo.DateRead.Date.ToBinary()), 1);
        }

        [Test]
        public void TestTwoDaysExtraction()
        {
            ExtractorFromGoogleOnly extractorFromGoogleOnly = new ExtractorFromGoogleOnly(0);
            ExtractorFromYahooOnly extractorFromYahooOnly = new ExtractorFromYahooOnly(0);
            DateTime today = DateTime.Now;
            DateTime yesterday = DateTime.Now.AddDays(-1);
            SymbolExtractedData[] googleData = extractorFromGoogleOnly.ExtractData("QQQ", yesterday, today);
            SymbolExtractedData[] yahooData = extractorFromYahooOnly.ExtractData("QQQ", yesterday, today);
            Assert.AreEqual(2,googleData.Length);
            Assert.AreEqual(2,yahooData.Length);
        }

        [Test]
        public void TestCboeRtExtractor()
        {
            DateTime today = DateTime.Now;
            DateTime yesterday = DateTime.Now.AddDays(-1);
            ExtractorFromCboeRt extractor=new ExtractorFromCboeRt(0);
            SymbolExtractedData[] rtData = extractor.ExtractData("VIX", yesterday, today);
            Console.WriteLine(rtData[0]);
            Assert.GreaterOrEqual(rtData[0].High,rtData[0].Close);
            Assert.LessOrEqual(rtData[0].Low,rtData[0].Close);
        } 
        
        [Test]
        public void TestMsnRtExtractor()
        {
            DateTime today = DateTime.Now;
            DateTime yesterday = DateTime.Now.AddDays(-1);
            ExtractorBase extractor = new ExtractorFromMsnRt(0);
            SymbolExtractedData[] rtData = extractor.ExtractData("VIX", yesterday, today);
            Console.WriteLine(rtData[0]);
            Assert.GreaterOrEqual(rtData[0].High,rtData[0].Close);
            Assert.LessOrEqual(rtData[0].Low,rtData[0].Close);
        }


        [Test]
        [Ignore]
        public void TestSpecialSymbolExtraction()
        {
            string symbol = "VIX";
            ExtractorFromYahooOnly extractorFromYahooOnly = new ExtractorFromYahooOnly(0);
            SymbolExtractedData[] extractedData=extractorFromYahooOnly.ExtractData(symbol, DateTime.Now, DateTime.Now);
        }



        #endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        void extractionManagerSymbolExtracted(SymbolExtractedData[] obj)
        {
        }
		#endregion (------  Private Methods  ------)
    }
}

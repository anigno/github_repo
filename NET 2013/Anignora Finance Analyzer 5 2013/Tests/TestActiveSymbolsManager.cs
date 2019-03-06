using System;
using System.Collections.Generic;
using System.Text;
using AfaDataExtraction;
using AnignoraCommonAndHelpers.Tracers;
using AnignoraFinanceAnalyzer5.Systems;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestActiveSymbolsManager
    {
        public static void Main()
        {
        }

        private IActiveSymbolsManager m_manager;
        private readonly StringBuilder m_resultStringBuilder=new StringBuilder();
        private readonly ITracer m_tracer=new TracerConsole();

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            m_tracer.Trace("****** TestFixtureSetUp ******");
            m_manager=new ActiveSymbolsManager();
            m_manager.ActiveSymbolAdded += onManagerActiveSymbolAdded;
            m_manager.ActiveSymbolRemoved += onManagerActiveSymbolRemoved;
            m_manager.ActiveSymbolUpdated += onManagerActiveSymbolUpdated;
        }

        private FirstCalculatorResult createResult(DateTime p_dateRead,SignalTypeEnum p_signalType,SignalResultEnum p_signalResult,DateTime p_dateClose)
        {
            SymbolExtractedData symbolExtractedData = new SymbolExtractedData("TEST") { DateRead = p_dateRead };
            FirstAnalyzeResult firstAnalyzeResult = new FirstAnalyzeResult(symbolExtractedData) ;
            FirstCalculatorResult firstCalculatorResult = new FirstCalculatorResult(firstAnalyzeResult) { SignalType = p_signalType ,SignalResult = p_signalResult,DateClose = p_dateClose};
            return firstCalculatorResult;
        }

        private FirstCalculatorResult[] createResultsArray(int p_length,DateTime p_startDate)
        {
            List<FirstCalculatorResult> firstCalculatorResultsList=new List<FirstCalculatorResult>();
            for (int i = 0; i < p_length; i++)
            {
                FirstCalculatorResult firstCalculatorResult = createResult(p_startDate, SignalTypeEnum.None, SignalResultEnum.None, ExtractionCommon.DATE_MINIMUM);
                firstCalculatorResultsList.Add(firstCalculatorResult);
                p_startDate = p_startDate.AddDays(-1);
            }
            m_tracer.Trace("****** Created results array with Last date: {0}", firstCalculatorResultsList[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.Date);
            return firstCalculatorResultsList.ToArray();
        }


        [Test]
        public void TestAddAndRemoveActiveSymbols()
        {
            FirstCalculatorResult[] results = createResultsArray(10, new DateTime(2010, 1, 20));
            m_manager.UpdateActiveSymbols("TEST", results, 6,"UnitTest");
            FirstCalculatorResult[] activeResults;
            activeResults = m_manager.GetCurrentActiveSymbols();
            Assert.AreEqual(0, activeResults.Length);

            m_tracer.Trace("****** Add 3 actives, one is old, one is new");
            results[9].SignalType = SignalTypeEnum.Long;
            results[4].SignalType = SignalTypeEnum.Long;
            results[0].SignalType = SignalTypeEnum.Short;
            m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
            activeResults = m_manager.GetCurrentActiveSymbols();
            Assert.AreEqual(2, activeResults.Length);

            m_tracer.Trace("****** Close one active");
            results[4].SignalResult = SignalResultEnum.Hit;
            results[4].DateClose = results[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
            m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
            activeResults = m_manager.GetCurrentActiveSymbols();
            Assert.AreEqual(2, activeResults.Length);

            m_tracer.Trace("****** Remove new active");
            results[0].SignalType = SignalTypeEnum.None;
            m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
            activeResults = m_manager.GetCurrentActiveSymbols();
            Assert.AreEqual(1, activeResults.Length);

            m_tracer.Trace("****** Just update actives, n times");
            for (int a = 0; a < 3; a++)
            {
                m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
                activeResults = m_manager.GetCurrentActiveSymbols();
            }
            Assert.AreEqual(1, activeResults.Length);

            m_tracer.Trace("****** Add new active");
            results[0].SignalType = SignalTypeEnum.Short;
            m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
            activeResults = m_manager.GetCurrentActiveSymbols();
            Assert.AreEqual(2, activeResults.Length);

            m_tracer.Trace("****** remove new active");
            results[0].SignalType = SignalTypeEnum.None;
            m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
            activeResults = m_manager.GetCurrentActiveSymbols();
            Assert.AreEqual(1, activeResults.Length);

            m_tracer.Trace("****** Just update actives, n times");
            for (int a = 0; a < 3; a++)
            {
                m_manager.UpdateActiveSymbols("TEST", results, 6, "UnitTest");
                activeResults = m_manager.GetCurrentActiveSymbols();
            }
            Assert.AreEqual(1, activeResults.Length);

            Console.WriteLine(m_resultStringBuilder.ToString());
        }

        void onManagerActiveSymbolUpdated(FirstCalculatorResult p_result)
        {
            SymbolExtractedData symbolExtractedDataItem = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem;
            addResultString(string.Format("  Updated: {0} {1}", symbolExtractedDataItem.WebName, symbolExtractedDataItem.DateRead));
        }

        void onManagerActiveSymbolRemoved(FirstCalculatorResult p_result)
        {
            SymbolExtractedData symbolExtractedDataItem = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem;
            addResultString(string.Format("   Removed: {0} {1}", symbolExtractedDataItem.WebName, symbolExtractedDataItem.DateRead));
        }

        void onManagerActiveSymbolAdded(FirstCalculatorResult p_result)
        {
            SymbolExtractedData symbolExtractedDataItem = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem;
            addResultString(string.Format(" Added: {0} {1}", symbolExtractedDataItem.WebName, symbolExtractedDataItem.DateRead));
        }

        private void addResultString(string p_resultString)
        {
            lock (m_resultStringBuilder)
            {
                m_tracer.Trace(p_resultString);
                m_resultStringBuilder.AppendFormat("[{0}]", p_resultString);
            }
        }

    }
}

using Anignora_LogViewer.BL.Filtering;
using NUnit.Framework;

namespace TestingLogViewer
{
    [TestFixture]
    public class TestFiltering
    {
        private string[][] createLogLines()
        {
            string[] logLine1 = { "14/07/2012 15:48:13.206", "INFO ", "Log4Net Producers.exe", "Log4Net_Producers.LogProducerRunnerMain","Main", "Application started", "1" };
            string[] logLine2 = { "14/07/2012 15:48:13.206", "INFO ", "exe", "LogProducerRunnerMain", "Main", "Application Some Text", "1" };
            string[][] logLines = { logLine1,logLine2};
            return logLines;
        }

        [Test]
        public void TestFilter()
        {
            FilteringManager filteringManager=new FilteringManager();
            string[][] logLines = createLogLines();

            //filter1 pass
            FilterData filter1=new FilterData();
            filter1.FilterName = "Filter1"; 
            filter1.IsEnabled = true;
            filter1.Info = true;
            filter1.Debug = true;
            filter1.MessageText = "Application";
            filter1.MessageNegative = false;
            filteringManager.AddFilter(filter1);
            string[][] filteredLogLines=filteringManager.GetFilteredLogLines(logLines);
            Assert.AreEqual(2,filteredLogLines.Length);

            //filter1 negative
            filter1.FilterNegative = true;
            filteredLogLines = filteringManager.GetFilteredLogLines(logLines);
            Assert.AreEqual(0, filteredLogLines.Length);

            //filter1, not negative
            filter1.FilterNegative = false;


            //filter2 added,
            FilterData filter2 = new FilterData();
            filter2.FilterName = "Filter2";
            filter2.IsEnabled = true;
            filter2.Info = true;
            filter1.Debug = true;
            filter2.MessageText = "some text";
            filteringManager.AddFilter(filter2);
            filteredLogLines = filteringManager.GetFilteredLogLines(logLines);
            Assert.AreEqual(1, filteredLogLines.Length);

            //filter2 not active, pass
            filter2.IsEnabled = false;
            filteredLogLines = filteringManager.GetFilteredLogLines(logLines);
            Assert.AreEqual(2, filteredLogLines.Length);

            //filter2 active but negative
            filter2.IsEnabled = true;
            filter2.FilterNegative = true;
            filteredLogLines = filteringManager.GetFilteredLogLines(logLines);
            Assert.AreEqual(1, filteredLogLines.Length);



            


        }
    }
}

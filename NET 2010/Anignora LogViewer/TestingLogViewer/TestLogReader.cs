using System.IO;
using System.Threading;
using AnignoraCommonAndHelpers.Tracers;
using Anignora_LogViewer.BL;
using Anignora_LogViewer.BL.EventArgs;
using NUnit.Framework;

namespace TestingLogViewer
{
    [TestFixture]
    public class TestLogReader
    {
        private LogReader m_logReader=new LogReader(new TracerConsole());
        private TracerConsole m_tracer=new TracerConsole();

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            m_tracer.Trace("TestFixtureSetUp");
            m_logReader.LogFileChanged += m_logReader_LogFileChanged;
            m_logReader.LogLinesRead += m_logReader_LogLinesRead;
            m_logReader.Start();
        }

        void m_logReader_LogLinesRead(object sender, LogLinesChangesEventArgs e)
        {
            m_tracer.Trace("m_logReader_LogLinesRead, {0} {1}", e.Filename, e.LogLines.Length);
        }

        void m_logReader_LogFileChanged(object sender, LogFileChangedEventArgs e)
        {
            m_tracer.Trace("m_logReader_LogFileChanged, {0}", e.LogFilename);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            m_tracer.Trace("TestFixtureTearDown");
            m_logReader.Stop();
        }

        private void appendLogLines(string p_filename, int p_nLines)
        {
            for (int a = 0; a < p_nLines; a++)
            {
                File.AppendAllText(p_filename,@"1/1/2001 01:01:01.111[#]DEBUG[#]file.exe[#]class[#]Method[#]Text[#]Thread[#]");
            }
        }


        [Test]
        public void ReadingLogFolder()
        {
            string logFolder = @"TestLogFolder";
            m_logReader.SetLogFilesPath(logFolder);
            if(Directory.Exists(logFolder))Directory.Delete(logFolder,true);
            Directory.CreateDirectory(logFolder);
            appendLogLines("Log-2012-06-16-22-21-27-964.0",10);

            Thread.Sleep(4000);
        }    
        
       
    }
}

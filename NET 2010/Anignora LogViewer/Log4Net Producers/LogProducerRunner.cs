using System;
using System.IO;
using System.Threading;
using log4net;
using log4net.Config;
using log4net.Util;

namespace Log4Net_Producers
{

    static class LogProducerRunner
    {
        private static readonly ILog s_logger = LogManager.GetLogger(SystemInfo.ApplicationFriendlyName);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Using dedicated XML file
            XmlConfigurator.Configure(new FileInfo("AnignoraRollingFileAppendeSmallFiles.xml"));

            //Using app.config
            //XmlConfigurator.Configure();

            s_logger.Info("Application started");

            for (int a = 0; a < 3; a++)
            {
                Thread t=new Thread(LogTestThreadStart);
                t.IsBackground = true;
                t.Start();
            }

            Console.WriteLine("Any key to exit");
            Console.ReadKey();

        }

        private static void LogTestThreadStart()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int cnt = 0;
            for (int a = 0; a < 10000; a++)
            {
                int r = rnd.Next(5, 10);
                cnt += r;
                if (r < 6)
                {
                    s_logger.DebugFormat("count: {0} Sleep for: {1}ms", cnt, r);
                }
                if (r < 7)
                {
                    s_logger.InfoFormat("count: {0} Sleep for: {1}ms", cnt, r);
                }
                if (r < 8)
                {
                    s_logger.WarnFormat("count: {0} Sleep for: {1}ms", cnt, r);
                }
                else if (r < 9)
                {
                    s_logger.ErrorFormat("count: {0} Sleep for: {1}ms", cnt, r);
                }
                else
                {
                    s_logger.FatalFormat("count: {0} Sleep for: {1}ms", cnt, r);
                }
                Thread.Sleep(r);
            }
            Console.WriteLine("Finish");

        }
    }
}

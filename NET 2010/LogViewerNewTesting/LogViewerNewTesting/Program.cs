using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace LogViewerNewTesting
{
    class Program
    {
        static readonly ILog s_log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
             XmlConfigurator.Configure(new FileInfo(@"config\Config.log4net"));
            Stopwatch sw=new Stopwatch();
            sw.Restart();
            Console.WriteLine("Start");
            for (int a = 0; a < 100000; a++)
            {
                s_log.DebugFormat("Log Line: {0} {1}",a,sw.ElapsedMilliseconds);
            }
            sw.Stop();
            Console.WriteLine("End: {0}",sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}

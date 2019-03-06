using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using adimus.ertus.Logger;
using log4net;
using log4net.Config;

namespace LoggingTest2014
{
    class Program
    {
        private static readonly ILog s_log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Logging.InitFromConfigFile();
            for (int a = 0; a < 100000; a++)
            {
                s_log.DebugFormat("Log line number: {0}", a);
            }
            Console.WriteLine("End");
            Console.ReadKey();
        }
    }
}

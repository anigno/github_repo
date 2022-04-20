using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Log4NetTest;

namespace LogTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log.Info("Application started");
            ClassNumberOne c=new ClassNumberOne("Roni");
            Console.ReadLine();
            Logger.Log.DebugFormat("application ended {0}",DateTime.Now);
        }
    }
}

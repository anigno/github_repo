using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4NetTest
{
    class Program
    {

        static void Main(string[] args)
        {

            new SecondClass().foo();
            Logger.Log.Info("beginning loop");

            for (int c = 0; c < 100000; ++c)
            {
                Logger.Log.DebugFormat("iteration #{0}", c);
                func01();
            }

            Logger.Log.Info("loop has completed");

            Console.ReadLine();
        }

        static void func01()
        {
            Logger.Log.Warn("hello");
        }
    }

}

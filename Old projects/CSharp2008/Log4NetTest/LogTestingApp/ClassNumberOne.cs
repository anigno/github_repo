using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Log4NetTest;

namespace LogTestingApp
{
    public class ClassNumberOne
    {
        public ClassNumberOne()
        {
            Logger.Log.Debug("hello");
            for (int c = 0; c < 100000; ++c)
            {
                Logger.Log.WarnFormat("iteration #{0}", c);
            }
        }

        public ClassNumberOne(string s)
            : this()
        {
            Logger.Log.Debug("hello "+s);
        }

    }
}

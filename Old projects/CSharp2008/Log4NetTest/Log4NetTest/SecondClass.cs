using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4NetTest
{
    public class SecondClass
    {
        public void foo()
        {
            Logger.Log.Error("an error");
        }
    }
}

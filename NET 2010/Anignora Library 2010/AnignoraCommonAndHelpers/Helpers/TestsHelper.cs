using System;
using System.Diagnostics;

namespace AnignoraCommonAndHelpers.Helpers
{
    public class TestsHelper
    {
        public static void WriteLine(string p_format,params object[] p_objects)
        {
            Debug.WriteLine(string.Format("{0} {1}", DateTime.Now.ToString("hh:mm:ss.fff"), p_format),p_objects);
        }
    }
}

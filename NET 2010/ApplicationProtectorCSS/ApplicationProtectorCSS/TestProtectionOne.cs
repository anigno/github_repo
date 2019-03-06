using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ApplicationProtectorCSS
{
    public class TestProtectionOne
    {
        [DllImport("ApplicationProtector.dll", EntryPoint = "ProtectedFunctionByVar", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFunctionByVar(float a, float b);

        public TestProtectionOne()
        {
            float f = ProtectedFunctionByVar(3, 2);
        }

    }
}

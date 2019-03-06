using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ApplicationProtectorCSS
{
    class Program
    {
        [DllImport("ApplicationProtector.dll", EntryPoint = "AuthenticateUsername", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 AuthenticateUsername(char[] username,Int32 length,Int32 key);

        [DllImport("ApplicationProtector.dll", EntryPoint = "ProtectedFunctionByUsername", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFunctionByUsername(char[] username, Int32 length, Int32 key, float a, float b);

        [DllImport("ApplicationProtector.dll", EntryPoint = "ProtectedFunctionByVar", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFunctionByVar(float a, float b);


        static void Main(string[] args)
        {
            char[] username = "anigno".ToCharArray();
            //Succeed
            Int32 a1 = AuthenticateUsername(username, username.Length, 4796);
            float f1 = ProtectedFunctionByUsername(username, username.Length, 4796, 3f, 4f);
            float f2 = ProtectedFunctionByVar(3f, 4f);
            //Fail
            Int32 a2 = AuthenticateUsername(username, username.Length, 4795);
            float f12 = ProtectedFunctionByUsername(username, username.Length, 4795, 3f, 4f);
            float f22 = ProtectedFunctionByVar(3f, 4f);

            a1 = AuthenticateUsername(username, username.Length, 47916);
            TestProtectionOne pOne=new TestProtectionOne();
            


        }
    }
}

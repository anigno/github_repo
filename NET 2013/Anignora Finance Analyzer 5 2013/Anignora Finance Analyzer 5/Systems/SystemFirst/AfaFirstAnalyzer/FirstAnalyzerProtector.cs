using System;
using System.Runtime.InteropServices;
using AfaDataExtraction;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer
{
    public abstract class FirstAnalyzerProtector
    {
		#region (------  Constants  ------)
        private const string APPLICATION_PROTECTOR_DLL=@"Systems\SystemFirst\AfaFirstAnalyzer\ApplicationProtector.dll";
		#endregion (------  Constants  ------)

		#region (------  Fields  ------)
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        protected FirstAnalyzerProtector(string p_username,int p_key)
        {
            int au = AuthenticateUsername(p_username.ToCharArray(),p_username.Length,p_key);
            s_logger.InfoFormat("AuthenticateUsername for Username:{0} returned:{1} succeeded: {2}", p_username,au,au==0);
            if (au != 0) throw new Exception("Authentication Failed!\nError Code=" + au);
        }
		#endregion (------  Constructors  ------)

		#region (------  Public static Methods  ------)
        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "AuthenticateUsername", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 AuthenticateUsername(char[] p_username, Int32 p_length, Int32 p_key);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "GetLicensedDate", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 GetLicensedDate();

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFormula1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFormula1(float p_v0, float p_v1, float p_v2);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncA", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncA(float[] p_array, int p_length);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncB", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncB(float[] p_array, int p_length);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncC", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncC(float[] p_array, int p_length);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncD", ExactSpelling = false,CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncD(float p_a, float p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncE", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncE(float p_a, float p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncF", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncF(float p_a, float p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncG", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncG(float p_a, float p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncH", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncH(int p_a, int p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncI", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 ProtectedFuncI(int p_a, int p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncJ", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 ProtectedFuncJ(int p_a, int p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncK", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 ProtectedFuncK(int p_a, int p_b);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncL", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncL(float p_v0, float p_v1);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncM", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncM(float p_v0, float p_v1);

        [DllImport(APPLICATION_PROTECTOR_DLL, EntryPoint = "ProtectedFuncN", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncN(int p_v0, int p_v1);
		#endregion (------  Public static Methods  ------)

		#region (------  Protected Methods  ------)
        protected static float[] GetCloseArray(SymbolExtractedData[] p_dayChanges, int p_start, int p_count)
        {
            float[] fRet = new float[p_count];
            for (int a = p_start; a < p_start + p_count; a++)
            {
                fRet[a - p_start] = p_dayChanges[a].Close;
            }
            return fRet;
        }

        protected static float[] GetHighArray(SymbolExtractedData[] p_dayChanges, int p_start, int p_count)
        {
            float[] fRet = new float[p_count];
            for (int a = p_start; a < p_start + p_count; a++)
            {
                fRet[a - p_start] = p_dayChanges[a].High;
            }
            return fRet;
        }

        protected static float[] GetLowArray(SymbolExtractedData[] p_dayChanges, int p_start, int p_count)
        {
            float[] fRet = new float[p_count];
            for (int a = p_start; a < p_start + p_count; a++)
            {
                fRet[a - p_start] = p_dayChanges[a].Low;
            }
            return fRet;
        }

        protected static float ProtectedFuncA(float[] p_fa)
        {
            float fRet = ProtectedFuncA(p_fa, p_fa.Length);
            return fRet;
        }

        protected static float ProtectedFuncB(float[] p_fa)
        {
            float fRet = ProtectedFuncB(p_fa, p_fa.Length);
            return fRet;
        }

        protected static float ProtectedFuncC(int p_lengthToCalculate,float[] p_fa)
        {
            float fRet=ProtectedFuncC(p_fa, p_lengthToCalculate);
            return fRet;
        }
		#endregion (------  Protected Methods  ------)
    }
}
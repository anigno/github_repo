using System;
using System.Runtime.InteropServices;
using AnignoraFinanceAnalyzer4.Data;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.Analyzers
{
    public abstract class AnalyzeBase
    {
		#region (------  Constructors  ------)

        protected AnalyzeBase(string p_username,int p_key)
        {
            Logger.LogInfo("Authenticating {0}", p_username);
            int au = AuthenticateUsername(p_username.ToCharArray(),p_username.Length,p_key);
            if(au!=0)throw new Exception("Authentication Failed!\nError Code="+au);
        }

		#endregion (------  Constructors  ------)



        #region DllImport
        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "GetLicensedDate", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 GetLicensedDate();

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "AuthenticateUsername", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 AuthenticateUsername(char[] username, Int32 length, Int32 key);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncA", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncA(float[] array, int length);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncB", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncB(float[] array, int length);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncC", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncC(float[] array, int length);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncD", ExactSpelling = false,CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncD(float a, float b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncE", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncE(float a, float b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncF", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncF(float a, float b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncG", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFuncG(float a, float b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncH", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncH(int a, int b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncI", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 ProtectedFuncI(int a, int b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncJ", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 ProtectedFuncJ(int a, int b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncK", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 ProtectedFuncK(int a, int b);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncL", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncL(float v0, float v1);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncM", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncM(float v0, float v1);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFuncN", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int ProtectedFuncN(int v0, int v1);

        [DllImport("Analyzers\\ApplicationProtector.dll", EntryPoint = "ProtectedFormula1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern float ProtectedFormula1(float v0, float v1, float v2);

        #endregion

		#region (------------------  Properties  ------------------)
        //public abstract int MaxDaysHoldingPos  { get; internal set; }

        public abstract int MinimumDataLengthForAnalyze { get; }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Static Methods  ------------------)
        protected static float ProtectedFuncC(int p_lengthToCalculate,float[] fa)
        {
            float fRet=ProtectedFuncC(fa, p_lengthToCalculate);
            return fRet;
        }

        protected static float ProtectedFuncA(float[] fa)
        {
            float fRet = ProtectedFuncA(fa, fa.Length);
            return fRet;
        }

        protected static float ProtectedFuncB(float[] fa)
        {
            float fRet = ProtectedFuncB(fa, fa.Length);
            return fRet;
        }

        protected static float[] GetCloseArray(SymbolDailyData[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].Close;
            }
            return fRet;
        }

        protected static float[] GetHighArray(SymbolDailyData[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].High;
            }
            return fRet;
        }

     

        protected static float[] GetLowArray(SymbolDailyData[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].Low;
            }
            return fRet;
        }

        /// <summary>
        /// Returns true if there is no trade for current date from previous date, else returns false.
        /// </summary>
        public static bool IsNoTrade_del(SymbolDailyDataAnalyzed currentDay, SymbolDailyDataAnalyzed previousDay)
        {
            //Check that all data in current date are the same
            if (currentDay.Close == currentDay.Low && currentDay.Close == currentDay.High) return true;
            //Check that 2 of 3 data from previous date are equal in current date 
            float h0 = currentDay.High;
            float h1 = previousDay.High;
            float l0 = currentDay.Low;
            float l1 = previousDay.Low;
            float c0 = currentDay.Close;
            float c1 = previousDay.Close;
            int i = (h0 == h1 ? 1 : 0) + (l0 == l1 ? 1 : 0) + (c0 == c1 ? 1 : 0);
            if (i >= 2)
            {
                return true;
            }
            return false;
        }

        
		#endregion (------------------  Static Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        /// <summary>
        /// Run Analize() over given List, calculate all params. must set TimeUpdated param
        /// </summary>
        public abstract bool AnalyzeAll(SymbolDailyDataAnalyzed[] dayChanges);

		#endregion (------------------  Public Methods  ------------------)
    }
}
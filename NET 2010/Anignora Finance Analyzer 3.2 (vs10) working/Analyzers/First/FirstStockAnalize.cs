using System;
using FinanceAnalyzerData.Data;
using LoggingProvider;
using System.Runtime.InteropServices;

namespace Analyzers.First
{
    public class FirstStockAnalize : AnalizeBase
    {

        [DllImport("first\\Dreams.dll", EntryPoint = "FuscatedOne", ExactSpelling = false)]
        public static extern int FuscatedOne(int v);

        [DllImport("first\\Dreams.dll", EntryPoint = "FuscatedTwo", ExactSpelling = false)]
        public static extern float FuscatedTwo(float v0, float v1, float v2);

		#region (------------------  Const Fields  ------------------)
        internal const int Original_MaxDaysHoldingPos = 6;
        internal const int Original_LargeAvg = 190;
        private const int Original_NegativeResult = 79;
        private const int Original_PositiveResult = 21;
        private const int Original_SmallAvg = 39;
        private const int Original_FormulaOneParam = 9;
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        //public DateTime StartDate = new DateTime(1990, 1, 1);
        public FirstStockAnalize()
        {
            Logger.Log();
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Overridden Properties  ------------------)
        public override int DaysHoldingPos
        {
            get { return Original_MaxDaysHoldingPos; }
            internal set {  }
        }
		#endregion (------------------  Overridden Properties  ------------------)


		#region (------------------  Static Methods  ------------------)
        /// <summary>
        /// Analize one DayChangeData according to given prevSkip
        /// </summary>
        private static void Analize(DayChangeData[] DayChanges, int prevSkip, int smallAvg, int largeAvg, int negativeResult, int positiveResult, int formulaOneParam, out int res1, out int res2, out float res2per)
        {
            float[] fa = GetCloseArray(DayChanges, prevSkip, smallAvg);
            float Fn = Avg(fa);
            fa = GetCloseArray(DayChanges, prevSkip, largeAvg);
            float Gn = Avg(fa);
            int Hn = Math.Sign(Fn - Gn);
            res1 = Hn;
            float[] In = new float[3];
            In[0] = Formula1(DayChanges, prevSkip + 0,formulaOneParam);
            In[1] = Formula1(DayChanges, prevSkip + 1,formulaOneParam);
            In[2] = Formula1(DayChanges, prevSkip + 2,formulaOneParam);
            float Jn = Avg(In);
            int Kn = Jn > negativeResult ? -1 : 0;
            int Ln = Jn < positiveResult ? 1 : 0;
            int Mn = FuscatedOne(Kn + Ln);
            int Nn = FuscatedOne(Mn * Hn);
            int On = Nn == 1 ? Hn : 0;
            res2 = FuscatedOne(On);
            res2per = Jn;
        }

        public static bool AnalyzeAllWithParams(DayChangeDataAnalyzed[] dayChanges, int p_daysHoldingPos, int p_largeAvg, int p_smallAvg, int p_negResult, int p_posResult, int p_formulaOneParam,int positionsSum,int positionsDevider)
        {
            //Oldest LargAvg dates will not be analyzed!
            if (dayChanges.Length - p_largeAvg <= 0)
            {
                dayChanges[0].TimeAnalyzed = DateTime.Now;
                Logger.LogWarning("Not enough data to analyze {0}", dayChanges[0].StockDescriptor);
                return false;
            }
            for (int a = dayChanges.Length - p_largeAvg; a >= 0; a--)
            {
                int res1;
                int res2;
                float res2per;
                Analize(dayChanges, a,p_smallAvg,p_largeAvg,p_negResult,p_posResult,p_formulaOneParam, out res1, out res2, out res2per);
                dayChanges[a].AnalizedOne = res1;
                dayChanges[a].AnalizedTwo = res2;
                dayChanges[a].AnalyzedTwoPer = res2per;
                //Update time updated
                dayChanges[a].TimeAnalyzed = DateTime.Now;
            }
            FirstCalculations.CalculateOthers(dayChanges, p_daysHoldingPos, p_largeAvg,positionsSum,positionsDevider);
            return true;
        }

        private static float Formula1(DayChangeData[] DayChanges, int prevSkip,int formulaOneParam)
        {
            float v0 = DayChanges[prevSkip].Close;
            float[] fa = GetLowArray(DayChanges, prevSkip, formulaOneParam);
            float v1 = Min(fa);
            fa = GetHighArray(DayChanges, prevSkip, formulaOneParam);
            float v2 = Max(fa);
            float fRet = FuscatedTwo(v0, v1, v2);
            return fRet;
        }
		#endregion (------------------  Static Methods  ------------------)


		#region (------------------  Overridden Methods  ------------------)
        /// <summary>
        /// Run Analize() over given array and calculate all params
        /// </summary>
        public override bool AnalyzeAll(DayChangeDataAnalyzed[] dayChanges, int positionsSum, int positionsDevider)
        {
            Logger.LogDebug("dayChanges length={0}", dayChanges.Length);

            AnalyzeAllWithParams(dayChanges, Original_MaxDaysHoldingPos, Original_LargeAvg, Original_SmallAvg, Original_NegativeResult, Original_PositiveResult,Original_FormulaOneParam,positionsSum,positionsDevider);
            return true;
        }

        public override int MinimumDatesForAnalyze
        {
            get { return Original_LargeAvg; }
        }

        #endregion (------------------  Overridden Methods  ------------------)
    }
}
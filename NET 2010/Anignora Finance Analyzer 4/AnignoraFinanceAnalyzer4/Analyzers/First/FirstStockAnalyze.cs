using System;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.Analyzers.First
{
    public class FirstStockAnalyze : AnalyzeBase
    {
		#region (------  Fields  ------)

        private  int m_FORMULA_ONE_PARAM;
        private int m_LARGE_AVG;
        private readonly float m_negativeResult;
        private readonly float m_positiveResult;
        private  int m_SMALL_AVG;
        private int m_otherAvg;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FirstStockAnalyze(string p_username, int p_key, float p_negativeResult, float p_positiveResult,int p_formilaOneParam,int p_smallAverage,int p_largeAverage,int p_otherAvg)
            : base(p_username, p_key)
        {
            m_negativeResult = p_negativeResult;
            m_positiveResult = p_positiveResult;
            m_FORMULA_ONE_PARAM = p_formilaOneParam;
            m_LARGE_AVG = p_largeAverage;
            m_SMALL_AVG = p_smallAverage;
            m_otherAvg = p_otherAvg;
            Logger.Log();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

     
        public override int MinimumDataLengthForAnalyze
        {
            get { return m_LARGE_AVG; }
        }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

        public override bool AnalyzeAll(SymbolDailyDataAnalyzed[] p_dayChanges)
        {
            if (p_dayChanges.Length - MinimumDataLengthForAnalyze <= 0)
            {
                p_dayChanges[0].TimeAnalyzed = DateTime.Now;
                return false;
            }
            //Oldest MinimumDatesForAnalyze dates will not be analyzed!
            for (int prevSkip = p_dayChanges.Length - m_LARGE_AVG; prevSkip >= 0; prevSkip--)
            {
                int res1;
                int res2;
                float res2per;
                analize(p_dayChanges, prevSkip, out res1, out res2, out res2per);
                p_dayChanges[prevSkip].AnalizedOne = res1;
                p_dayChanges[prevSkip].AnalizedTwo = res2;
                p_dayChanges[prevSkip].AnalyzedTwoPer = res2per;
                //Update time updated
                p_dayChanges[prevSkip].TimeAnalyzed = DateTime.Now;
            }
            return true;
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        /// <summary>
        /// Analize one DayChangeData acording to given prevSkip
        /// </summary>
        private void analize(SymbolDailyDataAnalyzed[] p_dayChanges, int p_prevSkip, out int p_res1, out int p_res2, out float p_res2Per)
        {
            float[] fa = GetCloseArray(p_dayChanges, p_prevSkip, m_SMALL_AVG);
            float Fn = ProtectedFuncC(fa.Length, fa);
            fa = GetCloseArray(p_dayChanges, p_prevSkip, m_LARGE_AVG);
            float Gn = ProtectedFuncC(fa.Length, fa);
            int Hn = Math.Sign(Fn - Gn);
            p_res1 = Hn;
            float[] In = new float[3];
            In[0] = formula1(p_dayChanges, p_prevSkip + 0);
            In[1] = formula1(p_dayChanges, p_prevSkip + 1);
            In[2] = formula1(p_dayChanges, p_prevSkip + 2);
            float Jn = ProtectedFuncC(m_otherAvg, In);
            int Kn = ProtectedFuncL(Jn, m_negativeResult);
            int Ln = ProtectedFuncM(Jn, m_positiveResult);
            int Mn = ProtectedFuncH(Kn, Ln);
            int Nn = ProtectedFuncJ(Mn, p_res1);
            p_res2 = ProtectedFuncN(Nn, p_res1);
            
            p_res2Per = Jn;
        }

        private  float formula1(SymbolDailyData[] DayChanges, int prevSkip)
        {
            float v0 = DayChanges[prevSkip].Close;
            float[] fa = GetLowArray(DayChanges, prevSkip, m_FORMULA_ONE_PARAM);
            float v1 = ProtectedFuncB(fa);
            fa = GetHighArray(DayChanges, prevSkip, m_FORMULA_ONE_PARAM);
            float v2 = ProtectedFuncA(fa);
            float fRet = ProtectedFormula1(v0, v1, v2);
            return fRet;
        }

		#endregion (------  Private Methods  ------)
    }
}
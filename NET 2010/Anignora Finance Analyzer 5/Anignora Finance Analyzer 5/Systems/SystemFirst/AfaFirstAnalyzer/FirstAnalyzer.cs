using System;
using System.Collections.Generic;
using AfaDataExtraction;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer
{
    public class FirstAnalyzer : FirstAnalyzerProtector
    {
		#region (------  Fields  ------)

        private readonly int m_formulaOneParam;
        private readonly int m_largeAvg;
        private readonly float m_negativeResult;
        private readonly int m_otherAvg;
        private readonly bool m_useR1;
        private readonly float m_positiveResult;
        private readonly int m_smallAvg;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FirstAnalyzer(string p_username, int p_key, float p_negativeResult, float p_positiveResult, int p_formilaOneParam, int p_smallAverage, int p_largeAverage, int p_otherAvg,bool p_useR1)
            : base(p_username, p_key)
        {
            m_negativeResult = p_negativeResult;
            m_positiveResult = p_positiveResult;
            m_formulaOneParam = p_formilaOneParam;
            m_largeAvg = p_largeAverage;
            m_smallAvg = p_smallAverage;
            m_otherAvg = p_otherAvg;
            m_useR1 = p_useR1;
        }

		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)

        public FirstAnalyzeResult[] AnalyzeAll(SymbolExtractedData[] p_symbolsExtractedArray)
        {
            //Create list and fill with nulls as place holders
            List<FirstAnalyzeResult> resultsList = new List<FirstAnalyzeResult>(new FirstAnalyzeResult[p_symbolsExtractedArray.Length]);
            if (p_symbolsExtractedArray.Length - m_largeAvg <= 0)
            {
                return null;
            }
            //Oldest MinimumDatesForAnalyze dates will not be analyzed!
            for (int prevSkip = p_symbolsExtractedArray.Length - m_largeAvg; prevSkip >= 0; prevSkip--)
            {
                resultsList[prevSkip] = new FirstAnalyzeResult(p_symbolsExtractedArray[prevSkip]);
                int res1;
                int res2;
                float res2Per;
                analize(p_symbolsExtractedArray, prevSkip, out res1, out res2, out res2Per);
                resultsList[prevSkip].AnalyzedOne = res1;
                resultsList[prevSkip].AnalyzedTwo = res2;
                resultsList[prevSkip].AnalyzedTwoPer = res2Per;
            }
            return resultsList.ToArray();
        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        /// <summary>
        /// Analize one DayChangeData acording to given prevSkip
        /// </summary>
        private void analize(SymbolExtractedData[] p_dayChanges, int p_prevSkip, out int p_res1, out int p_res2, out float p_res2Per)
        {
            float[] fa = GetCloseArray(p_dayChanges, p_prevSkip, m_smallAvg);
            float fn = ProtectedFuncC(fa.Length, fa);
            fa = GetCloseArray(p_dayChanges, p_prevSkip, m_largeAvg);
            float gn = ProtectedFuncC(fa.Length, fa);
            int hn = Math.Sign(fn - gn);
            p_res1 = hn;
            float[] pn = new float[3];
            pn[0] = formula1(p_dayChanges, p_prevSkip + 0);
            pn[1] = formula1(p_dayChanges, p_prevSkip + 1);
            pn[2] = formula1(p_dayChanges, p_prevSkip + 2);
            float jn = ProtectedFuncC(m_otherAvg, pn);
            int kn = ProtectedFuncL(jn, m_negativeResult);
            int ln = ProtectedFuncM(jn, m_positiveResult);
            if (m_useR1)
            {
                int mn = ProtectedFuncH(kn, ln);
                int qn = ProtectedFuncJ(mn, p_res1);
                p_res2 = ProtectedFuncN(qn, p_res1);
            }
            else
            {
                int mn = ProtectedFuncH(kn, ln);
                p_res2 = mn;
            }
            p_res2Per = jn;
        }

        private  float formula1(SymbolExtractedData[] p_symbolExtractedDataArray, int p_prevSkip)
        {
            float v0 = p_symbolExtractedDataArray[p_prevSkip].Close;
            float[] fa = GetLowArray(p_symbolExtractedDataArray, p_prevSkip, m_formulaOneParam);
            float v1 = ProtectedFuncB(fa);
            fa = GetHighArray(p_symbolExtractedDataArray, p_prevSkip, m_formulaOneParam);
            float v2 = ProtectedFuncA(fa);
            float fRet = ProtectedFormula1(v0, v1, v2);
            return fRet;
        }

		#endregion (------  Private Methods  ------)
    }
}
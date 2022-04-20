using System;
using FinanceAnalyzerData.Data;
using NUnit.Framework;

namespace Analyzers
{
    public abstract class AnalizeBase
    {
		#region (------------------  Properties  ------------------)
        public abstract int DaysHoldingPos  { get; internal set; }

        public abstract int MinimumDatesForAnalyze { get; }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Static Methods  ------------------)
        protected static float Avg(float[] fa)
        {
            float sum = 0;
            foreach (float f in fa)
            {
                sum += f;
            }
            return sum / fa.Length;
        }

        protected static float[] GetCloseArray(DayChangeData[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].Close;
            }
            return fRet;
        }

        protected static float[] GetHighArray(DayChangeData[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].High;
            }
            return fRet;
        }

        public static float[] GetHitMissChangePerArray(DayChangeDataAnalyzed[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].HitMissChangePer;
            }
            return fRet;
        }

        protected static float[] GetLowArray(DayChangeData[] DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].Low;
            }
            return fRet;
        }

        public static float GetTotalHitMissProfitPer(DayChangeDataAnalyzed[] DayChanges, int start, int count)
        {
            float fRet = 0;
            for (int a = start; a < start + count; a++)
            {
                float v=Math.Abs(DayChanges[a].HitMissChangePer);
                if (DayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Hit) fRet += v;
                if (DayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Miss) fRet -= v;
            }
            return fRet;
        }

        public static float GetTotalHitsMissesRatio(DayChangeDataAnalyzed[] DayChanges, int start, int count)
        {
            float fRet;
            int hits = 0;
            int misses = 0;
            for (int a = start; a < start + count; a++)
            {
                if (DayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Hit) hits ++;
                if (DayChanges[a].Hit == DayChangeDataAnalyzed.HitStateEnum.Miss) misses ++;
            }
            fRet = (float)hits / (hits + misses);
            return fRet;
        }


        /// <summary>
        /// Returns true if there is no trade for current date from previous date, else returns false.
        /// </summary>
        public static bool IsNoTrade(DayChangeDataAnalyzed currentDay, DayChangeDataAnalyzed previousDay)
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

        protected static float Max(float[] fa)
        {
            float fRet = float.MinValue;
            foreach (float f in fa)
            {
                if (f > fRet) fRet = f;
            }
            return fRet;
        }

        protected static float Min(float[] fa)
        {
            float fRet = float.MaxValue;
            foreach (float f in fa)
            {
                if (f < fRet) fRet = f;
            }
            return fRet;
        }

        public static float StandardDeviation(float[] fa)
        {
            float avg = Avg(fa);
            double sum = 0;
            for (int a = 0; a < fa.Length; a++)
            {
                double d = Math.Pow(fa[a] - avg, 2);
                sum+=d;
            }
            sum = sum / fa.Length;
            return (float) Math.Sqrt(sum);
        }
		#endregion (------------------  Static Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        /// <summary>
        /// Run Analize() over given List, calculate all params. must set TimeUpdated param
        /// </summary>
        public abstract bool AnalyzeAll(DayChangeDataAnalyzed[] dayChanges, int positionsSum, int positionsDevider);
		#endregion (------------------  Public Methods  ------------------)
    }
}
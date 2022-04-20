using System;
using System.Collections.Generic;
using FinanceAnalizer.Data;
using NUnit.Framework;

namespace FinanceAnalizer
{
    [TestFixture]
    public class StockAnalizeFirst
    {
        public int SmallAvg = 39;
        public int LargeAvg = 190;
        public int NegativeResult=79;
        public int PositiveResult = 21;
        public int DaysForTrans = 6;
        public DateTime StartDate = new DateTime(1990,1,1);


		#region (------------------  Private Methods  ------------------)
        private float Avg(float[] fa)
        {
            float sum=0;
            foreach (float f in fa)
            {
                sum+=f;
            }
            return sum / fa.Length;
        }

        private float Formula1(List<DayChangeData> DayChanges, int prevSkip)
        {
            float v0 = DayChanges[prevSkip].Close;
            float[] fa = GetLowArray(DayChanges, prevSkip, 9);
            float v1 = Min(fa);
            fa = GetHighArray(DayChanges, prevSkip, 9);
            float v2 = Max(fa);
            return (v0 - v1) / (v2 - v1) * 100;
        }

        private float[] GetCloseArray(List<DayChangeData> DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].Close;
            }
            return fRet;
        }

        private float[] GetHighArray(List<DayChangeData> DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].High;
            }
            return fRet;
        }

        private float[] GetLowArray(List<DayChangeData> DayChanges, int start, int count)
        {
            float[] fRet = new float[count];
            for (int a = start; a < start + count; a++)
            {
                fRet[a - start] = DayChanges[a].Low;
            }
            return fRet;
        }

        private float Max(float[] fa)
        {
            float fRet = float.MinValue;
            foreach (float f in fa)
            {
                if (f > fRet) fRet = f;
            }
            return fRet;
        }

        private float Min(float[] fa)
        {
            float fRet = float.MaxValue;
            foreach (float f in fa)
            {
                if (f < fRet) fRet = f;
            }
            return fRet;
        }
		#endregion (------------------  Private Methods  ------------------)


		#region (------------------  Public Methods  ------------------)
        public void Analize(List<DayChangeData> DayChanges, out int res1, out int res2, int prevSkip)
        {
            float[] fa = GetCloseArray(DayChanges, prevSkip,  SmallAvg);
            float Fn = Avg(fa);
            fa = GetCloseArray(DayChanges, prevSkip, LargeAvg);
            float Gn = Avg(fa);
            int Hn = Math.Sign(Fn - Gn);
            res1=Hn;
            float[] In = new float[3];
            In[0] = Formula1(DayChanges, prevSkip + 0);
            In[1] = Formula1(DayChanges, prevSkip + 1);
            In[2] = Formula1(DayChanges, prevSkip + 2);
            float Jn = Avg(In);
            int Kn = Jn > NegativeResult ? -1 : 0;
            int Ln = Jn < PositiveResult ? 1 : 0;
            int Mn=Kn+Ln;
            int Nn=Mn*Hn;
            int On = Nn == 1 ? Hn : 0;
            res2=On;
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}

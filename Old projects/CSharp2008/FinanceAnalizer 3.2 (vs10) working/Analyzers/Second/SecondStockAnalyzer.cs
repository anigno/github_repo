using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinanceAnalyzerData.Data;
using LoggingProvider;

namespace Analyzers.Second
{
    public class SecondStockAnalyzer : AnalizeBase
    {
        private int largeAvg = 60;
        private int smallAvg = 12;

        public override bool AnalyzeAll(DayChangeDataAnalyzed[] dayChanges, int positionsSum, int positionsDevider)
        {
            Logger.LogDebug("dayChanges length={0}", dayChanges.Length);
            //Oldest LargAvg dates will not be analyzed!
            if (dayChanges.Length - largeAvg <= 0)
            {
                Logger.LogWarning("Not enough data to analyze {0}", dayChanges[0].StockDescriptor);
                return false;
            }
            for (int a = dayChanges.Length - largeAvg; a >= 0; a--)
            {
                int res1;
                int res2;
                float res2per;
                Analize(dayChanges, a, out res1, out res2, out res2per);
                dayChanges[a].AnalizedOne = res1;
                dayChanges[a].AnalizedTwo = res2;
                dayChanges[a].AnalyzedTwoPer = res2per;
                //Update time updated
                dayChanges[a].TimeAnalyzed = DateTime.Now;
            }
            CalculateOthers(dayChanges);
            return true;
        }

        public override int MinimumDatesForAnalyze
        {
            get { return largeAvg; }
        }

        private void Analize(DayChangeDataAnalyzed[] dayChanges, int index, out int res1, out int res2, out float res2per)
        {
            float[] cal = GetCloseArray(dayChanges, index, largeAvg);
            float[] cas = GetCloseArray(dayChanges, index, smallAvg);
            float la=Avg(cal);
            float sa = Avg(cas);
            res1 = sa > la ? -1 : 1;
            res2 = res1 == dayChanges[index + 1].AnalizedOne ? 0 : 1;
            res2per=la-sa;
        }



        protected void CalculateOthers(DayChangeDataAnalyzed[] dayChanges)
        {
            if (dayChanges.Length - largeAvg <= 0)
            {
                Logger.LogWarning("Not enough data to analyze {0}", dayChanges[0].StockDescriptor);
                return;
            }
            for (int a = dayChanges.Length - largeAvg; a >= 0; a--)
            {
                dayChanges[a].DailyChangePer = (dayChanges[a].Close - dayChanges[a + 1].Close) / dayChanges[a + 1].Close * 100;
                dayChanges[a].SignalType = dayChanges[a].AnalizedTwo == 1 && dayChanges[a].AnalizedOne == 1 ? DayChangeDataAnalyzed.SignalTypeEnum.Long : DayChangeDataAnalyzed.SignalTypeEnum.None;
                dayChanges[a].Hit = dayChanges[a].AnalizedTwo == 1 && dayChanges[a].AnalizedOne == -1 ? DayChangeDataAnalyzed.HitStateEnum.Hit : DayChangeDataAnalyzed.HitStateEnum.None;
            }
           
        }



        public override int DaysHoldingPos
        {
            get { return 1; }
            internal set {  }
        }
    }
}

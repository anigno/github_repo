using System.Collections.Generic;
using System.Linq;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;

namespace AnignoraFinanceAnalyzer4.Analyzers.MoneyFlowIndex
{
    public static class MoneyFlowIndexAnlyzer
    {
        public static float CalculateMfi(SymbolDailyDataAnalyzed[] p_dayChanges,int p_prevSkip,int p_length)
        {
            CalculateRawMoneyFlowForAll(p_dayChanges);
            float positiveSum = 0f;
            float negativeSum = 0f;
            for (int i = p_prevSkip; i < p_prevSkip + p_length; i++)
            {
                if (p_dayChanges[i].TypicalPrice >= p_dayChanges[i + 1].TypicalPrice)
                {
                    positiveSum += p_dayChanges[i].RawMoneyFlow;
                }
                else
                {
                    negativeSum += p_dayChanges[i].RawMoneyFlow;
                }
            }
            if (negativeSum == 0) return 100;
            float moneyFlowRatio = positiveSum / negativeSum;
            float moneyFlowIndex = 100 - 100 / (1 + moneyFlowRatio);
            return moneyFlowIndex;
        }

        public static void CalculateRawMoneyFlowForAll(SymbolDailyDataAnalyzed[] p_dayChanges)
        {
            foreach (SymbolDailyDataAnalyzed dailyData in p_dayChanges)
            {
                dailyData.TypicalPrice = (dailyData.High + dailyData.Low + dailyData.Close) / 3.0f;
                dailyData.RawMoneyFlow = dailyData.TypicalPrice * dailyData.Volume;
            }
        }

       
    }
}

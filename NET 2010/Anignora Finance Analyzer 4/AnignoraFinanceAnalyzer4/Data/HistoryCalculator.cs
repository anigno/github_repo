using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.Data
{
    public class HistoryCalculator
    {

        private string[] m_descriptors;
        private DateTime m_fromDate;
        private DateTime m_toDate;

        public int HitsLongsNumber { get; private set; }
        public int MissesLongsNumber { get; private set; }
        public int HitsShortsNumber { get; private set; }
        public int MissesShortsNumber { get; private set; }

        public float HitsLongsPer { get; private set; }
        public float MissesLongsPer { get; private set; }
        public float HitsShortsPer { get; private set; }
        public float MissesShortsPer { get; private set; }

        public SortedDictionary<DateTime, DailyCalculatedData> CalculateHistory(string[] descriptors, DateTime fromDate, DateTime toDate)
        {
            Logger.Log();
            m_descriptors = descriptors;
            m_fromDate = fromDate;
            m_toDate = toDate;
            HitsLongsNumber = 0;
            MissesLongsNumber = 0;
            HitsShortsNumber = 0;
            MissesShortsNumber = 0;
            HitsLongsPer = 0;
            MissesLongsPer = 0;
            HitsShortsPer = 0;
            MissesShortsPer = 0;

            return CalculateSymbolsHistory();
        }

        private SortedDictionary<DateTime, DailyCalculatedData> CalculateSymbolsHistory()
        {
            Logger.Log();
            SortedDictionary<DateTime, DailyCalculatedData> dicRet = new SortedDictionary<DateTime, DailyCalculatedData>();
            foreach (string descriptor in m_descriptors)
            {
                if (descriptor == DataManager.INDEX_SYMBOL) continue;
                SymbolDailyDataAnalyzed[] symbolDailyData = DataManager.Instance.GetSymbolDailyDataAnalyzed(descriptor);
                for (int index = symbolDailyData.Length - 1; index >= 0; index--)
                {
                    SymbolDailyDataAnalyzed dailyData = symbolDailyData[index];
                    if (dailyData.ReadDate < m_fromDate || dailyData.ReadDate > m_toDate) continue;
                    
                    if (dailyData.SignalHitMiss == SymbolDailyDataAnalyzed.SignalHitMissEnum.None) continue;
                    if (!dicRet.ContainsKey(dailyData.ReadDate)) dicRet.Add(dailyData.ReadDate, new DailyCalculatedData());
                    DailyCalculatedData dailyCalculatedData = dicRet[dailyData.ReadDate];
                    float signalMul = dailyData.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Long ? 1 : -1;

                    
                    dailyCalculatedData.DailyDeltaPer += dailyData.DailyChangePer;



                    switch (dailyData.SignalHitMiss)
                    {
                        case SymbolDailyDataAnalyzed.SignalHitMissEnum.Hit:
                            dailyCalculatedData.DailyChangePer += dailyData.SignalToDateChangePer * signalMul;
                            switch (dailyData.SignalType)
                            {
                                case SymbolDailyDataAnalyzed.SignalTypeEnum.Long:
                                    HitsLongsNumber++;
                                    HitsLongsPer += dailyData.SignalToDateChangePer * signalMul;
                                    break;
                                case SymbolDailyDataAnalyzed.SignalTypeEnum.Short:
                                    HitsShortsNumber++;
                                    HitsShortsPer += dailyData.SignalToDateChangePer * signalMul;
                                    break;
                            }
                            break;
                        case SymbolDailyDataAnalyzed.SignalHitMissEnum.Miss:
                            dailyCalculatedData.DailyChangePer += dailyData.SignalToDateChangePer * signalMul;
                            switch (dailyData.SignalType)
                            {
                                case SymbolDailyDataAnalyzed.SignalTypeEnum.Long:
                                    MissesLongsNumber++;
                                    MissesLongsPer += dailyData.SignalToDateChangePer * signalMul;
                                    break;
                                case SymbolDailyDataAnalyzed.SignalTypeEnum.Short:
                                    MissesShortsNumber++;
                                    MissesShortsPer += dailyData.SignalToDateChangePer * signalMul;
                                    break;
                            }
                            break;
                    }
                }
            }
            return dicRet;
        }

    }
}

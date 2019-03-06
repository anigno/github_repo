using System;
using AnignoraFinanceAnalyzer4.Analyzers.MoneyFlowIndex;
using AnignoraFinanceAnalyzer4.Data.SymbolsDataItems;
using AnignoraFinanceAnalyzer4.Data;
using LoggingProvider;

namespace AnignoraFinanceAnalyzer4.Analyzers.First
{
    public class FirstCalculations : CalculationsBase
    {
		#region (------  Fields  ------)

        private readonly int m_maxDaysHoldingPos;
        private readonly int m_minimumDataLengthForAnalyze;
        private readonly object m_syncRoot=new object();

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public FirstCalculations(int p_minDataLengthForAnalyze)
        {
            m_minimumDataLengthForAnalyze = p_minDataLengthForAnalyze;
            m_maxDaysHoldingPos = DataManager.Instance.ApplicationDataItem.MaxDaysHoldingPosition;
            Logger.LogDebug("MaxDaysHoldingPosition:{0} minimumDataLengthForAnalyze:{1}", m_maxDaysHoldingPos, m_minimumDataLengthForAnalyze);
        }

		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)

        public override void CalculateAll(string p_descriptor, SymbolDailyDataAnalyzed[] p_dayChanges)
        {
            Logger.LogDebug("descriptor:{0} dayChanges length:{1}", p_descriptor, p_dayChanges.Length);
            if (p_dayChanges.Length - m_minimumDataLengthForAnalyze <= 0)
            {
                Logger.LogWarning("data length too short for calculating");
                return;
            }
            float doublerStart = DataManager.Instance.ApplicationDataItem.DoublerStart;
            for (int iTested = p_dayChanges.Length - m_minimumDataLengthForAnalyze; iTested >= 0; iTested--)
            {
                setParams(p_dayChanges,iTested);
                if (p_dayChanges[0].Descriptor == DataManager.INDEX_SYMBOL) continue; //Index symbol is not calculated
                if (p_dayChanges[iTested].SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.None) continue;  //Nothing to do
                //Iterate through next maxPositionDays from tested date [i] by [j] and calculate data
                for (int iIterator = iTested - 1; iIterator >= (iTested - (m_maxDaysHoldingPos + 1) + 1 > 0 ? iTested - (m_maxDaysHoldingPos + 1) + 1 : 0); iIterator--)
                {
                    if (p_dayChanges[iTested].SignalState == SymbolDailyDataAnalyzed.SignalStateEnum.Waiting) //SymbolData is created in waiting state
                    {
                        p_dayChanges[iTested].SignalToDateChangePer = calcSignalToDateChangePer(p_dayChanges[iIterator].Close, p_dayChanges, iTested);
                        if (iTested - iIterator + 1 == (m_maxDaysHoldingPos + 1))
                        {
                            //Max position days
                            p_dayChanges[iTested].SignalState = SymbolDailyDataAnalyzed.SignalStateEnum.ATC;
                            p_dayChanges[iTested].ConditionedDate = p_dayChanges[iIterator].ReadDate;
                        }
                        if (isConditionFulfilled(p_dayChanges, iTested, iIterator))
                        {
                            //Conditioned
                            p_dayChanges[iTested].SignalState = SymbolDailyDataAnalyzed.SignalStateEnum.ATC;
                            p_dayChanges[iTested].ConditionedDate = p_dayChanges[iIterator].ReadDate;
                        }
                    }
                    if (p_dayChanges[iTested].SignalState == SymbolDailyDataAnalyzed.SignalStateEnum.ATC)
                    {

                        p_dayChanges[iTested].SignalToDateChangePer = calcSignalToDateChangePer(getSymbolData(p_dayChanges, p_dayChanges[iTested].ConditionedDate).Close, p_dayChanges, iTested);
                        if (!isConditionFulfilled(p_dayChanges, iTested, iIterator) && (iTested - iIterator + 1 < (m_maxDaysHoldingPos + 1)))
                        {
                            p_dayChanges[iTested].SignalState = SymbolDailyDataAnalyzed.SignalStateEnum.Waiting;
                        }
                        if (p_dayChanges[iTested].ConditionedDate <= p_dayChanges[0].ReadDate && p_dayChanges[iTested].ConditionedDate!=DateTime.MinValue)
                        {
                            p_dayChanges[iTested].SignalState = SymbolDailyDataAnalyzed.SignalStateEnum.Closed;
                        }

                    }
                    if (p_dayChanges[iTested].SignalState == SymbolDailyDataAnalyzed.SignalStateEnum.Closed)
                    {
                        p_dayChanges[iTested].SignalToDateChangePer = calcSignalToDateChangePer(getSymbolData(p_dayChanges, p_dayChanges[iTested].ConditionedDate).Close, p_dayChanges,iTested);
                        setHitMiss(p_dayChanges[iTested]);
                    }
                    //Set Doubler Date according to calculated SignalToDateChangePer
                    int signalMul = p_dayChanges[iTested].SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Long ? 1 : -1;
                    if (DataManager.Instance.ApplicationDataItem.UseDoubler)
                    {
                        if (signalMul * p_dayChanges[iTested].SignalToDateChangePer < -doublerStart/100 && p_dayChanges[iTested].DoublerFirstDate==DateTime.MinValue)
                        {
                            p_dayChanges[iTested].DoublerFirstDate = p_dayChanges[iIterator].ReadDate;
                            p_dayChanges[iTested].DoublerFirstDateSet = true;
                        }
                    }
                }
            }
          
            calculateActiveSymbols(p_dayChanges);

        }

		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)

        private float calcChangePerSimple(float p_fLast, float p_fFirst, float p_fSymbolMultiplier)
        {
            return (p_fLast / p_fFirst - 1) * p_fSymbolMultiplier;
        }

        private float calcSignalToDateChangePer(float p_iteratorNewerClose,SymbolDailyDataAnalyzed[] p_symbolData,int p_iTested)
        {
            float regularMultiplier = DataManager.Instance.ApplicationDataItem.RegularMultiplier;
            SymbolDailyDataAnalyzed testedSymbolData = p_symbolData[p_iTested];
            float testedClose = testedSymbolData.Close;
            float symbolMultiplier = testedSymbolData.GetSymbolMultiplier();
            float newestClose = p_iteratorNewerClose;
            float oldestClose = testedSymbolData.Close;

            float doublerParam = DataManager.Instance.ApplicationDataItem.DoublerMultiplier;

            if (testedSymbolData.DoublerFirstDateSet)
            {
                //Use doubler
                DateTime doublerDate = testedSymbolData.DoublerFirstDate;
                float doublerClose = getSymbolData(p_symbolData, doublerDate).Close;
                float fRet1 = regularMultiplier * calcChangePerSimple(doublerClose, oldestClose, symbolMultiplier * 1f);
                float fRet2 = calcChangePerSimple(newestClose, doublerClose, symbolMultiplier * (0f + doublerParam));
                float fRet = (1 + fRet1)*(1 + fRet2);
                return fRet - 1;
            }
            else
            {
                //No doubler
                float fRet = regularMultiplier*calcChangePerSimple(p_iteratorNewerClose, testedClose, symbolMultiplier);
                return fRet;
            }
        }

        int m_activeSymbolsClearCounter = 0;

        private void calculateActiveSymbols(SymbolDailyDataAnalyzed[] p_dayChanges)
        {
            lock (m_syncRoot)
            {
                m_activeSymbolsClearCounter++;
            }
            if (m_activeSymbolsClearCounter > 3000)
            {
                DataManager.Instance.ClearActiveSymbols();
                m_activeSymbolsClearCounter = 0;
            }

            if (p_dayChanges[0].Descriptor == DataManager.INDEX_SYMBOL) return;
            for(int a=0;a<m_maxDaysHoldingPos+1;a++)
            {
                if (p_dayChanges[a].SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.None)
                {
                    //probably an old signal, remove if exist
                    DataManager.Instance.RemoveActiveSymbol(p_dayChanges[a]);
                    continue;
                }
                if(
                    p_dayChanges[a].SignalState==SymbolDailyDataAnalyzed.SignalStateEnum.Closed &&
                    p_dayChanges[a].ConditionedDate!=p_dayChanges[0].ReadDate)
                {
                    //Closed signal not from the reading date, remove if exist
                    DataManager.Instance.RemoveActiveSymbol(p_dayChanges[a]);
                    continue;
                }
                //Add or update
                DataManager.Instance.AddUpdateActiveSymbol(p_dayChanges[a]);
            }
            DataManager.Instance.UpdateActiveTotalAndCountParams();
        }

        private float getProfitCutToUse(SymbolDailyDataAnalyzed p_dailyData)
        {
            if (p_dailyData.DoublerFirstDateSet)
            {
                return DataManager.Instance.ApplicationDataItem.ProfitCutDoubler;
            }
            return DataManager.Instance.ApplicationDataItem.ProfitCut;
        }

        private static int GetQuantityForPositionValue(SymbolDailyDataAnalyzed p_dayChange, int p_positionsSum, int p_positionsDevider)
        {
            float sp = p_positionsSum / p_dayChange.Close / p_positionsDevider * p_dayChange.GetSymbolMultiplier();
            int ret = (int)sp * p_positionsDevider;
            return ret;
        }

        private SymbolDailyDataAnalyzed getSymbolData(SymbolDailyDataAnalyzed[] dayChanges, DateTime date)
        {
            foreach (SymbolDailyDataAnalyzed dayChange in dayChanges)
            {
                if (dayChange.ReadDate == date) return dayChange;
            }
            return null;
        }

        private bool isConditionFulfilled(SymbolDailyDataAnalyzed[] p_dayChanges, int p_iTested, int p_iIterator)
        {
            //Set different profit cut for doubling or not
            float suitableProfitCut = getProfitCutToUse(p_dayChanges[p_iTested]);
            //Profit cut
            float change = 100*calcSignalToDateChangePer(p_dayChanges[p_iIterator].Close, p_dayChanges, p_iTested);
            float signalMul = p_dayChanges[p_iTested].SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Long ? 1 : -1;
            //Profit cut
            if (change * signalMul >= suitableProfitCut) return true;
            //Loss cut
            if (change*-signalMul >= DataManager.Instance.ApplicationDataItem.LossCut) return true;
            return false;
        }

        private void setHitMiss(SymbolDailyDataAnalyzed dayChange)
        {
            if (dayChange.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Long && dayChange.SignalToDateChangePer >= 0)
            {
                dayChange.SignalHitMiss = SymbolDailyDataAnalyzed.SignalHitMissEnum.Hit;
                return;
            }
            if (dayChange.SignalType == SymbolDailyDataAnalyzed.SignalTypeEnum.Short && dayChange.SignalToDateChangePer <= 0)
            {
                dayChange.SignalHitMiss = SymbolDailyDataAnalyzed.SignalHitMissEnum.Hit;
                return;
            }
            dayChange.SignalHitMiss = SymbolDailyDataAnalyzed.SignalHitMissEnum.Miss;
        }

        /// <summary>
        /// Set SignalType, DailyChangePer and QuantityForPosition values, and reset other params.
        /// </summary>
        private void setParams(SymbolDailyDataAnalyzed[] p_dayChanges, int p_index)
        {
            int minDaysBetweenPosition = DataManager.Instance.ApplicationDataItem.MinDaysBetweenPosition;
            //Reset values
            p_dayChanges[p_index].ConditionedDate = DateTime.MinValue;
            p_dayChanges[p_index].DoublerFirstDate = DateTime.MinValue;
            p_dayChanges[p_index].DoublerFirstDateSet = false;
            p_dayChanges[p_index].SignalState = SymbolDailyDataAnalyzed.SignalStateEnum.Waiting;
            p_dayChanges[p_index].SignalHitMiss = SymbolDailyDataAnalyzed.SignalHitMissEnum.None;

            //SignalType
            p_dayChanges[p_index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.None;
            //if (dayChanges[index].AnalizedTwo == -1 && dayChanges[index + 1].AnalizedTwo == 0)dayChanges[index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.Short;
            //if (dayChanges[index].AnalizedTwo == 1 && dayChanges[index + 1].AnalizedTwo == 0)dayChanges[index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.Long;

            bool useMfi = DataManager.Instance.ApplicationDataItem.UseMfi;
            if (useMfi)
            {
                //New position settings with MFI
                int mfiA = DataManager.Instance.ApplicationDataItem.mfiA;
                int mfiB = DataManager.Instance.ApplicationDataItem.mfiB;

                float mfiALow = DataManager.Instance.ApplicationDataItem.mfiALow;
                float mfiAHigh = DataManager.Instance.ApplicationDataItem.mfiAHigh;

                float mfi_a = MoneyFlowIndexAnlyzer.CalculateMfi(p_dayChanges, p_index, mfiA);
                float mfi_b = MoneyFlowIndexAnlyzer.CalculateMfi(p_dayChanges, p_index, mfiB);
                float mfi_aPrev = MoneyFlowIndexAnlyzer.CalculateMfi(p_dayChanges, p_index + 1, mfiA);

                p_dayChanges[p_index].MoneyFlowIndexA = mfi_a;
                p_dayChanges[p_index].MoneyFlowIndexB = mfi_b;

                if (p_dayChanges[p_index].AnalizedOne == 1 && mfi_a <= mfiALow && mfi_b == 0 && mfi_aPrev > 20)
                    p_dayChanges[p_index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.Long;
                if (p_dayChanges[p_index].AnalizedOne == -1 && mfi_a >= mfiAHigh && mfi_b == 100 && mfi_aPrev < 80)
                    p_dayChanges[p_index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.Short;
            }
            else
            {
                //Old position settings
                if (p_dayChanges[p_index].AnalizedTwo == -1 && getDaysWithoutSignal(p_dayChanges, p_index) > minDaysBetweenPosition)
                    p_dayChanges[p_index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.Short;
                if (p_dayChanges[p_index].AnalizedTwo == 1 && getDaysWithoutSignal(p_dayChanges, p_index) > minDaysBetweenPosition)
                    p_dayChanges[p_index].SignalType = SymbolDailyDataAnalyzed.SignalTypeEnum.Long;
            }

            //DailyChangePer
            float symbolmultiplier = p_dayChanges[0].GetSymbolMultiplier();
            p_dayChanges[p_index].DailyChangePer = calcChangePerSimple(p_dayChanges[p_index].Close, p_dayChanges[p_index + 1].Close, symbolmultiplier);
            p_dayChanges[p_index].DailyChangePerRecent = calcChangePerSimple(p_dayChanges[0].Close, p_dayChanges[0 + 1].Close, symbolmultiplier);
            //QuantityForPosition
            p_dayChanges[p_index].QFP = GetQuantityForPositionValue(p_dayChanges[p_index], DataManager.Instance.ApplicationDataItem.TradeSum, DataManager.Instance.ApplicationDataItem.TradeDevider);
        }

        private int getDaysWithoutSignal(SymbolDailyDataAnalyzed[] p_dayChanges, int p_index)
        {
            p_index++;
            for (int i = p_index ; i <= p_index+m_maxDaysHoldingPos; i++)
            {
                int iRet = i - p_index;
                if (p_dayChanges[i].AnalizedTwo != 0) return iRet+1;
            }
            return m_maxDaysHoldingPos+1;
        }

        #endregion (------  Private Methods  ------)
    }
}

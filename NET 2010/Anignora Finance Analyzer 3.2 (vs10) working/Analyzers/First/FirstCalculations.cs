using FinanceAnalyzerData.Data;
using LoggingProvider;

namespace Analyzers.First
{
    internal class FirstCalculations
    {
		#region (------------------  Static Methods  ------------------)
        /// <summary>
        /// Returns ChangePer, from signaled date to trans date
        /// </summary>
        private static float CalculateHitMissChangePer(DayChangeDataAnalyzed[] dayChanges, int a, int daysHoldingPos)
        {
            //If Hit/Miss calculate changePer
            if (dayChanges[a].Hit != DayChangeDataAnalyzed.HitStateEnum.None)
            {
                return (dayChanges[a].Close - dayChanges[a + daysHoldingPos].Close) / dayChanges[a + daysHoldingPos].Close * 100;
            }
            return  0;
        }

        /// <summary>
        /// Calculate all other helping values
        /// </summary>
        public static bool CalculateOthers(DayChangeDataAnalyzed[] dayChanges, int daysHoldingPos,int LargeAvg,int positionsSum,int positionsDevider)
        {
            if (dayChanges.Length - LargeAvg <= 0)
            {
                Logger.LogWarning("Not enough data to analyze {0}", dayChanges[0].StockDescriptor);
                return false;
            }
            for (int a = dayChanges.Length - LargeAvg; a >= 0; a--)
            {
                float multiplier = DayChangeData.GetStockMultiplier(dayChanges[a].StockDescriptor);

                dayChanges[a].SignalType = GetSignalType(dayChanges[a], dayChanges[a + 1]);
                dayChanges[a].Hit = HitOrMiss(dayChanges[a], dayChanges[a + daysHoldingPos]);
                dayChanges[a].StockActiveSignal = CheckActiveUpdateChangeToCurrentDate(dayChanges, a,daysHoldingPos,multiplier);
                dayChanges[a].HitMissChangePer=CalculateHitMissChangePer(dayChanges, a,daysHoldingPos)*multiplier;
                dayChanges[a].DailyChangePer = (dayChanges[a].Close - dayChanges[a + 1].Close) / dayChanges[a + 1].Close * 100*multiplier;
                dayChanges[a].QuantityForPos = GetQuantityForPositionValue(dayChanges[a],positionsSum,positionsDevider);
            }
            //UpdateTestValue(dayChanges, 0,daysHoldingPos);
            return true;
        }

        private static int GetQuantityForPositionValue(DayChangeDataAnalyzed dayChange,int positionsSum,int positionsDevider)
        {
            float sp=positionsSum/dayChange.Close/positionsDevider;
            int ret= (int)sp * positionsDevider;
            return ret;
        }

        //Return signalType for stock and update SignalToDateChangePer field with change per from signaled date
        private static DayChangeDataAnalyzed.SignalTypeEnum CheckActiveUpdateChangeToCurrentDate(DayChangeDataAnalyzed[] dayChanges, int index, int daysHoldingPos,float multiplier)
        {
            if (index >= dayChanges.Length) return DayChangeDataAnalyzed.SignalTypeEnum.None;
            DayChangeDataAnalyzed.SignalTypeEnum ret = DayChangeDataAnalyzed.SignalTypeEnum.None;
            for (int a = index; a < index + daysHoldingPos + 1; a++)
            {
                if (dayChanges[a].SignalType != DayChangeDataAnalyzed.SignalTypeEnum.None)
                {
                    dayChanges[a].SignalToDateChangePer = (dayChanges[index].Close / dayChanges[a].Close - 1) * 100f * multiplier;
                    //dayChanges[index].SignalToDateChangePer = dayChanges[a].SignalToDateChangePer;
                    ret = dayChanges[a].SignalType;
                }
            }
            return ret;
        }

        /// <summary>
        /// Returns the signal type
        /// </summary>
        private static DayChangeDataAnalyzed.SignalTypeEnum GetSignalType(DayChangeDataAnalyzed currentDayChange, DayChangeDataAnalyzed prevDayChange)
        {
            //If previous was signaled, this one couldn not be
            if (prevDayChange.AnalizedTwo != 0) return DayChangeDataAnalyzed.SignalTypeEnum.None;
            //Return signal type according to analyzedTwo value
            if (currentDayChange.AnalizedTwo == 1) return DayChangeDataAnalyzed.SignalTypeEnum.Long;
            if (currentDayChange.AnalizedTwo == -1) return DayChangeDataAnalyzed.SignalTypeEnum.Short;
            //No signal for this dayChange data
            return DayChangeDataAnalyzed.SignalTypeEnum.None;
        }

        /// <summary>
        /// Returns if Hit, Miss or None
        /// </summary>
        private static DayChangeDataAnalyzed.HitStateEnum HitOrMiss(DayChangeDataAnalyzed currentDayChange, DayChangeDataAnalyzed prevDayChangeFromTrans)
        {
            //If there was no signal
            if (prevDayChangeFromTrans.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.None) return DayChangeDataAnalyzed.HitStateEnum.None;
            //If signal was Long and Close increased
            if (prevDayChangeFromTrans.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Long)
            {
                if (prevDayChangeFromTrans.Close < currentDayChange.Close) return DayChangeDataAnalyzed.HitStateEnum.Hit;
            }
            //If signal was Short and Close decreased
            if (prevDayChangeFromTrans.SignalType == DayChangeDataAnalyzed.SignalTypeEnum.Short)
            {
                if (prevDayChangeFromTrans.Close > currentDayChange.Close) return DayChangeDataAnalyzed.HitStateEnum.Hit;
            }
            return DayChangeDataAnalyzed.HitStateEnum.Miss;
        }

        //private static void UpdateTestValue(DayChangeDataAnalyzed[] dayChanges, int a, int daysHoldingPos)
        //{
        //    dayChanges[a].fTest = "";
        //    for (int i = a; i <= a + daysHoldingPos; i++)
        //    {
        //        if (dayChanges[i].SignalType != DayChangeDataAnalyzed.SignalTypeEnum.None)
        //        {
        //            float f = (dayChanges[a].Close / dayChanges[i].Close - 1) * 100f;
        //            dayChanges[a].fTest += dayChanges[i].SignalType.ToString().Substring(0, 1) + f.ToString(" 0.00");
        //        }
        //    }
        //}
		#endregion (------------------  Static Methods  ------------------)
    }
}
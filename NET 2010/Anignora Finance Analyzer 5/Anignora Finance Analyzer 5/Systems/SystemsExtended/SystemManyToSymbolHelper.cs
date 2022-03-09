using System;
using System.Collections.Generic;
using System.Linq;
using AfaDataExtraction;
using AnignoraDataTypes;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class SystemManyToSymbolHelper
    {
        private static ILog s_log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static SignalOpenCloseData[] CollectAllTriggersOpenClose(AfaSystemBase p_system, SignalTypeEnum p_triggerSignalType, string p_profitSymbolName, string[] p_nonTriggerSymbols)
        {
            List<SignalOpenCloseData> openCloseList = new List<SignalOpenCloseData>();
            //Prevent profitSymbol from prev iteration to became a trigger to next iterator
            string[] symbolsNames = p_system.SymbolsWebNames.Except(new[] { p_profitSymbolName }).Except(p_nonTriggerSymbols).ToArray();
            symbolsNames.DoForAll(p_symbolName =>
            {
                FirstCalculatorResult[] results = p_system.GetSymbolCalculatedResults(p_symbolName);
                results = results.Where(p_result => p_result.SignalType == p_triggerSignalType).ToArray();
                results.DoForAll(p_result =>
                {
                    DateTime dateRead = p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    DateTime closeDate = p_result.DateClose;
                    SignalOpenCloseData signalData = new SignalOpenCloseData(
                        dateRead,
                        closeDate < dateRead ? dateRead.AddDays(90) : closeDate,
                        p_result.SignalType,
                        p_symbolName);
                    openCloseList.Add(signalData);
                });

            });
            return openCloseList.ToArray();
        }

        public static SignalOpenCloseData[] EliminatMultipleReadDates(SignalOpenCloseData[] p_openCloseDataArray)
        {
            Dictionary<DateTime, SignalOpenCloseData> releventOpenCloseDictionary = new Dictionary<DateTime, SignalOpenCloseData>();
            p_openCloseDataArray.DoForAll(p_data =>
            {
                if (!releventOpenCloseDictionary.ContainsKey(p_data.DateRead))
                {
                    releventOpenCloseDictionary.Add(p_data.DateRead, p_data);
                }
                else
                {
                    SignalOpenCloseData existingData = releventOpenCloseDictionary[p_data.DateRead];
                    if (existingData.DateClose > p_data.DateClose) releventOpenCloseDictionary[p_data.DateRead] = p_data;
                }

            });
            return releventOpenCloseDictionary.Values.ToArray();
        }

        public static SignalOpenCloseData[] ElliminateTriggersIntersections(SignalOpenCloseData[] p_openCloseDataArray)
        {
            IOrderedEnumerable<SignalOpenCloseData> openCloseArraySorted = p_openCloseDataArray.OrderBy(p => p.DateRead);
            Dictionary<DateTime, SignalOpenCloseData> openCloseDictionary = openCloseArraySorted.ToDictionary(p => p.DateRead, p => p);
            List<DateTime> removalList = new List<DateTime>();
            List<DateTime> activationList = new List<DateTime>();
            //Build removalList
            openCloseDictionary.DoForAll(p_pair =>
            {
                if (activationList.Contains(p_pair.Key))
                {
                    removalList.Add(p_pair.Key);
                }
                else
                {
                    for (DateTime date = p_pair.Value.DateRead; date < p_pair.Value.DateClose; date = date.AddDays(1))
                    {
                        activationList.Add(date);
                    }
                }
            });
            //Remove items
            removalList.DoForAll(p_date =>
            {
                openCloseDictionary.Remove(p_date);
            });
            return openCloseDictionary.Values.ToArray();
        }

        public static void ResetNewlyProfitSymbolData(FirstCalculatorResult[] p_profitResults)
        {
            p_profitResults.DoForAll(p_result =>
            {
                ResetResultData(p_result);
            });
        }

        public static void InsertTriggersSignalsToProfitSymbolData(FirstCalculatorResult[] p_profitResults, SignalOpenCloseData[] p_triggersData, SignalTypeEnum p_profitSignalType)
        {
            p_triggersData.DoForAll(p_openCloseData =>
            {
                FirstCalculatorResult result = p_profitResults.SingleOrDefault(p => p.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == p_openCloseData.DateRead);
                if (result != null)
                {
                    result.SignalType = p_profitSignalType;
                    result.SignalWeight = 1f;
                    result.DateClose = ExtractionCommon.DATE_MINIMUM;
                    result.ProfitPer = 0f;
                    result.SignalResult = SignalResultEnum.None;
                }
                else
                {
                    //No read date in profit symbol that matched trigger's read date
                }
            });
            //Problem with oldest result calculated
            FirstCalculatorResult last = p_profitResults.Last();
            last.SignalType=SignalTypeEnum.None;
        }

        public static void RemoveProfitSymbolIntersections(FirstCalculatorResult[] p_profitResults)
        {
            for (int a = p_profitResults.Length - 1; a >= 0; a--)
            {
                if (a > 0 && p_profitResults[a].SignalType != SignalTypeEnum.None)
                {
                    //Clear all signals until close date
                    for (int b = a - 1; b >= 0; b--)
                    {
                        DateTime dateRead = p_profitResults[b].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                        //Will remove all signals until last close date, or, if signal is active (No signal result), remove all signals untill today (zero index)
                        if (dateRead < p_profitResults[a].DateClose || p_profitResults[a].SignalResult == SignalResultEnum.None)
                        {
                            ResetResultData(p_profitResults[b]);
                            p_profitResults[b].ExtraData = "Cleared";
                        }
                    }
                }
            }
        }

        public static void CalculateProfitSymbolData(FirstCalculatorResult[] p_profitResults, float p_profitCut, float p_lossCut, int p_maxDaysHoldingPos, ContangoManager p_contangoManager, float p_contangoLossCutA, float p_contangoLossCutB, float p_contangoLossCutB2, float p_contangoLossCutStepTrigger)
        {
            for (int a = 0; a < p_profitResults.Length-1; a++)
            {
                calculateProfitForDateInDay(p_profitResults, a, p_profitCut, p_lossCut, p_maxDaysHoldingPos, p_contangoManager, p_contangoLossCutA, p_contangoLossCutB,  p_contangoLossCutB2,  p_contangoLossCutStepTrigger);
            }
        }

        private static void calculateProfitForDateInDay(FirstCalculatorResult[] p_results, int p_index, float p_profitCut, float p_lossCut, int p_maxDays, ContangoManager p_contangoManager, float p_contangoLossCutA, float p_contangoLossCutB, float p_contangoLossCutB2, float p_contangoLossCutStepTrigger)
        {
            if (p_results[p_index].SignalType == SignalTypeEnum.None) return;
            if (p_index == p_results.Count() - 1) return;   //possible no previous day

            //New LossCut calculated
            DateTime prevDateTime = p_results[p_index + 1].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
            float prevContango = p_contangoManager.GetContangoValue(prevDateTime);
            //p_lossCut = -(prevContango * p_contangoLossCutA + p_contangoLossCutB);
            p_lossCut = (prevContango * p_contangoLossCutA + p_contangoLossCutB);

            p_results[p_index].DaysToClose = p_maxDays - p_index;

            //setProfitAndLossCut(p_results[p_index], p_profitCut, p_lossCut);

            int daysToCount = p_index >= p_maxDays ? p_maxDays : p_index;
            float profit = CalculateSingleProfit(p_results, p_index, p_index - daysToCount);
            
            p_results[p_index].ProfitPer = profit;
            for (int i = 1; i <= daysToCount; i++)
            {
                //profit and loss for cut check are calculated without multiplier
                float profitForCut = CalculateSingleProfitInDay(p_results, p_index, p_index - i);
                float lossForCut = CalculateSingleLossInDay(p_results, p_index, p_index - i);

                if (profitForCut > p_contangoLossCutStepTrigger)
                {
                    p_lossCut = (prevContango * p_contangoLossCutA + p_contangoLossCutB2);
                }

                p_results[p_index].PositionStartValue = p_results[p_index].FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;

                float gap = CalculateGap(p_results, p_index, p_index - i);
                if (lossForCut < p_lossCut)
                {
                    p_results[p_index].SignalResult = SignalResultEnum.Miss;
                    p_results[p_index].DateClose = p_results[p_index - i].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    p_results[p_index].ProfitPer = p_lossCut;
                    //Check for GAP to increase the loss between days
                    if (gap < p_lossCut)
                    {
                        p_results[p_index].ProfitPer = gap;
                    }
                    //Used calculation for shorts only
                    p_results[p_index].PositionEndValue = p_results[p_index].PositionStartValue * (1 - p_results[p_index].ProfitPer);
                    return;
                }
                if (profitForCut > p_profitCut)
                {
                    p_results[p_index].SignalResult = SignalResultEnum.Hit;
                    p_results[p_index].DateClose = p_results[p_index - i].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    p_results[p_index].ProfitPer = p_profitCut;
                    //Check for GAP to increase the profit between days
                    if (gap > p_profitCut)
                    {
                        p_results[p_index].ProfitPer = gap;
                    }
                    //Used calculation for shorts only
                    p_results[p_index].PositionEndValue = p_results[p_index].PositionStartValue * (1 - p_results[p_index].ProfitPer);
                    return;
                }
            }
            if (daysToCount == p_maxDays)
            {
                float maxDaysProfit = CalculateSingleProfit(p_results, p_index, p_index - daysToCount);
                p_results[p_index].ProfitPer = maxDaysProfit;
                p_results[p_index].DateClose = p_results[p_index - daysToCount].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                p_results[p_index].SignalResult = maxDaysProfit > 0 ? SignalResultEnum.Hit : SignalResultEnum.Miss;
                //Used calculation for shorts only
                p_results[p_index].PositionEndValue = p_results[p_index].PositionStartValue * (1 - p_results[p_index].ProfitPer);
            }
        }

        public static float CalculateGap(FirstCalculatorResult[] p_results, int p_signalStartIndex, int p_signalEndIndex)
        {
            float closeStart = p_results[p_signalStartIndex].FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
            float openEnd = p_results[p_signalEndIndex].FirstAnalyzeResultItem.SymbolExtractedDataItem.Open;
            SignalTypeEnum signalType = p_results[p_signalStartIndex].SignalType;
            if (signalType == SignalTypeEnum.Long) return openEnd / closeStart - 1;
            float gap = closeStart / openEnd - 1;
            return gap;
        }

        //Calculate profit for long/short between days indexs
        public static float CalculateSingleProfitInDay(FirstCalculatorResult[] p_results, int p_signalStartIndex, int p_signalEndIndex)
        {
            FirstCalculatorResult signalStartResult = p_results[p_signalStartIndex];
            FirstCalculatorResult signalEndResult = p_results[p_signalEndIndex];
            float startResultClose = signalStartResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
            float endResultHigh = signalEndResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.High;
            float endResultLow = signalEndResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low;
            SignalTypeEnum signalType = signalStartResult.SignalType;
            if (signalType == SignalTypeEnum.Long) return endResultHigh / startResultClose - 1;
            return startResultClose / endResultLow - 1;
        }

        //Calculate loss for close and low/high
        public static float CalculateSingleLossInDay(FirstCalculatorResult[] p_results, int p_signalStartIndex, int p_signalEndIndex)
        {
            FirstCalculatorResult signalStartResult = p_results[p_signalStartIndex];
            FirstCalculatorResult signalEndResult = p_results[p_signalEndIndex];
            float startResultClose = signalStartResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
            float endResultHigh = signalEndResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.High;
            float endResultLow = signalEndResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low;
            SignalTypeEnum signalType = signalStartResult.SignalType;
            if (signalType == SignalTypeEnum.Long) return endResultLow / startResultClose - 1;
            return startResultClose / endResultHigh - 1;
        }



        //Calculate profit for close and high/low
        public static float CalculateSingleProfit(FirstCalculatorResult[] p_results, int p_signalStartIndex, int p_signalEndIndex)
        {
            FirstCalculatorResult signalOpenResult = p_results[p_signalStartIndex];
            FirstCalculatorResult signalCloseResult = p_results[p_signalEndIndex];
            float endResultClose = signalCloseResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
            float startResultClose = signalOpenResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
            if (signalOpenResult.SignalType == SignalTypeEnum.Long) return endResultClose / startResultClose - 1;
            return startResultClose / endResultClose - 1;
        }

        public static void WriteContangoAverageValues(FirstCalculatorResult[] p_results, Dictionary<DateTime, float> contangoAverageDictionary)
        {
            foreach (FirstCalculatorResult result in p_results)
            {
                DateTime dateRead = result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                if (contangoAverageDictionary.ContainsKey(dateRead))
                {
                    result.ContangoAverage = contangoAverageDictionary[dateRead];
                }
                else
                {
                    result.ContangoAverage = 0;
                }
            }
        }

        public static void FilterByContangoAverage(FirstCalculatorResult[] p_results, float p_minimum, float p_maximum)
        {
            p_results.DoForAll(p_result =>
                                   {
                                       if (p_result.ContangoAverage < p_minimum || p_result.ContangoAverage > p_maximum)
                                       {
                                           ResetResultData(p_result);
                                       }
                                   }
                );
        }

        public static void ResetResultData(IEnumerable<FirstCalculatorResult> p_result)
        {
            p_result.DoForAll(p_calculatorResult => ResetResultData(p_calculatorResult));
        }

        public static void ResetResultData(FirstCalculatorResult p_result)
        {
            p_result.DateClose = ExtractionCommon.DATE_MINIMUM;
            p_result.ProfitPer = 0f;
            p_result.SignalType = SignalTypeEnum.None;
            p_result.SignalResult = SignalResultEnum.None;
            p_result.SignalWeight = 0f;
            p_result.ProfitCut = 0f;
            p_result.LossCut = 0f;
        }
        public static void FilterByR2(FirstCalculatorResult[] p_results, float p_minimumR2, float p_maximumR2)
        {
            p_results.DoForAll(p_result =>
                                   {
                                       if (p_result.FirstAnalyzeResultItem.AnalyzedTwoPer < p_minimumR2 || p_result.FirstAnalyzeResultItem.AnalyzedTwoPer > p_maximumR2)
                                       {
                                           ResetResultData(p_result);
                                       }
                                   }
                );
        }

        private static void setProfitAndLossCut(FirstCalculatorResult p_signaledData, float p_profitCut, float p_lossCut)
        {
            //Calculate ProfitCut and LossCut
            if (p_signaledData.SignalType == SignalTypeEnum.Long)
            {
                p_signaledData.ProfitCut = p_signaledData.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close * (1 + p_profitCut);
                p_signaledData.LossCut = p_signaledData.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close * (1 + p_lossCut); ;
            }
            else
            {
                p_signaledData.ProfitCut = p_signaledData.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close / (1 + p_profitCut);
                p_signaledData.LossCut = p_signaledData.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close / (1 + p_lossCut); ;
            }
        }

    }
}
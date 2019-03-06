using System;
using System.Linq;
using AfaDataExtraction;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraFinanceAnalyzer5.Systems.SystemOptions;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{

    public static class SystemCalculationHelper
    {
        #region (------------------  Static Methods  ------------------)
        private static float calcMovingAverage(FirstCalculatorResult[] p_firstCalculatorResultArray, int p_index, int p_length)
        {
            float sum = 0;
            for (int a = 0; a < p_length; a++)
            {
                sum += p_firstCalculatorResultArray[p_index + a].FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
            }
            return sum / p_length;
        }

        public static void CalculateDrawDowns(FirstCalculatorResult[] p_results)
        {
            FirstCalculatorResult[] signaledResults = SystemOptionsHelper.GetSignaledResults(p_results);
            foreach (FirstCalculatorResult signaledResult in signaledResults)
            {
                DateTime closeDate = signaledResult.DateClose;
                float openValue = signaledResult.PositionStartValue;

                FirstCalculatorResult gMinResult = findMinFromDate(p_results, signaledResult, closeDate);
                FirstCalculatorResult lMaxResult = findMaxFromDate(p_results, gMinResult, closeDate);

                float gMin = gMinResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low;
                float lMax = lMaxResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.High;
                
                signaledResult.MaxProfit = (1 - gMin/openValue)*100;
                signaledResult.MaxLossLocal = (1 - lMax/openValue)*100;
                signaledResult.DrawDownLocal = (lMax / gMin - 1) * 100;
            }
        }

        public static void CalculateMovingAverageDif(FirstCalculatorResult[] p_firstCalculatorResultArray, int p_shortAverageDays, int p_longAverageDays)
        {
            if (p_firstCalculatorResultArray.Length == 0) return;
            for (int a = 0; a < p_firstCalculatorResultArray.Length - p_longAverageDays; a++)
            {
                var shortAvg = calcMovingAverage(p_firstCalculatorResultArray, a, p_shortAverageDays);
                var longAvg = calcMovingAverage(p_firstCalculatorResultArray, a, p_longAverageDays);
                p_firstCalculatorResultArray[a].FirstAnalyzeResultItem.SymbolExtractedDataItem.MovAvgDiff = longAvg - shortAvg;
            }
        }

        private static FirstCalculatorResult findMaxFromDate(FirstCalculatorResult[] p_results, FirstCalculatorResult p_startSearchResult, DateTime p_closeDate)
        {
            if (p_closeDate == ExtractionCommon.DATE_MINIMUM) p_closeDate = DateTime.Now.Date;
            float max = p_startSearchResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.High;
            FirstCalculatorResult maxResult = p_startSearchResult;
            try
            {
                for (DateTime date = p_startSearchResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead; date <= p_closeDate; date = date.AddDays(1))
                {
                    FirstCalculatorResult result = p_results.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.Date == date);
                    //verify not no trade date
                    if (result == null) continue;
                    if (result.FirstAnalyzeResultItem.SymbolExtractedDataItem.High >= max)
                    {
                        max = result.FirstAnalyzeResultItem.SymbolExtractedDataItem.High;
                        maxResult = result;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return maxResult;
        }

        private static FirstCalculatorResult findMinFromDate(FirstCalculatorResult[] p_results, FirstCalculatorResult p_startSearchResult, DateTime p_closeDate)
        {
            if (p_closeDate == ExtractionCommon.DATE_MINIMUM) p_closeDate = DateTime.Now.Date;
            float min = p_startSearchResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low;
            FirstCalculatorResult minResult = p_startSearchResult;
            try
            {
                for (DateTime date = p_startSearchResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead; date <= p_closeDate; date = date.AddDays(1))
                {
                    FirstCalculatorResult result = p_results.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.Date == date);
                    //verify not no trade date
                    if (result == null) continue;
                    if (result.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low <= min)
                    {
                        min = result.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low;
                        minResult = result;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return minResult;
        }
        #endregion (------------------  Static Methods  ------------------)
    }
}
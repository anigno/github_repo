using System;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class AfaSystemContangoHelper
    {
        public static bool IsResultToday(FirstCalculatorResult p_result)
        {
            return (p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead.Date == DateTime.Now.Date);
        }

        public static float SetSignalContangoShorts(FirstCalculatorResult p_current, FirstCalculatorResult p_previous, CIntraDayConfigurationBase p_config)
        {
            float closeToHigh = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.High / p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close - 1;
            float closeToOpen = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open / p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close - 1;


            float startValue = 0;
            bool ctgCondition = p_previous.Contango > p_config.ContangoStartPer;
            bool iperConditionHigh = closeToHigh > p_config.IperStart;
            bool iperConditionOpen = closeToOpen > p_config.IperStart;

            if (ctgCondition || IsResultToday(p_current)) p_current.CIntraStart = p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close * (1 + p_config.IperStart);

            if (p_config.UseHigh)
            {
                p_current.IntraPer = closeToHigh;
                //Check Gap
                if (ctgCondition && iperConditionOpen)
                {
                    startValue = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open;
                    p_current.SignalType = SignalTypeEnum.Short;
                }
                    //Check condition with high
                else if (ctgCondition && iperConditionHigh)
                {
                    startValue = (p_config.IperStart + 1) * p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                    p_current.SignalType = SignalTypeEnum.Short;
                }
            }
            else
            {
                p_current.IntraPer = closeToOpen;
                //Check condition with open
                if (ctgCondition && iperConditionOpen)
                {
                    startValue = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open;
                    p_current.SignalType = SignalTypeEnum.Short;
                }
            }
            return startValue;
        }

        public static float SetSignalContangoLongs(FirstCalculatorResult p_current, FirstCalculatorResult p_previous, CIntraDayLongConfiguration p_config)
        {
            float closeToLow = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Low / p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close - 1;
            float closeToOpen = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open / p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close - 1;


            float startValue = 0;
            bool ctgCondition = p_previous.Contango < p_config.ContangoStartPer;
            bool iperConditionLow = closeToLow < p_config.IperStart;
            bool iperConditionOpen = closeToOpen < p_config.IperStart;
            if (ctgCondition || IsResultToday(p_current)) p_current.CIntraStart = p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close * (1 + p_config.IperStart);

            if (p_config.UseLow)
            {
                p_current.IntraPer = closeToLow;
                //Check Gap
                if (ctgCondition && iperConditionOpen)
                {
                    startValue = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open;
                    p_current.SignalType = SignalTypeEnum.Long;
                }
                //Check condition with high
                else if (ctgCondition && iperConditionLow)
                {
                    startValue = (p_config.IperStart + 1) * p_previous.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                    p_current.SignalType = SignalTypeEnum.Long;
                }
            }
            else
            {
                p_current.IntraPer = closeToOpen;
                //Check condition with open
                if (ctgCondition && iperConditionOpen)
                {
                    startValue = p_current.FirstAnalyzeResultItem.SymbolExtractedDataItem.Open;
                    p_current.SignalType = SignalTypeEnum.Long;
                }
            }
            return startValue;
        }

    }
}
using System;
using System.Linq;
using AfaDataExtraction;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems.SystemOptions
{
    public static class SystemOptionsHelper
    {
        #region (------  Fields  ------)
        public static IvDataProvider m_ivDataProvider = new IvDataProvider();
        private static readonly BlackAndScholes s_blackAndScholes = new BlackAndScholes();
        public static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion (------  Fields  ------)

        #region (------  Public static Methods  ------)
        public static void CalculateOptionsDataIvNoFloorNoCellingShorts(
            FirstCalculatorResult[] p_results,
            float p_volatilityConstant,
            int p_daysToOptionMaturity,
            float p_optionsChangeCall,
            float p_optionsChangePut,
            float p_optionsWeightCall,
            float p_optionsWeightPut)
        {
            FirstCalculatorResult[] signaledResults = GetSignaledResults(p_results);
            //signaledResults = signaledResults.Reverse().ToArray();
            foreach (FirstCalculatorResult signaledResult in signaledResults)
            {
                try
                {
                    //Verify close date exits , else position not closed yet, use last date
                    DateTime closeDate = signaledResult.DateClose;
                    DateTime lastDate = p_results[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    if (closeDate==ExtractionCommon.DATE_MINIMUM) closeDate = lastDate;

                    float volatilityRead = m_ivDataProvider.GetIv(signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead, p_volatilityConstant);
                    float volatilityClose = m_ivDataProvider.GetIv(closeDate, p_volatilityConstant);

                    float stockPriceRead = signaledResult.PositionStartValue;
                    if (stockPriceRead == 0)
                    {
                    }
                    float stockPriceClose = signaledResult.PositionEndValue;

                    int deltaDaysCalendaric = (int)(closeDate - signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead).TotalDays;
                    int deltaDays = p_daysToOptionMaturity - deltaDaysCalendaric;

                    if (signaledResult.SignalType == SignalTypeEnum.Short)
                    {
                        const double RISK_FREE = 0.01;
                        double strikePriceLongCall = (stockPriceRead * (1 + p_optionsChangeCall));
                        var bsReadCall = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Call, stockPriceRead, strikePriceLongCall, p_daysToOptionMaturity / 365d, RISK_FREE, volatilityRead / 100);
                        var bsCloseCall = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Call, stockPriceClose, strikePriceLongCall, deltaDays / 365d, RISK_FREE, volatilityClose / 100);

                        double strikePricePut = (stockPriceRead * (1 + p_optionsChangePut));
                        var bsReadPut = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceRead, strikePricePut, p_daysToOptionMaturity / 365d, RISK_FREE, volatilityRead / 100);
                        var bsClosePut = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceClose, strikePricePut, deltaDays / 365d, RISK_FREE, volatilityClose / 100);

                        signaledResult.ExtraData = string.Format("bsRCall:{0:0.##} bsCCall:{1:0.##} bsRPut:{2:0.##} bsCPut:{3:0.##} DDays:{4:0.##} strikeCall:{5:0.##} strikePut:{6:0.##} volatilityRead:{7:0.##} volatilityClose:{8:0.##}", bsReadCall, bsCloseCall, bsReadPut, bsClosePut, deltaDaysCalendaric, strikePriceLongCall, strikePricePut, volatilityRead, volatilityClose);

                        bsReadCall *= p_optionsWeightCall;
                        bsCloseCall *= p_optionsWeightCall;
                        bsReadPut *= p_optionsWeightPut;
                        bsClosePut *= p_optionsWeightPut;

                        //Calculate profit
                        signaledResult.ProfitPer = (float)((bsReadCall - bsCloseCall) + (bsReadPut - bsClosePut)) / stockPriceRead;
                    }

                    //Set signal result only if position is closed
                    if (signaledResult.DateClose > ExtractionCommon.DATE_MINIMUM)
                        signaledResult.SignalResult = signaledResult.ProfitPer >= 0 ? SignalResultEnum.Hit : SignalResultEnum.Miss;
                }
                catch (Exception ex)
                {
                    s_logger.ErrorFormat("[{0}]", ex);
                }
            }
        }

        public static void CalculateOptionsDataShortIv(
            FirstCalculatorResult[] p_results,
            float p_volatilityConstant,
            int p_daysToOptionMaturity,
            float p_optionsChangePut,
            float p_optionsWeightPut,
            float p_optionsChangeCall,
            float p_optionsWeightCall)
        {

            FirstCalculatorResult[] signaledResults = GetSignaledResults(p_results);
            //signaledResults = signaledResults.Reverse().ToArray();
            foreach (FirstCalculatorResult signaledResult in signaledResults)
            {
                try
                {
                    //Verify close date exits , else position not closed yet, use last date
                    DateTime closeDate = signaledResult.DateClose;
                    DateTime lastDate = p_results[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    if (closeDate == ExtractionCommon.DATE_MINIMUM) closeDate = lastDate;

                    float volatilityRead = m_ivDataProvider.GetIv(signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead, p_volatilityConstant);
                    float volatilityClose = m_ivDataProvider.GetIv(closeDate, p_volatilityConstant);

                    //FirstCalculatorResult resultClose = p_results.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == closeDate);
                    //float stockPriceClose = resultClose.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                    //float stockPriceRead = signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;

                    float stockPriceRead = signaledResult.PositionStartValue;
                    float stockPriceClose = signaledResult.PositionEndValue;


                    int deltaDays = (int)(closeDate - signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead).TotalDays;
                    int daysToOptionMaturity = p_daysToOptionMaturity;

                    if (signaledResult.SignalType == SignalTypeEnum.Long)
                    {
                        const double RISK_FREE = 0.01;
                        double strikePriceLongCall = Math.Ceiling(stockPriceRead * (1 + p_optionsChangeCall));
                        var bsReadCall = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Call, stockPriceRead, strikePriceLongCall, daysToOptionMaturity / 365d, RISK_FREE, volatilityRead / 100);
                        var bsCloseCall = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Call, stockPriceClose, strikePriceLongCall, (daysToOptionMaturity - deltaDays) / 365d, RISK_FREE, volatilityClose / 100);

                        double strikePricePut = Math.Ceiling(stockPriceRead * (1 + p_optionsChangePut));
                        var bsReadPut = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceRead, strikePricePut, daysToOptionMaturity / 365d, RISK_FREE, volatilityRead / 100);
                        var bsClosePut = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceClose, strikePricePut, (daysToOptionMaturity - deltaDays) / 365d, RISK_FREE, volatilityClose / 100);

                        signaledResult.ExtraData = string.Format("bsRCall:{0:0.##} bsCCall:{1:0.##} bsRPut:{2:0.##} bsCPut:{3:0.##} DDays:{4:0.##} strikeCall:{5:0.##} strikePut:{6:0.##} volatilityRead:{7:0.##} volatilityClose:{8:0.##}", bsReadCall, bsCloseCall, bsReadPut, bsClosePut, deltaDays, strikePriceLongCall, strikePricePut, volatilityRead, volatilityClose);

                        bsReadCall *= p_optionsWeightCall;
                        bsCloseCall *= p_optionsWeightCall;
                        bsReadPut *= p_optionsWeightPut;
                        bsClosePut *= p_optionsWeightPut;

                        //Calculate profit
                        signaledResult.ProfitPer = (float)((bsReadPut - bsClosePut) + (bsReadCall - bsCloseCall)) / stockPriceRead;
                    } if (signaledResult.SignalType == SignalTypeEnum.Short)
                    {
                        //if used profitCut or lossCut stockPriceClose should be the cut value instead on close value
                        //stockPriceClose = (1 - signaledResult.ProfitPer) * stockPriceRead;

                        const double RISK_FREE = 0.01;
                        double strikePriceShort = (stockPriceRead * (1 - p_optionsChangePut));
                        var bsRead = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceRead, strikePriceShort, daysToOptionMaturity / 365d, RISK_FREE, volatilityRead / 100);
                        var bsClose = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceClose, strikePriceShort, (daysToOptionMaturity - deltaDays) / 365d, RISK_FREE, volatilityClose / 100);
                        signaledResult.ExtraData = string.Format("bsR:{0:0.##} bsC:{1:0.##} DDays:{2} strike:{3} vixR:{4:0.##} vixC:{5:0.##} stockPriceClose:{6:0.##} strikePriceShort:{7:0.##} daysToOptionMaturity:{8:0.##}", bsRead, bsClose, deltaDays, strikePriceShort, volatilityRead, volatilityClose, stockPriceClose, strikePriceShort, daysToOptionMaturity);

                        //Multiply by weight
                        bsRead *= p_optionsWeightPut;
                        bsClose *= p_optionsWeightPut;
                        //Calculate profit
                        signaledResult.ProfitPer = (float)((stockPriceRead - stockPriceClose) - (bsClose - bsRead)) / stockPriceRead;
                    }
                    //Set signal result only if position is closed
                    if (signaledResult.DateClose > ExtractionCommon.DATE_MINIMUM)
                        signaledResult.SignalResult = signaledResult.ProfitPer >= 0 ? SignalResultEnum.Hit : SignalResultEnum.Miss;
                }
                catch (Exception ex)
                {
                    s_logger.ErrorFormat("[{0}]", ex);
                }
            }
        }

        public static void CalculateOptionsDataVix(
            FirstCalculatorResult[] p_results,
            FirstCalculatorResult[] p_vixResults,
            int p_daysToOptionMaturity,
            float p_optionsChangeCall,
            float p_optionsChangePut,
            float p_optionsWeightCall,
            float p_optionsWeightPut)
        {
            FirstCalculatorResult[] signaledResults = GetSignaledResults(p_results);
            //signaledResults = signaledResults.Reverse().ToArray();
            foreach (FirstCalculatorResult signaledResult in signaledResults)
            {
                try
                {
                    //Verify close date exits , else position not closed yet, use last date
                    DateTime closeDate = signaledResult.DateClose;
                    DateTime lastDate = p_results[0].FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    if (closeDate == ExtractionCommon.DATE_MINIMUM) closeDate = lastDate;

                    FirstCalculatorResult firstCalculatorResultVixRead = p_vixResults.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead);
                    FirstCalculatorResult firstCalculatorResultVixClose = p_vixResults.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == closeDate);

                    if (firstCalculatorResultVixRead == null || firstCalculatorResultVixClose == null)
                    {
                        continue;
                    }
                    float vixRead = firstCalculatorResultVixRead.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                    float vixClose = firstCalculatorResultVixClose.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                    float stockPriceRead = signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;


                    FirstCalculatorResult resultClose = p_results.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == closeDate);
                    float stockPriceClose = resultClose.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;

                    int deltaDaysCalendaric = (int)(closeDate - signaledResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead).TotalDays;
                    int daysToOptionMaturity = p_daysToOptionMaturity;

                    if (signaledResult.SignalType == SignalTypeEnum.Long)
                    {
                        const double RISK_FREE = 0.01;
                        double strikePriceLongCall = Math.Ceiling(stockPriceRead * (1 + p_optionsChangeCall));
                        var bsReadCall = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Call, stockPriceRead, strikePriceLongCall, daysToOptionMaturity / 365d, RISK_FREE, vixRead / 100);
                        var bsCloseCall = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Call, stockPriceClose, strikePriceLongCall, (daysToOptionMaturity - deltaDaysCalendaric) / 365d, RISK_FREE, vixClose / 100);

                        double strikePricePut = Math.Ceiling(stockPriceRead * (1 + p_optionsChangePut));
                        var bsReadPut = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceRead, strikePricePut, daysToOptionMaturity / 365d, RISK_FREE, vixRead / 100);
                        var bsClosePut = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceClose, strikePricePut, (daysToOptionMaturity - deltaDaysCalendaric) / 365d, RISK_FREE, vixClose / 100);

                        signaledResult.ExtraData = string.Format("bsRCall:{0:0.##} bsCCall:{1:0.##} bsRPut:{2:0.##} bsCPut:{3:0.##} DDays:{4:0.##} strikeCall:{5:0.##} strikePut:{6:0.##} volatilityRead:{7:0.##} volatilityClose:{8:0.##}", bsReadCall, bsCloseCall, bsReadPut, bsClosePut, deltaDaysCalendaric, strikePriceLongCall, strikePricePut, vixRead, vixClose);

                        bsReadCall *= p_optionsWeightCall;
                        bsCloseCall *= p_optionsWeightCall;
                        bsReadPut *= p_optionsWeightPut;
                        bsClosePut *= p_optionsWeightPut;

                        //Calculate profit
                        signaledResult.ProfitPer = (float)((bsReadPut - bsClosePut) + (bsReadCall - bsCloseCall)) / stockPriceRead;
                    }
                    if (signaledResult.SignalType == SignalTypeEnum.Short)
                    {
                        const double RISK_FREE = 0.01;
                        double strikePriceShort = Math.Ceiling(stockPriceRead * (1 - p_optionsChangePut));
                        var bsRead = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceRead, strikePriceShort, daysToOptionMaturity / 365d, RISK_FREE, vixRead / 100);
                        var bsClose = s_blackAndScholes.Calculate(BlackAndScholes.CallPutEnum.Put, stockPriceClose, strikePriceShort, (daysToOptionMaturity - deltaDaysCalendaric) / 365d, RISK_FREE, vixClose / 100);
                        signaledResult.ExtraData = string.Format("bsR:{0:0.##} bsC:{1:0.##} DDays:{2} strike:{3} vixR:{4:0.##} vixC:{5:0.##} stockPriceClose:{6:0.##} strikePriceShort:{7:0.##} daysToOptionMaturity:{8:0.##}", bsRead, bsClose, deltaDaysCalendaric, strikePriceShort, vixRead, vixClose, stockPriceClose, strikePriceShort, daysToOptionMaturity);

                        //Multiply by weight
                        bsRead *= p_optionsWeightPut;
                        bsClose *= p_optionsWeightPut;
                        //Calculate profit
                        signaledResult.ProfitPer = (float)((stockPriceRead - stockPriceClose) - (bsClose - bsRead)) / stockPriceRead;
                    }
                    //Set signal result only if position is closed
                    if (signaledResult.DateClose > ExtractionCommon.DATE_MINIMUM)
                        signaledResult.SignalResult = signaledResult.ProfitPer >= 0 ? SignalResultEnum.Hit : SignalResultEnum.Miss;
                }
                catch (Exception ex)
                {
                    s_logger.ErrorFormat("[{0}]", ex);
                }
            }
        }

        public static FirstCalculatorResult[] GetSignaledResults(FirstCalculatorResult[] p_results)
        {
            return p_results.Where(p_result => p_result.SignalType != SignalTypeEnum.None).ToArray();
        }
        #endregion (------  Public static Methods  ------)
    }
}

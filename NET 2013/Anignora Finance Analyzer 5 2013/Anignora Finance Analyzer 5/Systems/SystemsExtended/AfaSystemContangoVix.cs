using System;
using System.Collections.Generic;
using System.Linq;
using AfaDataExtraction;
using AfaDataExtraction.HistoryData;
using AnignoraDataTypes;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew;
using AnignoraFinanceAnalyzer5.MainManagement;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class AfaSystemContangoVix<T> : AfaSystemFirstBase<T> where T : ContangoVixConfiguration, new()
    {
        #region Constructors

        public AfaSystemContangoVix(string p_username, int p_key, string p_filename, ContangoManager p_contangoManager)
            : base(p_username, p_key, p_filename, true, false)
        {
            m_contangoManager = p_contangoManager;
            m_configurator = new ConfiguratorXml<T>(p_filename);
            m_configurator.Load();
        }

        #endregion

        #region Public Methods

        public override void CreateProfitSignalsReport(string p_reportsPath)
        {
            //Nothing yet
        }

        #endregion

        #region Public Properties

        public override string[] ProfitSymbol
        {
            get { return m_configurator.Configuration.ProfitSymbol; }
        }

        public override bool IsSystemActive
        {
            get { return m_configurator.Configuration.IsSystemActive; }
        }

        #endregion

        #region Protected Methods

        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            if (p_symbolName.ToUpper() == "CA")
            {
                List<SymbolExtractedData> symbolExtractedDataList = new List<SymbolExtractedData>();
                //Build ContangoA data overriding CA extracted data
                m_contangoManager.ContangoExtractedData.DoForAll(p_data =>
                {
                    SymbolExtractedData symbolExtractedData = new SymbolExtractedData("CA");
                    symbolExtractedData.DateRead = p_data.ReadDate;
                    symbolExtractedData.Open = p_data.ValueA;
                    symbolExtractedData.Close = p_data.ValueA;
                    symbolExtractedData.High = p_data.ValueA;
                    symbolExtractedData.Low = p_data.ValueA;
                    symbolExtractedData.TimeExtracted = DateTime.Now;
                    symbolExtractedDataList.Add(symbolExtractedData);
                });
                for (int a = 1; a < symbolExtractedDataList.Count - 1; a++)
                {
                    symbolExtractedDataList[a].DailyChangePerSignaled = symbolExtractedDataList[a].Close/symbolExtractedDataList[a-1].Close - 1;
                }
                var analyzeResults = symbolExtractedDataList.Select(p_extractedData => new FirstAnalyzeResult(p_extractedData));
                var firstCalculatorResults = analyzeResults.Select(p_analyzeResult => new FirstCalculatorResult(p_analyzeResult)).ToArray();
                //calculate profits
                FirstCalculatorResult[] vixCalculatedData = GetSymbolCalculatedResults("VIX");
                if (vixCalculatedData.Length > 50)
                {
                    foreach (FirstCalculatorResult caResult in firstCalculatorResults)
                    {
                        DateTime caResultDateRead = caResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                        FirstCalculatorResult vixForDateResult = vixCalculatedData.SingleOrDefault(p_result => p_result.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead == caResultDateRead);
                        if (vixForDateResult != null)
                        {
                            float caResultStartClose = caResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                            float vixClose = vixForDateResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                            float c1 = caResultStartClose / vixClose - 1;

                            if (c1 > m_configurator.Configuration.CaToVixTrigger)
                            {
                                int caDaysToClose = m_caDataProvider.CaDays.ContainsKey(caResultDateRead) ? m_caDataProvider.CaDays[caResultDateRead] : 0;
                                if (caDaysToClose > m_configurator.Configuration.MinimumDaysLeft)
                                {
                                    caResult.ExtraData = string.Format("Ca={0} vix={1} C1={2}", caResultStartClose, vixClose, c1);
                                    caResult.MaxLossLocal = c1;
                                    caResult.SignalType = SignalTypeEnum.Short;
                                    //try to close position using max days
                                    DateTime maxEndDate = getNearestEndDate(caResultDateRead);
                                    if (maxEndDate.Date > DateTime.Now.Date) maxEndDate = DateTime.Now.Date;
                                    for (DateTime date = caResultDateRead; date <= maxEndDate; date = date.AddDays(1))
                                    {
                                        FirstCalculatorResult result = GetResultByDate(firstCalculatorResults, date);
                                        float endClose = result == null ? caResultStartClose : result.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                                        caResult.ProfitPer = 1 - endClose / caResultStartClose;
                                        if (caResult.ProfitPer <= m_configurator.Configuration.RegularLossCut ||
                                            caResult.ProfitPer >= m_configurator.Configuration.RegularProfitCut ||
                                        date == maxEndDate)
                                        {
                                            caResult.DateClose = date;
                                            break;
                                        }
                                    }

                                    //caResult.DateClose = maxEndDate;
                                    //FirstCalculatorResult endResult = GetResultByDate(firstCalculatorResults, caResult.DateClose);
                                    //float caResultEndClose = endResult == null ? caResultStartClose : endResult.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                                    //caResult.ProfitPer = 1 - caResultEndClose/caResultStartClose;
                                    caResult.SignalWeight = 1;
                                    caResult.SignalResult = caResult.ProfitPer > 0 ? SignalResultEnum.Hit : SignalResultEnum.Miss;
                                }
                            }
                        }
                        else
                        {
                            //vixForDateResult is null
                        }
                    }
                }
                //Results are reversed!!!, fix order
                FirstCalculatorResult[] results = firstCalculatorResults.Reverse().ToArray();

                SystemManyToSymbolHelper.RemoveProfitSymbolIntersections(results);

                return results.ToArray();
            }
            return base.StartProcessingSpecific(p_symbolName, p_symbolExtractedDataArray);
        }



        #endregion

        #region Private Methods

        private DateTime getNearestEndDate(DateTime p_startDate)
        {
            foreach (KeyValuePair<DateTime, int> caDay in m_caDataProvider.CaDays)
            {
                if (caDay.Key >= p_startDate && caDay.Value == 1) return caDay.Key.Date;
            }
            return DateTime.Now.Date;
        }

        #endregion

        #region Fields

        private readonly CaDataProvider m_caDataProvider = new CaDataProvider();

        private readonly ConfiguratorXml<T> m_configurator;
        private readonly ContangoManager m_contangoManager;

        #endregion
    }
}
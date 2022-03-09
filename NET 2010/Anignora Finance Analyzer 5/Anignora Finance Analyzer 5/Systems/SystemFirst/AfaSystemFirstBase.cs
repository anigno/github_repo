using AfaDataExtraction;
using AnignoraFinanceAnalyzer5.Configurators;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator;
using AnignoraFinanceAnalyzer5.Systems.SystemsExtended;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst
{
    public abstract class AfaSystemFirstBase<T> : AfaSystemBase where T : AfaSystemFirstConfigurationBase, new()
    {
        #region (------  Fields  ------)
        private readonly AfaSystemFirstConfigurator<T> m_afaSystemFirstConfigurator;
        private readonly FirstAnalyzer m_firstAnalyzer;
        private readonly FirstCalculator m_firstCalculator;
        private new static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion (------  Fields  ------)

        protected FirstAnalyzer Analyzer
        {
            get { return m_firstAnalyzer; }
        }

        protected FirstCalculator Calculator
        {
            get { return m_firstCalculator; }
        }

        #region (------  Constructors  ------)

        protected AfaSystemFirstBase(string p_username, int p_key, string p_filename, bool p_useR1, bool p_useCalendaricMaxDays)
        {
            if (p_filename == null) return;
            m_afaSystemFirstConfigurator = new AfaSystemFirstConfigurator<T>(p_filename);
            m_afaSystemFirstConfigurator.Load();
            T configuration = m_afaSystemFirstConfigurator.Configuration;
            m_firstAnalyzer = new FirstAnalyzer(
                p_username,
                p_key,
                configuration.NegativeParam,
                configuration.PositiveParam,
                configuration.FormulaOneParam,
                configuration.SmallAverage,
                configuration.LargeAverage,
                configuration.OtherAvg,
                p_useR1
                );
            m_firstCalculator = new FirstCalculator(
                this,
                configuration.MaxDaysHoldingPos,
                configuration.RegularProfitCut,
                configuration.RegularLossCut,
                configuration.RegularProfitCutA,
                configuration.RegularLossCutA,
                p_useCalendaricMaxDays,
                p_useR1
                );
        }

        #endregion (------  Constructors  ------)

        #region (------  Properties  ------)

        public override int MaxDaysHoldingPos
        {
            get { return m_afaSystemFirstConfigurator.Configuration.MaxDaysHoldingPos; }
        }

        public override float RegularMultiplier
        {
            get { return m_afaSystemFirstConfigurator.Configuration.RegularMultiplier; }
        }

        public override string[] SymbolsWebNames
        {
            get
            {
                return m_afaSystemFirstConfigurator.Configuration.SymbolsNames;
            }
        }

        public override string SystemName
        {
            get { return m_afaSystemFirstConfigurator.Configuration.SystemName; }
        }

        #endregion (------  Properties  ------)

        #region (------  Public Methods  ------)
        protected override FirstCalculatorResult[] StartProcessingSpecific(string p_symbolName, SymbolExtractedData[] p_symbolExtractedDataArray)
        {
            s_logger.DebugFormat("{0} dataLength:{1}", p_symbolName, p_symbolExtractedDataArray.Length);
            FirstAnalyzeResult[] firstAnalyzeResultArray = m_firstAnalyzer.AnalyzeAll(p_symbolExtractedDataArray);
            FirstCalculatorResult[] firstCalculatorResultArray = m_firstCalculator.Calculate(firstAnalyzeResultArray);

            if (p_symbolName.ToUpper().Contains("VXX"))
            {
                SystemCalculationHelper.CalculateMovingAverageDif(firstCalculatorResultArray, m_afaSystemFirstConfigurator.Configuration.MovingAvgShortDays, m_afaSystemFirstConfigurator.Configuration.MovingAvgLongDays);
            }
            return firstCalculatorResultArray;
        }



        public override float GetSignalWeight(FirstCalculatorResult p_result)
        {
            return 1f;
        }

        #endregion (------  Public Methods  ------)
    }

    //internal class SymbolWeightPair
    //{
    //    public string SymbolName { get; set; }
    //    public float Factor { get; set; }
    //}
}
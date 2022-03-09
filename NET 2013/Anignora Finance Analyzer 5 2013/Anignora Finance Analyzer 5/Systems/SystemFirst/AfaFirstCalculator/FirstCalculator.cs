using System.Linq;
using AnignoraDataTypes.StateMachines;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstAnalyzer;
using AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator.AfaFirstStateMachines;
using log4net;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator
{
    public class FirstCalculator : IFirstCalculator
    {
		#region (------  Fields  ------)
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly FirstSetSignalsStateMachine m_firstSetSignalsStateMachine;
        FirstCalculateProfitStateMachineNoDoubler m_stateMachine;
        private readonly float m_regularProfitCut;
        private readonly int m_maxDaysHoldingPos;
        private readonly bool m_useCalendaricMaxDays;
        private readonly float m_regularLossCut;
        private readonly float m_regularLossCutA;
        private readonly float m_regularProfitCutA;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public FirstCalculator(
            AfaSystemBase p_system,
            int p_maxDaysHoldingPos,
            float p_regularProfitCut,
            float p_regularLossCut,
            float p_regularProfitCutA,
            float p_regularLossCutA,
            bool p_useCalendaricMaxDays,
            bool p_useR1)
        {
            m_firstSetSignalsStateMachine=new FirstSetSignalsStateMachine(p_system,p_useR1);
            m_maxDaysHoldingPos = p_maxDaysHoldingPos;
            m_regularProfitCut = p_regularProfitCut;
            m_regularLossCut = p_regularLossCut;
            m_regularProfitCutA = p_regularProfitCutA;
            m_regularLossCutA = p_regularLossCutA;
            m_useCalendaricMaxDays = p_useCalendaricMaxDays;
        }
		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)
        public FirstCalculatorResult[] Calculate(FirstAnalyzeResult[] p_firstAnalyzeResults)
        {
            if(p_firstAnalyzeResults==null)return new FirstCalculatorResult[0];
            s_logger.DebugFormat("FirstAnalyzeResult data length:{0}", p_firstAnalyzeResults.Length);
            //Remove nulls
            p_firstAnalyzeResults = p_firstAnalyzeResults.Where(p_analyzeResult => p_analyzeResult != null).ToArray();
            //Create FirstCalculatorResult array that contains the p_firstAnalyzeResults item
            FirstCalculatorResult[] firstCalculatorResults = p_firstAnalyzeResults.Select(p_firstAnalyzeResult => new FirstCalculatorResult(p_firstAnalyzeResult)).ToArray();
            //Run calculation
            setSignals(firstCalculatorResults);
            calculateSpecific(firstCalculatorResults);
            return firstCalculatorResults;
        }
		#endregion (------  Public Methods  ------)

		#region (------  Private Methods  ------)
        private void calculateSpecific(FirstCalculatorResult[] p_firstCalculatorResults)
        {
            s_logger.DebugFormat("FirstCalculatorResult data length:{0}", p_firstCalculatorResults.Length);
            //get the indexes of all signaled results
            int[] signaledIndexes = p_firstCalculatorResults.Select((p_p, p_i) => new { p = p_p, i = p_i }).
                Where(p_q => p_q.p.SignalType != SignalTypeEnum.None).
                Select(p_q => p_q.i).ToArray();
            //Run calcProfit state machine for each signaled result
            foreach (int signaledIndex in signaledIndexes)
            {
                m_stateMachine=new FirstCalculateProfitStateMachineNoDoubler(
                        p_firstCalculatorResults,
                        signaledIndex,
                        m_regularProfitCut,
                        m_regularLossCut,
                        m_regularProfitCutA,
                        m_regularLossCutA,
                        m_maxDaysHoldingPos,
                        m_useCalendaricMaxDays
                    );

                int nDays = signaledIndex < m_maxDaysHoldingPos ? signaledIndex : m_maxDaysHoldingPos;
                int[] indexesArray = Enumerable.Range(0, nDays+1).ToArray();
                m_stateMachine.Run(indexesArray);
            }
            
        }

        private void setSignals( FirstCalculatorResult[] p_firstCalculatorResults)
        {
            s_logger.DebugFormat("FirstCalculatorResult data length:{0}", p_firstCalculatorResults.Length);
            //Run setSignals state machine on all results
            m_firstSetSignalsStateMachine.Run(p_firstCalculatorResults,RunDirectionEnum.RunBackward);
        }
		#endregion (------  Private Methods  ------)
    }
}

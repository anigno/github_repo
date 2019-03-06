using System;
using AnignoraDataTypes.StateMachines;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator.AfaFirstStateMachines
{
    public class FirstCalculateProfitStateMachineNoDoubler : AStateMachine<int>
    {
        #region (------  Fields  ------)

        private readonly int m_maxDaysHoldingPos;
        private readonly int m_signaledIndex;
        private readonly AState<int> m_stateClose = new AState<int>("stateClose");
        private readonly AState<int> m_stateRoot = new AState<int>("stateRoot");
        private readonly float m_regularLossCut;
        private readonly float m_regularProfitCut;
        private readonly float m_regularLossCutA;
        private readonly float m_regularProfitCutA;

        #endregion (------  Fields  ------)

        #region (------  Constructors  ------)
        public FirstCalculateProfitStateMachineNoDoubler(
            FirstCalculatorResult[] p_firstCalculatorResults,
            int p_signaledIndex,
            float p_regularProfitCut,
            float p_regularLossCut,
            float p_regularProfitCutA,
            float p_regularLossCutA,
            int p_maxDaysHoldingPos,
            bool p_useCalendaricMaxDays
            )
        {
            m_signaledIndex = p_signaledIndex;
            m_regularProfitCut = p_regularProfitCut;
            m_regularLossCut = p_regularLossCut;
            m_regularProfitCutA = p_regularProfitCutA;
            m_regularLossCutA = p_regularLossCutA;
            m_maxDaysHoldingPos = p_maxDaysHoldingPos;
            RootState = m_stateRoot;

            //StateRoot
            m_stateRoot.Conditions.Add(delegate(int p_index)
            {
                FirstCalculatorResult signaledData = p_firstCalculatorResults[m_signaledIndex];
                FirstCalculatorResult indexData = p_firstCalculatorResults[m_signaledIndex - p_index];


                float indexDataClose = indexData.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                float signaledClose = signaledData.FirstAnalyzeResultItem.SymbolExtractedDataItem.Close;
                float signalMul = signaledData.SignalType == SignalTypeEnum.Long ? 1 : -1;

                signaledData.ProfitPer = (indexDataClose / signaledClose - 1) * signalMul;

                //Check if need to close signal
                DateTime dateIndex = indexData.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                DateTime dateSignaled = signaledData.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                int calendaricDaysDelta = (dateIndex - dateSignaled).Days;

                int dDays = (int) (p_useCalendaricMaxDays ? (dateIndex - dateSignaled).TotalDays : p_index);
                //signaledData.DaysToClose = m_maxDaysHoldingPos - p_index;


                bool isLossCutCondition = signaledData.ProfitPer <= m_regularLossCut + m_regularLossCutA * dDays;
                bool isProfitCutCondition = signaledData.ProfitPer >= m_regularProfitCut + m_regularProfitCutA * dDays;
                bool isMaxMarketDaysCondition = p_index >= m_maxDaysHoldingPos;
                bool isMaxCaledaricDaysCondition = calendaricDaysDelta >= m_maxDaysHoldingPos;

                bool isDatesCondition = p_useCalendaricMaxDays ? isMaxCaledaricDaysCondition : isMaxMarketDaysCondition;

                if (isLossCutCondition || isProfitCutCondition || isDatesCondition)
                {
                    signaledData.DateClose = indexData.FirstAnalyzeResultItem.SymbolExtractedDataItem.DateRead;
                    signaledData.SignalResult = signaledData.ProfitPer >= 0 ? SignalResultEnum.Hit : SignalResultEnum.Miss;
                    //Result close reason and data
                    //signaledData.DeltaDaysMarket = dDays;
                    //signaledData.SignalResultType=SignalResultTypeEnum.MaxDays;
                    //if(isProfitCutCondition)signaledData.SignalResultType=SignalResultTypeEnum.ProfitCut;
                    //if(isLossCutCondition)signaledData.SignalResultType=SignalResultTypeEnum.LossCut;
                    return m_stateClose;
                }
                return null;
            });
        }
        #endregion (------  Constructors  ------)

        //stateClose - Nothing to do
    }
}

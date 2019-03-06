using AnignoraDataTypes.StateMachines;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst.AfaFirstCalculator.AfaFirstStateMachines
{
    public class FirstSetSignalsStateMachine : AStateMachine<FirstCalculatorResult>
    {
        private readonly AfaSystemBase m_system;
        private readonly AState<FirstCalculatorResult> m_stateRoot = new AState<FirstCalculatorResult>("stateRoot");
        private readonly AState<FirstCalculatorResult> m_stateLong = new AState<FirstCalculatorResult>("stateLong");
        private readonly AState<FirstCalculatorResult> m_stateShort = new AState<FirstCalculatorResult>("stateShort");
        private readonly AState<FirstCalculatorResult> m_stateAfterSignal = new AState<FirstCalculatorResult>("stateAfterSignal");

        public FirstSetSignalsStateMachine(AfaSystemBase p_system, bool p_useR1)
        {
            m_system = p_system;
            RootState = m_stateRoot;
            //StateRoot
            m_stateRoot.Conditions.Add(
                delegate(FirstCalculatorResult p_result)
                {
                    if ((p_result.FirstAnalyzeResultItem.AnalyzedOne == 1 || !p_useR1) && p_result.FirstAnalyzeResultItem.AnalyzedTwo == 1)
                    {
                        p_result.SignalType = SignalTypeEnum.Long;
                        p_result.SignalWeight = m_system.GetSignalWeight(p_result);
                        return m_stateLong;
                    }
                    return null;
                }
                );
            m_stateRoot.Conditions.Add(
                delegate(FirstCalculatorResult p_result)
                {
                    if ((p_result.FirstAnalyzeResultItem.AnalyzedOne == -1 || !p_useR1) && p_result.FirstAnalyzeResultItem.AnalyzedTwo == -1)
                    {
                        p_result.SignalType = SignalTypeEnum.Short;
                        p_result.SignalWeight = m_system.GetSignalWeight(p_result);
                        return m_stateShort;
                    }
                    return null;
                }
                );
            //StateLong
            m_stateLong.Conditions.Add(
                delegate(FirstCalculatorResult p_result)
                {
                    if (p_result.FirstAnalyzeResultItem.AnalyzedTwo == 0) return m_stateRoot;
                    if (p_result.FirstAnalyzeResultItem.AnalyzedTwo != 0) return m_stateAfterSignal;

                    return null;
                });
            //StateShort
            m_stateShort.Conditions.Add(
                delegate(FirstCalculatorResult p_result)
                {
                    if (p_result.FirstAnalyzeResultItem.AnalyzedTwo == 0) return m_stateRoot;
                    if (p_result.FirstAnalyzeResultItem.AnalyzedTwo != 0) return m_stateAfterSignal;
                    return null;
                });
            //stateAfterSignal
            m_stateAfterSignal.Conditions.Add(
                delegate(FirstCalculatorResult p_result)
                {
                    if (p_result.FirstAnalyzeResultItem.AnalyzedTwo == 0) return m_stateRoot;
                    return null;
                });

        }
    }
}
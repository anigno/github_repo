namespace AnignoraFinanceAnalyzer5.Systems
{
    public enum SignalTypeEnum
    {
        None,
        Long,
        Short
    }

    public enum SignalResultEnum
    {
        None,
        Hit,
        Miss
    }

    public enum SignalResultTypeEnum
    {
        None,
        MaxDays,
        ProfitCut,
        LossCut
    }
}

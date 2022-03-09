namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstConfigurations
{
    public class AfaSystemFirstOriginalConfiguration : AfaSystemFirstConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "SystemFirstOriginal";
            RegularMultiplier = 1/8f;
            PositiveParam = 21f;
            NegativeParam = 79f;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 190;
            OtherAvg = 3;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new [] { "DIA", "SPY", "IJH", "QQQ", "XLE", "XLF" ,"EEM","XLF"};
            ProfitSymbol = SymbolsNames;
            RegularLossCut = -0.07f;
            RegularProfitCut = 0.15f;

            RegularLossCutA = 0;
            RegularProfitCutA = 0;
            MovingAvgShortDays = 1;
            MovingAvgLongDays = 6;
            IsSystemActive = true;
        }
    }
}

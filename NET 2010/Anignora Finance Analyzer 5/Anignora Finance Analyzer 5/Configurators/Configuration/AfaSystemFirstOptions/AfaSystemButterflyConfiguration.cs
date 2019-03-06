namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstOptions
{
    public class AfaSystemButterflyConfiguration : AfaSystemFirstOptionsConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "System Butterfly";
            RegularMultiplier = 1f;
            PositiveParam = 21f;
            NegativeParam = 175f;   //Longs only
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 190;
            OtherAvg = 3;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new[] { "VIX", "SPY" };
            ProfitSymbol = new[] { "VIX", "DIA", "IWM", "SPY" };

            RegularLossCut = -0.02f;
            RegularProfitCut = 0.03f;
            IsSystemActive = true;

            DaysToOptionMaturity = 13;
            OptionsWeightCall = 1f;
            OptionsWeightPut = 1f;
            OptionsChangeCall = 0.015f;
            OptionsChangePut = 0.01f;

            RegularLossCutA = 0f;
            RegularProfitCutA = 0f;

            UseOptionCalculation = true;
        }
    }
}

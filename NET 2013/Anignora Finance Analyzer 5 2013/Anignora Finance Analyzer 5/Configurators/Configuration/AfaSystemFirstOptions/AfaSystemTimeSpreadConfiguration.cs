namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstOptions
{
    public class AfaSystemTimeSpreadConfiguration : AfaSystemFirstOptionsConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "System Time Spread";
            RegularMultiplier = 2f;
            PositiveParam = -21f;   //Shorts only
            NegativeParam = 79f;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 190;
            OtherAvg = 3;
            MaxDaysHoldingPos = 5;
            SymbolsNames = new[] { "VIX", "SPY", "DIA" };
            ProfitSymbol = new[] { "VIX", "SPY", "DIA" };

            RegularLossCut = -0.02f;
            RegularProfitCut = 0.5f;
            IsSystemActive = true;

            DaysToOptionMaturity = 13;
            OptionsWeightCall =-9999f;
            OptionsWeightPut = 1.5f;
            OptionsChangeCall = -9999f;
            OptionsChangePut = 0.00f;

            RegularLossCutA = 0f;
            RegularProfitCutA = 0f;

            UseOptionCalculation = true;
        }
    }
}

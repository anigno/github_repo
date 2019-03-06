namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class ContangoShortsConfiguration : CIntraDayConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "ContangoShorts";
            IsSystemActive = true;

            RegularProfitCut = 1f;
            RegularLossCut = -0.03f;

            SymbolsNames = new[] { "VXX" };
            ProfitSymbol = new string[] { "VXX" };

            ContangoStartPer = 0.10f;
            IperStart = 0.01f;

            RegularMultiplier = 0.1f;
            MaxDaysHoldingPos = 4;

            UseHigh = true;

            VolatilityConstant = 60;
            DaysToOptionMaturity = 13;
            OptionsChangePut = -0.05f;
            OptionsWeightPut = 1f;
            OptionsChangeCall = 0f;
            OptionsWeightCall = 1f;

            ContangoLossCutA = 0f;
            ContangoLossCutB = 0.07f;
            ContangoStartPer = 0.08f;
            IperStart = 0.01f;
            UseOptionCalculation = false;
        }
    }
}
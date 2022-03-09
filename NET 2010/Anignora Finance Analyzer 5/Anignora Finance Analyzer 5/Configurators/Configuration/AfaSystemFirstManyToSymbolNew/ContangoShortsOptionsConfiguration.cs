namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class ContangoShortsOptionsConfiguration : CIntraDayConfigurationBase
    {

        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "ContangoShortsOptions";
            IsSystemActive = true;

            RegularProfitCut = 0.04f;
            RegularLossCut = -0.03f;

            SymbolsNames = new[] { "VXX" };
            ProfitSymbol = new string[] { "VXX" };

            ContangoStartPer = 0.10f;
            IperStart = 0.01f;

            RegularMultiplier = 1f;
            MaxDaysHoldingPos = 4;

            UseHigh = true;

            VolatilityConstant = 60;
            DaysToOptionMaturity = 10;
            OptionsChangePut = -0.005f;
            OptionsWeightPut = 1f;
            OptionsChangeCall = 0f;
            OptionsWeightCall = 1f;

            ContangoLossCutA = 0f;
            ContangoLossCutB = 0.07f;

            UseOptionCalculation = true;
        }
    }
}
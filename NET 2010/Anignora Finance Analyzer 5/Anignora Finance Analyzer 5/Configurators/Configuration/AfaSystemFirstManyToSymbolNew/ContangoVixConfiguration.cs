namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class ContangoVixConfiguration : CIntraDayConfigurationBase
    {
        public float CaToVixTrigger { get; set; }
        public int MinimumDaysLeft { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "ContangoVix";
            IsSystemActive = true;

            CaToVixTrigger = 0.05f;
            MinimumDaysLeft = 2;
            RegularMultiplier = 1f;



            RegularProfitCut = 0.50f;
            RegularLossCut = -0.5f;

            SymbolsNames = new[] { "VIX" ,"CA"};
            ProfitSymbol = new string[] { "CA" };

            ContangoStartPer = 0.10f;
            IperStart = 0.01f;
            
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
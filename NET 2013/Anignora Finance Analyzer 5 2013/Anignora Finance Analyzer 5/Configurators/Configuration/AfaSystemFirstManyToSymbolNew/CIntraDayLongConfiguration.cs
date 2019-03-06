namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class CIntraDayLongConfiguration : CIntraDayConfigurationBase
    {
        public bool UseLow { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "CIntraDayLong";
            IsSystemActive = true;

            RegularProfitCut = 0.99f;
            RegularLossCut = -0.03f;

            SymbolsNames = new[] { "VXX" };
            ProfitSymbol = new string[] { "VXX" };

            ContangoStartPer = -0.03f;
            IperStart = -0.02f;

            RegularMultiplier =0.1f;
            MaxDaysHoldingPos = 0;

            UseLow = false;

        }
    }
}
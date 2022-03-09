namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class CIntraDayShortConfiguration : ContangoShortsOptionsConfiguration
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "CIntraDayShort";
            IsSystemActive = true;

            RegularProfitCut = 0.99f;
            RegularLossCut = -0.03f;

            SymbolsNames = new[] { "VXX" };
            ProfitSymbol = new string[] { "VXX" };

            ContangoStartPer = 0.08f;
            IperStart = 0.01f;

            RegularMultiplier = 0.1f;
            MaxDaysHoldingPos = 0;

            UseHigh = true;

        }
    }
}
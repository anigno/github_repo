namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstConfigurations
{
    public class AfaSystemFirstOriginalStocksConfiguration : AfaSystemFirstConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "SystemFirstOriginalStocks";
            RegularMultiplier = 1f;
            PositiveParam = 21f;
            NegativeParam = 79f;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 90;
            OtherAvg = 3;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new[] { 
                "AFL","AMZN","APA","APC","AVB","BXP","CF","CTSH","DHR","DO","FLS","GOOG",
                "HPQ","HSP","ICE","ITT","MON","NBL","NTRS","PPG","PSA","PX","ROK","SHLD",
                "SIAL","SLB","SPG","TGT","TRV","UNP","VNO","TEVA"};
            ProfitSymbol = SymbolsNames;
            RegularLossCut = -0.07f;
            RegularProfitCut = 0.20f;

            IsSystemActive = true;
        }
    }
}
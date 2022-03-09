using AnignoraFinanceAnalyzer5.Systems;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class XivLConfiguration : AfaSystemFirstManyToSymbolNewConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "System XIV_L";
            RegularMultiplier = 0.25f;
            //RegularMultiplier = 0.5f;
            PositiveParam = -21f;
            NegativeParam = 89;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 190;
            OtherAvg = 3;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new string[] { "DIA",  "SPY", "IJH", "QQQ", "XLE", "XLF", " XIV", "XIV" };
            ProfitSymbol = new string[] { "XIV" };
            SignalTypeCalculated = SignalTypeEnum.Short;
            SignalTypeProfit = SignalTypeEnum.Short;
            MinimumR2 = 0;
            MaximumR2 = 100;

            MinimumEnableContangoAverage = -999;
            MaximumEnableContangoAverage = 0.02f;

            VolatilityConstant = 60;
            DaysToOptionMaturity = 13;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
        }
    }
}
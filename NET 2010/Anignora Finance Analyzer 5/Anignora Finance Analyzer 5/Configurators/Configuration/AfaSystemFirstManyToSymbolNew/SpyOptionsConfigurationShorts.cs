using AnignoraFinanceAnalyzer5.Systems;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class SpyOptionsConfigurationShorts : AfaSystemFirstManyToSymbolNewConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "SpyOptionsShorts";
            RegularMultiplier = 1f;
            PositiveParam = 21f;
            NegativeParam = 179f;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 190;
            OtherAvg = 3;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new string[] { "DIA", "SPY", "IJH", "QQQ", "XLE", "XLF", "XIV", "VIX" };
            ProfitSymbol = new string[] { "SPY" };
            NoneTriggerSymbols = new string[] { "VIX" };

            SignalTypeCalculated = SignalTypeEnum.Long;
            SignalTypeProfit = SignalTypeEnum.Long;
            MinimumR2 = 0;
            MaximumR2 = 100;

            MinimumEnableContangoAverage = -0.05f;
            MaximumEnableContangoAverage = 999;

            VolatilityConstant = 60;
            DaysToOptionMaturity = 13;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;
            OptionsChangeCall = 0f;
            OptionsWeightCall = 1f;

            UseOptionCalculation = true;

        }
    }
}
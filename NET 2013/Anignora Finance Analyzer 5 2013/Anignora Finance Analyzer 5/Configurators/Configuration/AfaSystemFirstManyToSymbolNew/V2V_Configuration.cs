using AnignoraFinanceAnalyzer5.Systems;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class V2VConfiguration : AfaSystemFirstManyToSymbolNewConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "System V2V";
            RegularMultiplier = 0.3f;
            PositiveParam = -21f;
            NegativeParam = 85;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 190;
            OtherAvg = 1;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new[] { "VIX", "VXX" };
            ProfitSymbol = new string[] { "VXX" };
            SignalTypeCalculated = SignalTypeEnum.Short;
            SignalTypeProfit = SignalTypeEnum.Short;
            MinimumR2 = 0;
            MaximumR2 = 100;

            MinimumEnableContangoAverage = -0.05f;
            MaximumEnableContangoAverage = 999;

            VolatilityConstant = 60;
            DaysToOptionMaturity = 13;
            OptionsChangePut = 0f;
            OptionsWeightPut = 1f;

        }
    }
}
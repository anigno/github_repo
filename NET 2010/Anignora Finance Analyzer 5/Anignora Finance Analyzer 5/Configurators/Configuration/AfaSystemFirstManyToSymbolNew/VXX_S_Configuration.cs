using AnignoraFinanceAnalyzer5.Systems;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public class VxxSConfiguration : AfaSystemFirstManyToSymbolNewConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "System VXX_S";
            RegularMultiplier = 0.3f;
            PositiveParam = 21f;
            NegativeParam = 179f;
            FormulaOneParam = 9;
            SmallAverage = 39;
            LargeAverage = 90;
            OtherAvg = 3;
            MaxDaysHoldingPos = 6;
            SymbolsNames = new string[] { "DIA", "SPY", "IJH", "QQQ", "XLE", "XLF","XIV",  "VXX" };
            ProfitSymbol = new string[] { "VXX" };
            SignalTypeCalculated = SignalTypeEnum.Long;
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
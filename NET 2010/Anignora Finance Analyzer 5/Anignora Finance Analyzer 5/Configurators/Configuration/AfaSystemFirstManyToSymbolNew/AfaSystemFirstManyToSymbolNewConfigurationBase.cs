using AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstOptions;
using AnignoraFinanceAnalyzer5.Systems;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public abstract class AfaSystemFirstManyToSymbolNewConfigurationBase : AfaSystemFirstOptionsConfigurationBase
    {
        public SignalTypeEnum SignalTypeCalculated { get; set; }
        public SignalTypeEnum SignalTypeProfit { get; set; }
        public float MinimumR2 { get; set; }
        public float MaximumR2 { get; set; }

        public float MinimumEnableContangoAverage { get; set; }
        public float MaximumEnableContangoAverage { get; set; }

        public float  ContangoLossCutA { get; set; }
        public float  ContangoLossCutB { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            MinimumR2 = -999;
            MaximumR2 = 999;

            RegularProfitCut = 0.2f;
            RegularLossCut = -0.07f;

            MinimumEnableContangoAverage = -999;
            MaximumEnableContangoAverage = 999;

            ContangoLossCutA = -0.00f;
            ContangoLossCutB = -0.07f;

            ContangoLossCutB2 = 0.1f;
            ContangoLossCutStepTrigger = 0.914f;


        }

        public float ContangoLossCutStepTrigger { get; set; }

        public float ContangoLossCutB2 { get; set; }
    }
    
}

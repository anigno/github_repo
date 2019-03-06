namespace AnignoraFinanceAnalyzer5.Configurators.Configuration
{
    public abstract class AfaSystemFirstConfigurationBase : AfaSystemConfigurationBase
    {
        public float RegularProfitCut { get; set; }

        public float RegularLossCut { get; set; }

        public float RegularMultiplier { get; set; }

        public float PositiveParam { get; set; }

        public float NegativeParam { get; set; }

        public int FormulaOneParam { get; set; }

        public int SmallAverage { get; set; }

        public int LargeAverage { get; set; }

        public int OtherAvg { get; set; }

        public string[] ProfitSymbol { get; set; }
        public string[] NoneTriggerSymbols { get; set; }

        public float RegularLossCutA { get; set; }
        public float RegularProfitCutA { get; set; }

        public int MovingAvgShortDays { get; set; }
        public int MovingAvgLongDays { get; set; }

        public override void SetDefaults()
        {
            base.SetDefaults();
            RegularLossCutA = 0;
            RegularProfitCutA = 0;
            NoneTriggerSymbols = new string[0];
            MovingAvgLongDays = 6;
            MovingAvgShortDays = 1;
            LargeAverage = 90;
            SmallAverage = 30;
            OtherAvg = 3;
        }


    }
}

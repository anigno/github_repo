namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstOptions
{
    public abstract class AfaSystemFirstOptionsConfigurationBase : AfaSystemFirstConfigurationBase
    {
        public int DaysToOptionMaturity { get; set; }
        public float OptionsWeightCall { get; set; }
        public float OptionsWeightPut { get; set; }
        public float OptionsChangeCall { get; set; }
        public float OptionsChangePut { get; set; }
        public float VolatilityConstant { get; set; }
        public bool UseOptionCalculation { get; set; }



        public override void SetDefaults()
        {
            base.SetDefaults();
            DaysToOptionMaturity = 9999;
            OptionsWeightCall = 9999f;
            OptionsWeightPut = 9999f;
            OptionsChangeCall = 9999f;
            OptionsChangePut = 9999f;
            VolatilityConstant = 9999f;
            UseOptionCalculation = false;
        }
    }
}
using AnignoraDataTypes.Configurations;

namespace TalentCalc.Configuration
{
    public class SystemConfigurationBase : IConfiguration
    {
        #region Public Methods

        public virtual void SetDefaults()
        {
            SystemName = "None";
            const double STEP = 0.05;
            const double MAX_VAL = 0.50;
            SwapParam = new ParameterConfig("SwapParam", 0.07, MAX_VAL, STEP, 0.10);
            BuyParam = new ParameterConfig("BuyParam", 0.05, MAX_VAL, STEP, 0.07);
            BuyPart = new ParameterConfig("BuyPart", 0.05, MAX_VAL, STEP, 0.10);
        }

        #endregion

        #region Public Properties

        public string SystemName { get; set; }

        public ParameterConfig SwapParam { get; set; }
        public ParameterConfig BuyParam { get; set; }
        public ParameterConfig BuyPart { get; set; }

        #endregion
    }
}
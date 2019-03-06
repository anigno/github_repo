using AnignoraDataTypes.Configurations;

namespace AnignoraFinanceAnalyzer5.Configurators.Configuration
{
    public abstract class AfaSystemConfigurationBase : IConfiguration
    {
        public string SystemName { get; set; }
        public string[] SymbolsNames { get; set; }
        public int MaxDaysHoldingPos { get; set; }

        public bool IsSystemActive { get; set; }

        public bool IsShowInUi { get; set; }

        public virtual void SetDefaults()
        {
            SystemName = "Afa System";
            SymbolsNames = new string[0];
            MaxDaysHoldingPos = 6;
            IsSystemActive = true;
            IsShowInUi = true;
        }
    }
}
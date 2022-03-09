namespace AnignoraFinanceAnalyzer5.Configurators.Configuration
{
    public class AfaSystemNullConfiguration : AfaSystemConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            MaxDaysHoldingPos = 6;

            SymbolsNames = new string[] { "DIA", "UVXY", "TVIX", "VXZ" };
            SystemName = "Null System";
            IsShowInUi = false;
        }

    }
}

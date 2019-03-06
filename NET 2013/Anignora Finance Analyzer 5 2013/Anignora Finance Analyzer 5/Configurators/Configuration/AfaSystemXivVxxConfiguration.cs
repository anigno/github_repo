namespace AnignoraFinanceAnalyzer5.Configurators.Configuration
{
    public class AfaSystemXivVxxConfiguration : AfaSystemFirstConfigurationBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            SystemName = "XivVix";
            SymbolsNames = new string[] { "XIV", "VXX" };
        }
    }
}

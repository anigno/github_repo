namespace AnignoraFinanceAnalyzer5.Configurators.Configuration.AfaSystemFirstManyToSymbolNew
{
    public abstract class CIntraDayConfigurationBase : AfaSystemFirstManyToSymbolNewConfigurationBase
    {
        public float ContangoStartPer { get; set; }
        public float IperStart { get; set; }
        public bool UseHigh { get; set; }

     
    }
}
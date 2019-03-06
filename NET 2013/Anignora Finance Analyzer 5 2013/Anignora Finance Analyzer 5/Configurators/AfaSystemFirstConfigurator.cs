using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;

namespace AnignoraFinanceAnalyzer5.Configurators
{
    public class AfaSystemFirstConfigurator<T> : ConfiguratorXml<T> where T : AfaSystemFirstConfigurationBase, new()
    {
        public AfaSystemFirstConfigurator(string p_filename)
            : base(p_filename)
        {
        }
    }
}
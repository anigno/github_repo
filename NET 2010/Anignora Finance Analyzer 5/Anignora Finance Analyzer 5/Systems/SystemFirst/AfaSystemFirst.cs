using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;

namespace AnignoraFinanceAnalyzer5.Systems.SystemFirst
{
    public class AfaSystemFirst<T> : AfaSystemFirstBase<T> where T : AfaSystemFirstConfigurationBase, new()
    {
        protected readonly ConfiguratorXml<T> m_configurator;

        public AfaSystemFirst(string p_username, int p_key, string p_filename, bool p_useR1, bool p_useCalendaricMaxDays)
            : base(p_username, p_key, p_filename, p_useR1, p_useCalendaricMaxDays)
        {
            if (p_filename == null) return;
            m_configurator = new ConfiguratorXml<T>(p_filename);
            m_configurator.Load();
        }

        public override string[] ProfitSymbol
        {
            get { return new string[0]; }
        }

        public override bool IsSystemActive
        {
            get { return m_configurator.Configuration.IsSystemActive; }
        }

        public override void CreateProfitSignalsReport(string p_reportsPath)
        {
            //todo
        }
    }
}

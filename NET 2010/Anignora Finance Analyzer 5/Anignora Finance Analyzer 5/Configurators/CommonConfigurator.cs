using System.Collections.Generic;
using AnignoraDataTypes.Configurations;
using AnignoraFinanceAnalyzer5.Configurators.Configuration;

namespace AnignoraFinanceAnalyzer5.Configurators
{
    public class CommonConfigurator : ConfiguratorXml<CommonConfiguration>
    {
		#region (------  Fields  ------)
        private readonly Dictionary<string,string> m_symbolsDataDictionary=new Dictionary<string, string>();
		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)
        public CommonConfigurator(string p_filename)
            : base(p_filename)
        {
        }
		#endregion (------  Constructors  ------)

		#region (------  Public Methods  ------)
        public string GetSymbolMetaData(string p_symbolWebName)
        {
            if(!m_symbolsDataDictionary.ContainsKey(p_symbolWebName))return p_symbolWebName;
            return m_symbolsDataDictionary[p_symbolWebName];
        }

        public override CommonConfiguration Load()
        {
            CommonConfiguration commonConfiguration=base.Load();
            return commonConfiguration;
        }
		#endregion (------  Public Methods  ------)
    }
}

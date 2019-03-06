namespace AnignoraFinanceAnalyzer5.Systems
{
    public class SystemSymbolPair
    {
        public AfaSystemBase SystemBase { get; private set; }
        public string SymbolName { get; private set; }

        public SystemSymbolPair(AfaSystemBase p_systemBase, string p_symbolName)
        {
            SystemBase = p_systemBase;
            SymbolName = p_symbolName;
        }
    }
}
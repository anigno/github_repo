using System;

namespace AnignoraFinanceAnalyzer5.Systems.SystemsExtended
{
    public class SignalOpenCloseData
    {
        public DateTime DateRead { get; private set; }
        public DateTime DateClose { get; private set; }
        public SignalTypeEnum SignalType { get; private set; }
        public string SymbolName { get; set; }

        public SignalOpenCloseData(DateTime p_dateRead,DateTime p_dateClose,SignalTypeEnum p_signalType,string p_symbolName)
        {
            DateRead = p_dateRead;
            DateClose = p_dateClose;
            SignalType = p_signalType;
            SymbolName = p_symbolName;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", SymbolName, DateRead, DateClose, SignalType);
        }
    }
}

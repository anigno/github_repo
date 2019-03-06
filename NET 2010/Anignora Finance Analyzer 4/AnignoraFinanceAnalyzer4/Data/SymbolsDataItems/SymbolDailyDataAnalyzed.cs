using System;
using System.Threading;

namespace AnignoraFinanceAnalyzer4.Data.SymbolsDataItems
{
    public class SymbolDailyDataAnalyzed : SymbolDailyData
    {
		#region (------  Enums  ------)

        public enum SignalTypeEnum
        {
            None,
            Short,
            Long
        }
public enum SignalStateEnum
        {
            Waiting,
            ATC,        //AboutToClose
            Closed
        }
public enum SignalHitMissEnum
        {
            None,
            Hit,
            Miss
        }

		#endregion (------  Enums  ------)

		#region (------  Fields  ------)

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public SymbolDailyDataAnalyzed(string descriptor,SymbolDailyData data)
            : base(descriptor,data)
        {
            SignalType = SignalTypeEnum.None;
            SignalState = SignalStateEnum.Waiting;
            ConditionedDate = DateTime.MinValue;
            SignalToDateChangePer = 0;
            SignalHitMiss = SignalHitMissEnum.None;
            DoublerFirstDate = DateTime.MinValue;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)
        public float RawMoneyFlow { get; set; }

        public float TypicalPrice { get; set; }

        public float MoneyFlowIndexA { get; set; }
        public float MoneyFlowIndexB { get; set; }

        public float AnalizedOne { get; set; }

        public float AnalizedTwo { get; set; }

        public float AnalyzedTwoPer { get; set; }

        public DateTime ConditionedDate { get; set; }

        public float DailyChangePer { get; set; }

        public float DailyChangePerRecent { get; set;}

        public DateTime DoublerFirstDate { get; set; }

        public bool DoublerFirstDateSet { get; set; }

        public int QFP { get; set; }

        public SignalHitMissEnum SignalHitMiss { get; set; }

        public SignalStateEnum SignalState { get; set; }

        public float SignalToDateChangePer { get; set; }

        public SignalTypeEnum SignalType { get; set; }

        public DateTime TimeAnalyzed { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

        public string ToPrintString()
        {
            string sState = "Active";
            if(SignalState==SignalStateEnum.Closed) sState = "Closing";
            if(SignalState==SignalStateEnum.Waiting && ReadDate==DateTime.Now.Date) sState = "Open";
            return string.Format(
                "{0}    Signal: {1}   SignalState: {2}   SignalToDateChange: {3}%   Hit/Miss: {4}  DoublerDate:{5}  ",
                base.ToString(),
                SignalType,
                sState,
                (SignalToDateChangePer*100).ToString("0.00"),
                SignalHitMiss,
                DoublerFirstDate.ToShortDateString()
                );
        }

        public override string ToString()
        {
            return string.Format("{0}  T:{1}  S:{2}  SigChange:{3:0.00}%  H:{4}  CD:{5}", base.ToString(), SignalType, SignalState, SignalToDateChangePer*100, SignalHitMiss, ConditionedDate.ToShortDateString());
        }

		#endregion (------  Public Methods  ------)
    }
}
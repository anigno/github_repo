namespace TalentCalc.Data
{
    public enum MarketDirectionEnum
    {
        None = 0,
        One = 1,
        Both = 11,
        //UpA,
        //UpB,
        //BothUp,
        //BothDown
    }

    public class ProfitData
    {
        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8:0.00},{9:0.00},{10:0.00},{11},{12}", RatioProfitTotal*100, MarketProfitATotal*100, MarketProfitBTotal*100, RatioProfitA*100, RatioProfitB*100, RatioProfitSum*100, SDevRatioProfitSum, SDevMarketProfitA, SDevMarketProfitB, MarketProfitA*100, MarketProfitB*100, DaysFromLastAction, (int) MarketDirection);
        }

        #endregion

        #region Public Properties

        public double SDevRatioProfitSum { get; set; }

        public double RatioProfitA { get; set; }

        public double RatioProfitB { get; set; }

        public double MarketProfitA { get; set; }
        public double MarketProfitB { get; set; }

        public double RatioProfitSum
        {
            get
            {
                double ratioProfitTotal = RatioProfitA + RatioProfitB;
                return ratioProfitTotal;
            }
        }

        public double RatioProfitTotal { get; set; }
        public double MarketProfitATotal { get; set; }
        public double MarketProfitBTotal { get; set; }
        public double SDevMarketProfitA { get; set; }
        public double SDevMarketProfitB { get; set; }

        public int DaysFromLastAction { get; set; }
        public MarketDirectionEnum MarketDirection { get; set; }

        #endregion

        #region Constants

        public const string CSV_HEADER = "RatioProfitTotal%,MarketProfit_A_Total%,MarketProfit_B_Total%,RatioProfitA%, RatioProfitB%, RatioProfitSum%,SDevRatioProfitSum,SDevMarketProfitA,SDevMarketProfitB, MarketProfitA%, MarketProfitB%,DaysFromLastAction,MarketDirection";

        #endregion
    }
}
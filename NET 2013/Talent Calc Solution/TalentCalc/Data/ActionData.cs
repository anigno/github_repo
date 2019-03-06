using System;
using TalentCalc.Systems;

namespace TalentCalc.Data
{
    public class ActionData
    {
        #region Constructors

        public ActionData(DateTime p_date, int p_holdIndex, double p_holdCountRatio, ActionTypeEnum p_actionType, double p_closeA, double p_closeB, double p_volumeA, double p_volumeB, string p_additionalData)
        {
            CloseA = p_closeA;
            CloseB = p_closeB;
            VolumeA = p_volumeA;
            VolumeB = p_volumeB;
            Date = p_date;
            HoldIndex = p_holdIndex;
            HoldCountRatio = p_holdCountRatio;
            ActionType = p_actionType;
            AdditionalData = p_additionalData;
            ProfitData = new ProfitData();
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2:0.00}, {3}, {4}, {5},{6}, {7},[{8}]\n", Date.ToShortDateString(), HoldIndex, HoldCountRatio, ActionType, VolumeA, VolumeB, RefIndexProfit,ProfitData, AdditionalData);
        }

        #endregion

        #region Public Properties

        public DateTime Date { get; private set; }
        public int HoldIndex { get; private set; }
        public double HoldCountRatio { get; private set; }
        public ActionTypeEnum ActionType { get; private set; }
        public string AdditionalData { get; private set; }
        public double CloseA { get; private set; }
        public double CloseB { get; private set; }
        public double VolumeA { get; private set; }
        public double VolumeB { get; private set; }
        public ProfitData ProfitData { get; private set; }
        public double RefIndexProfit { get; set; }

        #endregion

        #region Constants

        public const string CSV_HEADER = "Date,HoldIndex,HoldCountRatio, ActionType,VolumeA,VolumeB,RefIndexProfit," + ProfitData.CSV_HEADER + ",AdditionalData";

        #endregion

        public enum ActionTypeEnum
        {
            None = 0,
            SwapBuy,
            Buy,
            NewMinMax,
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AnignoraCommonAndHelpers.Helpers;
using log4net;
using TalentCalc.Configuration;
using TalentCalc.Data;

namespace TalentCalc.Systems
{
    public class SystemDualMarkets : SystemBase
    {
        #region Constructors

        public SystemDualMarkets(RawData[][] p_rawDatas, SystemConfigurationBase p_configuration,RawData[] p_refIndexData)
            : base(p_rawDatas, p_configuration.SystemName,p_refIndexData)
        {
            Configuration = p_configuration;
            s_logger.DebugFormat("System: {0} created", Name);
        }

        #endregion

        #region Public Methods

        public override void Start()
        {
            s_logger.Debug("Start()");
            base.Start();
        }

        #endregion

        #region Public Properties

        public SystemConfigurationBase Configuration { get; protected set; }

        #endregion

        #region Protected Methods


        protected override double CalculateProfitAfterSwaps(ActionData[] p_actions)
        {
            double ratioProfitTotal = 1.0;
            double marketProfitATotal = 1.0;
            double marketProfitBTotal = 1.0;
            int prevActionIndex = 2;
            for (int a = 2; a < p_actions.Length; a++)
            {
                ActionData action = p_actions[a];
                ProfitData profitData = action.ProfitData;

                ratioProfitTotal *= (1 + profitData.RatioProfitSum);

                marketProfitATotal *= (1 + profitData.MarketProfitA);
                marketProfitBTotal *= (1 + profitData.MarketProfitB);

                profitData.MarketProfitATotal = marketProfitATotal;
                profitData.MarketProfitBTotal = marketProfitBTotal;
                profitData.RatioProfitTotal = ratioProfitTotal;
                if (action.ActionType == ActionData.ActionTypeEnum.Buy || action.ActionType == ActionData.ActionTypeEnum.SwapBuy)
                {
                    int currentActionIndex = a;
                    action.ProfitData.DaysFromLastAction = currentActionIndex - prevActionIndex;
                    double changeA = p_actions[currentActionIndex].CloseA - p_actions[prevActionIndex].CloseA;
                    double changeB = p_actions[currentActionIndex].CloseB - p_actions[prevActionIndex].CloseB;
                    if (changeA >= 0 && changeB < 0) action.ProfitData.MarketDirection = MarketDirectionEnum.One;
                    if (changeA >= 0 && changeB >= 0) action.ProfitData.MarketDirection = MarketDirectionEnum.Both;
                    if (changeA < 0 && changeB >= 0) action.ProfitData.MarketDirection = MarketDirectionEnum.One;
                    if (changeA < 0 && changeB < 0) action.ProfitData.MarketDirection = MarketDirectionEnum.Both;
                    //if (changeA >= 0 && changeB < 0) action.ProfitData.MarketDirection = MarketDirectionEnum.UpA;
                    //if (changeA >= 0 && changeB >= 0) action.ProfitData.MarketDirection = MarketDirectionEnum.BothUp;
                    //if (changeA < 0 && changeB >= 0) action.ProfitData.MarketDirection = MarketDirectionEnum.UpB;
                    //if (changeA < 0 && changeB < 0) action.ProfitData.MarketDirection = MarketDirectionEnum.BothDown;
                    prevActionIndex = currentActionIndex;
                }
            }
            return ratioProfitTotal;
        }


        protected override ActionData[] CalculateSwaps()
        {
            double swapValue = Configuration.SwapParam.Last;
            double buyValue = Configuration.BuyParam.Last;
            double buyPart = Configuration.BuyPart.Last;
            List<ActionData> actionsList = new List<ActionData>();
            int length = RawDataRef.Length;
            int swapIndex = length - 1;
            int buyIndex = length - 1;
            int holdIndex = 0;
            double holdCountRatio = 0; //How much holds are for second market (0 means 100% holds of A market)
            int startIndex = length - 1;
            double minMaxS = 0;
            //Adding First zero index action
            ActionData actionDataZero = new ActionData(RawDatas[0].Last().Date, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.None, 0, 0, 0, 0, "Start");
            actionsList.Add(actionDataZero);

            for (int index = startIndex; index >= 0; index--)
            {
                double closeA = RawDatas[0][index].Close;
                double closeB = RawDatas[1][index].Close;
                double volumeA = RawDatas[0][index].Close;
                double volumeB = RawDatas[1][index].Close;



                double profitForSwapA = closeA/RawDatas[0][swapIndex].Close - 1;
                double profitForSwapB = closeB/RawDatas[1][swapIndex].Close - 1;

                double profitForBuyA = closeA/RawDatas[0][buyIndex].Close - 1;
                double profitForBuyB = closeB/RawDatas[1][buyIndex].Close - 1;

                double diffForSwap = profitForSwapA - profitForSwapB;
                double diffForBuy = profitForBuyA - profitForBuyB;


                DateTime currentDate = RawDatas[0][index].Date;
                //if (currentDate == new DateTime(2008, 11, 13))
                //{
                //}

                calculateProfitInSwaps(actionsList);

                if (holdIndex == 0)
                {
                    if (diffForBuy < -buyValue)
                    {
                        //Buy A
                        ActionData action = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.Buy, closeA, closeB, volumeA, volumeB, "diffForBuy=" + diffForBuy);
                        actionsList.Add(action);
                        buyIndex = index;
                        swapIndex = index;
                        minMaxS = 0;
                        holdCountRatio -= buyPart;
                        if (holdCountRatio <= 0) holdCountRatio = 0;
                        continue;
                    }

                    if (diffForSwap < minMaxS)
                    {
                        ActionData action = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.NewMinMax, closeA, closeB, volumeA, volumeB, "diffForSwap=" + diffForSwap);
                        actionsList.Add(action);
                        minMaxS = diffForSwap;
                        continue;
                    }

                    if (diffForSwap - minMaxS > swapValue)
                    {
                        //SwapBuy to B, buy B
                        ActionData action = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.SwapBuy, closeA, closeB, volumeA, volumeB, string.Format("diffForSwap={0} minMaxS={1}", diffForSwap, minMaxS));
                        actionsList.Add(action);
                        swapIndex = index;
                        buyIndex = index;
                        minMaxS = 0;
                        holdIndex = (holdIndex + 1)%2;
                        holdCountRatio += buyPart;
                        if (holdCountRatio > 1.0) holdCountRatio = 1.0;
                        continue;
                    }
                }
                if (holdIndex == 1)
                {
                    if (diffForBuy > buyValue)
                    {
                        //Buy B
                        ActionData action = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.Buy, closeA, closeB, volumeA, volumeB, "diffForBuy=" + diffForBuy);
                        actionsList.Add(action);
                        buyIndex = index;
                        swapIndex = index;
                        minMaxS = 0;
                        holdCountRatio += buyPart;
                        if (holdCountRatio >= 1.0) holdCountRatio = 1.0;
                        continue;
                    }

                    if (diffForSwap > minMaxS)
                    {
                        ActionData action = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.NewMinMax, closeA, closeB, volumeA, volumeB, string.Format("diffForSwap={0} minMaxS={1}", diffForSwap, minMaxS));
                        actionsList.Add(action);
                        minMaxS = diffForSwap;
                        continue;
                    }

                    if (diffForSwap - minMaxS < -swapValue)
                    {
                        //SwapBuy to A, Buy A
                        ActionData action = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.SwapBuy, closeA, closeB, volumeA, volumeB, string.Format("diffForSwap={0} minMaxS={1}", diffForSwap, minMaxS));
                        actionsList.Add(action);
                        swapIndex = index;
                        buyIndex = index;
                        minMaxS = 0;
                        holdIndex = (holdIndex + 1)%2;
                        holdCountRatio -= buyPart;
                        if (holdCountRatio <= 0) holdCountRatio = 0;
                        continue;
                    }
                }
                ActionData actionNone = new ActionData(currentDate, holdIndex, holdCountRatio, ActionData.ActionTypeEnum.None, closeA, closeB, volumeA, volumeB, string.Format("diffForSwap={0} minMaxS={1}", diffForSwap, minMaxS));
                actionsList.Add(actionNone);
            }
            return actionsList.ToArray();
        }

        protected override ActionData[] CalculateRtSwaps()
        {
            List<ActionData> actionDatas = new List<ActionData>();


            return actionDatas.ToArray();
        }

        protected override void InitParameterList()
        {
            ParametersList.Add(Configuration.SwapParam);
            ParametersList.Add(Configuration.BuyParam);
            ParametersList.Add(Configuration.BuyPart);
        }

        protected override void SaveParameterList()
        {
            //TODO: Save config data with parameters
        }

        #endregion

        #region Private Methods

        private void calculateProfitInSwaps(IList<ActionData> p_actionsList)
        {
            if (p_actionsList.Count < 10) return;
            ActionData action = p_actionsList[p_actionsList.Count - 1];
            ActionData prevAction = p_actionsList[p_actionsList.Count - 2];
            double marketProfitA = action.CloseA/prevAction.CloseA - 1;
            double marketProfitB = action.CloseB/prevAction.CloseB - 1;
            double ratioProfitA = (1 - action.HoldCountRatio)*marketProfitA;
            double ratioProfitB = action.HoldCountRatio*marketProfitB;

            action.ProfitData.RatioProfitA = ratioProfitA;
            action.ProfitData.RatioProfitB = ratioProfitB;
            action.ProfitData.MarketProfitA = marketProfitA;
            action.ProfitData.MarketProfitB = marketProfitB;

            const int S_DEV_MAX = 60;
            if (p_actionsList.Count > S_DEV_MAX + 1)
            {
                int count = p_actionsList.Count;
                List<ActionData> lastActions = p_actionsList.Skip(count - S_DEV_MAX - 1).Take(S_DEV_MAX).ToList();
                IList<double> ratioProfitsSums = lastActions.Select(p_actionData => p_actionData.ProfitData.RatioProfitSum).ToList();
                double stdevRatioProfitsSums = MathHelper.GetStandardDeviation(ratioProfitsSums)*Math.Sqrt(S_DEV_MAX);
                IList<double> marketProfitAList = lastActions.Select(p_actionData => p_actionData.ProfitData.MarketProfitA).ToList();
                double stdevMarketProfitAList = MathHelper.GetStandardDeviation(marketProfitAList)*Math.Sqrt(S_DEV_MAX);
                IList<double> marketProfitBList = lastActions.Select(p_actionData => p_actionData.ProfitData.MarketProfitB).ToList();
                double stdevMarketProfitBList = MathHelper.GetStandardDeviation(marketProfitBList)*Math.Sqrt(S_DEV_MAX);

                ActionData last1 = p_actionsList.Last();
                last1.ProfitData.SDevRatioProfitSum = stdevRatioProfitsSums;
                last1.ProfitData.SDevMarketProfitA = stdevMarketProfitAList;
                last1.ProfitData.SDevMarketProfitB = stdevMarketProfitBList;
            }
        }

        #endregion

        #region Fields

        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
    }
}
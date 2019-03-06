using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentCalc.BL;
using TalentCalc.Configuration;
using TalentCalc.Data;

namespace TalentCalc.Systems
{
    public static class SystemHelper
    {
        #region Public Methods

        /// <summary>
        /// Increase parameters according to order
        /// </summary>
        /// <returns>True if there are parameter's values remain. else return false</returns>
        public static bool IncreaseParametersRecurse(int p_parameterIndex, List<ParameterConfig> p_parameterConfigs)
        {
            if (p_parameterIndex == p_parameterConfigs.Count) return false;
            ParameterConfig parameter = p_parameterConfigs[p_parameterIndex];
            parameter.Last += parameter.Step;
            if (parameter.Last <= parameter.MaxVal) return true;
            parameter.Last = parameter.MinVal;
            return IncreaseParametersRecurse(p_parameterIndex + 1, p_parameterConfigs);
        }

        /// <summary>
        /// Creates a CSV file with actions
        /// </summary>
        public static void CreateResultFile(SystemBase p_system, string p_directory,MainConfiguration p_mainConfiguration)
        {
            if (!Directory.Exists(p_directory)) Directory.CreateDirectory(p_directory);
            ActionData[] actionDataArray = p_system.ActionDatas;
            ActionData firstActionData = actionDataArray[1];
            ActionData lastActionData = actionDataArray.Last();
            double profitA = lastActionData.CloseA / firstActionData.CloseA;
            double profitB = lastActionData.CloseB / firstActionData.CloseB;
            double profitAdvantage = p_system.BestProfit / Math.Max(profitA, profitB);
            double profitBetweenAandB = Math.Abs(profitA - profitB);
            string csvFilename = string.Format("Result_{0}.csv", p_system.Name);
            csvFilename = Path.Combine(p_directory, csvFilename);
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0},[BestScore={1}] \n", DateTime.Now.ToString("G"), p_system.BestScore);
            sb.AppendFormat("[StartDate={0}] \n", AppContainer.Instance.MainConfig.StartDate);
            sb.AppendFormat("[BestScore/BestMarket={0}] [A={1} B={2}] \n", profitAdvantage, profitA, profitB);
            sb.AppendFormat("[ProfitDiffAB={0}%]\n", profitBetweenAandB * 100);
            sb.AppendFormat("[RefIndexName={0}]\n", p_mainConfiguration.RefIndexName);
            sb.AppendFormat("------Parameters------\n");
            foreach (ParameterConfig parameterConfig in p_system.ParametersList)
            {
                sb.AppendFormat(",[{0}={1}] \n", parameterConfig.Name, parameterConfig.Last);
            }
            sb.AppendFormat("----------------------\n");
            sb.AppendFormat("\n{0}\n\n", ActionData.CSV_HEADER);

            int swapCounter = 0;
            int swapDaysSum = 0;
            ActionData prevAction = null;
            int reBuyCounter = 0;
            int directionsDifferentCounter = 0;

            foreach (ActionData actionData in actionDataArray)
            {
                if (actionData.ActionType == ActionData.ActionTypeEnum.Buy || actionData.ActionType == ActionData.ActionTypeEnum.SwapBuy)
                {
                    sb.AppendFormat(actionData.ToString());
                    if (prevAction == null)
                    {
                        prevAction = actionData;
                    }
                    else
                    {
                        swapDaysSum += (int)(actionData.Date - prevAction.Date).TotalDays;
                        prevAction = actionData;
                        swapCounter++;
                        if (actionData.ActionType == ActionData.ActionTypeEnum.Buy) reBuyCounter++;
                        if (actionData.ProfitData.MarketDirection == MarketDirectionEnum.One) directionsDifferentCounter++;
                    }
                }
            }
            sb.AppendFormat("----------------------\n");
            sb.AppendFormat("[Total swaps={0}]\n", swapCounter);
            sb.AppendFormat("[Total swaps cost={0}%]\n", swapCounter * 0.2);
            int averageSwapDays = swapCounter == 0 ? 0 : swapDaysSum / swapCounter;
            sb.AppendFormat("[Average swaps days={0}]\n", averageSwapDays);
            sb.AppendFormat("{0},[profit={1}] \n", DateTime.Now.ToString("G"), p_system.BestProfit);
            sb.AppendFormat("[ReBuy swaps%={0:0.00}]\n", 100.0 * reBuyCounter / swapCounter);
            sb.AppendFormat("[Direction different%%={0:0.00}]\n", 100.0 * directionsDifferentCounter / swapCounter);


            File.WriteAllText(csvFilename, sb.ToString());
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using TalentCalc.Configuration;
using TalentCalc.Data;

namespace TalentCalc.Systems
{
    public abstract class SystemBase
    {
        private readonly RawData[] m_refIndexData;

        #region Constructors

        protected SystemBase(RawData[][] p_rawDatas, string p_systemName,RawData[] p_refIndexData)
        {
            m_refIndexData = p_refIndexData;
            Name = p_systemName;
            RawDatas = p_rawDatas;
            ParametersList = new List<ParameterConfig>();
            BestScore = -999999;
            BestProfit = -999999;
            bool bResult = checkRawDataDates(p_rawDatas);
            RawDataRef = p_rawDatas[0];
            if (!bResult) throw new ApplicationException("Raw data dates don't match for system: " + Name);
        }

        #endregion

        #region Public Methods

        public virtual void Stop()
        {
            Interlocked.Exchange(ref m_continueFlag, 0);
            SaveParameterList();
            ParametersList.Clear();
        }

        public virtual void Start()
        {
            if (Interlocked.Read(ref m_continueFlag) != 0) throw new ApplicationException("System already started");
            InitParameterList();
            Task.Factory.StartNew(() =>
            {
                Interlocked.Exchange(ref m_continueFlag, 1);
                while (Interlocked.Read(ref m_continueFlag) == 1)
                {
                    calculate();
                }
            }, TaskCreationOptions.None);
        }

        #endregion

        #region Public Properties

        public IObservable<SystemBase> OnBestScoreCalculated
        {
            get { return m_bestScoreCalculatedsSubject; }
        }

        public IObservable<SystemBase> OnProfitCalculated
        {
            get { return m_profitCalculatedsSubject; }
        }

        public Subject<SystemBase> OnParameterValueDone
        {
            get { return m_parametersValuesDone; }
        }

        public double BestScore { get; set; }
        public double BestProfit { get; set; }

        public string Name { get; protected set; }
        public List<ParameterConfig> ParametersList { get; private set; }
        public ActionData[] ActionDatas { get; private set; }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Calculate profit from actions
        /// </summary>
        protected abstract double CalculateProfitAfterSwaps(ActionData[] p_actions);

        /// <summary>
        /// Calculate actions with RT config data
        /// </summary>
        protected abstract ActionData[] CalculateRtSwaps();

        /// <summary>
        /// Calculate actions increasing parameters
        /// </summary>
        protected abstract ActionData[] CalculateSwaps();

        protected abstract void InitParameterList();
        protected abstract void SaveParameterList();

        #endregion

        #region Protected Properties

        protected RawData[] RawDataRef { get; private set; }
        protected RawData[][] RawDatas { get; private set; }

        #endregion

        #region Private Methods

        private bool checkRawDataDates(RawData[][] p_rawDatas)
        {
            RawData[][] temp = FixRawData(p_rawDatas[0], p_rawDatas[1]);
            if (temp[0].Length != temp[1].Length)
                return false;
            for (int a = 0; a < temp[0].Length; a++)
            {
                if (temp[0][a].Date.Date != temp[1][a].Date.Date) return false;
            }
            p_rawDatas[0] = temp[0];
            p_rawDatas[1] = temp[1];
            return true;
        }

        public static RawData[][] FixRawData(RawData[] p_rawDataA, RawData[] p_rawDataB)
        {
            int a = 0;
            int b = 0;
            List<RawData> listA = new List<RawData>();
            List<RawData> listB = new List<RawData>();
            while (a < p_rawDataA.Length && b < p_rawDataB.Length)
            {
                if (p_rawDataA[a].Date == p_rawDataB[b].Date)
                {
                    RawData rawDataA = new RawData(p_rawDataA[a].Date, p_rawDataA[a].Close, p_rawDataA[a].Open, p_rawDataA[a].High, p_rawDataA[a].Low, p_rawDataA[a].Volume);
                    RawData rawDataB = new RawData(p_rawDataB[b].Date, p_rawDataB[b].Close, p_rawDataB[b].Open, p_rawDataB[b].High, p_rawDataB[b].Low, p_rawDataB[b].Volume);
                    listA.Add(rawDataA);
                    listB.Add(rawDataB);
                    a++;
                    b++;
                }
                else if (p_rawDataA[a].Date > p_rawDataB[b].Date)
                {
                    RawData rawDataA = new RawData(p_rawDataA[a].Date, p_rawDataA[a].Close, p_rawDataA[a].Open, p_rawDataA[a].High, p_rawDataA[a].Low, p_rawDataA[a].Volume);
                    RawData rawDataB = new RawData(p_rawDataA[a].Date, p_rawDataB[b].Close, p_rawDataB[b].Open, p_rawDataB[b].High, p_rawDataB[b].Low, p_rawDataB[b].Volume);
                    listA.Add(rawDataA);
                    listB.Add(rawDataB);
                    a++;
                }
                else if (p_rawDataA[a].Date < p_rawDataB[b].Date)
                {
                    RawData rawDataA = new RawData(p_rawDataB[b].Date, p_rawDataA[a].Close, p_rawDataA[a].Open, p_rawDataA[a].High, p_rawDataA[a].Low, p_rawDataA[a].Volume);
                    RawData rawDataB = new RawData(p_rawDataB[b].Date, p_rawDataB[b].Close, p_rawDataB[b].Open, p_rawDataB[b].High, p_rawDataB[b].Low, p_rawDataB[b].Volume);
                    listA.Add(rawDataA);
                    listB.Add(rawDataB);
                    b++;
                }
            }
            while (a < p_rawDataA.Length)
            {
                RawData rawDataA = new RawData(p_rawDataA[a].Date, p_rawDataA[a].Close, p_rawDataA[a].Open, p_rawDataA[a].High, p_rawDataA[a].Low, p_rawDataA[a].Volume);
                RawData rawDataB = new RawData(p_rawDataA[a].Date, p_rawDataB[b - 1].Close, p_rawDataB[b - 1].Open, p_rawDataB[b - 1].High, p_rawDataB[b - 1].Low, p_rawDataB[b - 1].Volume);
                listA.Add(rawDataA);
                listB.Add(rawDataB);
                a++;
            }
            while (b < p_rawDataB.Length)
            {
                RawData rawDataA = new RawData(p_rawDataB[b].Date, p_rawDataA[a - 1].Close, p_rawDataA[a - 1].Open, p_rawDataA[a - 1].High, p_rawDataA[a - 1].Low, p_rawDataA[a - 1].Volume);
                RawData rawDataB = new RawData(p_rawDataB[b].Date, p_rawDataB[b].Close, p_rawDataB[b].Open, p_rawDataB[b].High, p_rawDataB[b].Low, p_rawDataB[b].Volume);
                listA.Add(rawDataA);
                listB.Add(rawDataB);
                b++;
            }
            RawData[][] ret = { listA.ToArray(), listB.ToArray() };
            return ret;
        }

        private void calculate()
        {
            ActionDatas = CalculateSwaps();

            double profit = CalculateProfitAfterSwaps(ActionDatas);
            var actionDataBuy = ActionDatas.Where(p_data => p_data.ActionType == ActionData.ActionTypeEnum.Buy || p_data.ActionType == ActionData.ActionTypeEnum.SwapBuy).ToList();
            double daysFromLastActionSum = 0;
            double refIndexProfit = 0;
            double refIndexFirstClose= m_refIndexData.Last().Close;
            // Calculate days between buys average and RefIndexProfit
            foreach (ActionData actionData in actionDataBuy)
            {
                daysFromLastActionSum += actionData.ProfitData.DaysFromLastAction;
                if (Math.Abs(refIndexProfit) < 0.000001)
                {
                    refIndexProfit = 1.0;
                }
                else
                {
                    RawData refData = m_refIndexData.SingleOrDefault(p => p.Date.Date == actionData.Date.Date);
                    if (refData != null)
                    {
                        actionData.RefIndexProfit = refData.Close/refIndexFirstClose*100;
                    }
                }


            }

            double daysBetweenBuysAvg = daysFromLastActionSum / actionDataBuy.Count();

            if (profit > BestProfit) BestProfit = profit;

            //double score = profit;
            double score = profit / daysBetweenBuysAvg;
            double swapLastValue = GetParameterConfig("SwapParam").Last;
            double buyLastValue = GetParameterConfig("BuyParam").Last;

            if (score > BestScore && swapLastValue >= buyLastValue)
            {
                BestScore = score;
                m_bestScoreCalculatedsSubject.OnNext(this);
            }
            m_profitCalculatedsSubject.OnNext(this);
            bool bResult = SystemHelper.IncreaseParametersRecurse(0, ParametersList);
            if (!bResult) m_parametersValuesDone.OnNext(this);
        }

        private ParameterConfig GetParameterConfig(string p_parameterName)
        {
            return ParametersList.Single(p_config => p_config.Name.ToUpper() == p_parameterName.ToUpper());
        }

        #endregion

        #region Fields

        private readonly Subject<SystemBase> m_bestScoreCalculatedsSubject = new Subject<SystemBase>();
        private readonly Subject<SystemBase> m_profitCalculatedsSubject = new Subject<SystemBase>();
        private readonly Subject<SystemBase> m_parametersValuesDone = new Subject<SystemBase>();

        private long m_continueFlag;

        #endregion
    }
}
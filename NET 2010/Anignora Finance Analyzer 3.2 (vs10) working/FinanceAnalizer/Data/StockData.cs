using System;
using System.Collections.Generic;

namespace FinanceAnalizer.Data
{
    public class StockData
    {
		#region (------------------  Fields  ------------------)
        private DateTime lastUpdated = DateTime.MinValue;
        private int analizeValue1;
        private int analizeValue2;
        private List<DayChangeData> dayChanges = new List<DayChangeData>();
        private readonly object _syncRoot = new object();
        private string name;
        private Dictionary<DateTime,string> specialActions=new Dictionary<DateTime, string>();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Properties  ------------------)
        public DateTime LastUpdated
        {
            get
            {
                lock (_syncRoot)
                {
                    return lastUpdated;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    lastUpdated = value;
                }
            }
        }

        public int AnalizeValue1
        {
            get
            {
                lock (_syncRoot)
                {
                    return analizeValue1;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    analizeValue1 = value;
                }
            }
        }

        public int AnalizeValue2
        {
            get { return analizeValue2; }
            set { analizeValue2 = value; }
        }

        public List<DayChangeData> DayChanges
        {
            get
            {
                lock (_syncRoot)
                {
                    return dayChanges;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    dayChanges = value;
                }

            }
        }

        public string Name
        {
            get
            {
                lock (_syncRoot)
                {
                    return name;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    name = value;
                }
            }
        }

        public Dictionary<DateTime, string> SpecialActions
        {
            get { return specialActions; }
            set { specialActions = value; }
        }

        #endregion (------------------  Properties  ------------------)
    }
}
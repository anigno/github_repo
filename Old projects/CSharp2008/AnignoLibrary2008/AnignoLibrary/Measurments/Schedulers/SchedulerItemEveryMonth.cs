using System;
using NUnit.Framework;
using System.Diagnostics;

namespace AnignoLibrary.Measurments.Schedulers
{
    [TestFixture]
    public class SchedulerItemEveryMonth : SchedulerItemBase
    {
		#region (------  Fields  ------)

        private int day;
        private int hour;

		#endregion (------  Fields  ------)

		#region (------  Tests  ------)

        [Test]
        public void Test_SchedulerItemEveryMonth()
        {
            Day = 7; Hour = 6;
            LastScheduled = new DateTime(2000, 4, 1, 3, 0, 0);
            DateTime next = GetNextSchedule();
            Debug.WriteLine(string.Format("last={0} next={1}", LastScheduled, next));
            Assert.AreEqual(new DateTime(2000, 4, Day, Hour, 0, 0), next);
            LastScheduled = next;
            next = GetNextSchedule();
            Debug.WriteLine(string.Format("last={0} next={1}", LastScheduled, next));
            Assert.AreEqual(new DateTime(2000, 4 + 1, Day, Hour, 0, 0), next);
        }

		#endregion (------  Tests  ------)

		#region (------  Constructors  ------)

        public SchedulerItemEveryMonth(int day, int hour)
        {
            Day = day;
            Hour = hour;
        }

        public SchedulerItemEveryMonth()
            : this(0, 0)
        {
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public int Hour
        {
            get { return hour; }
            set { hour = value % 60; }
        }

        public int Day
        {
            get { return day; }
            set { day = value % 28; }
        }

		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        public override DateTime GetNextSchedule()
        {
            DateTime nextDate = new DateTime(LastScheduled.Year, LastScheduled.Month,Day , Hour, 0, 0);
            if (nextDate <= LastScheduled)
            {
                nextDate = new DateTime(LastScheduled.Year, LastScheduled.Month+1, Day, Hour, 0, 0);
            }
            return nextDate;
        }

		#endregion (------  Overridden Methods  ------)
    }
}
using System;
using System.Diagnostics;
using NUnit.Framework;

namespace AnignoLibrary.Measurments.Schedulers
{
    [TestFixture]
    public class SchedulerItemEveryDay : SchedulerItemBase
    {
		#region (------  Fields  ------)

        private int minute;
        private int hour;

		#endregion (------  Fields  ------)

		#region (------  Tests  ------)

        [Test]
        public void Test_SchedulerItemEveryDay()
        {
            Minute = 7; Hour = 6;
            LastScheduled = new DateTime(2000, 4, 1, 3, 20, 1);
            DateTime next = GetNextSchedule();
            Debug.WriteLine(string.Format("last={0} next={1}", LastScheduled, next));
            Assert.AreEqual(new DateTime(2000, 4, 1, Hour, Minute, 0), next);
            LastScheduled = next;
            next = GetNextSchedule();
            Debug.WriteLine(string.Format("last={0} next={1}", LastScheduled, next));
            Assert.AreEqual(new DateTime(2000, 4, 1+1, Hour, Minute, 0), next);
        }

		#endregion (------  Tests  ------)

		#region (------  Constructors  ------)

        public SchedulerItemEveryDay(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public SchedulerItemEveryDay()
            : this(0, 0)
        {
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public int Minute
        {
            get { return minute; }
            set { minute = value % 60; }
        }

        public int Hour
        {
            get { return hour; }
            set { hour = value % 60; }
        }

		#endregion (------  Properties  ------)

		#region (------  Overridden Methods  ------)

        public override DateTime GetNextSchedule()
        {
            DateTime nextDate = new DateTime(LastScheduled.Year, LastScheduled.Month, LastScheduled.Day , Hour, Minute, 0);
            if (nextDate <= LastScheduled)
            {
                nextDate = new DateTime(LastScheduled.Year, LastScheduled.Month, LastScheduled.Day + 1, Hour, Minute, 0);
            }
            return nextDate;
        }

		#endregion (------  Overridden Methods  ------)
    }
}
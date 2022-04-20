using System;

namespace AnignoLibrary.Measurments.Schedulers
{
    /// <summary>
    /// Default sdchedule item will schedule each call
    /// </summary>
    public class SchedulerItemDefault : SchedulerItemBase
    {
        public override DateTime GetNextSchedule()
        {
            DateTime nextDate = new DateTime(LastScheduled.Year, LastScheduled.Month, LastScheduled.Day, LastScheduled.Hour, LastScheduled.Minute, LastScheduled.Second);
            return nextDate;
        }
    }
}

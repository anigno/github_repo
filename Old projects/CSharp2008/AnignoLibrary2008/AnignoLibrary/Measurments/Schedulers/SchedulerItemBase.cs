using System;

namespace AnignoLibrary.Measurments.Schedulers
{
    public abstract class SchedulerItemBase
    {
		#region (------  Constructors  ------)

        protected SchedulerItemBase()
        {
            LastScheduled = DateTime.MinValue;
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        protected DateTime LastScheduled { get; set; }

		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)

        public abstract DateTime GetNextSchedule();

        public bool IsSchedule()
        {
            if (DateTime.Now >= GetNextSchedule())
            {
                LastScheduled = DateTime.Now;
                return true;
            }
            return false;
        }

		#endregion (------  Public Methods  ------)
    }
}

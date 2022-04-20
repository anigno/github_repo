using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using LoggingProvider;
using System.Windows.Forms;
using Timer=System.Timers.Timer;

namespace AnignoLibrary.Measurments.Schedulers
{
    public class PeriodicScheduler
    {
		#region (------  Const Fields  ------)

        private const double PERIODIC_TIME_DEFAULT = 1000;

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)

        private SchedulerItemBase schedulerItem = new SchedulerItemDefault();
        private readonly Timer periodicTimer;

		#endregion (------  Fields  ------)

		#region (------  Events  ------)

        public event EventHandler<EventArgs> ScheduleOccured;

		#endregion (------  Events  ------)

		#region (------  Constructors  ------)

        public PeriodicScheduler(double periodicTime)
            : this()
        {
            PeriodicTime = periodicTime;
            periodicTimer.Elapsed += periodicTimer_Elapsed;
        }

        public PeriodicScheduler()
        {
            periodicTimer = new Timer(PERIODIC_TIME_DEFAULT);
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public double PeriodicTime
        {
            get { return periodicTimer.Interval; }
            set { periodicTimer.Interval = value; }
        }

        public SchedulerItemBase SchedulerItem
        {
            get { return schedulerItem; }
            set
            {
                Stop();
                schedulerItem = value;
                Start();
            }
        }

		#endregion (------  Properties  ------)

		#region (------  Event Handlers  ------)

        void periodicTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            periodicTimer.Stop(); 
            if (SchedulerItem.IsSchedule())
            {
                object targetObject = ScheduleOccured.Target;
                //if (targetObject is Form)
                //{
                //    (targetObject as Form).Invoke(ScheduleOccured, this, new EventArgs());
                //}
                //else
                {
                    if (ScheduleOccured != null) ScheduleOccured(this, new EventArgs());
                }
            }
            periodicTimer.Start();
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Public Methods  ------)

        public void Start()
        {
            periodicTimer.Start();
        }

        public void Stop()
        {
            periodicTimer.Stop();
        }

		#endregion (------  Public Methods  ------)
    }
}

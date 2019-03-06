using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace SoundsManager
{
    public class LabelDateTimeNow : Label
    {
		#region (------  Fields  ------)

        private readonly Timer m_timer=new Timer();

		#endregion (------  Fields  ------)

		#region (------  Events  ------)

        [Category(" LabelDateTimeNow")]
        public event Action<LabelDateTimeNow,DateTime> Tick;

		#endregion (------  Events  ------)

		#region (------  Constructors  ------)

        public LabelDateTimeNow()
        {
            m_timer.Interval=1000;
            m_timer.Tick += onTimerTick;
            m_timer.Start();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        [Category(" LabelDateTimeNow")]
        public string DateTimeFormat { get; set; }

        [Category(" LabelDateTimeNow")]
        public DateTime DateTime
        {
            get { return System.DateTime.Now; }
        }

		#endregion (------  Properties  ------)

		#region (------  Private Methods  ------)

        void onTimerTick(object p_sender, EventArgs p_e)
        {
            DateTime now = DateTime.Now;
            if (Tick != null) Tick(this, now);
            Text = now.ToString(DateTimeFormat);
        }

		#endregion (------  Private Methods  ------)
    }
}

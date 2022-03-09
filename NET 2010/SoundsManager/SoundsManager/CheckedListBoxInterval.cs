using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundsManager
{
    public class CheckedListBoxInterval : CheckedListBox
    {
		#region (------  Fields  ------)

        private const string CATEGORY_STRING=" CheckedListBoxInterval";
        private string m_dateTimeFormat="HH:mm:ss";
        private TimeSpan m_interval = new TimeSpan(0, 0, 30, 0);
        private DateTime m_timeMax= DateTime.Now;
        private DateTime m_timeMinimum= DateTime.Now.Subtract(new TimeSpan(0, 1, 0, 0));

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public CheckedListBoxInterval()
        {
            redraw();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        [Browsable(false)]
        public TimeInterval[] CheckedIntervalItems
        {
            get
            {
                List<TimeInterval> ret = new List<TimeInterval>();
                foreach (TimeInterval ti in CheckedItems)
                {
                    ret.Add(ti);
                }
                return ret.ToArray();
            }
        }

        [Category(CATEGORY_STRING)]
        public string DateTimeFormat
        {
            get { return m_dateTimeFormat; }
            set
            {
                m_dateTimeFormat = value;
                redraw();
            }
        }

        [Category(CATEGORY_STRING)]
        public TimeSpan Interval
        {
            get { return m_interval; }
            set
            {
                m_interval = value;
                redraw();
            }
        }

        [Category(CATEGORY_STRING)]
        public DateTime TimeMax
        {
            get { return m_timeMax; }
            set
            {
                m_timeMax = value;
                redraw();
            }
        }

        [Category(CATEGORY_STRING)]
        public DateTime TimeMinimum
        {
            get { return m_timeMinimum; }
            set
            {
                m_timeMinimum = value;
                redraw();
            }
        }

		#endregion (------  Properties  ------)

		#region (------  Protected Methods  ------)

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            redraw();
        }

		#endregion (------  Protected Methods  ------)

		#region (------  Private Methods  ------)

        private void redraw()
        {
            Items.Clear();
            for (DateTime a = TimeMinimum; a < TimeMax; a=a.Add(Interval))
            {
                TimeInterval ti=new TimeInterval();
                ti.TimeStart = a;
                ti.TimeEnd = a.Add(Interval);
                ti.DateTimeFormat = DateTimeFormat;
                Items.Add(ti);
            }
        }

		#endregion (------  Private Methods  ------)
    }
}
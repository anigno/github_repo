using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace AnignoLibrary.UI.ProgressBars
{
    public class AnignoProgressBarAutoIncreament : AnignoProgressBarFlat
    {
        #region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoProgressBarAutoIncreament";

        #endregion (------  Const Fields  ------)

        #region (------  Fields  ------)

        private int _increament = 1;
        private readonly Timer _timer = new Timer();

        #endregion (------  Fields  ------)

        #region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event EventHandler ValueMinOrMax;

        #endregion (------  Events  ------)

        #region (------  Constructors  ------)

        public AnignoProgressBarAutoIncreament()
        {
            _timer.Tick += _timer_Tick;
        }

        #endregion (------  Constructors  ------)

        #region (------  Properties  ------)
        [Category(CATEGORY_STRING)]
        public bool ShowTextAsTime { get; set; }

        [Category(CATEGORY_STRING)]
        public bool ShowTextAsPecent { get; set; }


        [Category(CATEGORY_STRING)]
        public bool TimerEnabled
        {
            get { return _timer.Enabled; }
            set
            {
                _timer.Enabled = value;
            }
        }

        [Category(CATEGORY_STRING)]
        public int IntervalMs
        {
            get { return _timer.Interval; }
            set
            {
                _timer.Interval = value;
            }
        }

        [Category(CATEGORY_STRING)]
        public int Increament
        {
            get { return _increament; }
            set { _increament = value; }
        }

        #endregion (------  Properties  ------)

        #region (------  Event Handlers  ------)

        void _timer_Tick(object sender, EventArgs e)
        {
            if (DesignMode) return;
            if (Value + Increament > Maximum) return;
            if (Value + Increament < Minimum) return;
            Value += Increament;
            if (ShowTextAsPecent) Text = (100 * (float)Value / (float)Maximum).ToString("0.#") + "%";
            TimeSpan ts = TimeSpan.FromSeconds(Value);
            if (ShowTextAsTime) Text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours,ts.Minutes,ts.Seconds);

            if (Value == Maximum || Value == Minimum)
            {
                if (ValueMinOrMax != null) ValueMinOrMax(this, new EventArgs());
            }
        }

        #endregion (------  Event Handlers  ------)
    }
}
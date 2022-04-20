using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using LoggingProvider;

namespace AnignoLibrary.UI.Multimedia
{
    public partial class AnignoCrossFade : UserControl
    {

		#region (------  Const Fields  ------)

        private const string CATEGORY_STRING = " AnignoCrossFade";
        private const float FADE_DELTA = 0.01f;
        private const int MAX_STEPS = (int)(2 / FADE_DELTA);

		#endregion (------  Const Fields  ------)

		#region (------  Fields  ------)


        private bool _isFading;
        private float _valueF;
        private int _ticks = 10;
        private int _fadeTime = 6000;

        private readonly object _syncRoot=new object();
        Thread _fadeThread;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        public AnignoCrossFade()
        {
            Logger.Log();
            InitializeComponent();
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)


        [Category(CATEGORY_STRING)]
        public float ValueF
        {
            get { return _valueF; }
            set
            {
                    _valueF = value;
                    if (_valueF < -1) _valueF = -1;
                    if (_valueF > 1) _valueF = 1;
                    SetTrackBarValue((int) (_valueF*50 + 50));
            }
        }

        [Category(CATEGORY_STRING)]
        public int Ticks
        {
            get { return _ticks; }
            set { _ticks = value; }
        }

        public int FadeTime
        {
            get { return _fadeTime; }
            set { _fadeTime = value; }
        }


		#endregion (------  Properties  ------)

		#region (------  Events  ------)

        [Category(CATEGORY_STRING)]
        public event FaderMovedEventHandler OnFaderMoved;

        [Category(CATEGORY_STRING)]
        public event FaderMovedEventHandler OnFaderMoveEnded;

		#endregion (------  Events  ------)

		#region (------  Delegates  ------)

        private delegate void ButtonFaderSetLeftHandler(int left);
        public delegate void FaderMovedEventHandler(float valuef);
        private delegate void SetTrackBarValueHandler(int value);

		#endregion (------  Delegates  ------)

		#region (------  Event Handlers  ------)

        private void buttonCenter_Click(object sender, EventArgs e)
        {
            FadeSmooth(0,false);
        }

        private void buttonFullLeft_Click(object sender, EventArgs e)
        {
            FadeSmooth(-1,false);
        }

        private void buttonFullRight_Click(object sender, EventArgs e)
        {
            FadeSmooth(1,false);
        }

        private void trackBarSlider_ValueChanged(object sender, EventArgs e)
        {
            lock (_syncRoot)
            {
                if (!_isFading) ValueF = (trackBarSlider.Value - 50)/50f;

            }
            if (OnFaderMoved != null) OnFaderMoved(ValueF);
        }

		#endregion (------  Event Handlers  ------)

		#region (------  Overridden Methods  ------)

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            if(_fadeThread!=null)_fadeThread.Abort();
        }

		#endregion (------  Overridden Methods  ------)

		#region (------  Private Methods  ------)

        private void FadeThreadStart(object o)
        {
            lock (_syncRoot)
            {
                _isFading = true;
            }
            object[] oArray=(object[])o;
            float valueTarget = (int) oArray[0];
            bool raiseEvent = (bool)oArray[1];
            int steps = (int) ((valueTarget - ValueF)/FADE_DELTA);
            steps = Math.Abs(steps);
            float dv = FADE_DELTA;
            //Set direction of slide
            if (valueTarget < ValueF)
            {
                dv = -dv;
            }
            //Do the slide
            for (int a = 0; a < steps + 1; a++)
            {
                ValueF += dv;
                Thread.Sleep(FadeTime/MAX_STEPS);
            }
            lock (_syncRoot)
            {
                _isFading = false;
            }
            if (OnFaderMoveEnded != null && raiseEvent) Invoke(new FaderMovedEventHandler(OnFaderMoveEnded), ValueF);
        }

        private void SetTrackBarValue(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new SetTrackBarValueHandler(SetTrackBarValue), value);
            }
            else
            {
                trackBarSlider.Value = value;
            }
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        /// <summary>
        /// Fade smoothly to full given direction
        /// </summary>
        /// <param name="direction">For full left value is (-1), For full right value is 1</param>
        /// <param name="raiseEndCrossFadeEvent"></param>
        public void FadeSmooth(int direction,bool raiseEndCrossFadeEvent)
        {
            if(_fadeThread!=null)_fadeThread.Abort();
             _fadeThread = new Thread(FadeThreadStart);
            object[] oArray=new object[2];
            oArray[0] = direction;
            oArray[1] = raiseEndCrossFadeEvent;
            _fadeThread.Start(oArray);
        }

		#endregion (------  Public Methods  ------)

    }
}

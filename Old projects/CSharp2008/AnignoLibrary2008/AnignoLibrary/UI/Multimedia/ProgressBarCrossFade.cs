using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace AnignoLibrary.UI.Multimedia
{
    [DefaultEvent("OnCrossFadeValueChanged")]
    public class ProgressBarCrossFade : TrackBar
    {

		#region Const Fields (1) 

        private const string CATEGORY_STRING = " ProgressBarCrossFade";

		#endregion Const Fields 

		#region Fields (3) 


        private int _leftSide = 100;
        private int _rightSide = 100;

        private Thread SmoothMoveThread;

		#endregion Fields 

		#region Constructors (1) 

        public ProgressBarCrossFade()
        {
            TickStyle = TickStyle.Both;
            Minimum = -100;
            Maximum = 100;
            Value = 0;
            TickFrequency = 50;
        }

		#endregion Constructors 

		#region Read only Properties (2) 

        [Category(CATEGORY_STRING)]
        public int LeftSide
        {
            get { return _leftSide; }
        }

        [Category(CATEGORY_STRING)]
        public int RightSide
        {
            get { return _rightSide; }
        }

		#endregion Read only Properties 

		#region Properties (1) 


        [Category(CATEGORY_STRING)]
        public int CrossFadeValue
        {
            get { return Value; }
            set { Value = value; }
        }


		#endregion Properties 

		#region Events (1) 

        [Category(CATEGORY_STRING)]
        public event CrossFadeValueChangedDelegate OnCrossFadeValueChanged;

		#endregion Events 

		#region Delegates (3) 

        public delegate void CrossFadeValueChangedDelegate(int value,int leftSide,int rightSide);
        public delegate void SmoothCrossFadeEndedDelegate(int value);
        private delegate int GetValueDelegate();
        private delegate void SetValueDelegate(int value);
        public event SmoothCrossFadeEndedDelegate OnSmoothCrossFadeEnded;

		#endregion Delegates 

		#region Overridden Methods (2) 

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                SmoothMove(0,10);
            }
        }
        protected override void OnValueChanged(EventArgs e)
        {
            base.OnValueChanged(e);
            _leftSide = (Value-100)/(-2);
            if (_leftSide > 100) _leftSide = 100;
            _rightSide = ( Value+100) / 2;
            if (_rightSide > 100) _rightSide = 100;
            if (OnCrossFadeValueChanged != null) OnCrossFadeValueChanged(Value, LeftSide, RightSide);
        }

		#endregion Overridden Methods 

		#region Private Methods (4) 

        private int GetValueInvoked()
        {
            if (InvokeRequired)
            {
                return (int)Invoke(new GetValueDelegate(GetValueInvoked));
            }
            return Value;
        }

        private void SetValueInvoked(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new SetValueDelegate(SetValueInvoked), value);
            }
            else
            {
                Value = value;
            }
        }

        public void SmoothMove(int value,int sec)
        {
            if (value < -100) value = -100;
            if (value > 100) value = 100;
            if (SmoothMoveThread != null) SmoothMoveThread.Abort();
            SmoothMoveThread = new Thread(SmoothMoveThreadStart);
            SmoothMoveThread.Start(new object[] { value, sec });
        }

        private void SmoothMoveThreadStart(object parameters)
        {
            float v = GetValueInvoked();
            object[] parametersArray = (object[])parameters;
            int newValue = (int)parametersArray[0];
            int sec = (int)parametersArray[1];
            float step = (newValue - v) / 10/sec;
            for (int a = 0; a < sec*10; a++)
            {
                v += step;
                SetValueInvoked((int)v);
                Thread.Sleep(100);
            }
            if (OnSmoothCrossFadeEnded != null) OnSmoothCrossFadeEnded(GetValueInvoked());
        }

		#endregion Private Methods 

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnignoLibrary.UI.TransparentControls;
using System.ComponentModel;
using LoggingProvider;

namespace AnignoLibrary.UI.Gauges.GaugeParts
{
    public abstract class CircularBase : TransparentUserControl
    {
        public delegate void OnPropertyChangedDelegate();
        public event OnPropertyChangedDelegate OnPropertyChanged;
        private float _minAngle = 0;
        private float _maxAngle = 180;
        private float _radious = 100;

        [Category(" DialBase")]
        public float MinAngle
        {
            get { return _minAngle; }
            set
            {
                _minAngle = value;
                if (OnPropertyChanged != null) OnPropertyChanged();
            }
        }

        [Category(" DialBase")]
        public float MaxAngle
        {
            get { return _maxAngle; }
            set
            {
                _maxAngle = value;
                if (OnPropertyChanged != null) OnPropertyChanged();
            }
        }

        [Category("DialBase")]
        protected float Radious
        {
            get { return _radious; }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Logger.Log();
            base.OnSizeChanged(e);
            _radious = Math.Min(Width, Height);
            if (OnPropertyChanged != null) OnPropertyChanged();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Logger.Log();
        }

    }
}
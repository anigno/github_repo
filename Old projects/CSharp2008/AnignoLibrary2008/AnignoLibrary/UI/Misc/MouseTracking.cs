using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace AnignoLibrary.UI.Misc
{
    public class MouseTracking : Component
    {
        private readonly int TRACKING_INTERVAL_INIT_VALUE = 250;

        private Point _tempMousePosition = new Point(-1, -1);
        private Rectangle _trackingRectangle;
        private Timer _TimerTracking = new Timer();
        private bool _mouseInTrackingRectangle = false;

        public delegate void OnMouseEventDelegate(Point mousePosition);
        public event OnMouseEventDelegate OnMouseCaptured;
        public event OnMouseEventDelegate OnMouseLeave;
        public event OnMouseEventDelegate OnMouseEnter;
        public event OnMouseEventDelegate OnMouseMove;


        [Browsable(false)]
        public Point MousePosition
        {
            get { return _tempMousePosition; }
        }

        [Category("MouseTracking")]
        public int TrackingInterval
        {
            get { return _TimerTracking.Interval; }
            set
            {
                _TimerTracking.Interval = value;
            }
        }

        [Category("MouseTracking")]
        public Rectangle TrackingRectangle
        {
            get { return _trackingRectangle; }
            set
            {
                _TimerTracking.Enabled = false;
                _trackingRectangle = value;
                _TimerTracking.Enabled = true;
            }
        }

        public MouseTracking()
        {
            _trackingRectangle = SystemInformation.VirtualScreen;
            _TimerTracking.Interval = TRACKING_INTERVAL_INIT_VALUE;
            _TimerTracking.Tick += _TimerTracking_Tick;
            _TimerTracking.Enabled = true;
        }

        void _TimerTracking_Tick(object sender, EventArgs e)
        {
            //raise mouse captured
            if (OnMouseCaptured != null) OnMouseCaptured(Control.MousePosition);
            //Check mouse leave
            if (
                Control.MousePosition.X < _trackingRectangle.Left ||
                Control.MousePosition.X > _trackingRectangle.Right ||
                Control.MousePosition.Y < _trackingRectangle.Top ||
                Control.MousePosition.Y > _trackingRectangle.Bottom)
            {
                if (_mouseInTrackingRectangle)
                {
                    _mouseInTrackingRectangle = false;
                    if (OnMouseLeave != null) OnMouseLeave(Control.MousePosition);
                }

            }
            //Check mouse enter
            if (
                Control.MousePosition.X >= _trackingRectangle.Left &&
                Control.MousePosition.X <= _trackingRectangle.Right &&
                Control.MousePosition.Y >= _trackingRectangle.Top &&
                Control.MousePosition.Y <= _trackingRectangle.Bottom)
            {
                if (!_mouseInTrackingRectangle)
                {
                    _mouseInTrackingRectangle = true;
                    if (OnMouseEnter != null) OnMouseEnter(Control.MousePosition);
                }
                //Check mouse move
                if (_tempMousePosition.X != Control.MousePosition.X || _tempMousePosition.Y != Control.MousePosition.Y)
                {
                    _tempMousePosition.X = Control.MousePosition.X;
                    _tempMousePosition.Y = Control.MousePosition.Y;
                    if (OnMouseMove != null) OnMouseMove(Control.MousePosition);
                }
            }
        }

    }
}
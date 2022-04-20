using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.UI.Buttons
{
    public delegate void OnCurrentStateChangedDelegate(ButtonOnOff_Images sender,bool currentState);

    public partial class ButtonOnOff_Images : UserControl
    {
        private object _syncRoot = new object();
        public event OnCurrentStateChangedDelegate OnCurrentStateChanged;
        private bool _currentState;

        public ButtonOnOff_Images()
        {
            InitializeComponent();
            SetStateImage();
        }

        [Category(" ButtonOnOff_Images")]
        public bool CurrentState
        {
            get
            {
                lock (_syncRoot)
                {
                    return _currentState;
                }
            }
            set
            {
                lock (_syncRoot)
                {
                    _currentState = value;
                    SetStateImage();
                }
            }
        }

        private void buttonMain_Click(object sender, EventArgs e)
        {
            lock (_syncRoot)
            {
                CurrentState = !CurrentState;
                SetStateImage();
                if (OnCurrentStateChanged != null) OnCurrentStateChanged(this, CurrentState);
            }
        }

        private void SetStateImage()
        {
            if (_currentState)
            {
                buttonMain.BackgroundImage = buttonOn.BackgroundImage;
            }
            else
            {
                buttonMain.BackgroundImage = buttonOff.BackgroundImage;
            }
        }

        private void buttonMain_MouseMove(object sender, MouseEventArgs e)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }

        private void buttonMain_MouseLeave(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.None;
        }
    }
}

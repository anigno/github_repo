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
    public partial class ButtonOnOff : UserControl
    {
        const string CATEGORY_STRING = " ButtonOnOff";
        private bool _state=true;
        private int _borderSize = 10;

        public ButtonOnOff()
        {
            InitializeComponent();
        }

        [Category(CATEGORY_STRING)]
        public String ButtonOnText
        {
            get { return buttonOn.Text; }
            set { buttonOn.Text = value; }
        }

        [Category(CATEGORY_STRING)]
        public String ButtonOffText
        {
            get { return buttonOff.Text; }
            set { buttonOff.Text = value; }
        }

        [Category(CATEGORY_STRING)]
        public int BorderSize
        {
            get { return _borderSize; }
            set
            {
                _borderSize = value;
                OnResize(new EventArgs());
            }
        }

        [Category(CATEGORY_STRING)]
        public bool State
        {
            get { return _state; }
            set
            {
                _state = value;
                SetStateColor();
            }
        }

        private void SetStateColor()
        {
            if (State)
            {
                BackColor = buttonOn.BackColor;
            }
            else
            {
                BackColor = buttonOff.BackColor;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            buttonOn.Width = buttonOff.Width = (Width-BorderSize) / 2;
            buttonOn.Height = buttonOff.Height = Height - BorderSize;
            buttonOn.Left = buttonOn.Top = buttonOff.Top = BorderSize/2;
            buttonOff.Left = buttonOn.Width + buttonOn.Left;
            SetStateColor();
        }

        private void buttonOn_Click(object sender, EventArgs e)
        {
            State=true;
            SetStateColor();
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            State = false;
            SetStateColor();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;


namespace AnignoLibrary.UI.Labels
{
    public class LabelTimedMessage : Label
    {
		#region (------------------  Const Fields  ------------------)
        private const string CATEGORY_STRING = " LabelTimedMessage";
		#endregion (------------------  Const Fields  ------------------)


		#region (------------------  Fields  ------------------)
        private readonly Timer timerVisible = new Timer();
		#endregion (------------------  Fields  ------------------)


		#region (------------------  Constructors  ------------------)
        public LabelTimedMessage()
        {
            Visible = DesignMode;
            VisibleTime = 3000;
            timerVisible.Tick += timerVisible_Tick;
        }
		#endregion (------------------  Constructors  ------------------)


		#region (------------------  Properties  ------------------)
        [Category(CATEGORY_STRING)]
        public int VisibleTime
        {
            get
            {
                return timerVisible.Interval;
            }
            set
            {
                timerVisible.Interval = value;
            }
        }
		#endregion (------------------  Properties  ------------------)


		#region (------------------  Event Handlers  ------------------)
        void timerVisible_Tick(object sender, EventArgs e)
        {
            Visible = false;
            timerVisible.Stop();
        }
		#endregion (------------------  Event Handlers  ------------------)


		#region (------------------  Public Methods  ------------------)
        public new void Show()
        {
            timerVisible.Start();
            Visible = true;
        }

        public void Show(string text)
        {
            Text = text;
            Show();
        }

        public void Show(string text, Color foreColor)
        {
            ForeColor = foreColor;
            Show(text);
        }

        public void Show(string text, Color foreColor, Color backColor)
        {
            BackColor = backColor;
            Show(text, foreColor);
        }
		#endregion (------------------  Public Methods  ------------------)
    }
}
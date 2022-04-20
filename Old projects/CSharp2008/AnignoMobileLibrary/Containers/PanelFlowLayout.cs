using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AnignoMobileLibrary.Containers
{
    /// <summary>
    /// Arrange contained controls using flow layout.
    /// Controls are being rearranged on adding or removing (checked every second), resize or double click
    /// </summary>
    public class PanelFlowLayout : Panel
    {
        private int _lastControlCount = 0;
        private Timer _TimerRefreshDisplay = new Timer();

        public PanelFlowLayout()
        {
            _TimerRefreshDisplay.Tick += new EventHandler(_TimerRefreshDisplay_Tick);
            _TimerRefreshDisplay.Interval = 1000;
            _TimerRefreshDisplay.Enabled = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetFlowLayout();
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            SetFlowLayout();
        }

        void _TimerRefreshDisplay_Tick(object sender, EventArgs e)
        {
            if (Controls.Count != _lastControlCount)
            {
                _lastControlCount = Controls.Count;
                SetFlowLayout();
            }
        }

        private void SetFlowLayout()
        {
            int itemInLine = 0;
            int lastXinLine = 0;
            int lastYinLine = 0;
            int nextY = 0;
            foreach (Control c in Controls)
            {
                if (itemInLine > 0)
                {
                    if (lastXinLine + c.Width > Width)
                    {
                        //Item too wide for the remain of the line
                        lastXinLine = 0;
                        lastYinLine = nextY;
                        itemInLine = 0;
                    }
                }
                c.Left = lastXinLine;
                lastXinLine += c.Width;
                c.Top = lastYinLine;
                if (c.Top + c.Height > nextY) nextY = c.Top + c.Height;
                itemInLine++;
            }
        }


        
    }
}

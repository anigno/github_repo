using System;
using System.Drawing;
using System.Windows.Forms;
using AnignoraCommonAndHelpers.HooksAndImmulate;

namespace Mouse_Emulator
{
    public partial class FormMain : Form
    {
        private readonly KeyboardHookController keyHook = new KeyboardHookController();
        private readonly MouseHookController mouseHook=new MouseHookController();
        private bool isEnable = true;
        private const int mouseDelta = 15;

        public FormMain()
        {
            InitializeComponent();
            keyHook.KeyDown += keyHook_KeyDown;
            keyHook.KeyUp += keyHook_KeyUp;
            SetText();
        }

        void keyHook_KeyUp(object sender, KeyEventArgs e)
        {
            listBoxKeys.Items.Add(e.Control + "," + e.KeyCode + "," + e.KeyValue);
        }
    

        void keyHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (isEnable)
            {
                Point mouseCur = mouseHook.GetMousePosition();
                switch (e.KeyValue)
                {
                    case 33:    //pgUp
                        mouseHook.EmulateMouseWheel(MouseWheelDirectionEnum.Up);
                        e.SuppressKeyPress = true;
                        break;
                    case 34:    //pgDown
                        mouseHook.EmulateMouseWheel(MouseWheelDirectionEnum.Down);
                        e.SuppressKeyPress = true;
                        break;
                    case 38:    //up
                        mouseHook.SetMousePosition(mouseCur.X,mouseCur.Y-mouseDelta);
                        e.SuppressKeyPress = true;
                        break;
                    case 40:    //down
                        mouseHook.SetMousePosition(mouseCur.X,mouseCur.Y+mouseDelta);
                        e.SuppressKeyPress = true;
                        break;
                    case 37:    //left
                        mouseHook.SetMousePosition(mouseCur.X - mouseDelta, mouseCur.Y);
                        e.SuppressKeyPress = true;
                        break;
                    case 39:    //right
                        mouseHook.SetMousePosition(mouseCur.X + mouseDelta, mouseCur.Y);
                        e.SuppressKeyPress = true;
                        break;
                    case 162:    //left ctrl
                        mouseHook.EmulateMouseButton(MouseEventFlags.LEFTDOWN);
                        mouseHook.EmulateMouseButton(MouseEventFlags.LEFTUP);
                        e.SuppressKeyPress = true;
                        break;
                    case 163:    //right ctrl
                        mouseHook.EmulateMouseButton(MouseEventFlags.RIGHTDOWN);
                        mouseHook.EmulateMouseButton(MouseEventFlags.RIGHTUP);
                        e.SuppressKeyPress = true;
                        break;
                    case 32:    //space
                        mouseHook.EmulateMouseButton(MouseEventFlags.MIDDLEDOWN);
                        mouseHook.EmulateMouseButton(MouseEventFlags.MIDDLEUP);
                        e.SuppressKeyPress = true;
                        break;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void SetText()
        {
            string enableText = isEnable ? "Enable" : "Disable";
            notifyIconMain.Text = "Mouse Emulator " + enableText;
            notifyIconMain.BalloonTipText = enableText;
            notifyIconMain.ShowBalloonTip(1000);
        }

        private void notifyIconMain_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
                isEnable = !isEnable;
            SetText();
        }
    }
}

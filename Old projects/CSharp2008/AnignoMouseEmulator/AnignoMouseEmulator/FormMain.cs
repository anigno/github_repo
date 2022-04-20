using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnignoLibrary.Misc.Hook;

namespace AnignoMouseEmulator
{
    public partial class FormMain : Form
    {
        KeyboardHookController _keyboardHookController = new KeyboardHookController();
        MouseHookController _mouseHookController = new MouseHookController();

        public FormMain()
        {
            InitializeComponent();
            _keyboardHookController.KeyDown += new KeyActionDelegate(_keyboardHookController_KeyDown);
        }

        void _keyboardHookController_KeyDown(bool alt, bool control, bool shift, string keyString)
        {
            if (alt | Control.IsKeyLocked(Keys.CapsLock))
            {
                Point p = _mouseHookController.GetMousePosition();
                if (keyString == Keys.Up.ToString())
                {
                    _mouseHookController.SetMousePosition(p.X, p.Y - 10);
                }
                else if (keyString == Keys.Down.ToString())
                {
                    _mouseHookController.SetMousePosition(p.X, p.Y + 10);
                }
                else if (keyString == Keys.Left.ToString())
                {
                    _mouseHookController.SetMousePosition(p.X - 10, p.Y);
                }
                else if (keyString == Keys.Right.ToString())
                {
                    _mouseHookController.SetMousePosition(p.X + 10, p.Y);
                }
                else if (keyString == Keys.PageUp.ToString())
                {
                    _mouseHookController.EmulateMouseWheel(MouseWheelDirectionEnum.Up);
                }
                else if (keyString == Keys.PageDown.ToString())
                {
                    _mouseHookController.EmulateMouseWheel(MouseWheelDirectionEnum.Down);
                }
            }
        }

        private void notifyIconMain_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
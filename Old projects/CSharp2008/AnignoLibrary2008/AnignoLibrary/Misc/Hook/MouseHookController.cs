using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace AnignoLibrary.Misc.Hook
{

    #region Enums
    [Flags]
    public enum MouseEventFlags
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010,
        WHEEL = 0x800
    }

    public enum MouseWheelDirectionEnum
    {
        Up = 0,
        Down = 2
    }
    #endregion

    public class MouseHookController
    {
        #region DllInport
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out Point lpPoint);
        #endregion

        #region Fields
        private UIntPtr uintHhook = UIntPtr.Zero;
        #endregion

        #region Public
        public void EmulateMouseWheel(MouseWheelDirectionEnum dir)
        {
            uint direction = (uint)(-120 * ((uint)dir - 1));
            mouse_event((uint)MouseEventFlags.WHEEL, 0, 0, direction, uintHhook);
        }

        public void EmulateMouseButton(MouseEventFlags mouseFlag)
        {
            mouse_event((uint)mouseFlag, 0, 0, 0, uintHhook);
        }

        public Point GetMousePosition()
        {
            Point p;
            GetCursorPos(out p);
            return p;
        }

        public void SetMousePosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        #endregion

    }
}
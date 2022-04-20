using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AnignoLibrary.Misc.Hook
{
    #region struct keyboardHookStruct
    public struct keyboardHookStruct
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }
    #endregion

    #region Delegates
        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);
        public delegate void KeyActionDelegate(bool alt, bool control, bool shift, string keyString);
        #endregion
    public class KeyboardHookController
    {
        #region DllInport
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        #endregion

        #region Consts
        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;
        #endregion

        #region Event decleration
        public event KeyActionDelegate KeyDown;
        public event KeyActionDelegate KeyUp;
        #endregion

        #region Fields
        private IntPtr hhook = IntPtr.Zero;
        private bool _altState = false;
        private bool _controlState = false;
        private bool _shiftState = false;
        #endregion

        #region CTOR and DTOR
        public KeyboardHookController()
        {
            hook();
        }

        ~KeyboardHookController()
        {
            unhook();
        }
        #endregion

        #region Public
        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hInstance, 0);
        }

        public void unhook()
        {
            UnhookWindowsHookEx(hhook);
        }

        #endregion

        #region Protected
        /// <summary>
        /// Override this method to hold next hook by returning 1
        /// </summary>
        /// <param name="code"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected int CallNextHook(int code, int wParam, ref keyboardHookStruct lParam)
        {
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }
        #endregion

        #region Private
        private int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {
            Keys key = (Keys)lParam.vkCode;
            string sKey = key.ToString();
            //Console.WriteLine(key.ToString());

            if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
            {
                if (sKey == "LMenu" || sKey == "RMenu") _altState = true;
                if (sKey == "LControlKey" || sKey == "RControlKey") _controlState = true;
                if (sKey == "LShiftKey" || sKey == "RShiftKey") _shiftState = true;
                if (KeyDown != null) KeyDown(_altState, _controlState, _shiftState, sKey);
            }
            else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
            {
                if (sKey == "LMenu" || sKey == "RMenu") _altState = false;
                if (sKey == "LControlKey" || sKey == "RControlKey") _controlState = false;
                if (sKey == "LShiftKey" || sKey == "RShiftKey") _shiftState = false;
                if (KeyUp != null) KeyUp(_altState, _controlState, _shiftState, sKey);
            }
            return CallNextHook(code, wParam, ref lParam);
        }
        #endregion
    }
}

#region Old version keep
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Windows.Forms;

//namespace AnignoLibrary.Misc.Hook
//{

//    #region struct keyboardHookStruct
//    public struct keyboardHookStruct
//    {
//        public int vkCode;
//        public int scanCode;
//        public int flags;
//        public int time;
//        public int dwExtraInfo;
//    }
//    #endregion

//    #region Delegates
//    public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);

//    #endregion

//    public class KeyboardHookManager_old
//    {
//        #region DllInport
//        [DllImport("user32.dll")]
//        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

//        [DllImport("user32.dll")]
//        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

//        [DllImport("user32.dll")]
//        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

//        [DllImport("kernel32.dll")]
//        static extern IntPtr LoadLibrary(string lpFileName);
//        #endregion

//        #region Consts
//        const int WH_KEYBOARD_LL = 13;
//        const int WM_KEYDOWN = 0x100;
//        const int WM_KEYUP = 0x101;
//        const int WM_SYSKEYDOWN = 0x104;
//        const int WM_SYSKEYUP = 0x105;
//        #endregion

//        #region Events decleration
//        public event KeyEventHandler KeyDown;
//        public event KeyEventHandler KeyUp;
//        #endregion

//        #region Fields
//        private readonly Dictionary<string, bool> _hookedKeys = new Dictionary<string, bool>();
//        private IntPtr hhook = IntPtr.Zero;
//        #endregion

//        #region CTOR and DTOR
//        public KeyboardHookManager_old()
//        {
//            hook();
//        }

//        ~KeyboardHookManager_old()
//        {
//            unhook();
//        }
//        #endregion

//        #region Public
//        public void hook()
//        {
//            IntPtr hInstance = LoadLibrary("User32");
//            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, hInstance, 0);
//        }
//        public void unhook()
//        {
//            UnhookWindowsHookEx(hhook);
//        }

//        public void AddKeyHook(Keys key, bool holdNextHook)
//        {
//            _hookedKeys.Add(key.ToString(), holdNextHook);
//        }

//        #endregion


//        private bool _altState = false;
//        private bool _controlState = false;
//        private bool _shiftState = false;

//        #region Private CallBacks
//        private int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
//        {
//            Keys key = (Keys)lParam.vkCode;
//            string sKey = key.ToString();
//            Console.WriteLine(key.ToString());
//            KeyEventArgs kea = null;
//            if (_hookedKeys.ContainsKey(sKey))
//            {
//                if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
//                {
//                    if (lParam.vkCode == 164 || lParam.vkCode == 165) _altState = true;
//                    if (lParam.vkCode == 162 || lParam.vkCode == 163) _controlState = true;
//                    if (lParam.vkCode == 160 || lParam.vkCode == 161) _shiftState = true;
//                    if(lParam.vkCode==20)
//                    kea =
//                        new KeyEventArgs(key | (_altState ? Keys.Alt : Keys.None) |
//                                         (_controlState ? Keys.Control : Keys.None) |
//                                         (_shiftState ? Keys.Shift : Keys.None));
//                    if (KeyDown != null) KeyDown(this, kea);
//                }
//                else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
//                {
//                    if (lParam.vkCode == 164 || lParam.vkCode == 165) _altState = false;
//                    if (lParam.vkCode == 162 || lParam.vkCode == 163) _controlState = false;
//                    if (lParam.vkCode == 160 || lParam.vkCode == 161) _shiftState = false;
//                    kea =
//                        new KeyEventArgs(key | (_altState ? Keys.Alt : Keys.None) |
//                                         (_controlState ? Keys.Control : Keys.None) |
//                                         (_shiftState ? Keys.Shift : Keys.None));
//                    if (KeyUp != null) KeyUp(this, kea);
//                }
//            }
//            if (kea != null && kea.Handled && _hookedKeys[sKey]) return 1;
//            return CallNextHookEx(hhook, code, wParam, ref lParam);
//        }
//        #endregion

//    }
//
//}
#endregion


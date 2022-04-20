using System.Windows.Forms;

namespace AnignoLibrary.Helpers.InvokationHelpers
{
    public enum InvokationTypeEnum
    {
        Synch,
        Async
    }

    public class ControlInvokationHelper
    {
        #region Delegates (1) 

        private delegate void ControlStringDelegate(Control control, InvokationTypeEnum invokationType, string text);
        private delegate void ControlBoolDelegate(Control control, InvokationTypeEnum invokationType, bool enabled);

        #endregion Delegates 

        #region Static Methods (1) 

        public static void SetText(Control control, InvokationTypeEnum invokationType, string text)
        {
            if (control.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    control.BeginInvoke(new ControlStringDelegate(SetText), control, invokationType, text);
                }
                else
                {
                    control.Invoke(new ControlStringDelegate(SetText), control, invokationType, text);
                }
            }
            else
            {
                control.Text = text;
            }
        }

        public static void SetEnabled(Control control, InvokationTypeEnum invokationType, bool enabled)
        {
            if (control.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    control.BeginInvoke(new ControlBoolDelegate(SetEnabled), control, invokationType, enabled);
                }
                else
                {
                    control.Invoke(new ControlBoolDelegate(SetEnabled), control, invokationType, enabled);
                }
            }
            else
            {
                control.Enabled = enabled;
            }
        }

        public static void SetVisible(Control control, InvokationTypeEnum invokationType, bool visible)
        {
            if (control.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    control.BeginInvoke(new ControlBoolDelegate(SetVisible), control, invokationType, visible);
                }
                else
                {
                    control.Invoke(new ControlBoolDelegate(SetVisible), control, invokationType, visible);
                }
            }
            else
            {
                control.Visible = visible;
            }
        }

        #endregion Static Methods 

    }
}
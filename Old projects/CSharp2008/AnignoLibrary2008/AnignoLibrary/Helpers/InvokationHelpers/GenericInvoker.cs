using System;
using System.Windows.Forms;

namespace AnignoLibrary.Helpers.InvokationHelpers
{
    public static class GenericInvoker
    {


        #region GenericInvoke
        public static void GenericInvoke<CONTROL>(CONTROL control, Action<CONTROL> actionDelegate) where CONTROL : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<CONTROL, Action<CONTROL>>(GenericInvoke), new object[] { control, actionDelegate });
            }
            else
            {
                actionDelegate(control);
            }
        }

        public static void GenericInvokeTryCached<CONTROL>(CONTROL control, Action<CONTROL> actionDelegate) where CONTROL : Control
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action<CONTROL, Action<CONTROL>>(GenericInvoke), new object[] { control, actionDelegate });
                }
                else
                {
                    actionDelegate(control);
                }
            }
            finally
            {
            }
        }


        //Usage example
        //GenericInvoke(control, ctrl => ctrl.Text = text);
        #endregion

        #region SafeThread
        public static void SafeThreadAction<FORM>(this FORM form, Action<FORM> call) where FORM : Form
        {
            form.BeginInvoke(call, form);
        }

        public static RET_TYPE SafeThreadGet<FORM, RET_TYPE>(this FORM form, Func<FORM, RET_TYPE> call) where FORM : Form
        {
            IAsyncResult result = form.BeginInvoke(call, form);
            object result2 = form.EndInvoke(result);
            return (RET_TYPE)result2;
        }

        //Usage example
        //Value change:
        //SafeThreadAction(frm => frm.progressbar1.value=5);
        //Method will run on UI thread:
        //SafeThreadAction(d => d.UpdateFormItems("test1", "test2"));
        //Getter:
        //textboxtext=this.SafeThreadGet(frm=>frm.textbox.text); 
        #endregion
    }
}
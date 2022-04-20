using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.Helpers.InvokationHelpers
{
    public static class ProgressBarInvokationHelper
    {
        public delegate void SetValueHandler(ProgressBar control, InvokationTypeEnum invokationType, int value);

        public static void SetValue(ProgressBar progressBar, InvokationTypeEnum invokationType, int value)
        {
            if (progressBar.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    progressBar.BeginInvoke(new SetValueHandler(SetValue), progressBar, invokationType, value);
                }
                else
                {
                    progressBar.Invoke(new SetValueHandler(SetValue), progressBar, invokationType, value);
                }
            }
            else
            {
                progressBar.Value = value;
            }
        }

        public static void SetMaximum(ProgressBar progressBar, InvokationTypeEnum invokationType, int maximum)
        {
            if (progressBar.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    progressBar.BeginInvoke(new SetValueHandler(SetMaximum), progressBar, invokationType, maximum);
                }
                else
                {
                    progressBar.Invoke(new SetValueHandler(SetMaximum), progressBar, invokationType, maximum);
                }
            }
            else
            {
                progressBar.Maximum = maximum;
            }
        }

    
    
    }
}

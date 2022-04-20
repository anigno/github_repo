using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnignoLibrary.Helpers.InvokationHelpers
{
    public static class ListBoxInvokationHelper
    {
        public delegate void InvocationDelegate_object(ListBox listBox, object obj);
        public delegate void InvocationDelegate_object_int(ListBox listBox, object obj,int i);

        public static void ItemAdd(ListBox listBox, object item)
        {
            if (listBox.InvokeRequired)
            {
                listBox.Invoke((InvocationDelegate_object)ItemAdd, new object[] { listBox, item });
            }
            else
            {
                listBox.Items.Add(item);
            }
        }
    }
}
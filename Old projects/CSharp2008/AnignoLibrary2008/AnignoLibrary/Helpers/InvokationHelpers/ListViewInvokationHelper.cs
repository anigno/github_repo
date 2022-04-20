using System;
using System.Windows.Forms;
using System.Drawing;

namespace AnignoLibrary.Helpers.InvokationHelpers
{
    public static class ListViewInvokationHelper
    {
		#region (------  Delegates  ------)

        public delegate void InvocationDelegate_ListViewItem(ListView listView, ListViewItem item);
        private delegate void ListViewAddItemDelegate(ListView listView, InvokationTypeEnum invokationType, ListViewItem item, bool ensureVisible);
        private delegate void ListViewClearItemsDelegate(ListView listView, InvokationTypeEnum invokationType);
        private delegate void ListViewItemRemoveDelegate(ListView listView, InvokationTypeEnum invokationType, int index);
        private delegate void ListViewSubItemSetDelegate(ListView listView, InvokationTypeEnum invokationType, int itemIndex, int subItemIndex, string text);
        private delegate void ListViewItemColorsSetDelegate(ListView listView, InvokationTypeEnum invokationType, int itemIndex, Color foreColor, Color backColor);


		#endregion (------  Delegates  ------)

		#region (------  Event Handlers  ------)
        public static void ListView_ItemColorsSet_Invoked(ListView listView, InvokationTypeEnum invokationType, int itemIndex, Color foreColor, Color backColor)
        {
            if (listView.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    listView.BeginInvoke(new ListViewItemColorsSetDelegate(ListView_ItemColorsSet_Invoked), listView, invokationType, itemIndex, foreColor,backColor);
                }
                else
                {
                    listView.Invoke(new ListViewItemColorsSetDelegate(ListView_ItemColorsSet_Invoked), listView, invokationType, itemIndex, foreColor, backColor);
                }
            }
            else
            {
                listView.Items[itemIndex].ForeColor = foreColor;
                listView.Items[itemIndex].BackColor = backColor;
            }
        }

        public static void ListView_SubItemSetText_Invoked(ListView listView, InvokationTypeEnum invokationType, int itemIndex, int subItemIndex, string text)
        {
            if (listView.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    listView.BeginInvoke(new ListViewSubItemSetDelegate(ListView_SubItemSetText_Invoked), listView, invokationType, itemIndex, subItemIndex,text);
                }
                else
                {
                    listView.Invoke(new ListViewSubItemSetDelegate(ListView_SubItemSetText_Invoked), listView, invokationType, itemIndex, subItemIndex, text);
                }
            }
            else
            {
                listView.Items[itemIndex].SubItems[subItemIndex].Text = text;
            }
        }

        public static void ListView_ItemAdd_Invoked(ListView listView, InvokationTypeEnum invokationType, ListViewItem item, bool ensureVisible)
        {
            if (listView.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    listView.BeginInvoke(new ListViewAddItemDelegate(ListView_ItemAdd_Invoked), listView, invokationType, item, ensureVisible);
                }
                else
                {
                    listView.Invoke(new ListViewAddItemDelegate(ListView_ItemAdd_Invoked), listView, invokationType, item, ensureVisible);
                }
            }
            else
            {
                listView.Items.Add(item);
                if (ensureVisible)
                {
                    item.EnsureVisible();
                }
            }
        }

        public static void ListView_ItemRemove_Invoked(ListView listView, InvokationTypeEnum invokationType, int index)
        {
            if (listView.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    listView.BeginInvoke(new ListViewItemRemoveDelegate(ListView_ItemRemove_Invoked), listView, invokationType, index);
                }
                else
                {
                    listView.Invoke(new ListViewItemRemoveDelegate(ListView_ItemRemove_Invoked), listView, invokationType, index);
                }
            }
            else
            {
                listView.Items.RemoveAt(index);
            }
        }

        public static void ListView_ItemsClear_Invoked(ListView listView, InvokationTypeEnum invokationType)
        {
            if (listView.InvokeRequired)
            {
                if (invokationType == InvokationTypeEnum.Async)
                {
                    listView.BeginInvoke(new ListViewClearItemsDelegate(ListView_ItemsClear_Invoked), listView, invokationType);
                }
                else
                {
                    listView.Invoke(new ListViewClearItemsDelegate(ListView_ItemsClear_Invoked), listView, invokationType);
                }
            }
            else
            {
                listView.Items.Clear();
            }
        }

        [Obsolete]
        public static void ListViewItemAdd_old(ListView listView, ListViewItem item)
        {
            if (listView.InvokeRequired)
            {
                listView.Invoke((InvocationDelegate_ListViewItem)ListViewItemAdd_old, new object[] { item });
            }
            else
            {
                listView.Items.Add(item);
                item.EnsureVisible();
            }
        }

		#endregion (------  Event Handlers  ------)
    }
}
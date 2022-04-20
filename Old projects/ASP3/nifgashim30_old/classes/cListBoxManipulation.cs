using System;
using System.Web.UI.WebControls;

namespace nifgashim30
{
	public class cListBoxManipulation
	{
		public cListBoxManipulation()
		{
		}//cListBoxManipulation()
        
		public static void fillListControlFromDataArray(cDataItemArray dataArray,ListControl listControl)
		{
			listControl.Items.Clear();
			foreach(cDataItem item in dataArray)
			{
				ListItem lItem=new ListItem();
				lItem.Text=item.Text;
				lItem.Value=item.Value.ToString();
				listControl.Items.Add(lItem);
			}//foreach
		}//fillListControlFromDataArray()

		//recieve user value of some list control, set the list control to select that value
		public static int setListControlIndexFromDataArray(cDataItemArray dataArray,object userValue,ListControl listControl)
		{
			int val;
			int c=0;
			if(userValue is string)
			{
				val=int.Parse((string)userValue);
			}
			else
			{
				val=(int)userValue;
			}//if else
			foreach(cDataItem item in dataArray)
			{
				if(item.Value==val)
				{
					listControl.SelectedIndex=c;
					return c;
				}//if
				c++;
			}//foreach
			return 0;
		}//setListControlIndexFromDataArray()

	}//class
}//namespace

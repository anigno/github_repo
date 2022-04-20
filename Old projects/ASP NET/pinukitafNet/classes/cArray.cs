using System;
using System.Collections;

namespace pinukitafNet
{
	public class cArray:ArrayList
	{
		public cArray()
		{
		}//public cArray()

		public object getByIndex(int index)
		{
			int j=0;
			foreach(object obj in this)
			{
				if(j==index)return obj;
				j++;
			}//foreach
			return null;
		}//public object getByIndex(int index)
	}//public class cArray
}//namespace pinukitafNet.classes

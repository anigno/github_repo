using System;
using System.Collections;

namespace mailExtractor
{
	/// <summary>
	/// Summary description for cCollection.
	/// </summary>
	public class cCollection:CollectionBase
	{
		public cCollection()
		{
		}//cCollection()
		public int add(String item)
		{
			return(List.Add(item));
		}//add

		public int count()
		{
			return(List.Count);
		}//count()

		public void clear()
		{
			List.Clear();
		}//clear()

	}//class cCollection
}//namespace

using System;

namespace business
{
	public class cUtils:System.Web.UI.Page
	{
		public static string convertToHtmlString(string text)
		{
			string ret="";
			string c;
			for(int i=0;i<text.Length;i++)
			{
				c=text.Substring(i,1);
				if(c=="\n")
				{
					ret+="<br>";
				}
				else
				{
					ret+=c;
				}//if else
			}//for
			return ret;
		}//convertToHtmlString()
	}//class
}//namespace

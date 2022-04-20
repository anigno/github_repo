using System;
using System.Collections;
using anignoLibrary.ClassLibraryMdbConnection;
using System.Data;

namespace nifgashim30
{
	public class cDataItemArray:ArrayList
	{
		//constructor, fill from database
		public cDataItemArray(cDatabaseConnection con,string tableName)
		{
			con.createSelect(tableName,"*","","","");
			DataTable table=con.runSelect();
			foreach(DataRow row in table.Rows)
			{
				int dataValue=int.Parse(row["fldValue"].ToString());
				string dataText=row["fldText"].ToString();
				cDataItem item=new cDataItem(dataValue,dataText);
				this.Add(item);
			}//foreach
		}//cDataItemArray()
		
		//constructor, empty
		public cDataItemArray()
		{
		}//cDataItemArray()
	}//class
}//namespace

using System;
using System.Data.OleDb;
using System.Data;

namespace webProjectFinal
{
	/// <summary>
	/// create,manage and run SELECT SQL command
	/// </summary>
	public class cSelect : cDbCommand
	{
		private String _sql="";
		
		//constructor,set parameters
		public cSelect(String connectionString,String fromTable,String selectedFields,String where,String orderBy,String groupBy) :base(connectionString,fromTable)
		{
			this.connectionString=connectionString;
			_sql="SELECT ";
			if(selectedFields=="")_sql+="*"; else _sql+=selectedFields;
			_sql+=" FROM "+fromTable;
			if(where!="")_sql+=" WHERE "+where;
			if(orderBy!="")_sql+=" ORDER BY "+orderBy;
			if(groupBy!="")_sql+=" GROUP BY "+groupBy;
		}//cSelect()

		//run SELECT command, return DataTable from requested query
		public DataTable run()
		{
			OleDbDataAdapter dbAdapter=new OleDbDataAdapter(_sql,connectionString);
			DataSet ds=new DataSet();
			//try to fill adapter data in DatSet
			try
			{
				dbAdapter.Fill(ds);
				return ds.Tables[0];
			}
			catch(Exception exception)
			{
				//problem with query, possible SQL error
				throw new Exception("SQL=<"+_sql+"> Message= "+exception.Message);
			}//catch
			finally
			{
				dbAdapter.Dispose();
			}//finally
		}//run()
	}//class cSelect
}//namespace

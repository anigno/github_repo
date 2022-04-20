using System;
using System.Collections;
using System.Data.OleDb;

namespace webProjectFinal
{
	/// <summary>
	/// create,manage and run DELETE SQL command
	/// </summary>
	public class cDelete : cDbCommand
	{
		private String where="";	//the WHERE part of the DELETE SQL command

		//constructor,set parameters
		public cDelete(String connectionString,String table,String where):base(connectionString,table)
		{
			this.connectionString=connectionString;
			this.table=table;
			this.where=where;
		}//public cInsert()

		//return SQL string for DELETE command
		private string getSql()
		{
			String ret="DELETE FROM "+table+" WHERE "+where;
			return ret;
		}//public string getSql()

		//clear parameters, prepere for new DELETE command
		public void clear()
		{
			table="";
			where="";
		}//public void clear()

		//run DELETE command
		public void run()
		{
			OleDbConnection dbconnection=new OleDbConnection(connectionString);
			try
			{
				dbconnection.Open();
				OleDbCommand dbCommand=new OleDbCommand(getSql(),dbconnection);
				dbCommand.ExecuteNonQuery();
				dbconnection.Close();
			}
			catch(Exception exception)
			{
				System.Console.WriteLine(exception.Message);
				throw new Exception(exception.Message);
			}//catch
			finally
			{
				dbconnection.Dispose();
			}//finally
			}//run	
	}//class cDelete
}//namespace

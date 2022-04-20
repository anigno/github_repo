using System;
using System.Collections;
using System.Data.OleDb;

namespace webProjectFinal
{
	/// <summary>
	/// create,manage and run UPDATE SQL command
	/// </summary>
	public class cUpdate : cDbCommand
	{
		private String where="";						//the WHERE part of the SQL sentence
		private ArrayList updateList=new ArrayList();	//collection of fields for UPDATE commannd to SET

		//constructor, set parameters
		public cUpdate(String connectionString,String table,String where) : base(connectionString,table)
		{
			this.connectionString=connectionString;
			this.table=table;
			this.where=where;
			updateList.Clear();
		}//public cUpdate()

		//add field to update list
		public void add(String fieldName,object fieldValue)
		{
			cField field=new cField(fieldName,fieldValue);
			updateList.Add(field);
		}//add()

		//return the SQL string for the update command
		private string getSql()
		{
			String ret="UPDATE "+table+" set ";
			foreach(cField field in updateList)
			{
				ret+=field.fieldName+"=";
				ret+=field.fieldValue+",";
			}//foreach
			//remove ',' at the end
			ret=ret.Substring(0,ret.Length-1);
			ret+=" WHERE "+where;
			return ret;
		}//public string getSql()

		//clear the update command, prepere for a new command
		public void clear()
		{
			updateList.Clear();
			table="";
			where="";
		}//public void clear()

		//run the UPDATE command
		public void run()
		{
			OleDbConnection dbconnection=new OleDbConnection(connectionString);
			dbconnection.Open();
			OleDbCommand dbCommand=new OleDbCommand(getSql(),dbconnection);
			try
			{
				dbCommand.ExecuteNonQuery();
				dbconnection.Close();
			}
			catch(Exception exception)
			{
				throw new Exception("SQL=<"+getSql()+"> Message= "+exception.Message);
			}//catch
			finally
			{
				dbconnection.Dispose();
			}//finally
		}//run	
	}//class cUpdate
}//namespace

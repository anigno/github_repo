using System;
using System.Collections;
using System.Data.OleDb;

namespace webProjectFinal
{
	/// <summary>
	/// create,manage and run INSERT SQL command
	/// </summary>
	public class cInsert : cDbCommand
	{
		private ArrayList insertList=new ArrayList();	//list of field to build SQL
		//constructor, set parameters
		public cInsert(String connectionString,String table):base(connectionString,table)
		{
			this.connectionString=connectionString;
			this.table=table;
			insertList.Clear();
		}//public cInsert()

		//add field to insertList
		public void add(String fieldName,object fieldValue)
		{
			cField field=new cField(fieldName,fieldValue);
			insertList.Add(field);
		}//add()
		
		//return legal SQL sentence
		private string getSql()
		{
			String ret="INSERT INTO "+table+" (";
			String fields="";
			String values="";
			foreach(cField field in insertList)
			{
				fields+=field.fieldName+",";
				values+=field.fieldValue+",";
			}//foreach
			//remove , at the end
			fields=fields.Substring(0,fields.Length-1);
			values=values.Substring(0,values.Length-1);
			ret+=fields+") VALUES (" + values +")";
			return ret;
		}//public string getSql()
		
		//clear the insertList and table, prepere for new INSERT command
		public void clear()
		{
			insertList.Clear();
			table="";
		}//public void clear()

		//run the INSERT command
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
		}//runInsert()
	}//public class cInsert
}//namespace

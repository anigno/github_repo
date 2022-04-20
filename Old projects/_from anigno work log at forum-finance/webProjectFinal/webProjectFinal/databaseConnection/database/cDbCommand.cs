using System;

namespace webProjectFinal
{
	/// <summary>
	/// Summary description for cDbCommand.
	/// </summary>
	public abstract class cDbCommand
	{
		protected String connectionString;	//the database connection string
		protected String table;				//the actual table to work with
		
		//constructor, set parameters
		public cDbCommand(String connectionString,String table)
		{
			this.connectionString=connectionString;
			this.table=table;
		}//cDbCommand()
		
	}//class cDbCommand
}//namespace

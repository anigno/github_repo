using System;
using System.Data.OleDb;
using System.Data;
using webProjectFinal;

namespace webProjectFinal
{
	/// <summary>
	/// contains classes for connection to database, setting parameters and running the commands
	/// </summary>
	public class cDatabaseConnection
	{
		private String mdbPath="";
		private String mdbFile="";
		private String mdbPassword="";
		private String connectionString="";
		private cSelect selectCommand;
		private cInsert insertCommand;
		private cUpdate updateCommand;
		private cDelete deleteCommand;

		//constructor, set the file and password for the connection
		public cDatabaseConnection(String mdbFile,String mdbPassword)
		{
			this.mdbPath=mdbPath;
			this.mdbFile=mdbFile;
			this.mdbPassword=mdbPassword;
			//create the connection string for this connection

			//connectionString="Provider=Microsoft.Jet.OLEDB.4.0;	data source=" + mdbFile;
			connectionString="Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source="+mdbFile+";Mode=Share Deny None;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
		}//cDatabaseConnection()

		public void createSelect(String fromTable,String selectedFields,String where,String orderBy,String groupBy)
		{
			selectCommand=new cSelect(connectionString,fromTable,selectedFields,where,orderBy,groupBy);
		}//select()

		public DataTable runSelect()
		{
			//return DataTable of requested SELECT
			return selectCommand.run();
		}//runSelect()

		public void createInsert(String table)
		{
			insertCommand=new cInsert(connectionString,table);
		}//createInsert()

		public void addToInsert(String fieldName,object fieldValue)
		{
			insertCommand.add(fieldName,fieldValue);
		}//addToInsert()

		public void clearInsert()
		{
			insertCommand.clear();
		}//clearInsert;

		public void runInsert()
		{
			insertCommand.run();
		}//runInsert()

		public void createUpdate(String table,String where)
		{
			updateCommand=new cUpdate(connectionString,table,where);
		}//createInsert()

		public void addToUpdate(String fieldName,object fieldValue)
		{
			updateCommand.add(fieldName,fieldValue);
		}//addToInsert()

		public void clearUpdate()
		{
			updateCommand.clear();
		}//clearInsert;

		public void runUpdate()
		{
			updateCommand.run();
		}//runInsert()

		public void createDelete(String table,String where)
		{
			deleteCommand=new cDelete(connectionString,table,where);
		}//createInsert()

		public void clearDelete()
		{
			deleteCommand.clear();
		}//clearInsert;

		public void runDelete()
		{
			deleteCommand.run();
		}//runInsert()
	}//class cDatabaseConnection}
}//namespace

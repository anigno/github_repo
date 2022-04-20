using System;
using System.Data.OleDb;
using System.Data;
using System.Collections;


namespace pinukitafNet
{
	public class cData
	{
		String mdbFilePath;
		String connectionString;
		public OleDbConnection dbconnection;
		public cData.cInsert insertCommand;
		public cData.cDelete deleteCommand;
		public cData.cUpdate updateCommand;
		public cData.cSelect selectCommand;
		
		public cData(String mdbPath,String mdbFileName)
		{
			this.mdbFilePath=mdbPath+mdbFileName;
			connectionString="Provider=Microsoft.Jet.OLEDB.4.0;	data source=" + cGeneralData.serverPath+mdbFilePath;
			dbconnection=new OleDbConnection(connectionString);
		}//public cData(String mdbFilePath)

		public void openConnection()
		{
			dbconnection.Open();
		}//public void createConnection()

		public void closeConnection()
		{
			dbconnection.Close();
		}//public void closeConnection()
		
		public void commandExecute(String sqlCommand)
		{
			dbconnection=new OleDbConnection(connectionString);
			dbconnection.Open();
			OleDbCommand dbCommand=new OleDbCommand(sqlCommand,dbconnection);
			dbCommand.ExecuteNonQuery();
			dbconnection.Close();
		}//public void runCommand(String sqlInsert)

		public cInsert createInsertCommand(String table)
		{
			this.insertCommand=new cInsert(table);
			return insertCommand;
		}//public String createInsert(String table)

		public void clearInsertCommand()
		{
			insertCommand.clear();
		}//public void clearInsert()

		public cDelete createDeleteCommand(String table,String where)
		{
			this.deleteCommand=new cDelete(table,where);
			return deleteCommand;
		}//public cDelete createDelete(String table,String where)

		public void clearDeleteCommand()
		{
			deleteCommand.clear();
		}//public void clearDelete()

		public cUpdate createUpdateCommand(String table,String where)
		{
			this.updateCommand=new cUpdate(table,where);
			return updateCommand;
		}//public cUpdate createUpdate(String table,String where)

		public void clearUpdateCommand()
		{
			updateCommand.clear();
		}//public void clearUpdate()

		public cSelect createSelectCommand(String table,String where,String order)
		{
			this.selectCommand=new cSelect(table,where,order,dbconnection);
			return selectCommand;
		}//public cSelect createSelectCommand(String table,String where)

		public void clearSelectCommand()
		{
			selectCommand.clear();
		}//public void clearSelectCommand()
		//-------------------------------------------------------------------------------
		public class cSelect
		{
			String table="";
			String where="";
			String order="";
			OleDbConnection dbConnection;
			public cSelect(String table,String where,String order,OleDbConnection dbConnection)
			{
				this.table=table;
				this.where=where;
				this.order=order;
				this.dbConnection=dbConnection;
			}//public cSelect(String table,String where)

			public DataTable getTable()
			{
				OleDbDataAdapter dbAdapter=new OleDbDataAdapter(getSql(),dbConnection);
				DataSet ds=new DataSet();
				if(dbConnection.State==0)dbConnection.Open();
				dbAdapter.Fill(ds);
				if(dbConnection.State!=0)dbConnection.Close();
				return ds.Tables[0];
			}//public DataTable getTable(String sqlSelect)
			public String getSql()
			{
				String ret="SELECT * FROM "+table;
				if(where!="")ret+=" WHERE "+where;
				if(order!="")ret+=" ORDER BY "+order;

				return ret;
			}//public String getSql()
			public void clear()
			{
				table="";
				where="";
				order="";
			}//public void clear()
		}//public class cSelect
		//-------------------------------------------------------------------------------
		private class cField
		{
			public String fieldName;
			public object fieldValue;
			public cField(String fieldName,object fieldValue)
			{
				this.fieldName=fieldName;
				this.fieldValue=fieldValue;
			}//cFields(String fieldName,object fieldValue)
		}//public class cFields
		//-------------------------------------------------------------------------------
		public class cInsert
		{
			String table="";
			ArrayList insertList=new ArrayList();
			public cInsert(String table)
			{
				this.table=table;
				insertList.Clear();
			}//public cInsert()

			public int add(String fieldName,object fieldValue)
			{
				cField field=new cField(fieldName,fieldValue);
				insertList.Add(field);
				return insertList.Count;
			}//public int add(String fieldName,object fieldValue)
			public string getSql()
			{
				String ret="INSERT INTO "+table+" (";
				String fields="";
				String values="";
				foreach(cField field in insertList)
				{
					fields+=field.fieldName+",";
					if(field.fieldValue.GetType().ToString().Equals("System.String"))
					{
						values+="'"+field.fieldValue+"',";
					}
					else
					{
						values+=field.fieldValue+",";
					}//if else
				}//foreach
				fields=fields.Substring(0,fields.Length-1);
				values=values.Substring(0,values.Length-1);
				ret+=fields+") VALUES (" + values +")";
				return ret;
			}//public string getSql()
			public void clear()
			{
				insertList.Clear();
				table="";
			}//public void clear()
		}//public class cInsert
		//-------------------------------------------------------------------------------
		public class cDelete
		{
			String table="";
			String where="";
			public cDelete(String table,String where)
			{
				this.table=table;
				this.where=where;
			}//public cInsert()

			public string getSql()
			{
				String ret="DELETE FROM "+table+" WHERE "+where;
				return ret;
			}//public string getSql()
			public void clear()
			{
				table="";
				where="";
			}//public void clear()
		}//public class cDelete
		//-------------------------------------------------------------------------------
		public class cUpdate
		{
			String table="";
			String where="";
			ArrayList updateList=new ArrayList();
			public cUpdate(String table,String where)
			{
				this.table=table;
				this.where=where;
				updateList.Clear();
			}//public cInsert()

			public int add(String fieldName,object fieldValue)
			{
				cField field=new cField(fieldName,fieldValue);
				updateList.Add(field);
				return updateList.Count;
			}//public int add(String fieldName,object fieldValue)
			public string getSql()
			{
				String ret="UPDATE "+table+" set ";
				foreach(cField field in updateList)
				{
					ret+=field.fieldName+"=";
					if(field.fieldValue.GetType().ToString().Equals("System.String"))
					{
						ret+="'"+field.fieldValue+"',";
					}
					else
					{
						ret+=field.fieldValue+",";
					}//if else
				}//foreach
				ret=ret.Substring(0,ret.Length-1);
				ret+=" WHERE "+where;
				return ret;
			}//public string getSql()
			public void clear()
			{
				updateList.Clear();
				table="";
				where="";
			}//public void clear()
		}//public class cUpdate
	}//public class cData
}//namespace pinukitafNet


//			myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);

//			myData.createSelectCommand("tblPictures","");
//			DataTable pictures=myData.selectCommand.getTable();
//			foreach(DataRow row in pictures.Rows)
//			{
//				Response.Write("subject=  "+row["iSubject"]+" ");
//				Response.Write("filename= "+row["iFileName"]+"<BR>");
//			}//foreach

//			myData.createInsertCommand("tblPictures");
//			myData.insertCommand.add("iFileName","3.jpg");
//			myData.insertCommand.add("iSubject",3);
//			myData.commandExecute(myData.insertCommand.getSql());
//			myData.insertCommand.clear();
//
//			myData.createDeleteCommand("tblPictures","iSubject=3");
//			myData.commandExecute(myData.deleteCommand.getSql());
//			myData.deleteCommand.clear();
//			
//			myData.createUpdateCommand("tblPictures","iSubject=2");
//			myData.updateCommand.add("iSubject",44);
//			myData.updateCommand.add("iFileName","myFile.bmp");
//			myData.commandExecute(myData.updateCommand.getSql());

using System;
using System.Collections;
using System.Data;

namespace webProjectFinal
{
	/// <summary>
	/// Summary description for cSecurityManupulation.
	/// </summary>
	public abstract class cSecurityManupulation
	{
		public cSecurityManupulation()
		{
		}

		protected string checkAdmin(string workerID,string password)
		{
			//check if workerID and password are in passwords table
			cDatabaseConnection con=new cDatabaseConnection(cGlobal.SECURITY_MDB_FILE,cGlobal.SECURITY_MDB_PASSWORD);
			string where="fldWorkerID='"+workerID+"' AND fldPassword='"+password+"'";
			con.createSelect(cGlobal.SECURITY_TABLE,"*",where,"","");
			DataTable table=con.runSelect();
			//if no rows, no workerID admin
			if(table.Rows.Count>0)
			{
				string id=table.Rows[0]["fldWorkerID"].ToString();
				string passwd=table.Rows[0]["fldPassword"].ToString();
				//if workerID and password ok return admin string
				if( (id==workerID)&&(passwd==password) )return cGlobal.ADMIN_STRING;
			}//if
			//check if workerID in workers table
			con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
			where="fldWorkerID='"+workerID+"'";
			con.createSelect(cGlobal.WORKERS_TABLE,"*",where,"","");
			table=con.runSelect();
			//if no rows, not a worker in factory
			if(table.Rows.Count>0)
			{
				string id=table.Rows[0]["fldWorkerID"].ToString();
				//if workerID OK return workerID
				if(id==workerID)return workerID;
			}//if
			//return "", not admin and not worker, possible hacker!
			return "";
		}//checkAdmin()
	}//class cSecurityManupulation
}//namespace

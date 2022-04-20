using System;
using System.Collections;
using System.Data;

namespace webProjectFinal
{
	/// <summary>
	/// interface between database actions and logic class requests of all workers data
	/// </summary>
	abstract public class cWorkerCollectionManipulation
	{
		string workingString="";

		//constructor, setting parameters
		protected cWorkerCollectionManipulation(string workingString)
		{
			this.workingString=workingString;
		}//cWorkersManipulation()

		//read all workers, return ArrayList contains data
		protected ArrayList readAllWorkers()
		{
			string where="";
			if(workingString==cGlobal.ADMIN_STRING)
				where="";
			else
				where="fldWorkerId='"+workingString+"'";
			cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
			con.createSelect(cGlobal.WORKERS_TABLE,"*",where,"fldWorkerID","");
			DataTable table=con.runSelect();
			ArrayList workers=new ArrayList();
			foreach(DataRow row in table.Rows)
			{
				cWorker worker=new cWorker(workingString,row["fldFirstName"].ToString(),
					row["fldLastName"].ToString(),
					Double.Parse(row["fldBaseHourRate"].ToString()),
					row["fldWorkerID"].ToString());
				workers.Add(worker);
			}//foreach
			return workers;			
		}//readAllWorkers()
	}//class cWorkerCollectionManipulation
}//namespace

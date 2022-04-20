using System;
using System.Data;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// interface between database actions and logic class requests of worker data
	/// </summary>
	abstract public class cWorkerManipulation
	{
		string workingString="";

		public cWorkerManipulation(string workingString)
		{
			this.workingString=workingString;
		}//cWorkerManipulation()

		//constructor,set parameters and add new worker to database
		protected void addWorker(string firstName,string lastName,double baseHourRate,string workerID)
		{
			if(workingString==cGlobal.ADMIN_STRING)
			{
				//create INSERT command
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				con.createInsert(cGlobal.WORKERS_TABLE);
				con.addToInsert("fldFirstName",firstName);
				con.addToInsert("fldLastName",lastName);
				con.addToInsert("fldBaseHourRate",baseHourRate);
				con.addToInsert("fldWorkerID",workerID);
				//try to add new worker
				try
				{
					con.runInsert();
				}
				catch(Exception exception)
				{
					//workerID already exist, or sql error
					throw new Exception("WorkerID "+workerID+" already exist or "+exception.Message);
				}//catch
			}//if
		}//addWorker

		//update worker's data in database
		protected void updateWorker(string firstName,string lastName,double baseHourRate,string workerID)
		{
			if(workingString==cGlobal.ADMIN_STRING)
			{
				//create UPDATE command
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				con.createUpdate(cGlobal.WORKERS_TABLE,"fldWorkerID='"+workerID+"'");
				con.addToUpdate("fldFirstName",firstName);
				con.addToUpdate("fldLastName",lastName);
				con.addToUpdate("fldBaseHourRate",baseHourRate);
				con.addToUpdate("fldWorkerID",workerID);
				//try to update workers data
				try
				{
					con.runUpdate();
				}
				catch
				{
					//workerID not exist or sql error
					throw new Exception("WorkerID "+workerID+" not exist");
				}//catch
			}//if
		}//updateWorker()

		//read worker data by workerID
		protected cWorker readWorker(string ID)
		{
			if( (workingString==cGlobal.ADMIN_STRING)||(workingString==ID) )
			{
				//create SELECT command
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				con.createSelect(cGlobal.WORKERS_TABLE,"*","fldWorkerID='"+ID+"'","","");
				DataTable table=con.runSelect();
				//try to read worker data
				try
				{
					cWorker w=new cWorker(workingString,table.Rows[0]["fldFirstName"].ToString(),
						table.Rows[0]["fldLastName"].ToString(),
						Double.Parse(table.Rows[0]["fldBaseHourRate"].ToString()),
						table.Rows[0]["fldWorkerID"].ToString());
					return w;
				}
				catch
				{
					throw new Exception("No data found for workerID="+ID);
				}//catch
			}//if
			return null;
		}//readWorker()

		//delete worker by workerID
		protected void deleteWorker(string ID)
		{
			if(workingString==cGlobal.ADMIN_STRING)
			{
				//create DELETE command
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				con.createDelete(cGlobal.WORKERS_TABLE,"fldWorkerID='"+ID+"'");
				con.runDelete();
			}//if
		}//deleteWorker()
	}//class cWorkerManipulation
}//namespace

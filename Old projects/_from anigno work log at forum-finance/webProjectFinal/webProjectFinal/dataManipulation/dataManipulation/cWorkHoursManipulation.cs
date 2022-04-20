using System;
using System.Collections;
using System.Data;

namespace webProjectFinal
{
	/// <summary>
	/// interface between database actions and logic class requests of work hours  data
	/// </summary>
	abstract public class cWorkHoursManipulation
	{
		string workingString;

		//constructor, setting parameters
		protected cWorkHoursManipulation(string workingString)
		{
			this.workingString=workingString;
		}//cWorkHoursManipulation()

		//constructor for adding new workHours in database
		protected void addWorkHours(string ID,DateTime date,double time)
		{
			if(workingString==cGlobal.ADMIN_STRING)
			{
				//add workHours to database
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				con.createInsert(cGlobal.WORK_HOURS_TABLE);
				con.addToInsert("fldWorkerID",ID);
				con.addToInsert("fldDate",date.ToShortDateString());
				con.addToInsert("fldTime",time);
				con.runInsert();
			}//if
		}//addWorkHours()

		//constructor for getting existed workHours from database
		protected cWorkHours readWorkHours(string workerID,DateTime date)
		{
			if(workingString==cGlobal.ADMIN_STRING)
			{
				//SELECT workHours by ID and date
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				string where="fldWorkerID='"+workerID+"' AND fldDate="+date.ToOADate()+"";
				con.createSelect(cGlobal.WORK_HOURS_TABLE,"*",where,"","");
				DataTable table=con.runSelect();
				cWorkHours workHours;
				//try to read workhours for ID and date
				try
				{
					workHours=new cWorkHours(
						workingString,
						table.Rows[0]["fldWorkerID"].ToString(),
						(DateTime)table.Rows[0]["fldDate"],
						Double.Parse(table.Rows[0]["fldTime"].ToString()));
				}
				catch
				{
					//no workhours exist for ID and date
					throw new Exception("No workHours set for "+workerID+" at "+date);
				}//catch
				return workHours;
			}//if
			return null;
		}//readWorkHours()

		//update workHours for workerID
		protected void updateWorkHours(string workerID,DateTime date,double time)
		{
			if(workingString==cGlobal.ADMIN_STRING)
			{
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
				con.createUpdate(cGlobal.WORK_HOURS_TABLE,"fldWorkerID='"+workerID+"' AND fldDate="+date.ToOADate()+"");
				con.addToUpdate("fldTime",time);
				con.runUpdate();
			}//if
		}//update()

	}//class cWorkHoursManipulation
}//namespace

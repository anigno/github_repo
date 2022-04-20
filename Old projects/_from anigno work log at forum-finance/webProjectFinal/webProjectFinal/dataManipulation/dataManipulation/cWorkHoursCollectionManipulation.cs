using System;
using System.Collections;
using System.Data;

namespace webProjectFinal
{
	/// <summary>
	/// interface between database actions and logic class requests of collection of workHours per worker
	/// </summary>
	abstract public class cWorkHoursCollectionManipulation
	{
		string workingString="";
		
		public cWorkHoursCollectionManipulation(string workingString)
		{
			this.workingString=workingString;
		}//cWorkHoursCollectionManipulation()

		//read all workHours for workerID and working month, return ArrayList with data
		protected ArrayList readWorkHoursCollection(string workerID,int year,int month)
		{
			cDatabaseConnection con=new cDatabaseConnection(cGlobal.WORKERS_MDB_FILE,cGlobal.WORKERS_MDB_PASSWORD);
			string sFromDate="1/"+month+"/"+year;
			DateTime fromDate=DateTime.Parse(sFromDate);
			DateTime toDate=fromDate.AddMonths(1);
			string where="fldWorkerID='"+workerID+"' AND fldDate>="+fromDate.ToOADate()+" AND fldDate<"+toDate.ToOADate()+"";
			con.createSelect(cGlobal.WORK_HOURS_TABLE,"*",where,"fldDate","");
			DataTable table=con.runSelect();
			ArrayList ret=new ArrayList();
			if( (workingString==cGlobal.ADMIN_STRING)||(workingString==workerID) )
			{
				foreach(DataRow row in table.Rows)
				{
					cWorkHours wh=new cWorkHours(
						workingString,
						row["fldWorkerID"].ToString(),
						(DateTime)row["fldDate"],
						double.Parse(row["fldTime"].ToString()));
					ret.Add(wh);
				}//foreach
			}//if
			return ret;
		}//readWorkHoursCollection
	}//class cWorkHoursCollectionManipulation
}//namespace

using System;

namespace webProjectFinal
{
	/// <summary>
	/// manage workHours data for worker
	/// </summary>
	public class cWorkHours:cWorkHoursManipulation
	{
		private string _workerID;
		private DateTime _date;
		private double _time;

		//constructor, setting parameters
		public cWorkHours(string workingString,string workerID,DateTime date,double time):base(workingString)
		{
			_workerID=workerID;
			_date=date;
			_time=time;
		}//cWorkHours()

		//constructor, read workHours for workerID and work month
		public cWorkHours(string workingString,string workerID,DateTime date):base(workingString)
		{
			try
			{
				cWorkHours workHours=readWorkHours(workerID,date);
				_workerID=workHours.workerID;
				_date=workHours.date;
				_time=workHours.time;
			}
			catch(Exception exception)
			{
				//no workhours found in date for workerID
				throw new Exception(exception.Message);
			}//catch
		}//cWorkHours()

		public void add()
		{
			addWorkHours(_workerID,_date,_time);
		}//add()

		public void update()
		{
			updateWorkHours(_workerID,_date,_time);
		}//update()

		public string workerID
		{
			get
			{
				return _workerID;
			}
		}

		public DateTime date
		{
			get
			{
				return _date;
			}
		}

		public double time
		{
			get
			{
				return _time;
			}
		}
	}//class cWorkHours
}//namespace

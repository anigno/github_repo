using System;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// interface between gui elements and data manipulation for worker
	/// </summary>
	public class cWorker:cWorkerManipulation
	{
		private string _firstName;
		private string _lastName;
		private double _baseHourRate;
		private string _workerID;
		
		public cWorker(string workingString,string firstName,string lastName,double baseHourRate,string workerID):base(workingString)
		{
			_firstName=firstName;
			_lastName=lastName;
			_baseHourRate=baseHourRate;
			_workerID=workerID;
		}//cWorker()

		public cWorker(string workingString,string workerID):base(workingString)
		{
			try
			{
				cWorker w=readWorker(workerID);
				_firstName=w.firstName;
				_lastName=w.lastName;
				_baseHourRate=w.baseHourRate;
				_workerID=w.workerID;
			}
			catch(Exception exception)
			{
				throw new Exception(exception.Message);
			}//catch
		}//cWorker()

		public void add()
		{
			try
			{
				addWorker(_firstName,_lastName,_baseHourRate,_workerID);
			}
			catch(Exception exception)
			{
				throw new Exception(exception.Message);
			}//catch
		}//add()

		public void update()
		{
			updateWorker(_firstName,_lastName,_baseHourRate,_workerID);
		}//update()

		public void delete()
		{
			deleteWorker(_workerID);
		}//delete()

		public string firstName
		{
			get
			{
				return _firstName;
			}//get
		}//firstname

		public string workerID
		{
			get
			{
				return _workerID;
			}//get
		}//workerID

		public string lastName
		{
			get
			{
				return _lastName;
			}//get
		}//lastName

		public double baseHourRate
		{
			get
			{
				return _baseHourRate;
			}//get
		}//baseHourRate
	}//class cWorker
}//namespace

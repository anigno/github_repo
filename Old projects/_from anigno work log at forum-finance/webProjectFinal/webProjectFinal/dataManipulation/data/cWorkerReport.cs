using System;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// create report for worker
	/// </summary>
	public class cWorkerReport
	{
		public double regularHours=0;
		public double extraHours=0;
		public double gross=0;
		public double incomeTax=0;
		public double socialSecurityTax=0;
		public double net=0;
		public ArrayList workHoursCollection;
		private cWorker _worker;

		//constructor, read workHours data for workerID
		public cWorkerReport(string workingString,string workerID,int year,int month)
		{
			_worker=new cWorker(workingString,workerID);
			cWorkHoursCollection whc=new cWorkHoursCollection(workingString);	//for reading data for workerID
			cFactoryData factoryData=new cFactoryData(workingString);			//for reading factory data
			//read worker workhoursData
			workHoursCollection=whc.readAll(workerID,year,month);
			foreach(cWorkHours workHours in workHoursCollection)
			{
				//count regular and extra work hours
				if(workHours.time>factoryData.baseWorkdayHours)
				{
					extraHours+=(workHours.time-factoryData.baseWorkdayHours);
					regularHours+=(factoryData.baseWorkdayHours);
				}
				else
				{
					regularHours+=workHours.time;
				}//if else
			}//foreach
			//calculate gross
			gross=(worker.baseHourRate*regularHours)+(worker.baseHourRate*extraHours*factoryData.extraHoursFactor/100);
			//calculate income tax
			double salaryLeft=gross;
			incomeTax=0;
			for(int a=factoryData.salaryStage.Count-1;a>=0;a--)
			{
				double sal=((cSalaryStage)factoryData.salaryStage[a]).salary;
				double per=((cSalaryStage)factoryData.salaryStage[a]).percent;
				if(salaryLeft>sal)
				{
					incomeTax+=(salaryLeft-sal)*per/100;
					salaryLeft=sal;
				}//if
			}//for
			//calculate social security tax
			salaryLeft=gross-incomeTax;
			socialSecurityTax=salaryLeft*factoryData.socialSecurityTax/100;
			//calculate net
			net=gross-incomeTax-socialSecurityTax;
		}//cWorkerReport()

		public cWorker worker
		{
			get
			{
				return _worker;
			}
		}//worker
	}//class cWorkerReport
}//namespace

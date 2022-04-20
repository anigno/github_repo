using System;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// Summary description for cFactoryReport.
	/// </summary>
	public class cFactoryReport:cFactoryDataManipulation
	{
		public ArrayList workerReports=new ArrayList();	//workers that worked in requested month
		public double incomeTaxTotal=0;
		public double socialInsuranceTaxTotal=0;
		public double netTotal=0;
		public double grossTotal=0;
		public double grossAverage=0;
		public int activeWorkersNum=0;					//number of active workers for requested month

		//constructor, read factory report data
		public cFactoryReport(string workingString,int year,int month):base(workingString)
		{
			cWorkerCollection workers=new cWorkerCollection(workingString);
			//add all workers that worked this month
			foreach(cWorker worker in workers.readAll())
			{
				//read worker data
				cWorkerReport workerReport=new cWorkerReport(workingString,worker.workerID,year,month);
				//check if worker did any work for requested month
				if(workerReport.gross>0)
				{
					//add worker workHours data
					workerReports.Add(workerReport);
					activeWorkersNum++;
					incomeTaxTotal+=workerReport.incomeTax;
					socialInsuranceTaxTotal+=workerReport.socialSecurityTax;
					netTotal+=workerReport.net;
					grossTotal+=workerReport.gross;
				}//if
				if(activeWorkersNum>0)
				{
					grossAverage=(grossTotal/activeWorkersNum);
				}
				else
				{
					grossAverage=0;
				}//if else
			}//foreach


		}//cFactoryReport()
	}//class cFactoryReport
}//namespace

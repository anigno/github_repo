using System;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// manage workHours collection for worker in work month
	/// </summary>
	public class cWorkHoursCollection:cWorkHoursCollectionManipulation
	{
		ArrayList workHousrCollection;
		public cWorkHoursCollection(string workingString):base(workingString)
		{
		}//cWorkHoursCollection()

		public ArrayList readAll(string workerID,int year,int month)
		{
			workHousrCollection=readWorkHoursCollection(workerID,year,month);
			return workHousrCollection;
		}//readAll
	}//class cWorkHoursCollection
}//namespace

using System;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// interface between gui elements and data manipulation for all workers
	/// </summary>
	public class cWorkerCollection : cWorkerCollectionManipulation
	{
		ArrayList workers;
		
		public cWorkerCollection(string workingString):base(workingString)
		{
		}//cWorkers

		public ArrayList readAll()
		{
			workers=readAllWorkers();
			return workers;
		}//readAllWorkers
	
	}//class cWorkerCollection
}//namespace

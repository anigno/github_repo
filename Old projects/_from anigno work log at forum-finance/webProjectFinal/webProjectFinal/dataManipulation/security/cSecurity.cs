using System;

namespace webProjectFinal
{
	/// <summary>
	/// Summary description for cSecurity.
	/// </summary>
	public class cSecurity:cSecurityManupulation
	{
		public cSecurity()
		{
		}

		public string getWorkingString(string workerID,string password)
		{
			return checkAdmin(workerID,password);
		}//check

	}//class cSecurity
}//namespace

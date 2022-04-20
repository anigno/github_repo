using System;

namespace webProjectFinal
{
	/// <summary>
	/// salary tax stage
	/// </summary>
	public class cSalaryStage
	{
		private double _salary;		//salary stage
		private double _percent;	//tax(%) for above salary

		public cSalaryStage(double salary,double percent)
		{
			_salary=salary;
			_percent=percent;
		}//cSalaryStage()

		public double salary
		{
			get
			{
				return _salary;
			}
		}//salary

		public double percent
		{
			get
			{
				return _percent;
			}
		}//percent
	}//class cSalaryStage
}//namespace

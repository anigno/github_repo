using System;
using System.Collections;

namespace webProjectFinal
{
	/// <summary>
	/// interface between gui elements and data manipulation for factory data
	/// </summary>
	public class cFactoryData:cFactoryDataManipulation
	{
		public ArrayList salaryStage=new ArrayList();
		public double baseWorkdayHours;
		public double extraHoursFactor;
		public double socialSecurityTax;

		//constructor for reading data
		public cFactoryData(string WorkingString):base(WorkingString)
		{
			readFactoryData(this);
		}//cFactoryData()

		//constructor for setting parameters
		public cFactoryData(
			string workingString,
			double FirstStagePrecents,
			double SecondStagePrecents,
			double ThirdStagePrecents,
			double AdditionalHourPrecents,
			double InsurancePrecents,
			double BaseHours,
			double LowTaxLevel,
			double MidTaxLevel,
			double HighTaxLevel):base(workingString)
		{
			//check stages
			if( (MidTaxLevel<=LowTaxLevel)||(HighTaxLevel<=MidTaxLevel) )
			{
				throw new Exception("stages are not correct!");
			}//if

			cSalaryStage s0=new cSalaryStage(LowTaxLevel,FirstStagePrecents);
			cSalaryStage s1=new cSalaryStage(MidTaxLevel,SecondStagePrecents);
			cSalaryStage s2=new cSalaryStage(HighTaxLevel,ThirdStagePrecents);
			salaryStage.Add(s0);
			salaryStage.Add(s1);
			salaryStage.Add(s2);
			baseWorkdayHours=BaseHours;
			extraHoursFactor=AdditionalHourPrecents;
			socialSecurityTax=InsurancePrecents;
		}//cFactoryData()

		//updating data
		public void update()
		{
			updateFactoryData(this);
		}//update()

	}//class cFactoryData
}//namespace

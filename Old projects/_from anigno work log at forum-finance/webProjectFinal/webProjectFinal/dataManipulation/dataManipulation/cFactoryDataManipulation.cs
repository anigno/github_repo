using System;
using System.Data;


namespace webProjectFinal
{
	/// <summary>
	/// interface between database actions and logic class requests of factory data
	/// </summary>
	abstract public class cFactoryDataManipulation
	{
		string workingString="";

		//constructor, setting parameters
		protected cFactoryDataManipulation(string workingString)
		{
			this.workingString=workingString;
		}//cFactoryDataManipulation

		protected void readFactoryData(cFactoryData fd)
		{
			//open for worker and admin
			if( (workingString==cGlobal.ADMIN_STRING)||(workingString!=""))
			{
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.FACTORY_DATA_MDB_FILE,cGlobal.FACTORY_DATA_MDB_PASSWORD);
				con.createSelect(cGlobal.FACTORY_DATA_TABLE,"*","","","");
				DataTable table=con.runSelect();
				//add salary stages
				DataRow row=table.Rows[0];
				cSalaryStage s0=new cSalaryStage(double.Parse(row["LowTaxLevel"].ToString()),double.Parse(row["FirstStagePrecents"].ToString()));
				cSalaryStage s1=new cSalaryStage(double.Parse(row["MidTaxLevel"].ToString()),double.Parse(row["SecondStagePrecents"].ToString()));
				cSalaryStage s2=new cSalaryStage(double.Parse(row["HighTaxLevel"].ToString()),double.Parse(row["ThirdStagePrecents"].ToString()));
				fd.salaryStage.Add(s0);
				fd.salaryStage.Add(s1);
				fd.salaryStage.Add(s2);
				//read other data
				fd.baseWorkdayHours=double.Parse(table.Rows[0]["BaseHours"].ToString());
				fd.extraHoursFactor=double.Parse(table.Rows[0]["AdditionalHourPrecents"].ToString());
				fd.socialSecurityTax=double.Parse(table.Rows[0]["InsurancePrecents"].ToString());
			}//if
		}//readFactoryData()

		protected void updateFactoryData(cFactoryData fd)
		{
			//open for admin only
			if(workingString==cGlobal.ADMIN_STRING)
			{
				cDatabaseConnection con=new cDatabaseConnection(cGlobal.FACTORY_DATA_MDB_FILE,cGlobal.FACTORY_DATA_MDB_PASSWORD);
				//read salary stages data
				cSalaryStage s0=(cSalaryStage)fd.salaryStage[0];
				cSalaryStage s1=(cSalaryStage)fd.salaryStage[1];
				cSalaryStage s2=(cSalaryStage)fd.salaryStage[2];
				//add data to update
				con.createUpdate(cGlobal.FACTORY_DATA_TABLE,"1=1");
				con.addToUpdate("LowTaxLevel",s0.salary);
				con.addToUpdate("MidTaxLevel",s1.salary);
				con.addToUpdate("HighTaxLevel",s2.salary);
				con.addToUpdate("FirstStagePrecents",s0.percent);
				con.addToUpdate("SecondStagePrecents",s1.percent);
				con.addToUpdate("ThirdStagePrecents",s2.percent);
				con.addToUpdate("BaseHours",fd.baseWorkdayHours);
				con.addToUpdate("AdditionalHourPrecents",fd.extraHoursFactor);
				con.addToUpdate("InsurancePrecents",fd.socialSecurityTax);
				con.runUpdate();
			}//if
		}//updateFactoryData()

	}//class cFactoryDataManipulation
}//namespace

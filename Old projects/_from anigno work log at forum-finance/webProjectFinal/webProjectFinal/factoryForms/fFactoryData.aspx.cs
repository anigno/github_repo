using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace webProjectFinal
{
	/// <summary>
	/// Summary description for fFactoryData.
	/// </summary>
	public class fFactoryData : System.Web.UI.Page
	{
		#region controls
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtBaseWorkdayHours;
		protected System.Web.UI.WebControls.TextBox txtSocialSecurityTax;
		protected System.Web.UI.WebControls.TextBox txtExtraTimeFactor;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtStage0;
		protected System.Web.UI.WebControls.TextBox txtStage1;
		protected System.Web.UI.WebControls.TextBox txtStage2;
		protected System.Web.UI.WebControls.TextBox txtTax0;
		protected System.Web.UI.WebControls.TextBox txtTax1;
		protected System.Web.UI.WebControls.TextBox txtTax2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox TextBox10;
		protected System.Web.UI.WebControls.TextBox TextBox8;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator9;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator10;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator11;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator4;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator5;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator6;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator7;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator8;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator9;
		protected System.Web.UI.WebControls.Label lblStages;
		protected System.Web.UI.WebControls.Button btnUpdate;
#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				string workingString=""+Session["workingString"].ToString();
				cFactoryData factoryData=new cFactoryData(workingString);
				txtStage0.Text=((cSalaryStage)factoryData.salaryStage[0]).salary.ToString();
				txtTax0.Text=((cSalaryStage)factoryData.salaryStage[0]).percent.ToString();
				txtStage1.Text=((cSalaryStage)factoryData.salaryStage[1]).salary.ToString();
				txtTax1.Text=((cSalaryStage)factoryData.salaryStage[1]).percent.ToString();
				txtStage2.Text=((cSalaryStage)factoryData.salaryStage[2]).salary.ToString();
				txtTax2.Text=((cSalaryStage)factoryData.salaryStage[2]).percent.ToString();
				txtBaseWorkdayHours.Text=factoryData.baseWorkdayHours.ToString();
				txtExtraTimeFactor.Text=factoryData.extraHoursFactor.ToString();
				txtSocialSecurityTax.Text=factoryData.socialSecurityTax.ToString();
			}//if
		}//Page_Load()

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string workingString=Session["workingString"].ToString();
			lblStages.Visible=false;
			try
			{
				cFactoryData fd=new cFactoryData(
					workingString,
					int.Parse(txtTax0.Text),
					int.Parse(txtTax1.Text),
					int.Parse(txtTax2.Text),
					int.Parse(txtExtraTimeFactor.Text),
					int.Parse(txtSocialSecurityTax.Text),
					int.Parse(txtBaseWorkdayHours.Text),
					int.Parse(txtStage0.Text),
					int.Parse(txtStage1.Text),
					int.Parse(txtStage2.Text));
				fd.update();
			}
			catch(Exception exception)
			{
				System.Console.WriteLine(exception.Message);
				lblStages.Visible=true;	//stages not the correct value order
			}//catch
		}//btnUpdate_Click()


	}//class fFactoryData
}//namespace

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

namespace webProjectFinal.reports
{
	/// <summary>
	/// Summary description for fWorkerReport.
	/// </summary>
	public class fWorkerReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.ListBox lstWorkerID;
		protected System.Web.UI.WebControls.ListBox lstReport;
		protected System.Web.UI.WebControls.DropDownList drpYear;
		protected System.Web.UI.WebControls.DropDownList drpMonth;
		protected System.Web.UI.WebControls.Button btnCreate;
		protected System.Web.UI.WebControls.Label lblWorkerID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label Label3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				HttpCookie userCookie=Request.Cookies.Get("userCookie");
				lblWorkerID.Text=userCookie.Value;
				string workingString=Session["workingString"].ToString();
				//read all workers
				cWorkerCollection workers=new cWorkerCollection(workingString);
				ArrayList workersList=workers.readAll();
				//add all workers ID to lstWorkerID
				foreach(cWorker worker in workersList)
				{
					lstWorkerID.Items.Add(worker.workerID);
				}//foreach
				//reset month and year DropDownList
				for(int year=DateTime.Now.Year;year>=DateTime.Now.Year-20;year--)
				{
					drpYear.Items.Add(year.ToString());
				}//for
				for(int month=1;month<=12;month++)
				{
					drpMonth.Items.Add(month.ToString());
				}//for
				if(lstWorkerID.Items.Count>0)lstWorkerID.SelectedIndex=0;
			}//if
		}//page_load()

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
			this.lstWorkerID.SelectedIndexChanged += new System.EventHandler(this.lstWorkerID_SelectedIndexChanged);
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			if(lstWorkerID.SelectedIndex>=0)
			{
				try
				{
					string workingString=Session["workingString"].ToString();
					//get parameters to perform query
					string id=lstWorkerID.Items[lstWorkerID.SelectedIndex].ToString();
					int year=int.Parse(drpYear.Items[drpYear.SelectedIndex].ToString());
					int month=int.Parse(drpMonth.Items[drpMonth.SelectedIndex].ToString());
					//perform query
					cWorkerReport report=new cWorkerReport(workingString,id,year,month);
					//add selected worker workHours to lstReports
					lstReport.Items.Clear();
					foreach(cWorkHours workHours in report.workHoursCollection)
					{
						lstReport.Items.Add(workHours.date.ToShortDateString()+" "+workHours.time.ToString("f2"));
					}//foreach
					cWorker worker=new cWorker(workingString,id);
					lstReport.Items.Insert(0,"ID: "+id);
					lstReport.Items.Insert(1,"First name:      "+worker.firstName);
					lstReport.Items.Insert(2,"Last name:       "+worker.lastName);
					lstReport.Items.Insert(3,"Base hour rate:  "+worker.baseHourRate.ToString("f2"));
					lstReport.Items.Insert(4,"Regular hours:   "+report.regularHours.ToString("f2"));
					lstReport.Items.Insert(5,"Extra hours:     "+report.extraHours.ToString("f2"));
					lstReport.Items.Insert(6,"Gross salary:    "+report.gross.ToString("f2"));
					lstReport.Items.Insert(7,"Income Tax:      "+report.incomeTax.ToString("f2"));
					lstReport.Items.Insert(8,"Social security: "+report.socialSecurityTax.ToString("f2"));
					lstReport.Items.Insert(9,"Net salary:      "+report.net.ToString("f2"));
					lstReport.Items.Insert(10,"---------------------------------------");
					lstReport.Items.Insert(11,"----Work dates and hours----");
				}
				catch(Exception exception)
				{
					System.Console.WriteLine(exception.Message);
				}//catch
			}//if		
		}

		private void lstWorkerID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}//btnCreate_Click()
	}//class fWorkerReport
}//namespace

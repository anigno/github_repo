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
	/// Summary description for fFactoryReport.
	/// </summary>
	public class fFactoryReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList drpMonth;
		protected System.Web.UI.WebControls.DropDownList drpYear;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.ListBox lstGeneralData;
		protected System.Web.UI.WebControls.Button btnCreate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//reset month and year DropDownList
				for(int year=DateTime.Now.Year;year>=DateTime.Now.Year-20;year--)
				{
					drpYear.Items.Add(year.ToString());
				}//for
				for(int month=1;month<=12;month++)
				{
					drpMonth.Items.Add(month.ToString());
				}//for
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_pageChanged);
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_pageChanged(object sender,System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//read factory data and create the table
			string workingString=Session["workingString"].ToString();
			//create the factory report
			int year=int.Parse(drpYear.Items[drpYear.SelectedIndex].ToString());
			int month=int.Parse(drpMonth.Items[drpMonth.SelectedIndex].ToString());
			cFactoryReport factoryReport=new cFactoryReport(workingString,year,month);
			DataTable table=createTable(factoryReport);
			// Set CurrentPageIndex to the page the user clicked.
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			//rebind the data source
			DataGrid1.DataSource=table;
			DataGrid1.DataBind();
		}
		
		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			try
			{
				string workingString=Session["workingString"].ToString();
				//create the factory report
				int year=int.Parse(drpYear.Items[drpYear.SelectedIndex].ToString());
				int month=int.Parse(drpMonth.Items[drpMonth.SelectedIndex].ToString());
				cFactoryReport factoryReport=new cFactoryReport(workingString,year,month);
				//add general sum data to lstGeneralData
				lstGeneralData.Items.Clear();
				lstGeneralData.Items.Add("Total income tax: "+factoryReport.incomeTaxTotal.ToString("f2"));
				lstGeneralData.Items.Add("Total social security: "+factoryReport.socialInsuranceTaxTotal.ToString("f2"));
				lstGeneralData.Items.Add("Total net: "+factoryReport.netTotal.ToString("f2"));
				lstGeneralData.Items.Add("Total gross: "+factoryReport.grossTotal.ToString("f2"));
				lstGeneralData.Items.Add("Gross average: "+factoryReport.grossAverage.ToString("f2"));
				//prepere table
				DataTable table=createTable(factoryReport);
				DataGrid1.DataSource=table;
				DataGrid1.DataBind();
			}
			catch(Exception exception)
			{
				System.Console.WriteLine(exception.Message);
			}//catch
		}//btnCreate_Click()

		DataTable createTable(cFactoryReport factoryReport)
		{
			//build DataTable for workers data display
			DataTable table=new DataTable("tblWorkersReports");
			DataColumn myDataColumn=new DataColumn("firstName");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("lastName");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("workerID");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("hours");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("gross");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("incomeTax");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("insurance");
			table.Columns.Add(myDataColumn);
			myDataColumn=new DataColumn("net");
			table.Columns.Add(myDataColumn);
			//fill table with worker data
			foreach(cWorkerReport workerReport in factoryReport.workerReports)
			{
				DataRow row=table.NewRow();
				row["firstName"]=workerReport.worker.firstName.ToString();
				row["lastName"]=workerReport.worker.lastName.ToString();
				row["workerID"]=workerReport.worker.workerID.ToString();
				row["hours"]=((workerReport.regularHours+workerReport.extraHours).ToString("f2"));
				row["gross"]=workerReport.gross.ToString("f2");
				row["incomeTax"]=workerReport.incomeTax.ToString("f2");
				row["insurance"]=workerReport.socialSecurityTax.ToString("f2");
				row["net"]=workerReport.net.ToString("f2");
				table.Rows.Add(row);
			}//foreach
			//add summery of data
			DataRow row1=table.NewRow();
			table.Rows.Add(row1);
			row1=table.NewRow();
			row1["gross"]=factoryReport.grossTotal.ToString("f2");
			row1["incomeTax"]=factoryReport.incomeTaxTotal.ToString("f2");
			row1["insurance"]=factoryReport.socialInsuranceTaxTotal.ToString("f2");
			row1["net"]=factoryReport.netTotal.ToString("f2");
			row1["workerID"]="Total:";
			table.Rows.Add(row1);
			row1=table.NewRow();
			row1["gross"]=factoryReport.grossAverage.ToString("f2");
			row1["workerID"]="Average:";
			table.Rows.Add(row1);
			return table;
		}


	}//class fFactoryReport
}//namespace

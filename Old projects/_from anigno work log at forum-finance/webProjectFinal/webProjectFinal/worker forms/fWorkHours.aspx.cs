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

namespace webProjectFinal.worker_forms
{
	/// <summary>
	/// Summary description for fWorkHours.
	/// </summary>
	public class fWorkHours : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtID;
		protected System.Web.UI.WebControls.TextBox txtWorkHours;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Button btnAddUpdate;
		protected System.Web.UI.WebControls.Button btnDate;
		protected System.Web.UI.WebControls.ListBox lstIds;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label lblUpdate;
		protected System.Web.UI.WebControls.Calendar Calendar1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				string workingString=Session["workingString"].ToString();
				//read all workers ID, add them to lstIds
				cWorkerCollection wcm=new cWorkerCollection(workingString);
				ArrayList workers=wcm.readAll();
				foreach(cWorker worker in workers)
				{
					lstIds.Items.Add(worker.workerID);
				}//foreach
				Calendar1.SelectedDate=DateTime.Now;
				btnDate.Text=Calendar1.SelectedDate.ToShortDateString();
				//select first in ID list
				if(lstIds.Items.Count>0)
				{
					lstIds.SelectedIndex=0;
					lstIds_SelectedIndexChanged(sender,e);
				}//if
			}//if
		}//Page_Load

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
			this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
			this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
			this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
			this.lstIds.SelectedIndexChanged += new System.EventHandler(this.lstIds_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstIds_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string workingString=Session["workingString"].ToString();
			string id;
			string date;
			//update data in form controls, fro selected workerID
			if(lstIds.SelectedIndex>-1)
			{
				int i=lstIds.SelectedIndex;
				id=lstIds.Items[i].ToString();
				date=btnDate.Text;
				txtID.Text=id;
				txtWorkHours.Text="";
				try
				{
					//try to read workHours data by ID and date
					DateTime d=DateTime.Parse(date);
					cWorkHours workHours=new cWorkHours(workingString,id,d);
					txtWorkHours.Text=workHours.time.ToString();
					//workHours exist, will update if needed
					lblUpdate.Visible=true;
				}
				catch(Exception exception)
				{
					//workHours not exist, will add if needed
					lblUpdate.Visible=false;
					txtWorkHours.Text="";
					System.Console.WriteLine(exception.Message);
				}//catch
			}//if
		}//lstIds_SelectedIndexChanged

		private void btnDate_Click(object sender, System.EventArgs e)
		{
			if(Calendar1.Visible==false)
			{
				Calendar1.Visible=true;
			}
			else
			{
				Calendar1.Visible=false;
			}//if else
		}//btnDate_Click()

		private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
		{
			btnDate.Text=Calendar1.SelectedDate.ToShortDateString();
			Calendar1.Visible=false;
			lstIds_SelectedIndexChanged(sender,e);
		}//Calendar1_SelectionChanged()

		private void btnAddUpdate_Click(object sender, System.EventArgs e)
		{
			string workingString=Session["workingString"].ToString();
			try
			{
//				cWorkHours workHours=new cWorkHours(workingString,txtID.Text,DateTime.Parse(btnDate.Text),Double.Parse(txtWorkHours.Text));
				cWorkHours workHours=new cWorkHours(workingString,txtID.Text,Calendar1.SelectedDate,Double.Parse(txtWorkHours.Text));
				if(lblUpdate.Visible==false)
				{
					workHours.add();
					lblUpdate.Visible=true;				
				}
				else
				{
					workHours.update();
				}//if else
			}
			catch(Exception exception)
			{
				//no correct string format
				System.Console.WriteLine(exception.Message);
			}//catch
		}//btnAddUpdate_Click()
	}//class fWorkHours
}//namespace
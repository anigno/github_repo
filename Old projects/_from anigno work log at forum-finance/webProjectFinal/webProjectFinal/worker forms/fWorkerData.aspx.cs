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
	/// Summary description for fWorkerData.
	/// </summary>
	public class fWorkerData : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtFirstName;
		protected System.Web.UI.WebControls.TextBox txtLastName;
		protected System.Web.UI.WebControls.TextBox txtBaseHourRate;
		protected System.Web.UI.WebControls.TextBox txtID;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.ListBox lstWorkerID;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.Button btnUpdate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				fillLstWorkerID();
			}//if
		}//Page_Load()

		private void fillLstWorkerID()
		{
			string workingString=Session["workingString"].ToString();
			//fill lstWorkerID with all workers ID
			cWorkerCollection w=new cWorkerCollection(workingString);
			ArrayList workers=w.readAll();
			lstWorkerID.Items.Clear();
			foreach(cWorker worker in workers)
			{
				lstWorkerID.Items.Add(worker.workerID);
			}//foreach
		}//fillLstWorkerID()

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
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.lstWorkerID.SelectedIndexChanged += new System.EventHandler(this.lstWorkerID_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstWorkerID_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string workingString=Session["workingString"].ToString();
			int i=lstWorkerID.SelectedIndex;
			string id=lstWorkerID.Items[i].ToString();
			//get worker data by id
			try
			{
				cWorker worker=new cWorker(workingString,id);
				//fill TextBox(s) with worker data
				txtFirstName.Text=worker.firstName;
				txtLastName.Text=worker.lastName;
				txtBaseHourRate.Text=worker.baseHourRate.ToString();
				txtID.Text=worker.workerID;
			}
			catch(Exception exception)
			{
				//input string not valid or worker not exist
				System.Console.WriteLine(exception.Message);
			}//catch
		}//lstWorkerID_SelectedIndexChanged

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string workingString=Session["workingString"].ToString();
			try
			{
				cWorker w=new cWorker(workingString,txtFirstName.Text,txtLastName.Text,Double.Parse(txtBaseHourRate.Text),txtID.Text);
				w.update();
			}
			catch(Exception exception)
			{
				//input string not valid or worker not exist
				System.Console.WriteLine(exception.Message);
			}//catch
		}//btnUpdate_Click

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			string workingString=Session["workingString"].ToString();
			try
			{
				cWorker w=new cWorker(workingString,txtID.Text);
				w.delete();
				fillLstWorkerID();
				txtFirstName.Text="";
				txtLastName.Text="";
				txtBaseHourRate.Text="";
				txtID.Text="";
			}
			catch(Exception exception)
			{
				//no worker selected
				System.Console.WriteLine(exception.Message);
			}//catch
		}//btnDelete_Click


	}//class fWorkerData
}//namespace

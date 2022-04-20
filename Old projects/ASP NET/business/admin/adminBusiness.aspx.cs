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
using anignoLibrary.ClassLibraryMdbConnection;
using System.IO;

namespace business.admin
{
	public class adminBusiness : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,"");
		string lastMessage="";

		protected System.Web.UI.WebControls.ListBox lstBusinesses;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button ntnNewBusiness;
		protected System.Web.UI.WebControls.Panel pnlAddNewBusiness;
		protected System.Web.UI.WebControls.Button btnAddNewBusiness;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnRemoveBusiness;
		protected System.Web.UI.WebControls.Button btnConfirmRemoveBusiness;
		protected System.Web.UI.WebControls.Button btnCancelRemoveBusiness;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel pnlRemoveBusiness;
		protected System.Web.UI.WebControls.Button btnEditBusiness;
		protected System.Web.UI.WebControls.TextBox txtWebName;
		protected System.Web.UI.WebControls.Label Label1;
	
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
			this.btnRemoveBusiness.Click += new System.EventHandler(this.btnRemoveBusiness_Click);
			this.btnAddNewBusiness.Click += new System.EventHandler(this.btnAddNewBusiness_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.ntnNewBusiness.Click += new System.EventHandler(this.ntnNewBusiness_Click);
			this.lstBusinesses.SelectedIndexChanged += new System.EventHandler(this.lstBusinesses_SelectedIndexChanged);
			this.btnConfirmRemoveBusiness.Click += new System.EventHandler(this.btnConfirmRemoveBusiness_Click);
			this.btnCancelRemoveBusiness.Click += new System.EventHandler(this.btnCancelRemoveBusiness_Click);
			this.btnEditBusiness.Click += new System.EventHandler(this.btnEditBusiness_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//----------------------------------------------------------------------------------
		private void cancelAction()
		{
			pnlAddNewBusiness.Visible=false;
			pnlRemoveBusiness.Visible=false;
		}//cancelAction()

		private void reloadPage(string message)
		{
			Response.Redirect("adminBusiness.aspx?message="+message);
		}//reloadPage()
//----------------------------------------------------------------------------------
		private void Page_Load(object sender, System.EventArgs e)
		{
			lastMessage=Request.QueryString.Get("message");	//null if no message!
			lblMessage.Text=lastMessage;
			if(!IsPostBack)
			{
				conn.createSelect("tblBusinesses","*","","fldWebName","");
				DataTable table=conn.runSelect();
				lstBusinesses.DataSource=table;
				lstBusinesses.DataTextField="fldWebName";
				lstBusinesses.DataValueField="fldKey";
				lstBusinesses.DataBind();
			}//if
		}//Page_Load()

		private void ntnNewBusiness_Click(object sender, System.EventArgs e)
		{
			cancelAction();
			pnlAddNewBusiness.Visible=true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			cancelAction();
		}

		private void btnAddNewBusiness_Click(object sender, System.EventArgs e)
		{
			//check if the webName is free
			conn.createSelect("tblBusinesses","*","fldWebName='"+txtWebName.Text+"'","","");
			DataTable table=conn.runSelect();
			if(table.Rows.Count==0)
			{
				//create unique key
				string key=DateTime.Now.Ticks.ToString();
				conn.createInsert("tblBusinesses");
				conn.addToInsert("fldWebName",txtWebName.Text);
				conn.addToInsert("fldKey",key);
				conn.runInsert();
				//create folder and default.htm for the business
				Directory.CreateDirectory(Global.serverPath+txtWebName.Text);
				TextWriter tw = new StreamWriter(Global.serverPath+txtWebName.Text+@"\default.htm");
				string fileText="";
				fileText+=@"<html><head><title>Business</title></head><frameset rows=80,*>";
				fileText+=@"<frame src=..\visitors\header.aspx?key="+key+">";
				fileText+=@"<frameset cols=180,*>";
				fileText+=@"<frame target=frameMain src=..\visitors\content.aspx?key="+key+">";
				fileText+=@"<frame name=frameMain id=frameMain src=..\visitors\main.aspx?key="+key+">";
				fileText+=@"</frameset></frameset></html>";
				tw.WriteLine(fileText);
				tw.Close();
				reloadPage("Added: "+txtWebName.Text);
			}
			else
			{
				//webName exist
				reloadPage("webName already exist!");
			}//if else
		}

		private void btnConfirmRemoveBusiness_Click(object sender, System.EventArgs e)
		{
			//set site to disable or remove files and records
			if(lstBusinesses.SelectedIndex>=0)
			{
				conn.createDelete("tblBusinesses","fldKey='"+lstBusinesses.SelectedValue.ToString()+"'");
				conn.runDelete();
				pnlRemoveBusiness.Visible=false;
				reloadPage("Deleted: "+lstBusinesses.SelectedItem.Text);
			}
			else
			{
				reloadPage("Select business to remove!");
			}//if else
		}

		private void btnCancelRemoveBusiness_Click(object sender, System.EventArgs e)
		{
			cancelAction();
		}

		private void btnRemoveBusiness_Click(object sender, System.EventArgs e)
		{
			cancelAction();
			pnlRemoveBusiness.Visible=true;
		}

		private void btnEditBusiness_Click(object sender, System.EventArgs e)
		{
			cancelAction();
			if(lstBusinesses.SelectedIndex<0)
			{
				reloadPage("Select business to edit!");
			}
			else
			{
				Session["businessKey"]=lstBusinesses.SelectedValue.ToString();
				Response.Redirect("adminEditBusiness.aspx");
			}//if else
		}

		private void lstBusinesses_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cancelAction();
		}

	}//class
}//namespace

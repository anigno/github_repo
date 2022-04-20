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

namespace webName.admin
{
	public class webName : basePage
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
		public string editWebName="";


		protected System.Web.UI.WebControls.ListBox lstWebName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Panel pnlAddNew;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnAddCancel;
		protected System.Web.UI.WebControls.Button btnDummie;
		protected System.Web.UI.WebControls.TextBox txtAddNew;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnRemoveYes;
		protected System.Web.UI.WebControls.Button btnRemoveNo;
		protected System.Web.UI.WebControls.Panel pnlRemove;
		protected System.Web.UI.WebControls.Button btnCreate;
		protected System.Web.UI.WebControls.Button btnEdit;

		private void panelOff()
		{
			pnlAddNew.Visible=false;
			pnlRemove.Visible=false;
		}//panelOff()
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			PageUrl="webName.aspx";
			lblMessage.Text=getReloadMessage();
			panelOff();
			if(!IsPostBack)
			{
				conn.createSelect("tblMain","*","","","");
				DataTable table=conn.runSelect();
				lstWebName.DataSource=table;
				lstWebName.DataTextField="fldWebName";
				lstWebName.DataValueField="fldWebName";
				lstWebName.DataBind();
			}//if
		}

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
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnRemoveYes.Click += new System.EventHandler(this.btnRemoveYes_Click);
			this.btnRemoveNo.Click += new System.EventHandler(this.btnRemoveNo_Click);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.lstWebName.SelectedIndexChanged += new System.EventHandler(this.lstWebName_SelectedIndexChanged);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			pnlAddNew.Visible=true;
		}

		private void btnAddCancel_Click(object sender, System.EventArgs e)
		{
		}

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			string retMessage="";
			conn.createInsert("tblMain");
			conn.addToInsert("fldWebName",txtAddNew.Text);
			try
			{
				conn.runInsert();
				retMessage="WebName: "+txtAddNew.Text+" added!";
			}
			catch
			{
				retMessage="Error!, "+txtAddNew.Text+" maybe duplicate webName?";
				pnlAddNew.Visible=true;
			}
			finally
			{
				reloadPage(retMessage);
			}//finally
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(lstWebName.SelectedIndex>=0)
			{
				pnlRemove.Visible=true;
			}
			else
			{
				lblMessage.Text="Select webName to remove!";
			}//if else
		}

		private void btnRemoveNo_Click(object sender, System.EventArgs e)
		{
			panelOff();
		}

		private void btnRemoveYes_Click(object sender, System.EventArgs e)
		{
			conn.createDelete("tblMain","fldWebName='"+lstWebName.SelectedValue+"'");
			conn.runDelete();
			reloadPage("WebName: "+lstWebName.SelectedItem.Text+" removed!");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if(lstWebName.SelectedIndex>=0)
			{
				Response.Redirect("editWebName.aspx");
			}
			else
			{
				lblMessage.Text="Select webName to edit!";
			}//if else
		}

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			if(lstWebName.SelectedIndex>-1)
			{
				Response.Redirect("createWebSite.aspx");
			}
			else
			{
				lblMessage.Text="Select webName to create!";
			}//if else
		}

		private void lstWebName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["webName"]=lstWebName.SelectedValue;
		}
	}//class
}//namespace

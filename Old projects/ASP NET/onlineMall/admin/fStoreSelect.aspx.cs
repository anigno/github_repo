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
using anignoLibrary.utils;

namespace onlineMall.admin
{
	public class fStoreSelect : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.storeDataMdb,Global.ADMIN_PASSWORD);

		protected System.Web.UI.WebControls.ListBox lstStores;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Panel panelAddNew;
		protected System.Web.UI.WebControls.Button btnAddNewOk;
		protected System.Web.UI.WebControls.Button btnAddNewCancel;
		protected System.Web.UI.WebControls.TextBox txtNewWebName;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.Button btnCreateSimpleWeb;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void updateStoreList()
		{
			conn.createSelect("tblStoreData","*","","","");
			DataTable table=conn.runSelect();
			lstStores.DataSource=table;
			lstStores.DataTextField="fldWebName";
			lstStores.DataValueField="fldKey";
			lstStores.DataBind();
		}//updateStoreList()
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				updateStoreList();
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
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.lstStores.SelectedIndexChanged += new System.EventHandler(this.lstStores_SelectedIndexChanged);
			this.btnAddNewOk.Click += new System.EventHandler(this.btnAddNewOk_Click);
			this.btnAddNewCancel.Click += new System.EventHandler(this.btnAddNewCancel_Click);
			this.btnCreateSimpleWeb.Click += new System.EventHandler(this.btnCreateSimpleWeb_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=true;
		}

		private void btnAddNewOk_Click(object sender, System.EventArgs e)
		{
			conn.createInsert("tblStoreData");
			conn.addToInsert("fldWebName",txtNewWebName.Text);
			conn.runInsert();
			updateStoreList();
			panelAddNew.Visible=false;
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=false;
			if(lstStores.SelectedIndex>-1)
			{
				Response.Redirect("fStoreData.aspx");
			}//if
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=false;
		}

		private void btnAddNewCancel_Click(object sender, System.EventArgs e)
		{
			panelAddNew.Visible=false;
		}

		private void lstStores_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["currentStoreKey"]=lstStores.SelectedValue;
		}

		private void btnCreateSimpleWeb_Click(object sender, System.EventArgs e)
		{
			if(lstStores.SelectedIndex>-1)
			{
				new cSimpleWeb(lstStores.SelectedValue);
			}//if
		}

	}//class
}//namespace

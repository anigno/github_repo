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

namespace webName.admin
{
	public class editSubjects : basePage
	{
		string webName="";
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
		public string subjectKey="";
		
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.Label lblWebName;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtNewSubject;
		protected System.Web.UI.WebControls.Button btnAddNewSubject;
		protected System.Web.UI.WebControls.Button btnCancelAddNewSubject;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Panel panelAddNew;
		protected System.Web.UI.WebControls.Button btnRemove;
		protected System.Web.UI.WebControls.Button btnRemoveYes;
		protected System.Web.UI.WebControls.Button btnRemoveNo;
		protected System.Web.UI.WebControls.Panel pnlRemove;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Button btnDummie;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;

		private void panelOff()
		{
			panelAddNew.Visible=false;
			pnlRemove.Visible=false;
		}//panelOff()

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			webName=Session["webName"].ToString();
			PageUrl="editSubjects.aspx";
			lblMessage.Text=getReloadMessage();
			lblWebName.Text=webName;
			if(!IsPostBack)
			{
				panelOff();
				//read subjects
				conn.createSelect("tblSubjects","*","fldWebName='"+webName+"'","","");
				DataTable table=conn.runSelect();
				lstSubjects.DataSource=table;
				lstSubjects.DataTextField="fldName";
				lstSubjects.DataValueField="fldKey";
				lstSubjects.DataBind();
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
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnAddNewSubject.Click += new System.EventHandler(this.btnAddNewSubject_Click);
			this.btnCancelAddNewSubject.Click += new System.EventHandler(this.btnCancelAddNewSubject_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnRemoveYes.Click += new System.EventHandler(this.btnRemoveYes_Click);
			this.btnRemoveNo.Click += new System.EventHandler(this.btnRemoveNo_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//read products for subject
			conn.createSelect("tblProducts","*","","","");
			DataTable table=conn.runSelect();


		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			panelOff();
			panelAddNew.Visible=true;
		}

		private void btnCancelAddNewSubject_Click(object sender, System.EventArgs e)
		{
			panelOff();
		}

		private void btnAddNewSubject_Click(object sender, System.EventArgs e)
		{
			conn.createInsert("tblSubjects");
			conn.addToInsert("fldName",txtNewSubject.Text);
			conn.addToInsert("fldWebName",webName);
			conn.runInsert();
			reloadPage("Subject added!");
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(lstSubjects.SelectedIndex>-1)
			{
				panelOff();
				pnlRemove.Visible=true;
			}
			else
			{
				lblMessage.Text="Select subject to remove!";
			}//if else
		}

		private void btnRemoveNo_Click(object sender, System.EventArgs e)
		{
			panelOff();
		}

		private void btnRemoveYes_Click(object sender, System.EventArgs e)
		{
			conn.createDelete("tblSubjects","fldKey="+lstSubjects.SelectedValue);
			conn.runDelete();
			reloadPage("Subject removed!");
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("editWebName.aspx");
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			if(lstSubjects.SelectedIndex>-1)
			{
				Session["subjectKey"]=lstSubjects.SelectedValue;
				Response.Redirect("editOneSubject.aspx");
			}
			else
			{
				lblMessage.Text="Select subject to edit!";
			}//if else
		}
	}//class
}//namespace

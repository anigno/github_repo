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

namespace nifgashim30.main
{
	/// <summary>
	/// Summary description for fMain.
	/// </summary>
	public class fMain : System.Web.UI.Page
	{
		cDatabaseConnection conRegisteredUsers=new cDatabaseConnection(Global.registeredUsersMdbFilePath,"");
		
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.Button btnLogin;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnExit;
		protected System.Web.UI.WebControls.Panel pnlLogin;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnNewUser;
		protected System.Web.UI.WebControls.Button btnEditPictures;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//check username session and show login panel if needed
			if(Session["username"]==null)
			{
				Session["username"]="noUser";
				Session.Timeout=60;
			}//if
			if(Session["username"].ToString()=="noUser")
			{
				//no user loged yet
				pnlLogin.Visible=true;
			}
			else
			{
				//user is loged in
				pnlLogin.Visible=false;
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
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			this.btnEditPictures.Click += new System.EventHandler(this.btnEditPictures_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			conRegisteredUsers.createSelect("tblRegisteredUsers","*","fldUsername='"+txtUserName.Text+"' AND fldPassword='"+txtPassword.Text+"'","","");
			DataTable result=conRegisteredUsers.runSelect();
			if(result.Rows.Count>0)
			{
				//login success
				Session["username"]=result.Rows[0]["fldUsername"].ToString();
				pnlLogin.Visible=false;
				lblMessage.Visible=false;
			}
			else
			{
				//login fail
				Session["username"]="noUser";
				pnlLogin.Visible=true;
				lblMessage.Text="טעות בהקלדת הסיסמה או שם משתמש לא קיים";
				lblMessage.Visible=true;
			}//if else
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Session["username"]="noUser";
			pnlLogin.Visible=true;
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			Session["registrationAction"]="edit";
			Response.Redirect("../registration/fRegistration.aspx");
		}

		private void btnNewUser_Click(object sender, System.EventArgs e)
		{
			Session["registrationAction"]="newUser";
			Response.Redirect("../registration/fRegistration.aspx");
		}

		private void btnEditPictures_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../registration/fAddPictures.aspx");
		}

	}//class
}//namespace

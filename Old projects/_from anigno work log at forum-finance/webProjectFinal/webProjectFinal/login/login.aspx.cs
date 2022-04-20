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
	/// Summary description for _default.
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtWorkerID;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.Button btnLogIn;
		protected System.Web.UI.WebControls.Label lblLoginAllow;
		protected System.Web.UI.WebControls.Label lblCounter;
		protected System.Web.UI.WebControls.Label Label3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//security session parameter
			Session["workingString"]="";
//Response.Cookies.Clear();
			if(!IsPostBack)
			{
				//last user, using cookie[]
				HttpCookie userCookie=Request.Cookies.Get("userCookie");
				if(userCookie!=null)
				{
					txtWorkerID.Text=userCookie.Value.ToString();
				}
				else
				{
					//create the cookie
					userCookie=new HttpCookie("userCookie","");
					userCookie.Expires=DateTime.MaxValue;
					Response.Cookies.Add(userCookie);
				}//if else

				//users counter, using Cache[]
				if(Cache["counter"]==null)Cache["counter"]="0";
				int a=int.Parse(Cache["counter"].ToString());
				a++;
				Cache["counter"]=a;
				lblCounter.Text=a.ToString();

				//check if site is already up from this computer
				if(Session["user"]==null)
				{
					Session["user"]="user";
					lblLoginAllow.Visible=false;

				}
				else
				{
					if(Session["user"].ToString()=="user")lblLoginAllow.Visible=true;
					Session["user"]="user";
				}//if else
			}
			else
			{

			}//if else
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
			this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnLogIn_Click(object sender, System.EventArgs e)
		{
			string redirectPath="";
			if(lblLoginAllow.Visible==false)
			{
				try
				{
					//check user security
					cSecurity security=new cSecurity();
					string workingString=security.getWorkingString(txtWorkerID.Text,txtPassword.Text);
					if(workingString==cGlobal.ADMIN_STRING)
					{
						Session["workingString"]=workingString;
						redirectPath="../header.htm";
					}//if
					if(workingString==txtWorkerID.Text)
					{
						Session["workingString"]=workingString;
						redirectPath="../headerWorker.htm";
					}//if
					//change cookie for user (not admin)
					HttpCookie userCookie=new HttpCookie("userCookie",txtWorkerID.Text);
					userCookie.Expires=DateTime.MaxValue;
					Response.Cookies.Add(userCookie);
				}
				catch(Exception exception)
				{
					System.Console.WriteLine(exception.Message);
				}//catch
			}//if
			if(redirectPath!="")Response.Redirect(redirectPath);
		}//btnLogIn_Click()
	}//class login
}//namespace

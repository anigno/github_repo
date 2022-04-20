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

namespace pinukitafNet
{
	/// <summary>
	/// Summary description for setAdmin.
	/// </summary>
	public class setAdmin : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(TextBox1.Text=="8702661")
			{
				Session["admin"]="yes";
				//remove userCookie for admin
				cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);
				HttpCookie userCookie=Request.Cookies.Get(cGeneralData.USER_COOKIE);
				myData.createDeleteCommand("tblIps","iCookieValue='"+userCookie.Value.ToString()+"'");
				myData.commandExecute(myData.deleteCommand.getSql());
			}
			else
			{
				Session["admin"]="";
			}//if else
			Response.Redirect("../main.aspx");
		}//private void Button1_Click(object sender, System.EventArgs e)

		private void TextBox1_TextChanged(object sender, System.EventArgs e)
		{
			Button1_Click(sender,e);
		}//private void TextBox1_TextChanged(object sender, System.EventArgs e)
	}//public class setAdmin : System.Web.UI.Page
}//namespace pinukitafNet

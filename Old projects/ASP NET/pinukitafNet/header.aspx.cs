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
	/// Summary description for header.
	/// </summary>
	public class header : System.Web.UI.Page
	{
		cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			getIp();
		}//private void Page_Load(object sender, System.EventArgs e)

		private void getIp()
		{
			HttpCookie userCookie;
			myData.createInsertCommand("tblIps");
			//get client ip
			String ip=Request.ServerVariables["REMOTE_ADDR"].ToString();
			//check cookie exist, if not create new one , value = Now
			userCookie=Request.Cookies.Get(cGeneralData.USER_COOKIE);
			if(userCookie==null)
			{
				userCookie=new HttpCookie(cGeneralData.USER_COOKIE);
				userCookie.Value=DateTime.Now.Ticks.ToString();
				userCookie.Expires=DateTime.Now.AddHours(24*365);
                Response.Cookies.Add(userCookie);
			}//if
			//add data do DB
			myData.insertCommand.add("iIp",ip);
			myData.insertCommand.add("iDate",cGeneralData.dateToString(DateTime.Now));
			myData.insertCommand.add("iTime",cGeneralData.timeToString(DateTime.Now));
			myData.insertCommand.add("iCookieValue",userCookie.Value.ToString());
			myData.commandExecute(myData.insertCommand.getSql());
		}//private void getIp()

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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

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

namespace PopUpByVivek
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Calendar CalVivek;
	
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
			this.CalVivek.SelectionChanged += new System.EventHandler(this.CalVivek_SelectionChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void CalVivek_SelectionChanged(object sender, System.EventArgs e)
		{
			if (Request.QueryString["textbox"] != "")
			{
				string strScript = "<script>window.opener.document.forms(0)." + Request.QueryString["textbox"].ToString() + ".value = '";
				strScript += CalVivek.SelectedDate.ToString("MM/dd/yyyy");
				strScript += "';self.close()";
				strScript += "</" + "script>";
				RegisterClientScriptBlock("Calendar_ChangeDate", strScript);
			}
		}
	}
}

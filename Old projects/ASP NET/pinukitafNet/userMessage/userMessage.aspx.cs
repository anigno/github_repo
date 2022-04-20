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

namespace pinukitafNet.userMessage
{
	public class userMessage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtMessage;
		protected System.Web.UI.WebControls.Button btnSend;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Repeater rptUserMessages;

		cData myData=new cData(cGeneralData.dbPath,cGeneralData.dbFile);
	
		private void Page_Load(object sender, System.EventArgs e)
		{		
				//force page to run event Page_load next time
				Request.Form.Get("nothing");
				//select userMessages and bind to repeater
				myData.createSelectCommand("tblUserMessages","","iKey DESC");
				DataTable userMessages=myData.selectCommand.getTable();
				rptUserMessages.DataSource=userMessages;
				rptUserMessages.DataBind();
		}//private void Page_Load(object sender, System.EventArgs e)

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
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			//update tblUserMessages
			myData.createInsertCommand("tblUserMessages");
			myData.insertCommand.add("iDate",DateTime.Now.ToString());
			myData.insertCommand.add("iMessage",txtMessage.Text);
			myData.commandExecute(myData.insertCommand.getSql());
			Response.Redirect("../main.aspx");
		}//private void btnSend_Click(object sender, System.EventArgs e)

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../main.aspx");
		}//private void btnCancel_Click(object sender, System.EventArgs e)
	}//public class userMessage : System.Web.UI.Page
}//namespace pinukitafNet.userMessage

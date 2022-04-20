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
using System.Collections.Specialized;

namespace pinukitafNet
{
	public class admin : System.Web.UI.Page
	{
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

		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.ListBox ListBox1;

		cData myData =new cData(cGeneralData.dbPath,cGeneralData.dbFile);

		private void Page_Load(object sender, System.EventArgs e)
		{
			//select tblIps to DataGrid
			myData.createSelectCommand("tblIps","","iCookieValue");
			DataTable ips=myData.selectCommand.getTable();
			DataGrid1.DataSource=ips;
			DataGrid1.DataBind();
			ListBox1.Items.Add("כניסות="+DataGrid1.Items.Count.ToString());
			//count users by iCookieValue, add them to ListBox
			int total=0;
			int current=0;
			String last="";
			foreach(DataRow row in ips.Rows)
			{
				if(last!=row["iCookieValue"].ToString())
				{
					if(!last.Equals(""))
					{
						ListBox1.Items.Add(total+" : "+last+" : "+current);
					}//if
					last=row["iCookieValue"].ToString();
					total++;
					current=1;
				}
				else
				{
					current++;
				}//if else
			}//foreach
            //add last item red from the table
			ListBox1.Items.Add(total+" : "+last+" : "+current);
		}//private void Page_Load(object sender, System.EventArgs e)

	}//public class admin : System.Web.UI.Page
}//namespace pinukitafNet

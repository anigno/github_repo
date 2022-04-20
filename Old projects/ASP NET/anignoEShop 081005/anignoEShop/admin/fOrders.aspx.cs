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
using anignoEShop.classes;

namespace anignoEShop.admin
{
	public class fOrders : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ListBox lstOrders;
		protected MarkItUp.WebControls.Timer tmrRefresh;
		protected System.Web.UI.WebControls.DataGrid dgProductsOrder;
		protected System.Web.UI.WebControls.Label lblOrderDate;
		protected System.Web.UI.WebControls.Label lblOrderName;
		protected System.Web.UI.WebControls.Label lblOrderAddress;
		protected System.Web.UI.WebControls.Label lblOrderPhone;
		protected System.Web.UI.WebControls.CheckBox chkReady;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
	

		cDatabaseConnection con=new cDatabaseConnection(cUtil.publicDB,"");

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				updateOrdersList();
			}
		}

		private void updateOrdersList()
		{
			con.createSelect("tblOrders","*","","fldOrderNumber DESC","");
			DataTable table=con.runSelect();
			lstOrders.DataSource=table;
			lstOrders.DataTextField="fldKey";
			lstOrders.DataValueField="fldOrderNumber";
			lstOrders.DataBind();

			if(lstOrders.Items.Count>0)
			{
				lstOrders.SelectedIndex=0;
				lstOrders_SelectedIndexChanged(lstOrders,null);
			}
		}
		
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.chkReady.CheckedChanged += new System.EventHandler(this.chkReady_CheckedChanged);
			this.lstOrders.SelectedIndexChanged += new System.EventHandler(this.lstOrders_SelectedIndexChanged);
			this.tmrRefresh.Elapsed += new MarkItUp.WebControls.TimerElapsedEventHandler(this.tmrRefresh_Elapsed);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void tmrRefresh_Elapsed(object sender, MarkItUp.WebControls.TimerElapsedEventArgs e)
		{
			Session["lastOrderNumber"]=lstOrders.SelectedValue;
			updateOrdersList();
		}

		private void lstOrders_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//update dgProductsOrder
			con.createSelect("tblProductsOrder","*","fldOrderNumber='"+lstOrders.SelectedValue+"'","","");
			DataTable table=con.runSelect();
			dgProductsOrder.DataSource=table;
			dgProductsOrder.DataBind();
			//calculate total sum
			double sum=0;
			for(int i=0;i<table.Rows.Count;i++)
			{
				double productPrise=Double.Parse(table.Rows[i]["fldProductPrise"].ToString());
				double productCount=Double.Parse(table.Rows[i]["fldProductCount"].ToString());
				sum+=productPrise*productCount;
			}
			lblSum.Text=sum.ToString();
			//update order labels and chkReady
			con.createSelect("tblOrders","*","fldOrderNumber='"+lstOrders.SelectedValue+"'","","");
			DataTable orderTable=con.runSelect();
			lblOrderAddress.Text=orderTable.Rows[0]["fldAddress"].ToString();
			lblOrderDate.Text=orderTable.Rows[0]["fldDate"].ToString();
			lblOrderName.Text=orderTable.Rows[0]["fldName"].ToString();
			lblOrderPhone.Text=orderTable.Rows[0]["fldPhone"].ToString();
			chkReady.Checked=bool.Parse(orderTable.Rows[0]["fldReady"].ToString());


		}

		private void chkReady_CheckedChanged(object sender, System.EventArgs e)
		{
			con.createUpdate("tblOrders","fldOrderNumber='"+lstOrders.SelectedValue+"'");
			con.addToUpdate("fldReady",chkReady.Checked);
			con.runUpdate();
		}
	}
}

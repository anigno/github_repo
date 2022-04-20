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

namespace anignoEShop.user
{
	/// <summary>
	/// Summary description for fUserData.
	/// </summary>
	public class fUserData : System.Web.UI.Page
	{
		#region controls
		protected System.Web.UI.WebControls.DataGrid dgBasket;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtCreditCardNumber;
		protected System.Web.UI.WebControls.TextBox txtId;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Button btnExecute;
		protected System.Web.UI.WebControls.DropDownList ddlCardType;
		protected System.Web.UI.WebControls.DropDownList ddlCardExDate;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.Label lblBasket;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Button btnReturn;
		#endregion
		cDatabaseConnection con=new cDatabaseConnection(cUtil.publicDB,"");
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				//show the basket and calculate total sum
				DataTable basketTable=(DataTable)(Session["basket"]);
				dgBasket.DataSource=basketTable;
				dgBasket.DataBind();
				lblSum.Text=calculateBasketSum().ToString();
				fillDdlExDate();
			}
			
		}

		private double calculateBasketSum()
		{
			DataTable basketTable=(DataTable)(Session["basket"]);
			double sum=0;
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				double productPrise=Double.Parse(basketTable.Rows[i]["fldPrise"].ToString());
				double productCount=Double.Parse(basketTable.Rows[i]["fldCount"].ToString());
				sum+=productPrise*productCount;
			}
			return sum;
		}

		private void fillDdlExDate()
		{
			DateTime d=new DateTime(DateTime.Now.Ticks);
			for(int i=0;i<60;i++)
			{
				ddlCardExDate.Items.Add(d.Month+"/"+d.Year);
				d=d.AddMonths(1);
			}
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
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnExecute_Click(object sender, System.EventArgs e)
		{
			//get basket from session
			DataTable basketTable=(DataTable)(Session["basket"]);
			if(basketTable==null)
			{
				Response.Redirect("fShop.aspx",true);
			}
			//update tblOrders
			long orderNumber=DateTime.Now.Ticks;
			con.createInsert("tblOrders");
			con.addToInsert("fldOrderNumber",orderNumber);
			con.addToInsert("fldName",txtName.Text);
			con.addToInsert("fldAddress",txtAddress.Text);
			con.addToInsert("fldPhone",txtPhone.Text);
			con.addToInsert("fldDate",DateTime.Now.ToOADate());
			con.addToInsert("fldReady",false);
			con.runInsert();
			//update tblProductsOrder from basket
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				con.createInsert("tblProductsOrder");
				con.addToInsert("fldOrderNumber",orderNumber);
				con.addToInsert("fldProductKey",basketTable.Rows[i]["fldKey"]);
				con.addToInsert("fldProductCount",basketTable.Rows[i]["fldCount"]);
				con.addToInsert("fldProductPrise",basketTable.Rows[i]["fldPrise"]);
				con.addToInsert("fldProductName",basketTable.Rows[i]["fldName"]);
				con.runInsert();
			}
			btnCancel.Enabled=false;
			btnExecute.Enabled=false;
			btnReturn.Visible=true;
			//clear session for next shop
			Session["basket"]=null;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fShop.aspx");
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fShop.aspx");
		}

	}//class fUserData
}//namespace

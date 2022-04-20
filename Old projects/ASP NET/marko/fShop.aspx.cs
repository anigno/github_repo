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

namespace marko
{
	/// <summary>
	/// Summary description for fShop.
	/// </summary>
	public class fShop : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.Label lblProducts;
		protected System.Web.UI.WebControls.Image imgSubject;
		public string imagesPath=Global.imagesPath+"\\";
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DataGrid dgProducts;
		protected System.Web.UI.WebControls.DataGrid dgBasket;
		protected System.Web.UI.WebControls.Label lblSum;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Button btnBuy;
	

		cDatabaseConnection con=new cDatabaseConnection(Global.dbFile,"");
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			DataTable basketTable;
			if(!IsPostBack)
			{
				//update lstSubjects
				con.createSelect("tblSubjects","*","","","");
				DataTable table=con.runSelect();
				lstSubjects.DataSource=table;
				lstSubjects.DataTextField="fldName";
				lstSubjects.DataValueField="fldKey";
				lstSubjects.DataBind();
				//check if lstSubject has items, if true select the first one
				if(lstSubjects.Items.Count>0)
				{
					if(lstSubjects.SelectedIndex<0)lstSubjects.SelectedIndex=0;
					lstSubjects_SelectedIndexChanged(lstSubjects,null);
				}
			}
			
			//check if no session["basket"] create one with dataTable
			if(Session["basket"]==null)
			{
				basketTable=new DataTable();
				basketTable.Columns.Add("fldBasketKey");
				basketTable.Columns.Add("fldKey");
				basketTable.Columns.Add("fldName");
				basketTable.Columns.Add("fldCount");
				basketTable.Columns.Add("fldPrise");
				Session["basket"]=basketTable;
				dgBasket.DataSource=basketTable;
				dgBasket.DataBind();
			}//if

			
			//if redirect update dgBasket (redirect is not a postBack action)
			if(!IsPostBack)
			{
				basketTable=(DataTable)(Session["basket"]);
				dgBasket.DataSource=basketTable;
				dgBasket.DataBind();
				//calculate total sum
				double totalSum=0;
				for(int i=0;i<basketTable.Rows.Count;i++)
				{
					double productPrise=Double.Parse(basketTable.Rows[i]["fldPrise"].ToString());
					double productCount=Double.Parse(basketTable.Rows[i]["fldCount"].ToString());
					totalSum+=productPrise*productCount;
				}
				lblSum.Text=totalSum.ToString();
			}



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
			this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.dgProducts.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgProducts_ItemCommand);
			this.dgProducts.SelectedIndexChanged += new System.EventHandler(this.dgProducts_SelectedIndexChanged);
			this.dgBasket.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgBasket_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//read the selected subject's data to get fldKey
			con.createSelect("tblSubjects","*","fldKey="+lstSubjects.SelectedValue,"","");
			DataTable table=con.runSelect();
			string sImage=Global.imagesPath+"\\"+table.Rows[0]["fldImage"].ToString();
			imgSubject.ImageUrl=sImage;
			//write subject to lblProducts
			lblProducts.Text=table.Rows[0]["fldName"].ToString();
			//read products for subject's key, bound them to dbGrid (columns set in html)
			con.createSelect("tblProducts","*","fldSubjectKey="+lstSubjects.SelectedValue,"","");
			table=con.runSelect();
			dgProducts.DataSource=table;
			dgProducts.DataBind();
		}

		private void dgProducts_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//get the dropDownList value (count) for current row
			DropDownList ddl=(DropDownList)(e.Item.Cells[4].Controls[1]);
			//get basketTable from session
			DataTable basketTable=(DataTable)(Session["basket"]);
			//add new row
			DataRow dr=basketTable.NewRow();
			dr["fldBasketKey"]=DateTime.Now.Ticks;
			dr["fldKey"]=e.Item.Cells[0].Text;
			dr["fldName"]=e.Item.Cells[1].Text;
			dr["fldCount"]=ddl.SelectedValue;
			dr["fldPrise"]=e.Item.Cells[2].Text;
			basketTable.Rows.Add(dr);
			//bind data
			dgBasket.DataSource=basketTable;
			dgBasket.DataBind();
			//calculate total sum
			double totalSum=0;
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				double productPrise=Double.Parse(basketTable.Rows[i]["fldPrise"].ToString());
				double productCount=Double.Parse(basketTable.Rows[i]["fldCount"].ToString());
				totalSum+=productPrise*productCount;
			}
			lblSum.Text=totalSum.ToString();


		}

		private void dgBasket_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//remove item from basket
			DataTable basketTable=(DataTable)(Session["basket"]);
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				string s=(string)(basketTable.Rows[i][0]);
				if(e.Item.Cells[0].Text==s)
				{
					basketTable.Rows.RemoveAt(i);
				}
			}
			dgBasket.DataSource=basketTable;
			dgBasket.DataBind();
			//calculate total sum
			double totalSum=0;
			for(int i=0;i<basketTable.Rows.Count;i++)
			{
				double productPrise=Double.Parse(basketTable.Rows[i]["fldPrise"].ToString());
				double productCount=Double.Parse(basketTable.Rows[i]["fldCount"].ToString());
				totalSum+=productPrise*productCount;
			}
			lblSum.Text=totalSum.ToString();

		}

		private void btnBuy_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fBuy.aspx");
		}

		private void dgProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}



	}
}

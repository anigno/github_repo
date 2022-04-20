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
	
	
	public class fProductUpdate : System.Web.UI.Page
	{
		#region controls
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.LinkButton lbtnAddSubject;
		protected System.Web.UI.WebControls.LinkButton lbtnEditSubject;
		protected System.Web.UI.WebControls.LinkButton lbtnRemoveSubject;
		protected System.Web.UI.WebControls.Panel pnlAddSubject;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtAddSubject;
		protected System.Web.UI.WebControls.Button btnAddSubjectOK;
		protected System.Web.UI.WebControls.Button btnAddSubjectCancel;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Panel pnlEditSubject;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Button btnEditSubjectOK;
		protected System.Web.UI.WebControls.Button btnEditSubjectCancel;
		protected System.Web.UI.WebControls.TextBox txtEditSubject;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Button btnRemoveSubjectOK;
		protected System.Web.UI.WebControls.Button btnRemoveSubjectCancel;
		protected System.Web.UI.WebControls.Label lblRemoveSubject;
		protected System.Web.UI.WebControls.Panel pnlRemoveSubject;
		protected System.Web.UI.WebControls.Button dummie;
		protected System.Web.UI.WebControls.DataGrid dgProducts;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Button btnRemoveProductCancel;
		protected System.Web.UI.WebControls.Button btnRemoveProductOK;
		protected System.Web.UI.WebControls.Label lblRemoveProduct;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Panel pnlRemoveProduct;
		protected System.Web.UI.WebControls.LinkButton lbtnAddProduct;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Panel pnlAddProduct;
		protected System.Web.UI.WebControls.TextBox txtAddProductName;
		protected System.Web.UI.WebControls.TextBox txtAddProductPrise;
		protected System.Web.UI.WebControls.Button btnAddProductCancel;
		protected System.Web.UI.WebControls.Button btnAddProductOK;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Button btnEditProductCancel;
		protected System.Web.UI.WebControls.Button btnEditProductOK;
		protected System.Web.UI.WebControls.TextBox txtEditProductPrise;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtEditProductName;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Panel pnlEditProduct;
		protected System.Web.UI.WebControls.Panel pnlUploadProductImage;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label lblUploadProductImage;
		protected System.Web.UI.WebControls.Button btnUploadProductImageCancel;
		protected System.Web.UI.WebControls.Button btnUploadProductImageOK;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileUploadProductImage;
		#endregion
		cDatabaseConnection con=new cDatabaseConnection(cUtil.publicDB,"");
		private const string attributePanelPositionEdit="Z-INDEX: 100; LEFT: 160px; TOP: 40px; POSITION: absolute;";	//define the position for any panel being shown

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				updateSubjectList();
			}//if
		}//Page_Load()

		private void closeAllPanels()
		{
			pnlAddSubject.Visible=false;
			pnlEditSubject.Visible=false;
			pnlRemoveSubject.Visible=false;
			pnlRemoveProduct.Visible=false;
			pnlAddProduct.Visible=false;
			pnlEditProduct.Visible=false;
			pnlUploadProductImage.Visible=false;
		}//closeAllPanels()

		//close all panels and show only requested panel.
		//set panel's attribute to position panel at edit position
		private void showPanel(Panel panel)
		{
			closeAllPanels();
			panel.Visible=true;
			panel.Attributes.Add("style",attributePanelPositionEdit);
		}//showPanel()

		//update subject list and auto select first item if exist
		private void updateSubjectList()
		{
			bool hasItems=cUtil.updateSubjectsList(con,lstSubjects);
			if(hasItems)
			{
				lstSubjects.SelectedIndex=0;
				lstSubjects_SelectedIndexChanged(lstSubjects,null);
			}//if
		}//updateSubjectList()

		//update the products dataGrid
		private void updateProductDataGrid()
		{
			cUtil.updateProductsDataGrid(con,dgProducts,lstSubjects);
		}//updateProductList()


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
			this.dummie.Click += new System.EventHandler(this.dummie_Click);
			this.btnEditProductOK.Click += new System.EventHandler(this.btnEditProductOK_Click);
			this.btnEditProductCancel.Click += new System.EventHandler(this.btnEditProductCancel_Click);
			this.lbtnAddProduct.Click += new System.EventHandler(this.lbtnAddProduct_Click);
			this.btnRemoveProductOK.Click += new System.EventHandler(this.btnRemoveProductOK_Click);
			this.btnRemoveProductCancel.Click += new System.EventHandler(this.btnRemoveProductCancel_Click);
			this.lbtnRemoveSubject.Click += new System.EventHandler(this.lbtnRemoveSubject_Click);
			this.lbtnEditSubject.Click += new System.EventHandler(this.lbtnEditSubject_Click);
			this.lbtnAddSubject.Click += new System.EventHandler(this.lbtnAddSubject_Click);
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.btnAddSubjectOK.Click += new System.EventHandler(this.btnAddSubjectOK_Click);
			this.btnAddSubjectCancel.Click += new System.EventHandler(this.btnAddSubjectCancel_Click);
			this.btnEditSubjectOK.Click += new System.EventHandler(this.btnEditSubjectOK_Click);
			this.btnEditSubjectCancel.Click += new System.EventHandler(this.btnEditSubjectCancel_Click);
			this.btnRemoveSubjectOK.Click += new System.EventHandler(this.btnRemoveSubjectOK_Click);
			this.btnRemoveSubjectCancel.Click += new System.EventHandler(this.btnRemoveSubjectCancel_Click);
			this.dgProducts.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgProducts_ItemCommand);
			this.btnAddProductOK.Click += new System.EventHandler(this.btnAddProductOK_Click);
			this.btnAddProductCancel.Click += new System.EventHandler(this.btnAddProductCancel_Click);
			this.btnUploadProductImageOK.Click += new System.EventHandler(this.btnUploadProductImageOK_Click);
			this.btnUploadProductImageCancel.Click += new System.EventHandler(this.btnUploadProductImageCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lbtnAddSubject_Click(object sender, System.EventArgs e)
		{
			showPanel(pnlAddSubject);
			txtAddSubject.Text="";
		}

		private void lbtnEditSubject_Click(object sender, System.EventArgs e)
		{
			showPanel(pnlEditSubject);
			txtEditSubject.Text=lstSubjects.SelectedItem.Text;
		}

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			closeAllPanels();
			updateProductDataGrid();
		}

		private void lbtnRemoveSubject_Click(object sender, System.EventArgs e)
		{
			showPanel(pnlRemoveSubject);
			lblRemoveSubject.Text=lstSubjects.SelectedItem.Text;
		}

		//add subject to DB
		private void btnAddSubjectOK_Click(object sender, System.EventArgs e)
		{
			con.createInsert("tblSubjects");
			con.addToInsert("fldName",txtAddSubject.Text);
			con.runInsert();
			closeAllPanels();
			updateSubjectList();
		}

		private void btnAddSubjectCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		//edit subject data in DB
		private void btnEditSubjectOK_Click(object sender, System.EventArgs e)
		{
			con.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
			con.addToUpdate("fldName",txtEditSubject.Text);
			con.runUpdate();
			closeAllPanels();
			updateSubjectList();
		}

		private void btnEditSubjectCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		//remove subject from db
		private void btnRemoveSubjectOK_Click(object sender, System.EventArgs e)
		{
			con.createDelete("tblSubjects","fldKey="+lstSubjects.SelectedValue);
			con.runDelete();
			updateSubjectList();
			closeAllPanels();

		}

		private void btnRemoveSubjectCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void dummie_Click(object sender, System.EventArgs e)
		{
			//dummie button
		}

		//handle dgProducts rows buttons events
		private void dgProducts_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string key=e.Item.Cells[0].Text;
			string commandName=e.CommandName.ToString();
			if(commandName.Equals("remove"))
			{
				//remove
				showPanel(pnlRemoveProduct);
				lblRemoveProduct.Text=e.Item.Cells[2].Text;
				//store product key in session
				Session["removedProductKey"]=e.Item.Cells[0].Text;
			}
			if(commandName.Equals("edit"))
			{
				//edit
				showPanel(pnlEditProduct);
				txtEditProductName.Text=e.Item.Cells[2].Text;
				txtEditProductPrise.Text=e.Item.Cells[3].Text;
				//store product key in session
				Session["editProductKey"]=e.Item.Cells[0].Text;
			}
			if(commandName.Equals("upload"))
			{
				//upload image
				showPanel(pnlUploadProductImage);
				lblUploadProductImage.Text=e.Item.Cells[2].Text;
				//store product key in session
				Session["uploadProductKey"]=e.Item.Cells[0].Text;
			}
		}//dgProducts_ItemCommand()

		//remove product from db
		private void btnRemoveProductOK_Click(object sender, System.EventArgs e)
		{
			string key=Session["removedProductKey"].ToString();
			con.createDelete("tblProducts","fldKey="+key);
			con.runDelete();
			updateProductDataGrid();
			Session["removedProductKey"]=null;
			closeAllPanels();
		}

		private void btnRemoveProductCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void lbtnAddProduct_Click(object sender, System.EventArgs e)
		{
			showPanel(pnlAddProduct);
			txtAddProductName.Text="";
			txtAddProductPrise.Text="";
		}

		//add product to DB
		private void btnAddProductOK_Click(object sender, System.EventArgs e)
		{
			con.createInsert("tblProducts");
			con.addToInsert("fldSubjectKey",lstSubjects.SelectedValue);
			con.addToInsert("fldName",txtAddProductName.Text);
			con.addToInsert("fldPrise",txtAddProductPrise.Text);
			con.runInsert();
			closeAllPanels();
			updateProductDataGrid();
		}

		private void btnAddProductCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		//edit product data in DB
		private void btnEditProductOK_Click(object sender, System.EventArgs e)
		{
			string key=Session["EditProductKey"].ToString();
			con.createUpdate("tblProducts","fldKey="+key);
			con.addToUpdate("fldName",txtEditProductName.Text);
			con.addToUpdate("fldPrise",txtEditProductPrise.Text);
			con.runUpdate();
			closeAllPanels();
			updateProductDataGrid();
			Session["EditProductKey"]=null;
		}

		private void btnEditProductCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		//upload image ad update product's image data in DB
		private void btnUploadProductImageOK_Click(object sender, System.EventArgs e)
		{
			//chek if posted file is really alegal file
			if(fileUploadProductImage.PostedFile.InputStream.Length>0)
			{
				string key=Session["uploadProductKey"].ToString();
				string filename=lstSubjects.SelectedValue+"_"+key+cUtil.getFileExtention(fileUploadProductImage.PostedFile.FileName);
				fileUploadProductImage.PostedFile.SaveAs(cUtil.uploads+"\\"+filename);
				//update product's image in DB
				con.createUpdate("tblProducts","fldKey="+key);
				con.addToUpdate("fldImage",filename);
				con.runUpdate();
				updateProductDataGrid();
				Session["uploadProductKey"]=null;
			}
			closeAllPanels();
		}

		private void btnUploadProductImageCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}
	}//class fProductUpdate
}//namespace

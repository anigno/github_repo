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
	/// Summary description for fSubjects.
	/// </summary>
	public class fSubjects : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.ListBox lstProducts;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnSubjectAdd;
		protected System.Web.UI.WebControls.Button btnSubjectRemove;
		protected System.Web.UI.WebControls.Button btnProductEdit;
		protected System.Web.UI.WebControls.Button btnProductRemove;
		protected System.Web.UI.WebControls.Button btnProductAdd;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Panel pnlAddNewSubject;
		protected System.Web.UI.WebControls.TextBox txtAddNewSubjectName;
		protected System.Web.UI.WebControls.Button btnAddNewSubjectCancel;
		protected System.Web.UI.WebControls.Button btnAddNewSubjectOK;
		protected System.Web.UI.WebControls.Button btnDummie;
		protected System.Web.UI.WebControls.Button btnSubjectEdit;
		protected System.Web.UI.WebControls.Panel pnlEditSubject;
		protected System.Web.UI.WebControls.Button btnEditSubjectOk;
		protected System.Web.UI.WebControls.Button pnlEditSubjectCancel;
		protected System.Web.UI.WebControls.Button btnEditSubjectUpload;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileEditSubject;
		protected System.Web.UI.WebControls.TextBox txtEditSubject;
		protected System.Web.UI.WebControls.Image imageSubject;
		protected System.Web.UI.WebControls.Panel pnlRemoveSubject;
		protected System.Web.UI.WebControls.Button btnRemoveSubjectOK;
		protected System.Web.UI.WebControls.Button btnRemoveSubjectCancel;
		protected System.Web.UI.WebControls.TextBox txtAddNewProduct;
		protected System.Web.UI.WebControls.Button btnAddNewProductCancel;
		protected System.Web.UI.WebControls.Button btnAddNewProductOK;
		protected System.Web.UI.WebControls.Panel pnlAddNewProduct;
		protected System.Web.UI.WebControls.Image imageProduct;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtEditProductName;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtEditProductPrise;
		protected System.Web.UI.WebControls.Button btnEditProductOK;
		protected System.Web.UI.WebControls.Button btnEditProductCancel;
		protected System.Web.UI.WebControls.Button btnEditProductUpload;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileEditProduct;
		protected System.Web.UI.WebControls.Panel pnlEditProduct;
		protected System.Web.UI.WebControls.Panel pnlRemoveProduct;
		protected System.Web.UI.WebControls.Button btnRemoveProductCancel;
		protected System.Web.UI.WebControls.Button btnRemoveProductOK;
		protected System.Web.UI.WebControls.Label lblProductPrise;

		
		cDatabaseConnection con=new cDatabaseConnection(Global.dbFile,"");
	
		
		private void updateSubjectsList()
		{
			//read subjects
			con.createSelect("tblSubjects","*","","","");
			DataTable subjectsTable=con.runSelect();
			lstSubjects.DataSource=subjectsTable;
			lstSubjects.DataTextField="fldName";
			lstSubjects.DataValueField="fldKey";
			lstSubjects.DataBind();
			//if subjects list not empty, force select the first item
			if(lstSubjects.Items.Count>0)
			{
				lstSubjects.SelectedIndex=0;
				lstSubjects_SelectedIndexChanged(lstSubjects,null);
			}
		}

		private void updateProductsList()
		{
			//read products for selected subject
			con.createSelect("tblProducts","*","fldSubjectKey="+lstSubjects.SelectedValue,"","");
			DataTable productsTable=con.runSelect();
			lstProducts.DataSource=productsTable;
			lstProducts.DataTextField="fldName";
			lstProducts.DataValueField="fldKey";
			lstProducts.DataBind();
			//set imageProducts and lblProductPrise visible to false
			imageProduct.Visible=false;
			lblProductPrise.Visible=false;
			//if products list not empty, force select the first item
			if(lstProducts.Items.Count>0)
			{
				lstProducts.SelectedIndex=0;
				lstProducts_SelectedIndexChanged(lstProducts,null);
			}
		}
		
		
		private void closeAllPanels()
		{
			pnlAddNewSubject.Visible=false;
			pnlRemoveSubject.Visible=false;
			pnlEditSubject.Visible=false;
			pnlAddNewProduct.Visible=false;
			pnlEditProduct.Visible=false;
			pnlRemoveProduct.Visible=false;
		}


		
		private void Page_Load(object sender, System.EventArgs e)
		{
			closeAllPanels();
			if(!IsPostBack)
			{
				updateSubjectsList();
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
			this.lstSubjects.SelectedIndexChanged += new System.EventHandler(this.lstSubjects_SelectedIndexChanged);
			this.btnProductAdd.Click += new System.EventHandler(this.btnProductAdd_Click);
			this.btnProductRemove.Click += new System.EventHandler(this.btnProductRemove_Click);
			this.btnProductEdit.Click += new System.EventHandler(this.btnProductEdit_Click);
			this.btnSubjectEdit.Click += new System.EventHandler(this.btnSubjectEdit_Click);
			this.btnSubjectRemove.Click += new System.EventHandler(this.btnSubjectRemove_Click);
			this.btnSubjectAdd.Click += new System.EventHandler(this.btnSubjectAdd_Click);
			this.lstProducts.SelectedIndexChanged += new System.EventHandler(this.lstProducts_SelectedIndexChanged);
			this.btnAddNewSubjectOK.Click += new System.EventHandler(this.btnAddNewSubjectOK_Click);
			this.btnAddNewSubjectCancel.Click += new System.EventHandler(this.btnAddNewSubjectCancel_Click);
			this.btnEditSubjectOk.Click += new System.EventHandler(this.btnEditSubjectOk_Click);
			this.pnlEditSubjectCancel.Click += new System.EventHandler(this.pnlEditSubjectCancel_Click);
			this.btnEditSubjectUpload.Click += new System.EventHandler(this.btnEditSubjectUpload_Click);
			this.btnRemoveSubjectOK.Click += new System.EventHandler(this.btnRemoveSubjectOK_Click);
			this.btnRemoveSubjectCancel.Click += new System.EventHandler(this.btnRemoveSubjectCancel_Click);
			this.btnAddNewProductOK.Click += new System.EventHandler(this.btnAddNewProductOK_Click);
			this.btnAddNewProductCancel.Click += new System.EventHandler(this.btnAddNewProductCancel_Click);
			this.btnEditProductOK.Click += new System.EventHandler(this.btnEditProductOK_Click);
			this.btnEditProductCancel.Click += new System.EventHandler(this.btnEditProductCancel_Click);
			this.btnEditProductUpload.Click += new System.EventHandler(this.btnEditProductUpload_Click);
			this.btnRemoveProductOK.Click += new System.EventHandler(this.btnRemoveProductOK_Click);
			this.btnRemoveProductCancel.Click += new System.EventHandler(this.btnRemoveProductCancel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lstSubjects_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			updateProductsList();
			//read the selected subject's image
			con.createSelect("tblSubjects","fldImage","fldKey="+lstSubjects.SelectedValue,"","");
			DataTable image=con.runSelect();
			string imageSubjectUrl=image.Rows[0][0].ToString();
			//if no subject's image is set, image visible false
			imageSubject.Visible=!(imageSubjectUrl=="");
			imageSubject.ImageUrl=Global.imagesPath+"\\"+imageSubjectUrl+"?rand="+DateTime.Now.Ticks;
		}

		private void btnSubjectAdd_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
			pnlAddNewSubject.Visible=true;
			txtAddNewSubjectName.Text="";
		}

		private void btnAddNewSubjectOK_Click(object sender, System.EventArgs e)
		{
			if(txtAddNewSubjectName.Text!="")
			{
				//add new subject name
				con.createInsert("tblSubjects");
				con.addToInsert("fldName",txtAddNewSubjectName.Text);
				con.runInsert();
				updateSubjectsList();
				pnlAddNewSubject.Visible=false;
			}
		}

		private void btnSubjectEdit_Click(object sender, System.EventArgs e)
		{
			//show edit subject panel and copy subject name to txtEditSubject
			closeAllPanels();
			pnlEditSubject.Visible=true;
			txtEditSubject.Text=lstSubjects.SelectedItem.Text;
		}

		private void btnEditSubjectOk_Click(object sender, System.EventArgs e)
		{
			//update subject's name
			if(txtEditSubject.Text!="")
			{
				con.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
				con.addToUpdate("fldName",txtEditSubject.Text);
				con.runUpdate();
				updateSubjectsList();
				pnlEditSubject.Visible=false;
			}
		}

		private void btnAddNewSubjectCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void pnlEditSubjectCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void btnEditSubjectUpload_Click(object sender, System.EventArgs e)
		{
			//check if file browsed, if true upload the file and update database
			if(fileEditSubject.PostedFile.InputStream.Length>0)
			{
				string savedFileName=lstSubjects.SelectedValue+Global.getFileExtention(fileEditSubject.PostedFile.FileName);
				fileEditSubject.PostedFile.SaveAs(Global.imagesPath+"\\"+savedFileName);
				//update db
				con.createUpdate("tblSubjects","fldKey="+lstSubjects.SelectedValue);
				con.addToUpdate("fldImage",savedFileName);
				con.runUpdate();
				updateSubjectsList();
				pnlEditSubject.Visible=false;
			}
		}


		private void lstProducts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//read the selected product's image and prise
			con.createSelect("tblProducts","fldPrise,fldImage","fldKey="+lstProducts.SelectedValue,"","");
			DataTable table=con.runSelect();
			string imageProductUrl=table.Rows[0][1].ToString();
			//if no product's image is set, image visible false
			imageProduct.Visible=!(imageProductUrl=="");
			//if there is a selection, there is a prise for the product, set visible true
			lblProductPrise.Visible=true;
			imageProduct.ImageUrl=Global.imagesPath+"\\"+imageProductUrl+"?rand="+DateTime.Now.Ticks;
			//write product's prise to txtEditProduct
			txtEditProductPrise.Text=table.Rows[0][0].ToString();
			lblProductPrise.Text="Prise: "+txtEditProductPrise.Text;
		}

		private void btnSubjectRemove_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
			pnlRemoveSubject.Visible=true;
		}

		private void btnRemoveSubjectOK_Click(object sender, System.EventArgs e)
		{
			con.createDelete("tblSubjects","fldKey="+lstSubjects.SelectedValue);
			con.runDelete();
			updateSubjectsList();
			pnlRemoveSubject.Visible=false;
		}

		private void btnRemoveSubjectCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void btnProductAdd_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
			pnlAddNewProduct.Visible=true;
			txtAddNewProduct.Text="";
		}

		private void btnAddNewProductOK_Click(object sender, System.EventArgs e)
		{
			if(txtAddNewProduct.Text!="")
			{
				//add new product name
				con.createInsert("tblProducts");
				con.addToInsert("fldSubjectKey",lstSubjects.SelectedValue);
				con.addToInsert("fldName",txtAddNewProduct.Text);
				con.runInsert();
				updateProductsList();
			}
		}

		private void btnAddNewProductCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void btnProductEdit_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
			pnlEditProduct.Visible=true;
			txtEditProductName.Text=lstProducts.SelectedItem.Text;


		}

		private void btnEditProductCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}

		private void btnEditProductOK_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
			if(txtEditProductName.Text!="" && txtEditProductPrise.Text!="")
			{
				//update product
				con.createUpdate("tblProducts","fldKey="+lstProducts.SelectedValue);
				con.addToUpdate("fldName",txtEditProductName.Text);
				con.addToUpdate("fldPrise",txtEditProductPrise.Text);
				con.runUpdate();
				updateProductsList();
			}
		}

		private void btnEditProductUpload_Click(object sender, System.EventArgs e)
		{
			//check if file browsed, if true upload the file and update database
			if(fileEditProduct.PostedFile.InputStream.Length>0)
			{
				string savedFileName=lstSubjects.SelectedValue+lstProducts.SelectedValue+Global.getFileExtention(fileEditProduct.PostedFile.FileName);
				fileEditProduct.PostedFile.SaveAs(Global.imagesPath+"\\"+savedFileName);
				//update db with image uploaded
				con.createUpdate("tblProducts","fldKey="+lstProducts.SelectedValue);
				con.addToUpdate("fldImage",savedFileName);
				con.runUpdate();
				updateProductsList();
				closeAllPanels();
			}
		}

		private void btnProductRemove_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
			pnlRemoveProduct.Visible=true;
		}

		private void btnRemoveProductOK_Click(object sender, System.EventArgs e)
		{
			con.createDelete("tblProducts","fldKey="+lstProducts.SelectedValue);
			con.runDelete();
			updateProductsList();
			closeAllPanels();
		}

		private void btnRemoveProductCancel_Click(object sender, System.EventArgs e)
		{
			closeAllPanels();
		}
	}
}

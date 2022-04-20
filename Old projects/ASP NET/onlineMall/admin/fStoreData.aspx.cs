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
using anignoLibrary.utils;
using System.IO;

namespace onlineMall.admin
{
	public class fStoreData : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.storeDataMdb,Global.ADMIN_PASSWORD);
		string currentStoreKey="";

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtWebName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtCellPhone;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Image imgMain;
		protected System.Web.UI.WebControls.Button btnUploadMainImage;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileMainImage;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileLogoImage;
		protected System.Web.UI.WebControls.Button btnUploadLogoImage;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtAbout;
		protected System.Web.UI.WebControls.Button btnUploadAboutImage;
		protected System.Web.UI.WebControls.Image imgAbout;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileAboutImage;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Button btnEditSubjects;
		protected System.Web.UI.WebControls.Button btnDummie;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator6;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator7;
		protected System.Web.UI.WebControls.Label lblMesage;
		protected System.Web.UI.WebControls.Image imgLogo;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDescription;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtHeader;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator8;

		private void refreshFormData()
		{
			conn.createSelect("tblStoreData","*","fldKey="+currentStoreKey,"","");
			DataTable table=conn.runSelect();
			DataRow row=table.Rows[0];
			txtWebName.Text=row["fldWebName"].ToString();
			txtName.Text=row["fldName"].ToString();
			txtPhone.Text=row["fldPhone"].ToString();
			txtCellPhone.Text=row["fldCellPhone"].ToString();
			txtFax.Text=row["fldFax"].ToString();
			txtEmail.Text=row["fldEmail"].ToString();
			txtAddress.Text=row["fldAddress"].ToString();
			txtAbout.Text=row["fldAbout"].ToString();
			txtDescription.Text=row["fldDescription"].ToString();
			txtHeader.Text=row["fldHeader"].ToString();
		}//refreshFormData()

		private void refreshImages()
		{
			conn.createSelect("tblStoreData","*","fldKey="+currentStoreKey,"","");
			DataTable table=conn.runSelect();
			DataRow row=table.Rows[0];
			imgMain.ImageUrl=Global.imagesPath+row["fldMainImage"].ToString();
			cImageManupulation.setImageWidthByHeight(imgMain,Global.PREV_IMAGE_HEIGHT);
			imgLogo.ImageUrl=Global.imagesPath+row["fldLogoImage"].ToString();
			cImageManupulation.setImageWidthByHeight(imgLogo,Global.PREV_IMAGE_HEIGHT);
			imgAbout.ImageUrl=Global.imagesPath+row["fldAboutImage"].ToString();
			cImageManupulation.setImageWidthByHeight(imgAbout,Global.PREV_IMAGE_HEIGHT);
		}//refreshImages()

		private void updateData()
		{
			conn.createUpdate("tblStoreData","fldKey="+currentStoreKey);
			conn.addToUpdate("fldWebName",txtWebName.Text);
			conn.addToUpdate("fldName",txtName.Text);
			conn.addToUpdate("fldPhone",txtPhone.Text);
			conn.addToUpdate("fldCellPhone",txtCellPhone.Text);
			conn.addToUpdate("fldFax",txtFax.Text);
			conn.addToUpdate("fldEmail",txtEmail.Text);
			conn.addToUpdate("fldAddress",txtAddress.Text);
			conn.addToUpdate("fldAbout",txtAbout.Text);
			conn.addToUpdate("fldDescription",txtDescription.Text);
			conn.addToUpdate("fldHeader",txtHeader.Text);
			conn.runUpdate();
			refreshFormData();
		}//updateData()
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			currentStoreKey=Session["currentStoreKey"].ToString();
			if(!IsPostBack)
			{
				refreshFormData();
				refreshImages();
			}//if
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
			this.btnDummie.Click += new System.EventHandler(this.btnDummie_Click);
			this.btnEditSubjects.Click += new System.EventHandler(this.btnEditSubjects_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnUploadMainImage.Click += new System.EventHandler(this.btnUploadMainImage_Click);
			this.btnUploadLogoImage.Click += new System.EventHandler(this.btnUploadLogoImage_Click);
			this.btnUploadAboutImage.Click += new System.EventHandler(this.btnUploadAboutImage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			updateData();
			lblMesage.Text="Data updated successfully!";
		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fStoreSelect.aspx");
		}

		private void btnEditSubjects_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("fSubjects.aspx");
		}

		private void btnUploadMainImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(fileMainImage.PostedFile.ContentLength<=Global.MAX_IMAGE_SIZE)
				{
					string extention=cFileManipulation.getExtention(fileMainImage.PostedFile.FileName);
					fileMainImage.PostedFile.SaveAs(Global.imagesPath+currentStoreKey+"mainImage"+extention);
					conn.createUpdate("tblStoreData","fldKey="+currentStoreKey);
					conn.addToUpdate("fldMainImage",currentStoreKey+"mainImage"+extention);
					conn.runUpdate();
					refreshImages();
					lblMesage.Text="Image uploaded successfully!";
				}
				else
				{
					lblMesage.Text="Image exceed "+Global.MAX_IMAGE_SIZE.ToString()+" bytes!";
				}//if else
			}
			catch
			{
				lblMesage.Text="Image upload error!";
			}//catch
		}

		private void btnUploadLogoImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(fileLogoImage.PostedFile.ContentLength<=Global.MAX_IMAGE_SIZE)
				{
					string extention=cFileManipulation.getExtention(fileLogoImage.PostedFile.FileName);
					fileLogoImage.PostedFile.SaveAs(Global.imagesPath+currentStoreKey+"logoImage"+extention);
					conn.createUpdate("tblStoreData","fldKey="+currentStoreKey);
					conn.addToUpdate("fldLogoImage",currentStoreKey+"logoImage"+extention);
					conn.runUpdate();
					refreshImages();
					lblMesage.Text="Image uploaded successfully!";
				}
				else
				{
					lblMesage.Text="Image exceed "+Global.MAX_IMAGE_SIZE.ToString()+" bytes!";
				}//if else
			}
			catch
			{
				lblMesage.Text="Image upload error!";
			}//catch
		}

		private void btnUploadAboutImage_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(fileAboutImage.PostedFile.ContentLength<=Global.MAX_IMAGE_SIZE)
				{
					string extention=cFileManipulation.getExtention(fileAboutImage.PostedFile.FileName);
					fileAboutImage.PostedFile.SaveAs(Global.imagesPath+currentStoreKey+"aboutImage"+extention);
					conn.createUpdate("tblStoreData","fldKey="+currentStoreKey);
					conn.addToUpdate("fldAboutImage",currentStoreKey+"aboutImage"+extention);
					conn.runUpdate();
					refreshImages();
					lblMesage.Text="Image uploaded successfully!";
				}
				else
				{
					lblMesage.Text="Image exceed "+Global.MAX_IMAGE_SIZE.ToString()+" bytes!";
				}//if else
			}
			catch
			{
				lblMesage.Text="Image upload error!";
			}//catch
		}

		private void btnDummie_Click(object sender, System.EventArgs e)
		{
			lblMesage.Text="Remember to click Update Button!";
		}
	}
}

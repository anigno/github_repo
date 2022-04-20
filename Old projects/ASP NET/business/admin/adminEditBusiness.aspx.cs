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
using System.IO;

using anignoLibrary.ClassLibraryMdbConnection;

namespace business.admin
{
	public class adminEditBusiness : System.Web.UI.Page
	{
		string businessKey="";
		string mainImageFile="";
		string logoImageFile="";
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,"");
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.HtmlControls.HtmlInputFile File2;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtCity;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtCellolarNumber;
		protected System.Web.UI.WebControls.TextBox txtFaxNumber;
		protected System.Web.UI.WebControls.DropDownList drpRegion;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtAbout;
		protected System.Web.UI.WebControls.Button btnUploadMain;
		protected System.Web.UI.WebControls.Button btnUploadSecond;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.Label lblWebName;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.HtmlControls.HtmlInputFile FileLogo;
		protected System.Web.UI.WebControls.Button btnUploadLogo;
		protected System.Web.UI.WebControls.Image imgLogo;
		protected System.Web.UI.WebControls.Button btnEditSubjects;
		protected System.Web.UI.WebControls.ListBox lstSubjects;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label1;

//---------------------------------------------------------------------------------
	
		private void reloadPage(string message)
		{
			Response.Redirect("adminEditBusiness.aspx?message="+message);
		}//reloadPage()
		
//---------------------------------------------------------------------------------

		private void Page_Load(object sender, System.EventArgs e)
		{
			businessKey=Session["businessKey"].ToString();
			lblMessage.Text=Request.QueryString.Get("message");
			if(!IsPostBack)
			{
				//set drpRegion
				for(int i=0;i<Global.regionTextField.Length;i++)
				{
					ListItem l=new ListItem(Global.regionTextField[i],Global.regionValueField[i]);
					drpRegion.Items.Add(l);
				}//foreach
				//reload subjects
				conn.createSelect("tblSubjects","*","fldBusinessKey='"+businessKey+"'","","");
				DataTable table1=conn.runSelect();
				lstSubjects.DataSource=table1;
				lstSubjects.DataTextField="fldName";
				lstSubjects.DataValueField="fldKey";
				lstSubjects.DataBind();
				//reload business's data
				conn.createSelect("tblBusinesses","*","fldKey='"+businessKey+"'","","");
				DataTable table=conn.runSelect();
				lblWebName.Text=table.Rows[0]["fldWebName"].ToString();
				txtName.Text=table.Rows[0]["fldName"].ToString();
				txtAddress.Text=table.Rows[0]["fldAddress"].ToString();
				txtCity.Text=table.Rows[0]["fldCity"].ToString();
				drpRegion.SelectedIndex=int.Parse("0"+table.Rows[0]["fldRegion"].ToString());
				txtPhoneNumber.Text=table.Rows[0]["fldPhone"].ToString();
				txtCellolarNumber.Text=table.Rows[0]["fldCellPhone"].ToString();
				txtFaxNumber.Text=table.Rows[0]["fldFax"].ToString();
				txtEmail.Text=table.Rows[0]["fldEmail"].ToString();
				txtAbout.Text=table.Rows[0]["fldAbout"].ToString();
				//reload pictures
				try
				{
					//main picture
					mainImageFile=table.Rows[0]["fldMainPicture"].ToString();
					Image1.ImageUrl=Global.picturePath+mainImageFile;
					//use FileStream to get image properties
					FileStream fs=new FileStream(Image1.ImageUrl,FileMode.Open,FileAccess.Read,FileShare.Read);
					System.Drawing.Image image=System.Drawing.Image.FromStream(fs);
					double heightFactor=Global.MAX_SMALL_IMAGE_HEIGHT/(double)image.Height;
					double width=(double)(image.Width*heightFactor);
					double height=(double)(image.Height*heightFactor);
					fs.Close();
					Image1.Width=(int)width;
					Image1.Height=(int)height;
					//add "?image=" to image name to force browser to download image from server
					Image1.ImageUrl=Image1.ImageUrl+"?image="+DateTime.Now.Ticks.ToString();
					//logo picture
					logoImageFile=table.Rows[0]["fldLogoPicture"].ToString();
					imgLogo.ImageUrl=Global.picturePath+logoImageFile;
					//use FileStream to get image properties
					fs=new FileStream(imgLogo.ImageUrl,FileMode.Open,FileAccess.Read,FileShare.Read);
					image=System.Drawing.Image.FromStream(fs);
					heightFactor=Global.MAX_SMALL_IMAGE_HEIGHT/(double)image.Height;
					width=(double)(image.Width*heightFactor);
					height=(double)(image.Height*heightFactor);
					fs.Close();
					imgLogo.Width=(int)width;
					imgLogo.Height=(int)height;
					//add "?image=" to image name to force browser to download image from server
					imgLogo.ImageUrl=imgLogo.ImageUrl+"?image="+DateTime.Now.Ticks.ToString();
				}
				catch(Exception ex)
				{
					//no image uploaded yet, or image not found, possible default image?
				}//catch
			}//if
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnEditSubjects.Click += new System.EventHandler(this.btnEditSubjects_Click);
			this.btnUploadLogo.Click += new System.EventHandler(this.btnUploadLogo_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnUploadMain.Click += new System.EventHandler(this.btnUploadMain_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUploadMain_Click(object sender, System.EventArgs e)
		{
			string pictureMessage="";
			try
			{
				//main picture file name is: <key>_mainPicture.<ext>
				string fileName="mainPicture";
				string fileExtention=File1.Value.Substring(File1.Value.LastIndexOf("."));
				fileName=businessKey+"_"+fileName+fileExtention;
				//upload new picture
				File1.PostedFile.SaveAs(Global.picturePath+fileName);
				File1.Dispose();
				//update image in database
				conn.createUpdate("tblBusinesses","fldKey='"+businessKey+"'"	);
				conn.addToUpdate("fldMainPicture",fileName);
				conn.runUpdate();
				pictureMessage="Picture uploaded!";
			}
			catch(Exception ex)
			{
				//no file, or file error
				pictureMessage="Upload error!";
			}//catch
			finally
			{
				reloadPage(pictureMessage);
			}//finally
		}//btnUploadMain_Click()

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			conn.createUpdate("tblBusinesses","fldKey='"+businessKey+"'");
			conn.addToUpdate("fldName",txtName.Text);
			conn.addToUpdate("fldPhone",txtPhoneNumber.Text);
			conn.addToUpdate("fldCellPhone",txtCellolarNumber.Text);
			conn.addToUpdate("fldFax",txtFaxNumber.Text);
			conn.addToUpdate("fldAddress",txtAddress.Text);
			conn.addToUpdate("fldCity",txtCity.Text);
			conn.addToUpdate("fldRegion",drpRegion.SelectedValue);
			conn.addToUpdate("fldAbout",txtAbout.Text);
			conn.addToUpdate("fldEmail",txtEmail.Text);
			conn.runUpdate();
			reloadPage("Data updated");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adminBusiness.aspx");
		}

		private void btnUploadLogo_Click(object sender, System.EventArgs e)
		{
			string pictureMessage="";
			try
			{
				//main picture file name is: <key>_logoPicture.<ext>
				string fileName="logoPicture";
				string fileExtention=FileLogo.Value.Substring(FileLogo.Value.LastIndexOf("."));
				fileName=businessKey+"_"+fileName+fileExtention;
				//upload new picture
				FileLogo.PostedFile.SaveAs(Global.picturePath+fileName);
				FileLogo.Dispose();
				//update image in database
				conn.createUpdate("tblBusinesses","fldKey='"+businessKey+"'"	);
				conn.addToUpdate("fldLogoPicture",fileName);
				conn.runUpdate();
				pictureMessage="Logo Picture uploaded!";
			}
			catch(Exception ex)
			{
				//no file, or file error
				pictureMessage="Logo Upload error!";
			}//catch
			finally
			{
				reloadPage(pictureMessage);
			}//finally
		}

		private void btnEditSubjects_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adminEditSubjects.aspx?webName="+lblWebName.Text);
		}


	}//class
}//namespace

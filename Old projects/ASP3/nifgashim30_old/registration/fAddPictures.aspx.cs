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
using System.IO;

namespace nifgashim30.registration
{
	public class fAddPictures : System.Web.UI.Page
	{
		private cDatabaseConnection conRegisteredUsers=new cDatabaseConnection(Global.registeredUsersMdbFilePath,"");
		private string userName;
		private const double MAX_IMAGE_HEIGHT=100;

		protected System.Web.UI.WebControls.Button btnUpload;
		protected System.Web.UI.HtmlControls.HtmlInputFile filePicture1;
		protected System.Web.UI.HtmlControls.HtmlInputFile filrPicture2;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Image Image3;
		protected System.Web.UI.HtmlControls.HtmlInputFile filePicture2;
		protected System.Web.UI.HtmlControls.HtmlInputFile filePicture3;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblHeader;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnRemove1;
		protected System.Web.UI.WebControls.Button btnRemove3;
		protected System.Web.UI.WebControls.Button btnRemove2;

		//change image size to fit max height
		private void setImageSize(string imageFile,System.Web.UI.WebControls.Image formImage)
		{
			try
			{
				imageFile=Global.imageUploadPath+imageFile;
				//use FileStream to get image properties
				FileStream fs=new FileStream(imageFile,FileMode.Open,FileAccess.Read,FileShare.Read);
				System.Drawing.Image image=System.Drawing.Image.FromStream(fs);
				double heightFactor=MAX_IMAGE_HEIGHT/(double)image.Height;
				double width=(double)(image.Width*heightFactor);
				double height=(double)(image.Height*heightFactor);
				//set image to new size
				formImage.Width=(int)width;
				formImage.Height=(int)height;
				fs.Close();
			}
			catch
			{
			}//catch
		}//setImageSize

		private void removeImage(int imageNumber)
		{
			conRegisteredUsers.createUpdate("tblRegisteredUsers","fldUsername='"+userName+"'");
			conRegisteredUsers.addToUpdate("fldImage"+imageNumber.ToString(),"");
			conRegisteredUsers.runUpdate();
			Response.Redirect("fAddPictures.aspx",true);
		}//removeImage()

		private void Page_Load(object sender, System.EventArgs e)
		{
			//check session Session["fileTooBig"] to display warning (image not loaded)
			if(Session["fileTooBig"]!=null)
			{
				if(Session["fileTooBig"].ToString()=="yes")lblMessage.Visible=true;
				Session["fileTooBig"]="no";
			}//if
			//get username from session
			userName=Session["userName"].ToString();
			lblHeader.Text=userName;
			//read images names from database
			conRegisteredUsers.createSelect("tblRegisteredUsers","*","fldUsername='"+userName+"'","","");
			DataTable table=conRegisteredUsers.runSelect();
			//insert images files to array
			string[] imageFile=new string[3];
			imageFile[0]=table.Rows[0]["fldImage1"].ToString();
			imageFile[1]=table.Rows[0]["fldImage2"].ToString();
			imageFile[2]=table.Rows[0]["fldImage3"].ToString();
			//if no image yet, set default NoImageYet.jpg
			if(imageFile[0]=="")imageFile[0]="NoImageYet.jpg";
			if(imageFile[1]=="")imageFile[1]="NoImageYet.jpg";
			if(imageFile[2]=="")imageFile[2]="NoImageYet.jpg";
			//correct Image control size
			setImageSize(imageFile[0],Image1);
			setImageSize(imageFile[1],Image2);
			setImageSize(imageFile[2],Image3);
			//setting images on form with defernt queryString to the image, for IE to update images
			if(imageFile[0]!="")Image1.ImageUrl=Global.imageUploadPath+imageFile[0]+"?r="+DateTime.Now.Ticks.ToString();
			if(imageFile[1]!="")Image2.ImageUrl=Global.imageUploadPath+imageFile[1]+"?r="+DateTime.Now.Ticks.ToString();
			if(imageFile[2]!="")Image3.ImageUrl=Global.imageUploadPath+imageFile[2]+"?r="+DateTime.Now.Ticks.ToString();
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
			this.btnRemove2.Click += new System.EventHandler(this.btnRemove2_Click);
			this.btnRemove3.Click += new System.EventHandler(this.btnRemove3_Click);
			this.btnRemove1.Click += new System.EventHandler(this.btnRemove1_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpload_Click(object sender, System.EventArgs e)
		{
			lblMessage.Visible=false;
			HttpPostedFile[] files=new HttpPostedFile[3];
			//insert posted files to array
			files[0]=filePicture1.PostedFile;
			files[1]=filePicture2.PostedFile;
			files[2]=filePicture3.PostedFile;
			int c=1;
			foreach(HttpPostedFile item in files)
			{
				//check upload image size
				if(item.ContentLength<Global.maxUploadSize)
				{
					//image size is ok or no image
					//check image exist
					if(item.ContentLength>0)
					{
						//image exist and at legal size
						string fileExtention=item.FileName.Substring(item.FileName.LastIndexOf("."));
						string filename=userName+"_image"+c.ToString()+fileExtention;
						//save the file
						item.SaveAs(Global.imageUploadPath+filename);
						//update the database
						conRegisteredUsers.createUpdate("tblRegisteredUsers","fldUsername='"+userName+"'");
						conRegisteredUsers.addToUpdate("fldImage"+c.ToString(),filename);
						conRegisteredUsers.runUpdate();
					}//if
				}
				else
				{
					//image size too big, set session
					Session["fileTooBig"]="yes";
				}//if else
				c++;
			}//foreach
			Response.Redirect("fAddPictures.aspx",true);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../main/fMain.aspx");
		}

		private void btnRemove1_Click(object sender, System.EventArgs e)
		{
			removeImage(1);
		}

		private void btnRemove2_Click(object sender, System.EventArgs e)
		{
			removeImage(2);
		}

		private void btnRemove3_Click(object sender, System.EventArgs e)
		{
			removeImage(3);
		}
	}//class
}//namespace

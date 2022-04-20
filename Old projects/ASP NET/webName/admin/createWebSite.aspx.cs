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

namespace webName.admin
{
	public class createWebSite : System.Web.UI.Page
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
		cDatabaseConnection connSubjects=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
		cDatabaseConnection connProducts=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
		string webName="";

		protected System.Web.UI.WebControls.Button btnReturn;
		protected System.Web.UI.WebControls.Image imgTemp;
		protected System.Web.UI.WebControls.Button btnCreate;

		private string readCommand(string s,int i,out int j)
		{
			string ret="";
			while(s.Substring(i,2)!="%>")
			{
				ret+=s.Substring(i,1);
				i++;
			}//while
			j=i+1;
			return ret;
		}//readCommand()

		private void createFile(string fileName,string subjectKey)
		{
			//read the source file
			TextReader tr=new StreamReader(Global.serverPath+@"admin\htm\"+fileName,System.Text.Encoding.UTF8);
			string defaultFile=tr.ReadToEnd();
			tr.Close();
			//create ret string for the dest file
			conn.createSelect("tblMain","*","fldWebName='"+webName+"'","","");
			DataTable tblMain=conn.runSelect();
			string color=tblMain.Rows[0]["fldColor"].ToString();
			string type=tblMain.Rows[0]["fldType"].ToString();
			string ret="";
			string command="";
			int i=0;
			while(i<defaultFile.Length)
			{
				if( (i<defaultFile.Length-1)&&(defaultFile.Substring(i,2)=="<%"))
				{
					i+=2;
					int j;
					command=readCommand(defaultFile,i,out j);
					i=j;

					if(command=="style")
					{
						string styleFileName="blue.css";
						string tableBackGroundImage="blue.jpg";
						if(color=="0")
						{
							styleFileName="blue.css";
							tableBackGroundImage="blue.jpg";
						}//if
						if(color=="1")
						{
							styleFileName="green.css";
							tableBackGroundImage="green.jpg";
						}//if
						if(color=="2")
						{
							styleFileName="brown.css";
							tableBackGroundImage="brown.jpg";
						}//if
						if(color=="3")
						{
							styleFileName="white.css";
							tableBackGroundImage="white.jpg";
						}//if
						File.Copy(Global.serverPath+@"admin\htm\"+styleFileName,Global.sitesPath+webName+@"\"+styleFileName,true);
						File.Copy(Global.serverPath+@"admin\htm\"+tableBackGroundImage,Global.sitesPath+webName+@"\"+tableBackGroundImage,true);
						ret+=styleFileName;
					}//if
					
					if(command=="realName")
					{
						ret+=tblMain.Rows[0]["fldRealName"].ToString();
					}//if
					
					if(command=="logoImage")
					{
						string imageName=tblMain.Rows[0]["fldLogoImage"].ToString();
						//copy image
						File.Copy(Global.imagesPath+imageName,Global.sitesPath+webName+@"\"+imageName,true);
						ret+=imageName;
					}//if
					
					if(command=="mainText")
					{
						ret+=tblMain.Rows[0]["fldMainText"].ToString();
					}//if
					
					if(command=="secondText")
					{
						ret+=tblMain.Rows[0]["fldSecondText"].ToString();
					}//if
					
					if(command=="mainImage")
					{
						string imageName=tblMain.Rows[0]["fldMainImage"].ToString();
						//copy image
						File.Copy(Global.imagesPath+imageName,Global.sitesPath+webName+@"\"+imageName,true);
						ret+=tblMain.Rows[0]["fldMainImage"].ToString();
					}//if
					
					if(command=="linksHorizonal")
					{
						connSubjects.createSelect("tblSubjects","*","fldWebName='"+webName+"'","fldIndex","");
						DataTable subjects=connSubjects.runSelect();
						//add home link
						ret+="<a href=main.htm target=frameMain>דף הבית</a>&nbsp&nbsp&nbsp";
						//add other links
						int pageIndex=1;
						foreach(DataRow row in subjects.Rows)
						{
							ret+="<a href="+row["fldKey"].ToString()+"page.htm target=frameMain >"+row["fldName"].ToString()+"</a>"+"&nbsp&nbsp&nbsp";
							pageIndex++;
						}//foreach
						ret+="<a href=about.htm target=frameMain>אודות</a>";
					}//if
					
					if(command=="products")
					{
						connProducts.createSelect("tblProducts","*","fldSubjectKey="+subjectKey,"fldIndex","");
						DataTable products=connProducts.runSelect();
						foreach(DataRow product in products.Rows)
						{
							ret+="<tr><td valign=top>";
							ret+=product["fldName"].ToString()+"<br>";
							ret+=product["fldText"].ToString();
							ret+="</td><td valign=middle align=center>";
							ret+="<img width=250 src="+product["fldImage"].ToString()+" >";
							ret+="</td></tr>";
							//copy product's image
							string imageName=product["fldimage"].ToString();
							if(imageName!="")
							{
								File.Copy(Global.imagesPath+imageName,Global.sitesPath+webName+@"\"+imageName,true);
							}//if
						}//foreach
					}//if
					
					if(command=="subject")
					{
						connSubjects.createSelect("tblSubjects","*","fldKey="+subjectKey,"","");
						DataTable subject=connSubjects.runSelect();
						ret+=subject.Rows[0]["fldName"].ToString();
					}//if

					if(command=="aboutText")
					{
						ret+=tblMain.Rows[0]["fldAbout"].ToString();
					}//if

					if(command=="address")
					{
						ret+=tblMain.Rows[0]["fldAddress"].ToString();
					}//if

					if(command=="phones")
					{
						ret+=tblMain.Rows[0]["fldPhone"].ToString()+"<br>";
						ret+=tblMain.Rows[0]["fldCellPhone"].ToString()+"<br>";
						ret+=tblMain.Rows[0]["fldFax"].ToString()+"<br>";
						ret+=tblMain.Rows[0]["fldEmail"].ToString()+"<br>";
					}//if

				}
				else
				{
					ret+=defaultFile.Substring(i,1);
				}//if else
				i++;
			}//while
			//write the dest file from ret
			TextWriter tw=new StreamWriter(Global.sitesPath+webName+@"\"+subjectKey+fileName,false,System.Text.Encoding.UTF8);
			tw.Write(ret);
			tw.Close();
		}//createFile()

		private void Page_Load(object sender, System.EventArgs e)
		{
			Session["webName"]="myFlowers";
			webName=Session["webName"].ToString();
			btnCreate.Text="Create: "+webName;
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
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCreate_Click(object sender, System.EventArgs e)
		{
			//create directory named: webName
			Directory.CreateDirectory(Global.sitesPath+webName);
			//get webName data from db
			conn.createSelect("tblMain","*","fldWebName='"+webName+"'","","");
			DataTable table=conn.runSelect();
			createFile("default.htm","");
			createFile("header.htm","");
			createFile("main.htm","");
			connSubjects.createSelect("tblSubjects","*","fldWebName='"+webName+"'","fldIndex","");
			DataTable subjects=connSubjects.runSelect();
			foreach(DataRow subject in subjects.Rows)
			{
				createFile("page.htm",subject["fldKey"].ToString());
			}//foreach
			createFile("about.htm","");

		}

		private void btnReturn_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("webName.aspx");
		}
	}//class
}//namespace

using System;
using anignoLibrary.ClassLibraryMdbConnection;
using anignoLibrary.utils;
using System.Data;
using System.IO;

namespace onlineMall
{
	public class cSimpleWeb
	{
		cDatabaseConnection conn=new cDatabaseConnection(Global.storeDataMdb,Global.ADMIN_PASSWORD);
		cDatabaseConnection connSubjects=new cDatabaseConnection(Global.storeDataMdb,Global.ADMIN_PASSWORD);
		string webName="";
		string storeKey="";
		DataRow storeDataRow;

		public cSimpleWeb(string storeKey)
		{
			this.storeKey=storeKey;
			conn.createSelect("tblStoreData","*","fldKey="+storeKey,"","");
			DataTable storeDataTable=conn.runSelect();
			storeDataRow=storeDataTable.Rows[0];
			webName=storeDataRow["fldWebName"].ToString();
			//create directory for webName in ROOT
			createDirectory(webName);
			//create htm pages
			createFile("default.htm","");
			createFile("header.htm","");
			createFile("main.htm","");
		}//cSimpleWeb()

		private void createDirectory(string directoryName)
		{
			Directory.CreateDirectory(Global.serverPath+webName);
		}//createDirectory()

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
			string color="0";
			string type="0";
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
						File.Copy(Global.serverPath+@"admin\htm\"+styleFileName,Global.serverPath+webName+@"\"+styleFileName,true);
						File.Copy(Global.serverPath+@"admin\htm\"+tableBackGroundImage,Global.serverPath+webName+@"\"+tableBackGroundImage,true);
						ret+=styleFileName;
					}//if
					
					if(command=="realName")
					{
						ret+=storeDataRow["fldName"].ToString();
					}//if
					
					if(command=="logoImage")
					{
						string imageName=storeDataRow["fldLogoImage"].ToString();
						//copy image
						File.Copy(Global.imagesPath+imageName,Global.serverPath+webName+@"\"+imageName,true);
						ret+=imageName;
					}//if
					
					if(command=="headerText")
					{
						ret+=storeDataRow["fldHeader"].ToString();
					}//if

					if(command=="descriptionText")
					{
						ret+=storeDataRow["fldDescription"].ToString();
					}//if
					
					
					if(command=="mainImage")
					{
						string imageName=storeDataRow["fldMainImage"].ToString();
						//copy image
						File.Copy(Global.imagesPath+imageName,Global.serverPath+webName+@"\"+imageName,true);
						ret+=storeDataRow["fldMainImage"].ToString();
					}//if
					
					if(command=="linksHorizonal")
					{
						connSubjects.createSelect("tblSubjects","*","fldStoreKey="+storeKey,"fldIndex","");
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
					
//					if(command=="products")
//					{
//						connProducts.createSelect("tblProducts","*","fldSubjectKey="+subjectKey,"fldIndex","");
//						DataTable products=connProducts.runSelect();
//						foreach(DataRow product in products.Rows)
//						{
//							ret+="<tr><td valign=top>";
//							ret+=product["fldName"].ToString()+"<br>";
//							ret+=product["fldText"].ToString();
//							ret+="</td><td valign=middle align=center>";
//							ret+="<img width=250 src="+product["fldImage"].ToString()+" >";
//							ret+="</td></tr>";
//							//copy product's image
//							string imageName=product["fldimage"].ToString();
//							if(imageName!="")
//							{
//								File.Copy(Global.imagesPath+imageName,Global.serverPath+webName+@"\"+imageName,true);
//							}//if
//						}//foreach
//					}//if
					
//					if(command=="subject")
//					{
//						connSubjects.createSelect("tblSubjects","*","fldKey="+subjectKey,"","");
//						DataTable subject=connSubjects.runSelect();
//						ret+=subject.Rows[0]["fldName"].ToString();
//					}//if

//					if(command=="aboutText")
//					{
//						ret+=tblMain.Rows[0]["fldAbout"].ToString();
//					}//if

//					if(command=="address")
//					{
//						ret+=tblMain.Rows[0]["fldAddress"].ToString();
//					}//if

//					if(command=="phones")
//					{
//						ret+=tblMain.Rows[0]["fldPhone"].ToString()+"<br>";
//						ret+=tblMain.Rows[0]["fldCellPhone"].ToString()+"<br>";
//						ret+=tblMain.Rows[0]["fldFax"].ToString()+"<br>";
//						ret+=tblMain.Rows[0]["fldEmail"].ToString()+"<br>";
//					}//if

				}
				else
				{
					ret+=defaultFile.Substring(i,1);
				}//if else
				i++;
			}//while
			//write the dest file from ret
			TextWriter tw=new StreamWriter(Global.serverPath+webName+@"\"+subjectKey+fileName,false,System.Text.Encoding.UTF8);
			tw.Write(ret);
			tw.Close();
		}//createFile()

	}//class
}//namespace

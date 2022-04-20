using System;
using anignoLibrary.ClassLibraryMdbConnection;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;


namespace webName
{
	public class cUtils
	{
		public static cDataItem[] fillDataArrayFromDb(string tableName)
		{
			cDatabaseConnection conn=new cDatabaseConnection(Global.mdbFile,Global.adminPassword);
			conn.createSelect(tableName,"*","","fldKey","");
			DataTable table=conn.runSelect();
			int size=table.Rows.Count;
			cDataItem[] ret=new cDataItem[size];
			int i=0;
			foreach(DataRow row in table.Rows)
			{
				ret[i++]=new cDataItem(row["fldData"].ToString(),row["fldKey"].ToString());
			}//for
			return ret;
		}//fillDataArrayFromDb()

		public static void fillDropDownListFromDataArray(DropDownList list,cDataItem[] array,string selectedValue)
		{
			for(int i=0;i<array.Length;i++)
			{
				ListItem item=new ListItem();
				item.Value=array[i].dataValue;
				item.Text=array[i].dataText;
				if(selectedValue==item.Value)item.Selected=true;
				list.Items.Add(item);
			}//for
		}//fillDropDownListFromDataArray()

		public static void setImageWidth(Image image,int maxHeight)
		{
			try
			{
				//use FileStream to get image properties
				FileStream fs=new FileStream(image.ImageUrl,FileMode.Open,FileAccess.Read,FileShare.Read);
				System.Drawing.Image Dimage=System.Drawing.Image.FromStream(fs);
				double heightFactor=maxHeight/(double)Dimage.Height;
				double width=(double)(Dimage.Width*heightFactor);
				double height=(double)(Dimage.Height*heightFactor);
				fs.Close();
				image.Width=(int)width;
				image.Height=(int)height;
				//add "?image=" to image name to force browser to download image from server
				image.ImageUrl=image.ImageUrl+"?image="+DateTime.Now.Ticks.ToString();
			}
			catch
			{
			}//catch
		}//setImageWidth()

		public static string getFileExtention(string fileName)
		{
			return fileName.Substring(fileName.LastIndexOf("."));
		}//getFileExtention()
		
		public cUtils()
		{
		}
	}//class
}//namespace

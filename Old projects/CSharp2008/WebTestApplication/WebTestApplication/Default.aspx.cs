using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebTestApplication
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string path = Server.MapPath("\\");
                string[] files = Directory.GetFiles(path + "\\images");
                foreach (string file in files)
                {
                    ListBoxFiles.Items.Add(file);
                    Image i = new Image();
                    Controls.Add(i);
                    i.ImageUrl = "/Images/" + Path.GetFileName(file);
                    i.Width = 100;
                    i.Height = 100;
                }
            }
        }

        protected void ButtonGetDate_Click(object sender, EventArgs e)
        {
            ListBoxDates.Items.Add(DateTime.Now.ToString());
        }

        protected void ListBoxDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            LabelSelectedDate.Text = ListBoxDates.SelectedValue;
        }

        protected void ListBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filePath = ListBoxFiles.SelectedValue;
            string f = Path.GetFileName(filePath);
            ImagePreview.ImageUrl = "/Images/" + f;

        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadImages.HasFile)
            {
                string path = Server.MapPath("\\");
                string filename = Path.GetFileName(FileUploadImages.FileName);
                FileUploadImages.SaveAs(path + "\\images\\" + filename);
                
            }
        }
    }
}
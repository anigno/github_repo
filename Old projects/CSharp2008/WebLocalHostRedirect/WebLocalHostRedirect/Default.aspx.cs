using System;
using System.Collections.Specialized;
using System.Threading;

//usage: http://www.anigno.somee.com/?SetHost=true

namespace WebLocalHostRedirect
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection keys = Request.QueryString;
            if (keys.Count > 0)
            {
                if (keys["SetHost"] != null)
                {
                    if (keys["SetHost"] == "true")
                    {
                        NameValueCollection serverVars = Request.ServerVariables;
                        string s = serverVars["REMOTE_ADDR"];
                        Application["REMOTE_ADDR"] = s;
                        Response.Write("Remote address set to: " + Application["REMOTE_ADDR"] + " at " + DateTime.Now);
                    }
                }
            }
            else
            {
                if (Application["REMOTE_ADDR"] != null)
                {
                    string s = Application["REMOTE_ADDR"].ToString();
                    if (s != null)
                    {
                        Response.Redirect("http://" + s);
                    }
                }
            }
        }
    }
}

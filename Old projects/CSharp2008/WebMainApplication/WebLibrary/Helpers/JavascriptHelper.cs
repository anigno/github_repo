using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebLibrary.Helpers
{
    public class JavascriptHelper 
    {
        public static void CreateAlertDialog(Page page,string text)
        {
            page.Response.Write("<script language=javascript>alert('" + text + "');</script>");
        }
    }
}

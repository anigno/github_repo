using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMainApplication.Library
{
    public partial class DatePicker : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalendarDate.SelectedDate = DateTime.Now;
                TextBoxDate.Text = CalendarDate.SelectedDate.Date.ToShortDateString();
            }
        }

        protected void ImageButtonShowCalendar_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDate.Visible=ImageButtonCancel.Visible=true;
            ImageButtonShowCalendar.Visible=false;
        }

        protected void CalendarDate_SelectionChanged(object sender, EventArgs e)
        {
            TextBoxDate.Text = CalendarDate.SelectedDate.Date.ToShortDateString();
            CalendarDate.Visible = ImageButtonCancel.Visible = false;
            ImageButtonShowCalendar.Visible = true;
        }

        protected void ImageButtonCancel_Click(object sender, ImageClickEventArgs e)
        {
            CalendarDate.Visible = ImageButtonCancel.Visible = false;
            ImageButtonShowCalendar.Visible = true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace VacationDenied
{
    public partial class RequestTimeOff : System.Web.UI.Page
    {
        public static List<DateTime> list = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = true;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected == true)
            {
                list.Add(e.Day.Date);
            }
            Session["SelectedDates"] = list;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                try
                {
                    List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                    List<int> dayInt = new List<int>();
                    bool flag = false;
                    foreach (DateTime dt in newList)
                    {
                        int dayTracker = Convert.ToInt32(dt.ToString("dd"));
                        dayInt.Add(dayTracker);
                    }
                    int index = 1;
                    for (int i = 0; i < dayInt.Count - 1; i++)
                    {
                        if (dayInt[i] + 1 < dayInt[index])
                        {
                            flag = true;
                        }
                        index++;
                    }
                    if (flag)
                    {
                        throw new FormatException();
                    }
                    int length = newList.Count - 1;
                    string startDate = newList[0].ToString("yyyy-MM-dd");
                    string endDate = newList[length].ToString("yyyy-MM-dd");
                    string status = "pending";
                    // Enter into Database here

                } catch (FormatException)
                {
                    string Message = "Please enter a sequence of Start Date and End Date and submit each one seperately, Success Example: Monday 1 Tuesday 2 Wednesday 3...Error Example: Monday 1 Thursday 4 Friday 5";
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('" + Message + "')", true);
                    
                }

            } 

                //write to database with status of pending for admin to check
                //clear session
                //have pop up "successfuly scheduled"

        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Calendar1.SelectedDates.Clear();
            Session["SelectedDates"] = list;
            list.Clear();
        }

    }
}
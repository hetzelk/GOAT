using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace VacationDenied
{
    public partial class RequestTimeOff : System.Web.UI.Page
    {
        private string currentUserId;
        public static List<DateTime> list = new List<DateTime>();
        public Models.ApplicationUser currentUser;
        public ApplicationUserManager manager;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUserId = HttpContext.Current.User.Identity.GetUserId();
            manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            currentUser = manager.FindById(User.Identity.GetUserId());
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
                    List<int> ids = new List<int>();
                    Models.VacationDate date = new Models.VacationDate();
                    date.StartDate = DateTime.Parse(startDate);
                    date.EndDate = DateTime.Parse(endDate);
                    date.EmployeeID = currentUserId;
                    date.Status = status;
                    date.Description = Description.Text;
                    Models.DataClasses1DataContext vacaManager = new Models.DataClasses1DataContext();
                    var dates = vacaManager.GetTable<Models.VacationDate>();
                    var q =
                    from c in vacaManager.VacationDates
                    where c.EmployeeID == currentUserId
                    select c;
                    foreach (Models.VacationDate c in q)
                    {
                        ids.Add(c.Id);
                    }
                    int Id = ids.Count + 2;
                    date.Id = Id;
                    vacaManager.VacationDates.InsertOnSubmit(date);
                    vacaManager.SubmitChanges();
                    currentUser.VacationDays -= dayInt.Count;
                    manager.Update(currentUser);


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
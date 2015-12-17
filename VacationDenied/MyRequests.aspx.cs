using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System.Data.SqlClient;
using System.Data;

namespace VacationDenied
{
    public partial class MyRequests : System.Web.UI.Page
    {
        public List<Models.VacationDate> dates;
        public string startTime;
        protected void Page_init(object sender, EventArgs e)
        {
            Models.DataClasses1DataContext manager = new Models.DataClasses1DataContext();
            dates = new List<Models.VacationDate>();
            Models.VacationDate empty = new Models.VacationDate();
            dates.Add(empty);
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var Umanager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUser = Umanager.FindById(User.Identity.GetUserId());
            var q =
            from c in manager.VacationDates
            where c.EmployeeID == currentUserId
            select c;
            foreach (Models.VacationDate c in q)
            {
                dates.Add(c);
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = dates;
                DropDownList1.DataTextField = "StartDate";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataBind();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dates.Count != 0)
            {
                DropDownList1.DataBind();
                Label1.Text = dates[DropDownList1.SelectedIndex].StartDate.ToString();
                Label2.Text = dates[DropDownList1.SelectedIndex].EndDate.ToString();
                Label3.Text = dates[DropDownList1.SelectedIndex].Description;
                Label4.Text = dates[DropDownList1.SelectedIndex].Status;
            }
        }
    }
}

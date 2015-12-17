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
    public partial class RequestReview : System.Web.UI.Page
    {
        public List<Models.VacationDate> dates;
        public List<string> dateStrngs;
        public string startTime;
        protected void Page_init(object sender, EventArgs e)
        {
            Models.DataClasses1DataContext manager = new Models.DataClasses1DataContext();
            dates = new List<Models.VacationDate>();
            dateStrngs = new List<string>();
            Models.VacationDate empty = new Models.VacationDate();
            dates.Add(empty);
            var q =
            from c in manager.VacationDates
            where c.Status == "pending"
            select c;
            foreach (Models.VacationDate c in q)
            {
                dates.Add(c);
                dateStrngs.Add(c.EmployeeID);
            }
            if (!IsPostBack)
            {
                DropDownList1.DataSource = dates;
                DropDownList1.DataTextField = "Id";
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
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var currentUser = manager.FindById(dates[DropDownList1.SelectedIndex].EmployeeID);
                Label4.Text = currentUser.firstName + currentUser.lastName;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Models.DataClasses1DataContext manager = new Models.DataClasses1DataContext();
            var q =
            from c in manager.VacationDates
            where c.Id == dates[DropDownList1.SelectedIndex].Id
            select c;
            foreach (Models.VacationDate c in q)
            {
                c.Status = "accepted";
                manager.SubmitChanges();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Models.DataClasses1DataContext manager = new Models.DataClasses1DataContext();
            var q =
            from c in manager.VacationDates
            where c.Id == dates[DropDownList1.SelectedIndex].Id
            select c;
            foreach (Models.VacationDate c in q)
            {
                c.Status = "denied";
                manager.SubmitChanges();
            }
        }
    }
}

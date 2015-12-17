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
        protected void Page_Load(object sender, EventArgs e)
        {
            Models.DataClasses1DataContext manager = new Models.DataClasses1DataContext();
            dates = new List<Models.VacationDate>();
            dateStrngs = new List<string>();
            var q =
            from c in manager.VacationDates
            where c.Status == "pending"
            select c;
            foreach (Models.VacationDate c in q)
            {
                dates.Add(c);
                dateStrngs.Add(c.EmployeeID);

            }
            DropDownList1.DataSource = dates;
            DropDownList1.DataTextField = "Description";
            DropDownList1.DataBind();
        }
    }
}
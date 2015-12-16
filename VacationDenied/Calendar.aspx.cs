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
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var datess = new List<Models.VacationDate>();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var currentUser = manager.FindByEmail("what@what.ocm");
            var currentUserId = currentUser.Id;
            Models.DataClasses1DataContext poop = new Models.DataClasses1DataContext();
            var dates = poop.GetTable<VacationDenied.Models.VacationDate>();
            var q =
            from c in poop.VacationDates
            where c.EmployeeID == currentUserId
            select c;
            foreach (Models.VacationDate c in q)
            {
                datess.Add(c);
            }
        }
    }
}
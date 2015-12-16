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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var currentUser = manager.FindById(User.Identity.GetUserId());
            //var currentUser = manager.FindByEmail("admin@admin.com");
            //currentUser.LockoutEnabled = false;            
            //manager.Delete(currentUser);
            //currentUser.firstName = "Cool guy ";
            //manager.Update(currentUser);
            //Models.VacationDate date = new Models.VacationDate();
            //date.StartDate = DateTime.Parse("2015-12-12");
            //date.EndDate = DateTime.Parse("2015-12-13");
            //date.EmployeeID = currentUserId;
            //date.Status = "pending";
            //date.Id = "1";
            //Models.DataClasses1DataContext poop = new Models.DataClasses1DataContext();
            //poop.VacationDates.InsertOnSubmit(date);
            //poop.SubmitChanges();

        }
    }
}

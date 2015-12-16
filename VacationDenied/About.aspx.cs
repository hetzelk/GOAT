using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web;
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
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var currentUser = manager.FindById(User.Identity.GetUserId());
            var currentUser = manager.FindByEmail("jbreezy@wtf.com");
            manager.Delete(currentUser);
            //currentUser.firstName = "Cool guy ";
            //manager.Update(currentUser);

        }

    }
}
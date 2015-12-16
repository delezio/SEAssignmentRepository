using SteveDelezioSEAssignment2Sit1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace SteveDelezioSEAssignment2Sit1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private DataContext db = new DataContext();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (Request.IsAuthenticated == true)
                {
                    // Debug#1            
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Context.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                    // In this case, ticket.UserData = "Admin"     
                    string role = db.tbl_Users.SingleOrDefault(x => x.Username == Context.User.Identity.Name).tbl_Roles.RoleName;
                    string[] roles = new string[1] { role };
                    FormsIdentity id = new FormsIdentity(ticket);                  
                    Context.User = new System.Security.Principal.GenericPrincipal(Context.User.Identity, roles);
                    
                  
                    // Debug#2
                }
            }
        }
    }
}

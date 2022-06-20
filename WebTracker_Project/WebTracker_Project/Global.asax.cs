using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace WebTracker_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;            
        }
        void Session_Start(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                //do things that need to happen
                //when a new session starts.
                Session.Timeout = 600;
            }
        }
    }
}

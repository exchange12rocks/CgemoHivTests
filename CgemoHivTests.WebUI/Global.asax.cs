using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CgemoHivTests.WebUI.App_Start;
using System.Web.Optimization;

namespace CgemoHivTests.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectWebCommon._kernel.Inject(System.Web.Security.Membership.Provider);
        }
    }
}

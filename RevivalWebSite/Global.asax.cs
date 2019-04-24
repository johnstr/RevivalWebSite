using RevivalWebSite.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RevivalWebSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new RevivalDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Language"];
            CultureInfo ci = new CultureInfo("en");
            if (cookie != null && cookie.Value != null)
            {
                ci = new System.Globalization.CultureInfo(cookie.Value);
            }
            else
            {
                string[] userLang = HttpContext.Current.Request.UserLanguages;
                if (userLang.Count() > 0)
                {
                    if (userLang[0].Contains("en") || userLang[0].Contains("uk"))
                    {
                        try
                        {
                            ci = new CultureInfo(userLang[0]);
                        }
                        catch (CultureNotFoundException)
                        {
                        }

                    }
                }
           }
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

    }
}

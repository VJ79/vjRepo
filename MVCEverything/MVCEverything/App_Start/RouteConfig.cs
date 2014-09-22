using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCEverything
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); 

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //constraints: new  { id="2"},
                namespaces: new string[] { "StudentManagement", "MVCEverything" }
            );

            routes.MapRoute(
              name: "Default1",
              url: "{controller}/{action}/{name}",
              defaults: new { controller = "Home", action = "Index" }
          );
        }
    }
}

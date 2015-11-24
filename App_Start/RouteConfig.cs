using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SupplementsPlannerWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "SupplementsPlanner", action = "Index" }
            );
            routes.MapRoute(
                name: "GetSupplements",
                url: "{controller}/{action}/{type}",
                defaults: new { controller = "SupplementsPlanner", action = "GetSupplements", type = UrlParameter.Optional }  
            );
            routes.MapRoute(
                name: "GetSupplementRelations",
                url: "{controller}/{action}/{id}/{type}",
                defaults: new { controller = "SupplementsPlanner", action = "GetSupplementRelations", id = UrlParameter.Optional, type = UrlParameter.Optional }  
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace thu_project2_cnt1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "Admin",
                 url: "Admin/{action}/{id}",
                 defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }

            );
        }
    }
}

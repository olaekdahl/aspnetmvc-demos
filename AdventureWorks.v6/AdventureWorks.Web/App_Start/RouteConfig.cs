﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdventureWorks.Controllers;

namespace AdventureWorks.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //namespaces: new[] { "AdventureWorks.Controllers" },
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                
            );
        }
    }
}

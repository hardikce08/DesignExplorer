using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DesignExplorer.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "EmailTemplate_List",
               url: "EmailTemplate",
               defaults: new { controller = "EmailTemplate", action = "Index", id = UrlParameter.Optional } 
           );
            routes.MapRoute(
              name: "EmailTemplate_Edit",
              url: "EmailTemplate/Edit/{id}",
              defaults: new { controller = "EmailTemplate", action = "Add", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Dashboard", id = UrlParameter.Optional },
                 new[] { "DesignExplorer.Web.Controllers" }
            );
        }
    }
}

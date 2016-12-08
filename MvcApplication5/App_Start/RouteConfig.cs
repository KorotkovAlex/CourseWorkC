using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Index",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Details",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Edit",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Create",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Admin", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "IndexW",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Worker", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CreateW",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Worker", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DeleteW",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Worker", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DetailsW",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Worker", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditW",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Worker", action = "Edit", id = UrlParameter.Optional }
            );

           
        }

    }
}
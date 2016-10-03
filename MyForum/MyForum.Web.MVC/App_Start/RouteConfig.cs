using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyForum.Web.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "TopicAddPost",
            //    "Post/{action}", // URL with parameters
            //    new { controller = "Post", action = "AddPost" } // Parameter defaults
            //);

            //routes.MapRoute(
            //    name: "Actions",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = "Home", action = "Index"}
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




        }
    }
}

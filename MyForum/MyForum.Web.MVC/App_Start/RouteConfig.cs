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

            routes.MapRoute(
                "TopicUrls",
                "Topic/{id}", // URL with parameters
                new { controller = "Topic", action = "Show", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "TopicCategoryUrls",
                "TopicCategory/{id}", // URL with parameters
                new { controller = "TopicCategory", action = "Show", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "MainCategoryUrls", 
                "MainCategory/{id}", // URL with parameters
                new { controller = "MainCategory", action = "Show", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );




        }
    }
}

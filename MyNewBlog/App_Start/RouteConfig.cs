using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyNewBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Manage",
              url: "Manage/{controller}/{action}/{id}",
              defaults: new { controller = "Articles", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Home",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );

           

            routes.MapRoute(
               name: "Login",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
           );

          

          
            routes.MapRoute(
                name: "Archives",
                url: "{controller}/{action}/{name}/{categoryId}"
            );
        }
    }
}

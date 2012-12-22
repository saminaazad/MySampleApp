﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MySampleApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Products/Detail",
               "products/{id}",
               new { controller = "Products", action = "Product" }
            );
            
            routes.MapRoute(
                "Product/Details",
                "items/{id}",
                new { controller = "Products", action = "Action", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
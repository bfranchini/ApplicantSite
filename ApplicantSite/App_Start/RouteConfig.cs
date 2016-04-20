using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApplicantSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "routeOne",
                url: "routesDemo/One",
                defaults: new { controller = "routesDemo", action = "One" });

            routes.MapRoute(
                name: "routeTwo",
                url: "routesDemo/Two/{donuts}",
                defaults: new { controller = "routesDemo", action = "Two", donuts = UrlParameter.Optional });

            routes.MapRoute(
                name: "routeThree",
                url: "routesDemo/Three",
                defaults: new { controller = "routesDemo", action = "Three" });

            routes.MapRoute(
                name: "login",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "register",
                url: "Account/Register",
                defaults: new { controller = "Account", action = "Register" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{*url}",
            //    defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Applicant", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pipewellservice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allActiveReport}", new { allActiveReport = @".*\.ar8(/.*)?" });

            routes.MapRoute(
                name: "PersonalDetails",
                url: "PersonalDetail",
                defaults: new { controller = "Home", action = "PersonalDetail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ProcurementStore",
                url: "{controller}/Store/{action}/{id}",
                defaults: new { controller = "Procurement", action = "Index", id = UrlParameter.Optional }
            );



            routes.MapRoute(
                name: "ProcurementPurchase",
                url: "{controller}/Purchase/{action}/{id}",
                defaults: new { controller = "Procurement", action = "Index", id = UrlParameter.Optional }
            );



            routes.MapRoute(
               name: "LoginID",
               url: "",
               defaults: new { controller = "Auth", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}

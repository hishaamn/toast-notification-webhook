using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Sitecore.Experiment.Webhook
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "NotificationApi",
                routeTemplate: "notification/read",
                //defaults: new { id = RouteParameter.Optional },
                new { controller = "Webhook", action = "TestGet" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}

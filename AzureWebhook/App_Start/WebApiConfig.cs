using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AzureWebhook
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //Testing some more
            config.InitializeReceiveKuduWebHooks();
            config.InitializeReceiveAzureAlertWebHooks();
            config.InitializeReceiveSlackWebHooks();
        }
    }
}

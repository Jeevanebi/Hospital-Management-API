using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;

namespace HospitalManagementAPI
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

            config.Routes.MapHttpRoute(
                name: "",
                routeTemplate: "api/{controller}/{func}/{id}",
                defaults: new
                {
                    func = RouteParameter.Optional,
                    id = UrlParameter.Optional
                }
                );
            
        }

         
    }
}

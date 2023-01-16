using HospitalManagementAPI.Repository;
using HospitalManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Microsoft.Owin.Security.OAuth;

namespace HospitalManagementAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WebServiceLayer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "PostApi",
                routeTemplate: "api/post/{action}/{postId}",
                defaults: new { controller = "Post" }
            );

            config.Routes.MapHttpRoute(
              name: "SearchApi",
              routeTemplate: "api/search/{statement}",
              defaults: new { controller = "Search" }
            );


            config.Routes.MapHttpRoute(
                name: "HistoryApi",
                routeTemplate: "api/history/{id}",
                defaults: new { controller = "History", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "MarkApi",
                routeTemplate: "api/mark/{id}",
                defaults: new { controller = "Mark", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/user/{id}",

                defaults: new { controller = "User" }
            );


            config.Routes.MapHttpRoute(
                name: "CommentApi",
                routeTemplate: "api/comment/{action}/{id}",
                defaults: new { controller = "Comment" }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver
               = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Blog.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ActionAndIdApi",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new
                {
                }
            );

            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { 
                }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

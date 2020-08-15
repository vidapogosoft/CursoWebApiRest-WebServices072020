﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.Http.Cors;

namespace DemoDevWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            //Formateo salida en Json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //Habilitando Cors
            var urlPermitidas = new EnableCorsAttribute("*"
                                                ,"*","*");
            config.EnableCors(urlPermitidas);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

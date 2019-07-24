using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace GENXAPI.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_BeginRequest()
        //{

        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        //These headers are handling the "pre-flight" OPTIONS call sent by the browser
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Origin,Accept,X-Requested-With,Content-Type,Access-Control-Request-Method,Access-Control-Request-Headers,Authorization");
        //        HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "60");
        //        HttpContext.Current.Response.End();
        //    }

        //}
    }
}

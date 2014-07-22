using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace Ploeh.Samples.BookingApi
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultAPI",
                routeTemplate: "{controller}/{id}",
                defaults: new { Controller = "Home", Id = RouteParameter.Optional });

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}
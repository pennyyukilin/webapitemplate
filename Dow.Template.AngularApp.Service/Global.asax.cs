using Dow.Template.AngularApp.Common;
using Microsoft.ApplicationInsights.Extensibility;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Dow.Template.AngularApp.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            TelemetryConfiguration.Active.InstrumentationKey = CommonConfig.InstrumentationKey;

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.RegisterComponents();

            // Config web api result as JSON camel case format
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Config log4net
            log4net.Config.XmlConfigurator.Configure();

        }
    }
}

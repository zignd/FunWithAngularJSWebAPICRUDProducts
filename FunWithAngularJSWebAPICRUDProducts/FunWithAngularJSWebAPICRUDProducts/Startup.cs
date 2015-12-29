using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

/// This assembly attribute directs Microsoft.Owin to use the Startup class
/// defined in this file as the start of our application
[assembly: OwinStartup(typeof(FunWithAngularJSWebAPICRUDProducts.Startup))]

namespace FunWithAngularJSWebAPICRUDProducts
{
    public partial class Startup
    {
        /// <summary>
        /// Used to create an instance of the Web application 
        /// </summary>
        /// <param name="app">Parameter supplied by OWIN implementation which our configuration is connected to</param>
        public void Configuration(IAppBuilder app)
        {
            // MVC
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // Web API
            HttpConfiguration config = new HttpConfiguration();
            // Handles registration of the Web API's routes
            WebApiConfig.Register(config);
            // Enables us to call the Web API from domains other than the ones the API responds to
            app.UseCors(CorsOptions.AllowAll);
            // Wire-in the authentication middleware
            ConfigureAuth(app);
            // Add the Web API framework to the app's pipeline
            app.UseWebApi(config);
        }
    }
}

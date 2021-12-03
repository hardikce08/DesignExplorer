using Hangfire;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(DesignExplorer.Web.Startup))]

namespace DesignExplorer.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // GlobalConfiguration.Configuration
           //.UseSqlServerStorage(ConfigurationManager.AppSettings["HangfireDbConnectionStringKey"]);
           // //app.UseHangfireDashboard();
           // //app.UseHangfireServer();
           // var options = new BackgroundJobServerOptions { WorkerCount = Environment.ProcessorCount * 5 };
           // app.UseHangfireServer(options);
           // //// Change `Back to site` link URL
           // //var options = new DashboardOptions { AppPath = "http://your-app.net" };
           // //// Make `Back to site` link working for subfolder applications
           // //var options1 = new DashboardOptions { AppPath = VirtualPathUtility.ToAppRelative("~")+"/BulkUpload/Index" };
           // var options1 = new DashboardOptions
           // {
           //     AppPath = null
           // };
           // app.UseHangfireDashboard("/hangfire", options1);
        }
    }
}
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Web.Optimization;

namespace rgn_rss_application
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            var styles = new StyleBundle("~/Content/bundledcss")
                .Include("~/Content/site.css",
                        "~/Content/bootstrap.min.css");

            var js = new ScriptBundle("~/Scripts/bundledjs").Include("~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/modernizr-2.6.2.js");

            var cdn = new ScriptBundle("~/Scripts/bundledjsCDN", "http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.0.0.js");

            bundles.UseCdn = true;
            bundles.Add(styles);
            bundles.Add(js);
            bundles.Add(cdn);
            BundleTable.EnableOptimizations = true;
        }
    }
}
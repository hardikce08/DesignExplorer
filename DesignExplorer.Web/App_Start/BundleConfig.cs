using System.Web;
using System.Web.Optimization;

namespace DesignExplorer.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/DashboardCSS").Include(
                    "~/Theme/Css/bootstrap.css",
                    "~/Theme/Css/font-awesome.min.css",
                    "~/Theme/Css/magnific-popup.css",
                    "~/Theme/Css/datepicker3.css",
                    "~/Theme/Css/jquery-ui-1.10.4.custom.min.css",
                    "~/Theme/Css/bootstrap-multiselect.css",
                    "~/Theme/Css/morris.css",
                    "~/Theme/Css/pnotify.custom.css",
                    "~/Theme/Css/datatables.css",
                    "~/Theme/Css/theme.css",
                    "~/Theme/Css/default.css",
                    "~/Theme/Css/theme-custom.css"));
        }
    }
}

using System.Web;
using System.Web.Optimization;

namespace RevivalWebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery.unobtrusive-ajax.js",
                         "~/Scripts/jquery.ui.widget.js",
                         "~/Scripts/jquery.iframe-transport",
                         "~/Scripts/jquery.fileupload.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap.bundle.js",
                      "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/revival-style.css",
                      "~/Content/css/custom-carousel.css",
                      "~/Content/css/jquery.fileupload.css",
                      "~/Content/css/simple-sidebar.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                     "~/Scripts/moment.min.js",
                     "~/Scripts/bootstrap-datetimepicker.min.js"
                     ));

          
        }
    }
}

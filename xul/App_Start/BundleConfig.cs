using System.Web;
using System.Web.Optimization;

namespace xul
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery-ui.unobtrusive-{version}.js"));

           
           

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/assets/js/jquery-1.10.2.js",
                "~/assets/js/bootstrap.min.js",
                "~/assets/js/jquery.metisMenu.js",
                "~/assets/js/morris/raphael-2.1.0.min.js",
                "~/assets/js/morris/morris.js",
                "~/assets/js/easypiechart.js",
                "~/assets/js/easypiechart-data.js",
                "~/assets/js/Lightweight-Chart/jquery.chart.js",
                "~/assets/js/custom-scripts.js",
                "~/DataTables/DataTables-1.10.18/js/jquery.dataTables.min.js",
                "~/assets/js/dataTables/jquery.dataTables.js",
                "~/assets/js/dataTables/dataTables.bootstrap.js",
                "~/Scripts/jquery-3.1.1.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                //"~/Content/bootstrap.css",
                "~/assets/css/bootstrap.css",
                "~/assets/css/font-awesome.css",
                "~/assets/js/morris/morris-0.4.3.min.css",
                "~/DataTables/DataTables-1.10.18/css/jquery.dataTables.css",
                "~/DataTables/DataTables-1.10.18/css/jquery.dataTables.min.css",
                "~/assets/css/custom-styles.css",
                "~/assets/js/dataTables/dataTables.bootstrap.css"
            ));
        }
    }
}
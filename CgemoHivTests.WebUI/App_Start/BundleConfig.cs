//using System;
//using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CgemoHivTests.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunob").Include(
                "~/Scripts/jquery.unobtrusive-ajax*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js", 
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                "~/Scripts/script.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/bootstrap-theme.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/bootstrap-datetimepicker.css",
                "~/Content/bootstrap-datetimepicker.min.css",
                "~/Content/site.css"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AstAppWebApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //JS BUNDLES
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            var bundle = new ScriptBundle("~/bundles/jqueryval").Include(
                           "~/Scripts/jquery.validate*");

            bundle.Orderer = new PassthruBundleOrderer();
            bundles.Add(bundle);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/unobtrusive-ajax").Include(
                      "~/Scripts/jquery.unobtrusive-ajax.js"));

            //Generics
            bundles.Add(new ScriptBundle("~/bundles/Generics").Include(
                "~/Scripts/Generic/AjaxUtils.js"              
                ));

            //AstApp Defaults
            bundles.Add(new ScriptBundle("~/bundles/AstAppDefaults").Include(
                "~/Scripts/Shared/AstAppObjAndStruct.js",
                "~/Scripts/Shared/AstAppShared.js"
                ));

            

            //CSS BUNDLES
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


        }

        class PassthruBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }
        }
    }
}

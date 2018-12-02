using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace ManagerUser
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/WebFormsJs").Include(
            //                "~/Content/Scripts/WebForms/WebForms.js",
            //                "~/Content/Scripts/WebForms/WebUIValidation.js",
            //                "~/Content/Scripts/WebForms/MenuStandards.js",
            //                "~/Content/Scripts/WebForms/Focus.js",
            //                "~/Content/Scripts/WebForms/GridView.js",
            //                "~/Content/Scripts/WebForms/DetailsView.js",
            //                "~/Content/Scripts/WebForms/TreeView.js",
            //                "~/Content/Scripts/WebForms/WebParts.js"));

            //// Order is very important for these files to work, they have explicit dependencies
            //bundles.Add(new ScriptBundle("~/bundles/MsAjaxJs").Include(
            //        "~/Content/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
            //        "~/Content/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
            //        "~/Content/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
            //        "~/Content/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //                "~/Content/Scripts/modernizr-*"));

            //ScriptManager.ScriptResourceMapping.AddDefinition(
            //    "respond",
            //    new ScriptResourceDefinition
            //    {
            //        Path = "~/Content/Scripts/respond.min.js",
            //        DebugPath = "~/Content/Scripts/respond.js",
            //    });
        }
    }
}
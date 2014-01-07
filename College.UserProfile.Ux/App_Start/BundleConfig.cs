using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace College.UserProfile.Ux
{
    public class BundleConfig
    {
        public static void RegisterBundles()
        {
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/scripts/jquery-{version}.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/scripts/knockout-{version}.js"));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/knockout-validation").Include("~/scripts/knockout.validation.debug.js"));
            BootstrapBundleConfig.RegisterBundles();
        }
    }
}
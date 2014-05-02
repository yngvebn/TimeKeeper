using System.Web.Optimization;

namespace ManageTime
{
    public static class BundleConfig
    {
        public static void Register(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/lib").Include("~/Scripts/angular.js", "~/Scripts/moment.js"));
            bundles.Add(new ScriptBundle("~/js/app").Include("~/app/app.js")
                .IncludeDirectory("~/app/mapping", "*.js", true)
                .IncludeDirectory("~/app/", "*.js", true));
        }
    }
}
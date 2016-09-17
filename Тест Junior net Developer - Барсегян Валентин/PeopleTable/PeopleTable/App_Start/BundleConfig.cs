using System.Web.Optimization;

namespace PeopleTable
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/JqBt").Include(
                        "~/Scripts/jquery-3.1.0.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/signin/css").Include(
                        "~/Content/signin.css"));

            bundles.Add(new StyleBundle("~/register/css").Include(
                        "~/Content/register.css"));

            bundles.Add(new StyleBundle("~/people.css").Include(
                        "~/Content/people.css"));
        }
    }
}

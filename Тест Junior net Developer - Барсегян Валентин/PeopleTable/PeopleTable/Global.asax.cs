using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;

namespace PeopleTable
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            NewtonsoftJsonConfig.JsonSttings();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}

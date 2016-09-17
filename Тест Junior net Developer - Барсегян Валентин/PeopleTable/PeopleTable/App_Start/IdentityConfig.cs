using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PeopleTable;
using PeopleTable.EntityFramework;
using PeopleTable.Identity;

[assembly: OwinStartup(typeof(IdentityConfig))]
namespace PeopleTable
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new PeopleDbContext());
            app.CreatePerOwinContext<PeopleUserManager>(PeopleUserManager.Create);
            //app.CreatePerOwinContext<RoleManager<PeopleRole>>((options, context) =>
            //    new RoleManager<PeopleRole>(
            //        new RoleStore<PeopleRole>(context.Get<MyDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Authentication/Login")
            });
        }
    }
}

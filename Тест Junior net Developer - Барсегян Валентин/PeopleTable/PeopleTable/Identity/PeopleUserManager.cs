using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PeopleTable.EntityFramework;
using PeopleTable.Models;

namespace PeopleTable.Identity
{
    public class PeopleUserManager : UserManager<PeopleUser>
    {
        public PeopleUserManager(IUserStore<PeopleUser> store)
        : base(store)
    {
        }


        public static PeopleUserManager Create(
            IdentityFactoryOptions<PeopleUserManager> options, IOwinContext context)
        {
            var manager = new PeopleUserManager(
                new UserStore<PeopleUser>(context.Get<PeopleDbContext>()));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            return manager;
        }
    }
}

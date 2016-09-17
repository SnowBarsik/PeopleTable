using Microsoft.AspNet.Identity.EntityFramework;

namespace PeopleTable.Models
{
    public class PeopleUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

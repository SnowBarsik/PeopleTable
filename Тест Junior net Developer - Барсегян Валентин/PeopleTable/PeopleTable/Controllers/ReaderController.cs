using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PeopleTable.Identity;
using PeopleTable.Models;
using PeopleTable.Repository;
using static System.Net.HttpStatusCode;

namespace PeopleTable.Controllers
{
    [Authorize]
    public class ReaderController : ApiController
    {
        private readonly JsonReaderRepository _reader;
        private readonly PeopleRepository _peopleRepository;
        public ReaderController()
        {
            _reader = new JsonReaderRepository();
            _peopleRepository = new PeopleRepository();
        }

        [HttpGet]
        [Route("read/accounts")]
        public  IHttpActionResult ReadAccounts()
        {
            PeopleUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<PeopleUserManager>();
            var accounts = _reader.ReadPeopleUsers();
            foreach (var account in accounts)
            {
                var user = new PeopleUser()
                { UserName = account.Login, Name = account.Name };
                var result = userManager.Create(user, account.Password);
            }
            return Ok();
        }

        [HttpGet]
        [Route("read/people")]
        public IHttpActionResult ReadPeople()
        {
            var people = _reader.ReadPeople();
            _peopleRepository.AddPeople(people);
            return Ok();
        }
    }
}

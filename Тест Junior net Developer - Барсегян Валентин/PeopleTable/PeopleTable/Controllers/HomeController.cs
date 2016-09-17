using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PeopleTable.EntityFramework;
using PeopleTable.Models;
using PeopleTable.Repository;
using PeopleTable.ViewModels;

namespace PeopleTable.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly PeopleRepository _peopleRepository;
        private readonly JsonReaderRepository _readerRepo;
        public HomeController()
        {
            _peopleRepository = new PeopleRepository();
            _readerRepo = new JsonReaderRepository();
        }

        public ActionResult People(int? page, int? pageSize, string filter)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            var startIndex = (page - 1) * pageSize;

            var people = filter != null ? _peopleRepository.GetFilteredPeople(filter) : _peopleRepository.GetPeople();
            
            var pager = new Pager(people.Count, page, (int) pageSize);

            var peopleModel = new PeopleViewModel()
            {
                People = people.Skip((int) startIndex).Take((int) pageSize).ToList(),
                Pager = pager

            };
            ViewBag.Title = "People";
            return View(peopleModel);
        }

        public ActionResult Person(string id)
        {
            var person = _peopleRepository.GetPerson(id);
            if (person == null) RedirectToAction("People", "Home");

            var userId = User.Identity.GetUserId();
            var user = _peopleRepository.GetUserById(userId);
            if (user != null) ViewBag.Name = user.Name;

            return View(person);
        }
    }
}
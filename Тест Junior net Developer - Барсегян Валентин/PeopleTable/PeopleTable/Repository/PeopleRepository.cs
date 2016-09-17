using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleTable.EntityFramework;
using PeopleTable.Interfaces;
using PeopleTable.Models;

namespace PeopleTable.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleDbContext _context;

        public PeopleRepository()
        {
            _context = new PeopleDbContext();
        }

        public void AddPeople(List<Person> people)
        {
            foreach (var person in people)
            {
                if (_context.People.FirstOrDefault(p => p.Guid == person.Guid) == null)
                {
                    _context.People.Add(person);
                }
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void UpdatePersonDateTime(List<Person> people)
        {
            foreach (var person in people)
            {
                var personeUpDate = _context.People.SingleOrDefault(p => p.Guid == person.Guid);
                personeUpDate.Registered = person.Registered;
                _context.SaveChanges();
            }
        }

        public List<Person> GetPeople(int startIndex, int count)
        {
            var people = _context.People.Skip(startIndex).Take(count).Include(p => p.TagList).ToList();
            return people;
        }

        public List<Person> GetPeople()
        {
            var people = _context.People.Include(p => p.TagList).ToList();
            return people;
        }

        public List<Person> GetFilteredPeople(string filter)
        {
            var people = _context.People
                .Where(p => p.TagList.Any(t => t.Name == filter))
                .Include(p => p.TagList)
                .ToList();

            return people;
        }

        public Person GetPerson(string id)
        {
            var person = _context.People.SingleOrDefault(p => p.Guid == id);
            return person;
        }

        public PeopleUser GetUserById(string id)
        {
            var user =_context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        } 

    }
}

using System.Collections.Generic;
using PeopleTable.Models;

namespace PeopleTable.Interfaces
{
    public interface IPeopleRepository
    {
        void AddPeople(List<Person> people);
        void UpdatePersonDateTime(List<Person> people);
        List<Person> GetPeople(int startIndex, int count);
        List<Person> GetPeople();
        List<Person> GetFilteredPeople(string filter);
        Person GetPerson(string id);
        PeopleUser GetUserById(string id);
    }
}
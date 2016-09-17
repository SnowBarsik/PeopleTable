using System.Collections.Generic;
using PeopleTable.Models;
using PeopleTable.ViewModels;

namespace PeopleTable.Interfaces
{
    public interface IJsonReaderRepository
    {
        List<Person> ReadPeople();
        List<RegisterViewModel> ReadPeopleUsers();
    }
}
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PeopleTable.Interfaces;
using PeopleTable.Models;
using PeopleTable.ViewModels;

namespace PeopleTable.Repository
{
    public class JsonReaderRepository : IJsonReaderRepository
    {
        private readonly JsonSerializerSettings _settings;
        public JsonReaderRepository()
        {
            _settings = new JsonSerializerSettings();
            _settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            _settings.Formatting = Formatting.Indented;
        }


        public List<Person> ReadPeople()
        {
            StreamReader r = new StreamReader(
                    @"C:\Users\Bars\Documents\Visual Studio 2015\Projects\PeopleTable\PeopleTable\JsonFiles\people.json");
            string json = r.ReadToEnd();
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json, _settings);
            return people;
        }

        public List<RegisterViewModel> ReadPeopleUsers()
        {
            StreamReader r = new StreamReader(
                @"C:\Users\Bars\Documents\Visual Studio 2015\Projects\PeopleTable\PeopleTable\JsonFiles\accounts.json");
            
            string json = r.ReadToEnd();
            var accounts = JsonConvert.DeserializeObject<List<RegisterViewModel>>(json, _settings);
            return accounts;
        }
    }
}

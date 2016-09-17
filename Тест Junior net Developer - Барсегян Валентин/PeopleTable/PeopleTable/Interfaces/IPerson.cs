using System;
using System.Collections.Generic;
using PeopleTable.Models;

namespace PeopleTable.Interfaces
{
    public interface IPerson
    {
        string Guid { get; set; }
        string Name { get; set; }
        string Company { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Picture { get; set; }
        string Gender { get; set; }
        string Address { get; set; }
        string About { get; set; }
        DateTimeOffset Registered { get; set; }
        List<Tag> TagList { get; set; }
        List<string> Tags { get; set; }
    }
}
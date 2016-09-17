using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PeopleTable.Interfaces;

namespace PeopleTable.Models
{
    public class Tag : ITag
    {
        public Tag()
        {
        }
        public Tag(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public string PersonId { get; set; }
    }
}
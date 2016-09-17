using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleTable.Interfaces;

namespace PeopleTable.Models
{
    public class Person : IPerson
    {
        private DateTimeOffset _registered;
        private List<Tag> _tags;
        
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTimeOffset Registered
        {
            get { return _registered; }
            set { _registered = DateTimeOffset.Parse(value.ToString()); }
        }

        public List<Tag> TagList
        {
            get { return _tags; } 
            set { _tags = value; }
        }

        public List<string> Tags
        {
            get
            {
                List<string> tagNames = new List<string>();
                foreach (var tag in _tags)
                {
                    tagNames.Add(tag.Name);
                }
                return tagNames;
            }
            set
            {
                List<Tag> tags = new List<Tag>();
                foreach (var tag in value)
                {
                    tags.Add(new Tag( tag));
                }
                _tags = tags;
            }
        }
    }
}

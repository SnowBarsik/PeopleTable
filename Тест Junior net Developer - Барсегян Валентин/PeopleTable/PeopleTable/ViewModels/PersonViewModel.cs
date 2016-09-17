using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleTable.ViewModels
{
    public class PersonViewModel
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string About { get; set; }

        public List<string> Tags { get; set; }

        public string Registered { get; set; }
    }
}

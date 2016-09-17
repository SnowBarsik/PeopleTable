using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleTable.Models;

namespace PeopleTable.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }
        public Pager Pager { get; set; }
    }
}

using PeopleTable.Models;

namespace PeopleTable.Interfaces
{
    public interface ITag
    {
        int Id { get; set; }
        string Name { get; set; }
        Person Person { get; set; }
        string PersonId { get; set; }
    }
}
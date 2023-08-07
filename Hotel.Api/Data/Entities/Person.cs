using Hotel.Api.Data.Common;

namespace Hotel.Api.Data.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyTitle { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}

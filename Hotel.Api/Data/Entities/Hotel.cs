using Hotel.Api.Data.Common;
using Hotel.Api.Data.Entities;

namespace Hotel.Api.Data
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}

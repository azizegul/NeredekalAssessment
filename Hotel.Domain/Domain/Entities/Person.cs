using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyTitle { get; set; }
        public Guid HotelId  { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}

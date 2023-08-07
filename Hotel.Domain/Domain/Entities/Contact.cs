using Hotel.Domain.Domain.Enums;

namespace Hotel.Domain.Domain.Entities
{
    public class Contact :BaseEntity
    {
        public Guid PersonId { get; set; }
        public ContactInfoType InfoType { get; set; }
        public string Info { get; set; }
        public virtual Person Person { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}

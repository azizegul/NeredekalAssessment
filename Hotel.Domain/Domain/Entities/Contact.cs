using Hotel.Domain.Domain.Enums;

namespace Hotel.Domain.Domain.Entities
{
    public class Contact :BaseEntity
    {
        public ContactInfoType InfoType { get; set; }
        public string Info { get; set; }

        public Guid HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}

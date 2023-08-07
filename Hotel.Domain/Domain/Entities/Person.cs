namespace Hotel.Domain.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string CompanyTitle { get; set; }

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}

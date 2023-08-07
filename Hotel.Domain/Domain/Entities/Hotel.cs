namespace Hotel.Domain.Domain.Entities
{
    public class Hotel:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Person> Persons { get; set; }

    }
}

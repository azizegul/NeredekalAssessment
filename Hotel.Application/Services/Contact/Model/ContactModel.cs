using Hotel.Domain.Domain.Enums;

namespace Hotel.Application.Services.Contact.Model;

public class ContactModel
{
    public Guid HotelId { get; set; }
    public ContactInfoType InfoType { get; set; }
    public string Info { get; set; }
}

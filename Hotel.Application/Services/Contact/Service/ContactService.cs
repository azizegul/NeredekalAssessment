using Hotel.Application.Services.Contact.Interface;
using Hotel.Application.Services.Contact.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.Services.Contact.Service;

public class ContactService : IContactService
{
    private readonly IApplicationDbContext _context;

    public ContactService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Domain.Domain.Entities.Contact> Add(ContactModel requestModel)
    {
        var contact = new Domain.Domain.Entities.Contact
        {
            HotelId = requestModel.HotelId,
            InfoType = requestModel.InfoType,
            Info = requestModel.Info,
        };

        _context.Contacts.Add(contact);

        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<bool> Delete(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        if (contact == null)
            throw new Exception("Hotel Not Found.");

        contact.IsDeleted = true;

        _context.Contacts.Update(contact);

        await _context.SaveChangesAsync();

        return contact.IsDeleted;
    }

    public async Task<List<ContactModel>> Get()
    {
        var contacts= await _context.Contacts
        .Where(x => x.IsDeleted == false)
        .Select(x => new ContactModel()
        {
            HotelId = x.HotelId,
            Info = x.Info,
            InfoType = x.InfoType,
        }).ToListAsync();

        return contacts;
    }
}

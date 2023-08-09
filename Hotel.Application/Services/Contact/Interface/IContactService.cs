using Hotel.Application.Services.Contact.Model;

namespace Hotel.Application.Services.Contact.Interface;

public interface IContactService
{
    Task<List<ContactModel>> Get();
    Task<Domain.Domain.Entities.Contact> Add(ContactModel requestModel);
    Task<bool> Delete(Guid id);

}

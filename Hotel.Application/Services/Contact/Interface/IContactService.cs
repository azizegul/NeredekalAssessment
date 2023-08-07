using Hotel.Application.Services.Contact.Model;

namespace Hotel.Application.Services.Contact.Interface
{
    public interface IContactService
    {
        Task<Domain.Domain.Entities.Contact> Add(ContactRequestModel requestModel);
        Task<bool> Delete(Guid id);

    }
}

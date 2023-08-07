using Hotel.Application.Common;
using Hotel.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Hotel.Application.Contact
{
    public class ContactService : IContactService
    {
        private readonly IContactService _contactService;
        private readonly IApplicationDbContext _applicationDbContext;

        public ContactService(IContactService contactService, IApplicationDbContext applicationDbContext)
        {
            _contactService = contactService;
            _applicationDbContext = applicationDbContext;
        }


        public async Task<Domain.Domain.Entities.Contact> Add(ContactRequestModel requestModel, CancellationToken cancellationToken)
        {
            var contact = await _contactService.Add(requestModel, cancellationToken);
            return contact;
        }

        public async Task<Domain.Domain.Entities.Contact> Delete(Guid id, CancellationToken cancellationToken)
        {
            var contact=  _applicationDbContext.Contacts.Find(id);

            contact.IsDeleted = true;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return contact;
        }

    }
}

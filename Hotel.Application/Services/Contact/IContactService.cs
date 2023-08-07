using Hotel.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Contact
{
    public interface IContactService
    {
        Task<Domain.Domain.Entities.Contact> Add(ContactRequestModel requestModel, CancellationToken cancellationToken);
        Task<Domain.Domain.Entities.Contact> Delete(Guid id, CancellationToken cancellationToken);

    }
}

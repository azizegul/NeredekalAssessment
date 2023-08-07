using Hotel.Application.Contact;
using Hotel.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Common.Interfaces
{
    public interface IContactService
    {
        Task<Domain.Domain.Entities.Contact> Add(ContactRequestModel requestModel,CancellationToken cancellationToken);
        Task<Domain.Domain.Entities.Contact> Delete(Guid id,CancellationToken cancellationToken);

    }
}

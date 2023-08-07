using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Services.Hotel
{
    public interface IHotelService
    {
        Task<Domain.Domain.Entities.Hotel> Add(HotelRequestModel requestModel, CancellationToken cancellationToken);
        Task<Domain.Domain.Entities.Hotel> ContactDetails(Guid id);
        Task<Domain.Domain.Entities.Hotel> Delete(Guid id, CancellationToken cancellationToken);
    }
}

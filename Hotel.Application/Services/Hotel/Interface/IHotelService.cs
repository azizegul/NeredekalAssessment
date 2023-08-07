using Hotel.Application.Services.Hotel.Model;

namespace Hotel.Application.Services.Hotel.Interface
{
    public interface IHotelService
    {
        Task<Domain.Domain.Entities.Hotel> Add(HotelRequestModel requestModel);
        Task<Domain.Domain.Entities.Hotel> ContactDetails(Guid id);
        Task<bool> Delete(Guid id);
    }
}

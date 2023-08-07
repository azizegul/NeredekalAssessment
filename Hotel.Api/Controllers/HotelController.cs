using Hotel.Application.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Api.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelService _hotelService;
        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<Domain.Domain.Entities.Hotel> Add(HotelRequestModel requestModel, CancellationToken cancellationToken)
        {
            return await _hotelService.Add(requestModel, cancellationToken);
        }

        [HttpGet]
        public async Task<Domain.Domain.Entities.Hotel> ContactDetails(Guid id)
        {
          return await _hotelService.ContactDetails(id);
        }

        public async Task<Domain.Domain.Entities.Hotel> Delete(Guid id, CancellationToken cancellationToken)
        {
            return await _hotelService.Delete(id, cancellationToken);
      
        }

    }
}

using Hotel.Application.Services.Hotel.Interface;
using Hotel.Application.Services.Hotel.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Domain.Domain.Entities.Hotel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(HotelRequestModel requestModel)
        {
            var hotel = await _hotelService.Add(requestModel);

            return Created($"api/hotels/{hotel.Id}", hotel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Domain.Domain.Entities.Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ContactDetails(Guid id)
        {
            var contactDetails = await _hotelService.ContactDetails(id);

            if (contactDetails is null)
            {
                return NotFound();
            }

            return Ok(contactDetails);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _hotelService.Delete(id);

            return NoContent();
        }

    }
}

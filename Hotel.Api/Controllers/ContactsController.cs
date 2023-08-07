
using Hotel.Application.Services.Contact.Interface;
using Hotel.Application.Services.Contact.Model;
using Hotel.Domain.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Domain.Domain.Entities.Contact), StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(ContactRequestModel requestModel)
        {
            var contact = await _contactService.Add(requestModel);

            return Created($"api/contacts/{contact.Id}", contact);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contactService.Delete(id);

            return NoContent();
        }
    }
}

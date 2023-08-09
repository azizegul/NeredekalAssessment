
using Hotel.Application.Services.Contact.Interface;
using Hotel.Application.Services.Contact.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _contactService;
    public ContactsController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ContactModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        var contacts = await _contactService.Get();

        return Ok(contacts);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Domain.Domain.Entities.Contact), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(ContactModel requestModel)
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

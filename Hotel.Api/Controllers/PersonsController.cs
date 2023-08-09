using Hotel.Application.Services.Person.Interface;
using Hotel.Application.Services.Person.Model;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonsController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Domain.Domain.Entities.Person), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add(PersonRequestModel requestModel)
    {
        var person= await _personService.Add(requestModel);

        return Created($"api/persons/{person.Id}", person);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Domain.Domain.Entities.Person), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<List<Domain.Domain.Entities.Person>> List([FromQuery] Guid hotelId)
    {
        var persons = await _personService.List(hotelId);

        return persons;
    }
}

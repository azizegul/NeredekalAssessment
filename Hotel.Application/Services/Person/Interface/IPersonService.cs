using Hotel.Application.Services.Person.Model;

namespace Hotel.Application.Services.Person.Interface;

public interface IPersonService
{
    Task<Domain.Domain.Entities.Person> Add(PersonRequestModel requestModel);
    Task<List<Domain.Domain.Entities.Person>> List(Guid hotelId);
}

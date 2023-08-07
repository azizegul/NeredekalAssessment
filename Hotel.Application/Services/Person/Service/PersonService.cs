using Hotel.Application.Services.Person.Interface;
using Hotel.Application.Services.Person.Model;
using Hotel.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Application.Services.Person.Service
{
    public class PersonService : IPersonService
    {
        private readonly IApplicationDbContext _context;
        public PersonService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Domain.Entities.Person> Add(PersonRequestModel requestModel)
        {
            var person = new Domain.Domain.Entities.Person
            {
                Name = requestModel.Name,
                Surname = requestModel.Surname,
                CompanyTitle = requestModel.CompanyTitle,
                HotelId = requestModel.HotelId,
            };

            await _context.Persons.AddAsync(person);

            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<List<Domain.Domain.Entities.Person>> List(Guid hotelId)
        {
            var persons = _context.Persons.Where(x => x.HotelId == hotelId).AsNoTracking().ToList();

            return persons;

        }
    }
}

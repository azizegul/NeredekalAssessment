using Hotel.Application.Common;
using Hotel.Application.Common.Interfaces;

namespace Hotel.Application.Person
{
    public class PersonService:IPersonService
    {
        private readonly IPersonService _personService;
        private readonly IApplicationDbContext _context;
        public PersonService(IPersonService personService, IApplicationDbContext context)
        {
            _personService = personService;
            _context = context;
        }

        public async Task<List<Domain.Domain.Entities.Person>> List(Guid id, CancellationToken cancellationToken)
        {
            var persons = _context.Persons.Where(x => x.HotelId == id).ToList();
            return persons;

        }
    }
}

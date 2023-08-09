using Microsoft.EntityFrameworkCore;

namespace Hotel.Application;

public interface IApplicationDbContext
{
    DbSet<Domain.Domain.Entities.Person> Persons { get; set; }

    DbSet<Domain.Domain.Entities.Contact> Contacts { get; set; }

    DbSet<Domain.Domain.Entities.Hotel> Hotels { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

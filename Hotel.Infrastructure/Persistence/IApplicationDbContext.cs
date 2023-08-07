using Hotel.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; set; }

        DbSet<Contact> Contacts { get; set; }
        DbSet<Domain.Domain.Entities.Hotel> Hotels { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

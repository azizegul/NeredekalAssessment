using Hotel.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Persistence.Configuration
{
    public  class PersonConfiguration :BaseEntityTypeConfiguration<Person>
    {
        protected override void DoConfigure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.Surname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.CompanyTitle)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}

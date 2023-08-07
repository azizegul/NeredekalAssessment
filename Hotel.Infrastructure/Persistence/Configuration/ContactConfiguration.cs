using Hotel.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Persistence.Configuration
{
    public class ContactConfiguration: BaseEntityTypeConfiguration<Contact>
    {
        protected override void DoConfigure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(t => t.Info)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.InfoType)
                .IsRequired();
          
        }
    }
}

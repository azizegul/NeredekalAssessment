using Hotel.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configuration;

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

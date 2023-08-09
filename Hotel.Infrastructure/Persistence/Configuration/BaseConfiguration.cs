using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.Configuration;

public abstract class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
  where TEntity : BaseEntity
{
    protected abstract void DoConfigure(EntityTypeBuilder<TEntity> builder);

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(t => t.CreatedDate)
            .IsRequired();

        builder.Property(t => t.IsDeleted)
            .IsRequired();

        DoConfigure(builder);
    }
}

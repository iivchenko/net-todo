using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.LableAggregate
{
    public sealed class LabelMapping : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder
                .ToTable("labels");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .OwnsOne(x => x.Color);

            builder
                .Property(x => x.DateCreated);

            builder
                .Property(x => x.DateUpdated);
        }
    }
}

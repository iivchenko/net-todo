using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Todo.Application.Domain.TodoItemAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.TodoItemAggregate
{
    public sealed class TodoItemMapping : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder
                .ToTable("items");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder
               .Property(x => x.Description)
               .IsRequired();

            builder
                .Property(x => x.Status)
                .HasConversion(
                    x => x.ToString(),
                    x => (TodoItemStatus)Enum.Parse(typeof(TodoItemStatus), x));

            builder
                .Property(x => x.DateCreated);

            builder
                .Property(x => x.DateUpdated);
        }
    }
}

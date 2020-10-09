using Microsoft.EntityFrameworkCore;
using Todo.Application.Domain.TodoItemAggregate;
using Todo.Application.Domain.TodoListAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.TodoListAggregate
{
    public sealed class TodoListMapping : IEntityTypeConfiguration<TodoList>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TodoList> builder)
        {
            builder
                .ToTable("lists");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .HasMany<TodoItem>()
                .WithOne()
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.DateCreated);

            builder
                .Property(x => x.DateUpdated);
        }
    }
}

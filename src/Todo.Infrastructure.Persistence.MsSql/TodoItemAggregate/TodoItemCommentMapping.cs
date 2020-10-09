using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Application.Domain.TodoItemAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.TodoItemAggregate
{
    public sealed class TodoItemCommentMapping : IEntityTypeConfiguration<TodoItemComment>
    {
        public void Configure(EntityTypeBuilder<TodoItemComment> builder)
        {
            builder
                .ToTable("comments");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Text)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.DateCreated);
        }
    }
}

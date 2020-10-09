using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Application.Domain.LableAggregate;
using Todo.Application.Domain.TodoItemAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.TodoItemAggregate
{
    public sealed class LableToItem
    {
        public Guid LabelId { get; set; }

        public Guid TodoItemId { get; set; }
    }

    public sealed class LableToItemMapping : IEntityTypeConfiguration<LableToItem>
    {
        public void Configure(EntityTypeBuilder<LableToItem> builder)
        {
            builder
                .ToTable("lableToItems");

            builder
                .HasKey(x => new { x.LabelId, x.TodoItemId });

            builder
                .HasOne<Label>()
                .WithMany()
                .HasForeignKey(x => x.LabelId);

            builder
                .HasOne<TodoItem>()
                .WithMany()
                .HasForeignKey(x => x.TodoItemId);
        }
    }
}

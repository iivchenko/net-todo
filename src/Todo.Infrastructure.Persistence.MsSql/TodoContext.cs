using Microsoft.EntityFrameworkCore;
using Todo.Application.Domain.LableAggregate;
using Todo.Application.Domain.TodoItemAggregate;
using Todo.Application.Domain.TodoListAggregate;
using Todo.Infrastructure.Persistence.MsSql.LableAggregate;
using Todo.Infrastructure.Persistence.MsSql.TodoItemAggregate;
using Todo.Infrastructure.Persistence.MsSql.TodoListAggregate;

namespace Todo.Infrastructure.Persistence.MsSql
{
    public sealed class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
          : base(options)
        {
        }

        public DbSet<Label> Labels { get; set; }

        public DbSet<TodoItem> Items { get; set; }

        public DbSet<TodoItemComment> Comments { get; set; }

        public DbSet<TodoList> Lists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LabelMapping());
            builder.ApplyConfiguration(new TodoListMapping());
            builder.ApplyConfiguration(new TodoItemMapping());
            builder.ApplyConfiguration(new TodoItemCommentMapping());
            builder.ApplyConfiguration(new LableToItemMapping());
        }
    }
}

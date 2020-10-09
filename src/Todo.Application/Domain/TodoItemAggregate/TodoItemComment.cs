using System;
using Todo.Application.Domain.Common;

namespace Todo.Application.Domain.TodoItemAggregate
{
    public sealed class TodoItemComment : IEntity<Guid>
    {
        public TodoItemComment (Guid id, string text)
        {
            Id = id;
            Text = text;

            DateCreated = DateTime.UtcNow;
        }

        private TodoItemComment()
        {
        }

        public Guid Id { get; }

        public string Text { get; }

        public DateTime DateCreated { get; }
    }
}
 
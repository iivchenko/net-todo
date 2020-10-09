using System;
using System.Collections.Generic;
using Todo.Application.Domain.Common;

namespace Todo.Application.Domain.TodoItemAggregate
{
    public sealed class TodoItem : IAggregateRoot<Guid>
    {
        private readonly List<TodoItemComment> _comments;

        public TodoItem(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;

            DateCreated = DateUpdated = DateTime.UtcNow;

            _comments = new List<TodoItemComment>();
        }

        private TodoItem()
        {
        }

        public Guid Id { get; }

	    public string Name { get; }

	    public string Description { get; }

	    public TodoItemStatus Status { get; }

        public IEnumerable<TodoItemComment> Comments { get; }

        public DateTime DateCreated { get; }

        public DateTime DateUpdated { get; private set; }

        public void AddComment(TodoItemComment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            _comments.Add(comment);
        }
    }
}
 
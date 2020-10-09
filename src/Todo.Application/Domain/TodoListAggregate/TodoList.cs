using System;
using System.Collections.Generic;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.TodoItemAggregate;

namespace Todo.Application.Domain.TodoListAggregate
{
    public sealed class TodoList : IAggregateRoot<Guid>
    {
        private readonly List<Guid> _items;

        public TodoList(Guid id, string text)
        {
            Id = id;
            Name = text;
            DateCreated = DateUpdated = DateTime.UtcNow;

            _items = new List<Guid>();
        }

        private TodoList()
        {
        }

        public Guid Id { get; }

        public string Name { get; }

        public DateTime DateCreated { get; }

        public DateTime DateUpdated { get; private set; }

        public IEnumerable<Guid> Items => _items;

        public void AddItem (TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _items.Add(item.Id);

            DateUpdated = DateTime.UtcNow;
        }
    }
}
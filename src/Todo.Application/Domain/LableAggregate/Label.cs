using System;
using Todo.Application.Domain.Common;

namespace Todo.Application.Domain.LableAggregate
{
    public sealed class Label : IAggregateRoot<Guid>
    {
        public Label(Guid id, string name, string description, Color color)
        {
            Id = id;
            Name = name;
            Description = description;
            Color = color;
        }

        private Label()
        {
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Color Color { get; }
    }
}

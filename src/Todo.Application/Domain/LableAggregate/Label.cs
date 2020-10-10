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

            DateCreated = DateUpdated = DateTime.UtcNow;
        }

        private Label()
        {
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public Color Color { get; private set; }

        public DateTime DateCreated { get; private set; }

        public DateTime DateUpdated { get; private set; }

        public void UpdateName(string name)
        {
            Name = name;
            DateUpdated = DateTime.UtcNow;
        }

        public void UpdateDescription(string description)
        {
            Description = description;
            DateUpdated = DateTime.UtcNow;
        }

        public void UpdateColor(Color color)
        {
            Color = color;
            DateUpdated = DateTime.UtcNow;
        }
    }
}

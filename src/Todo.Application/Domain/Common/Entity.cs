namespace Todo.Application.Domain.Common
{
    public abstract class Entity<TId> : IEntity<TId>
    {
        protected Entity(TId id)
        {
            Id = id;
        }

        public TId Id { get; }
    }

    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}

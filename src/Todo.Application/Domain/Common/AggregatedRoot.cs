namespace Todo.Application.Domain.Common
{
    public abstract class AggregatedRoot<TId> : IAggregateRoot<TId>
    {
        protected AggregatedRoot(TId id)
        {
            Id = id;
        }

        public TId Id { get; }
    }

    public interface IAggregateRoot<TId>
    {
        TId Id { get; }
    }
}

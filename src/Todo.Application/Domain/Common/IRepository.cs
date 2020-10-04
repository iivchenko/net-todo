using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Todo.Application.Domain.Common
{
    public interface IRepository<TAggregateRoot, TId> : 
        IReadRepository<TAggregateRoot, TId>, 
        IWriteRepository<TAggregateRoot, TId>
        where TAggregateRoot : IAggregateRoot<TId>
    {
    }

    public interface IWriteRepository<TAggregateRoot, TId>
    where TAggregateRoot : IAggregateRoot<TId>
    {
        Task<TId> CreateAsync(TAggregateRoot aggregate);

        Task UpdateAsync(TAggregateRoot aggregate);
    }

    public interface IReadRepository<TAggregateRoot, TId>
    where TAggregateRoot : IAggregateRoot<TId>
    {
        Task<TAggregateRoot> FindByIdAsync(TId id);

        Task<IEnumerable<TAggregateRoot>> FindAsync(Expression<Func<TAggregateRoot, bool>> predicate);
    }
}

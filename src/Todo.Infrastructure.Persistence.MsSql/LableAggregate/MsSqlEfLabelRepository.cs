using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.LableAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.LableAggregate
{
    public sealed class MsSqlEfLabelRepository : IRepository<Label, Guid>
    {
        private readonly TodoContext _context;

        public MsSqlEfLabelRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Label aggregate)
        {
            var label = await _context.Labels.AddAsync(aggregate);

            return label.Entity.Id;
        }

        public async Task<IEnumerable<Label>> FindAsync(Expression<Func<Label, bool>> predicate)
        {
            return await _context.Labels.Where(predicate).ToListAsync();
        }

        public Task<Label> FindByIdAsync(Guid id)
        {
            return _context.Labels.SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Label aggregate)
        {
            _context.Entry(aggregate).State = EntityState.Modified;

            return Task.CompletedTask; 
        }
    }
}

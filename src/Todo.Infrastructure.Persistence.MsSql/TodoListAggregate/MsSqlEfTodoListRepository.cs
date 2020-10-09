using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo.Application.Domain.Common;
using Todo.Application.Domain.TodoListAggregate;

namespace Todo.Infrastructure.Persistence.MsSql.TodoListAggregate
{
    public sealed class MsSqlEfTodoListRepository : IRepository<TodoList, Guid>
    {
        private readonly TodoContext _context;

        public MsSqlEfTodoListRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(TodoList aggregate)
        {
            var label = await _context.Lists.AddAsync(aggregate);

            return label.Entity.Id;
        }

        public async Task<IEnumerable<TodoList>> FindAsync(Expression<Func<TodoList, bool>> predicate)
        {
            return await _context.Lists.Where(predicate).ToListAsync();
        }

        public Task<TodoList> FindByIdAsync(Guid id)
        {
            return _context.Lists.SingleAsync(x => x.Id == id);
        }

        public Task UpdateAsync(TodoList aggregate)
        {
            _context.Entry(aggregate).State = EntityState.Modified;

            return Task.CompletedTask;
        }
    }
}

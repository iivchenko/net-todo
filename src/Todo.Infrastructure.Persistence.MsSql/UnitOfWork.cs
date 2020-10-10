using System.Threading.Tasks;
using Todo.Application.Domain.Common;

namespace Todo.Infrastructure.Persistence.MsSql
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using System.Threading.Tasks;

namespace Todo.Infrastructure.Persistence.MsSql
{
    public sealed class UnitOfWork
    {
        private readonly TodoContext _context;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}

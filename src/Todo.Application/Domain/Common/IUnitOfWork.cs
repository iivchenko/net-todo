using System.Threading.Tasks;

namespace Todo.Application.Domain.Common
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}

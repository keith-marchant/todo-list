using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.Entities;

namespace TodoList.Application.Common
{
    public interface IAppDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

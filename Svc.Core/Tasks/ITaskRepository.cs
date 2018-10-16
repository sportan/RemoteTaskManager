using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;

namespace Svc.Tasks
{
    public interface ITaskRepository : IRepository<Task, long>
    {
        Task<List<Task>> GetListAsync(TaskState? state);
    }
}

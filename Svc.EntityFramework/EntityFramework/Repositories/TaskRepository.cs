using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.EntityFramework;
using Svc.Tasks;

namespace Svc.EntityFramework.Repositories
{
    public class TaskRepository : SvcRepositoryBase<Tasks.Task, long>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<SvcDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Tasks.Task>> GetListAsync(TaskState? state)
        {
            var query = GetAll();

            if (state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }
            
            return await query
                .OrderByDescending(task => task.CreationTime)
                .ToListAsync();
        }
    }
}

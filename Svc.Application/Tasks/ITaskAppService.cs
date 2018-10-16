using System.Threading.Tasks;
using Abp.Application.Services;
using Svc.Tasks.Dtos;

namespace Svc.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<GetTasksOutput> GetTasksAsync(GetTasksInput input);

        System.Threading.Tasks.Task UpdateTaskAsync(UpdateTaskInput input);

        System.Threading.Tasks.Task CreateTaskAsync(CreateTaskInput input);
    }
}

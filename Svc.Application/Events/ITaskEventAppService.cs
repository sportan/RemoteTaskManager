using System.Threading.Tasks;
using Abp.Application.Services;
using Svc.Events.Dtos;

namespace Svc.Events
{
    public interface ITaskEvevntAppService : IApplicationService
    {
        Task<GetTaskEvenListOutput> GetEventListAsync();
    }
}

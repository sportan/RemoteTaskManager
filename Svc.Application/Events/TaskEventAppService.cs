using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Svc.Events.Dtos;

namespace Svc.Events
{
    public class TaskEvevntAppService : ITaskEvevntAppService
    {
        private readonly IRepository<TaskEvent> _taskEventRepository;

        public TaskEvevntAppService(IRepository<TaskEvent> taskEventRepository)
        {
            _taskEventRepository = taskEventRepository;
        }

        //This method uses async pattern that is supported by ASP.NET Boilerplate
        public async Task<GetTaskEvenListOutput> GetEventListAsync()
        {
            var taskEvents = await _taskEventRepository.GetAllListAsync();
            return new GetTaskEvenListOutput
                   {
                       TaskEvents = taskEvents.MapTo<List<TaskEventDto>>()
                   };
        }
    }
}
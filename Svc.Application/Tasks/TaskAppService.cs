using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Svc.Events;
using Svc.Tasks.Dtos;

namespace Svc.Tasks
{
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IRepository<TaskEvent> _eventRepository;

        public TaskAppService(ITaskRepository taskRepository, IRepository<TaskEvent> eventRepository)
        {
            _taskRepository = taskRepository;
            _eventRepository = eventRepository;
        }

        public async Task<GetTasksOutput> GetTasksAsync(GetTasksInput input)
        {
            var tasks = await _taskRepository.GetListAsync(input.State);

            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(tasks)
            };
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(UpdateTaskInput input)
        {
            Logger.Info($"Updating a task for input: {input}");

            var task = await _taskRepository.GetAsync(input.TaskId);

            if (input.State.HasValue && input.State.Value != task.State)
            {
                task.State = input.State.Value;
                task.LastModificationTime = DateTime.Now;
            }
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(CreateTaskInput input)
        {
            if (await _taskRepository.CountAsync(e => e.Name == input.Name) > 0)
            {
                Logger.Info($"The task [{input}] already exists.");
                return;
            }

            Logger.Info($"Creating a task for input: {input}");

            var task = new Task
            {
                Name = input.Name,
                Description = input.Description,
                State = input.State ?? TaskState.Active
            };

            await _taskRepository.InsertAsync(task);
        }
    }
}
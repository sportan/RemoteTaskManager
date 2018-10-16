using System;
using System.ServiceProcess;
using Abp.Dependency;
using Abp.Threading;
using Svc.Events;
using Svc.Tasks;
using Svc.Tasks.Dtos;

namespace Svc
{
    public class SystemSpy : ITransientDependency
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ITaskEvevntAppService _taskEvevntAppService;

        public SystemSpy(ITaskAppService taskAppService, ITaskEvevntAppService taskEvevntAppService)
        {
            _taskAppService = taskAppService;
            _taskEvevntAppService = taskEvevntAppService;
        }

        public void UpdateStoredTasks()
        {
            var services = ServiceController.GetServices();

            foreach (var service in services)
            {
                AsyncHelper.RunSync(
                    () =>
                        _taskAppService.CreateTaskAsync(new CreateTaskInput()
                        {
                            Name = service.ServiceName,
                            Description = service.DisplayName,
                            State = service.Status == ServiceControllerStatus.Stopped ? TaskState.Stopped : TaskState.Active
                        }));
            }
        }

        public void GetStoredTasks()
        {
            var result = AsyncHelper.RunSync(() => _taskAppService.GetTasksAsync(new GetTasksInput()));

            foreach (var task in result.Tasks)
            {
                Console.WriteLine(task.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("{0} tasks listed.", result.Tasks.Count);
        }
    }
}
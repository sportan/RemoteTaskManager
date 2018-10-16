using System.Linq;
using Abp.Runtime.Validation;
using Abp.Threading;
using Shouldly;
using Svc.Tasks;
using Svc.Tasks.Dtos;
using Xunit;

namespace Svc.Test.Tasks
{
    public class TaskAppService_Tests : SvcTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            //Creating the class which is tested (SUT - Software Under Test)
            //Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            _taskAppService = LocalIocManager.Resolve<ITaskAppService>();
        }

        [Fact]
        public void Should_Get_Tasks()
        {
            //Run SUT
            var output = AsyncHelper.RunSync(() =>_taskAppService.GetTasksAsync(new GetTasksInput { State = TaskState.Stopped }));

            //Checking results
            output.Tasks.Count.ShouldBe(2);
            output.Tasks.All(t => t.State == (byte)TaskState.Stopped).ShouldBe(true);
        }

        [Fact]
        public void Should_Create_New_Tasks()
        {
            //Prepare for test
            var initialTaskCount = UsingDbContext(context => context.Tasks.Count());
            
            //Run SUT
            AsyncHelper.RunSync(() => _taskAppService.CreateTaskAsync(
                new CreateTaskInput
                {
                    Description = "service11"
                }));
            AsyncHelper.RunSync(() => _taskAppService.CreateTaskAsync(
                new CreateTaskInput
                {
                    Description = "service22"
                }));

            //Check results
            UsingDbContext(context =>
            {
                context.Tasks.Count().ShouldBe(initialTaskCount + 2);
                context.Tasks.FirstOrDefault(t => t.Description == "service11").ShouldNotBe(null);
                var task2 = context.Tasks.FirstOrDefault(t => t.Description == "service22");
                task2.ShouldNotBe(null);
            });
        }

        [Fact]
        public void Should_Not_Create_Task_Without_Description()
        {
            //Description is not set
            Assert.Throws<AbpValidationException>(() => AsyncHelper.RunSync(() => _taskAppService.CreateTaskAsync(new CreateTaskInput())));
        }
    }
}

using System.Threading.Tasks;
using System.Web.Http;
using Abp.WebApi.Controllers;
using Svc.Tasks;
using Svc.Tasks.Dtos;

namespace Svc{
    
    [RoutePrefix("api/rtmservice")]
    public class RtmServiceController : AbpApiController
    {
        private readonly TaskAppService _taskAppService;

        public RtmServiceController(TaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IHttpActionResult> GetRtmServices(byte? state)
        {
            var tasks = await _taskAppService.GetTasksAsync(new GetTasksInput() {State = (TaskState?) state});
            return Ok(tasks);
        }

        [HttpPost]
        [Route("create")]
        public async System.Threading.Tasks.Task CreateRtmService(CreateTaskInput createTaskInput)
        {
            await _taskAppService.CreateTaskAsync(createTaskInput);
        }

        [HttpPut]
        [Route("update")]
        public async System.Threading.Tasks.Task UpdateRtmService(UpdateTaskInput updateTaskInput)
        {
            await _taskAppService.UpdateTaskAsync(updateTaskInput);
        }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Svc.Events.Dtos
{
    [AutoMapFrom(typeof(TaskEvent))] //AutoMapFrom attribute maps Person -> TaskEventDto
    public class TaskEventDto : EntityDto
    {
        public string Name { get; set; }
    }
}
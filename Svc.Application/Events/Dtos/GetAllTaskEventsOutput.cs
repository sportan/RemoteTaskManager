using System.Collections.Generic;

namespace Svc.Events.Dtos
{
    public class GetTaskEvenListOutput
    {
        public List<TaskEventDto> TaskEvents { get; set; }
    }
}
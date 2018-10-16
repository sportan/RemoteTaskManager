using System;
using Abp.Application.Services.Dto;

namespace Svc.Tasks.Dtos
{
    public class TaskDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public byte State { get; set; }

        public override string ToString()
        {
            return $"[Task Id={Id}, Description={Description}, Description={Description}, CreationTime={CreationTime}, LastModificationTime={LastModificationTime}, State={(TaskState) State}]";
        }
    }
}
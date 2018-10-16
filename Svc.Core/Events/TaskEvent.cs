using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Svc.Tasks;

namespace Svc.Events
{
    [Table("TaskEvents")]
    public class TaskEvent : EventBase, IHasCreationTime
    {
        public virtual Task Task { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
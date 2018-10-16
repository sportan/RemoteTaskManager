using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Svc.Events;

namespace Svc.Tasks
{
    //[Table("Tasks")]
    public class Task : Entity<long>, IHasCreationTime, IHasModificationTime
    {

        /// <summary>
        /// Task name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Describes the task.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// The time when this task is created.
        /// </summary>
        public virtual DateTime CreationTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Current state of the task.
        /// </summary>
        public virtual TaskState State { get; set; } = TaskState.Active;

        /// <summary>
        /// The time when task is updated
        /// </summary>
        public DateTime? LastModificationTime { get; set; } = DateTime.Now;

        /// <summary>
        /// List of events associated with the task
        /// </summary>
        public virtual IList<TaskEvent> Events { get; set; } = new List<TaskEvent>();
    }
}

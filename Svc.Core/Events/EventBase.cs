using Abp.Domain.Entities;

namespace Svc.Events
{
    public class EventBase : Entity
    {
        public virtual string Description { get; set; }
    }
}
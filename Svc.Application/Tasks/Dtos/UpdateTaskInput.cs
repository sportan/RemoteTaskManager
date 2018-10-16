using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace Svc.Tasks.Dtos
{
    public class UpdateTaskInput : ICustomValidate
    {
        [Range(1, long.MaxValue)] //Data annotation attributes work as expected.
        public long TaskId { get; set; }

        public TaskState? State { get; set; }

        //Custom validation method.
        //It's called by ABP after data annotation validations.
        public void AddValidationErrors(CustomValidationContext context)
        {
            if (State == null)
            {
                context.Results.Add(new ValidationResult("State can not be null in order to update a Task!", new[] { "State" }));
            }
        }

        public override string ToString()
        {
            return $"[UpdateTaskInput > TaskId = {TaskId}, State = {State}]";
        }
    }
}

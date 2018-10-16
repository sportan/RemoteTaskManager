using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;

namespace Svc.Tasks.Dtos
{
    public class CreateTaskInput : ICustomValidate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskState? State { get; set; } = TaskState.Active;

        public override string ToString()
        {
            return $"[CreateTaskInput > Name = {Name}, Description = {Description}, State = {State}]";
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Description) || State == null)
            {
                context.Results.Add(
                    new ValidationResult(
                        "Name, Description and State can not be null in order to create a Task!",
                        new[] {"Name", "Description", "State"}));
            }
        }
    }
}
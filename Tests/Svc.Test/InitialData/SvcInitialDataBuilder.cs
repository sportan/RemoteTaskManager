using System.Data.Entity.Migrations;
using System.Linq;
using Svc.EntityFramework;
using Svc.Tasks;

namespace Svc.Test.InitialData
{
    public class SvcInitialDataBuilder
    {
        public void Build(SvcDbContext context)
        {
            //Add some tasks
            context.Tasks.AddOrUpdate(
                t => t.Description,
                new Task
                {
                    Description = "service1"
                },
                new Task
                {
                    Description = "service2",
                    State = TaskState.Stopped
                });
            context.SaveChanges();
        }
    }
}

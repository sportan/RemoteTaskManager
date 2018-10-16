using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using Svc.Events;
using Svc.Tasks;

namespace Svc.EntityFramework
{
    public class SvcDbContext : AbpDbContext
    {
        public virtual IDbSet<Task> Tasks { get; set; }

        public virtual IDbSet<TaskEvent> TaskEvents { get; set; }

        public SvcDbContext()
            : base("Default")
        {

        }

        public SvcDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        //This constructor is used in tests
        public SvcDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().HasMany(e => e.Events).WithRequired(e => e.Task).WillCascadeOnDelete(true);
        }
    }
}

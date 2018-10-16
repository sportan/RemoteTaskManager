using System.Data.Entity.Migrations;
using Svc.EntityFramework;

namespace Svc.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SvcDbContext>
    {
        public Configuration()
        {
            ContextKey = "Svc";
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        //protected override void Seed(SvcDbContext context)
        //{
        //}
    }
}

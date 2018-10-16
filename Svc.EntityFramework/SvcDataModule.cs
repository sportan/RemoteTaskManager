using System.Data.Entity;
using System.Reflection;
using System.Transactions;
using Abp.Configuration.Startup;
using Abp.EntityFramework;
using Abp.Modules;
using Svc.EntityFramework;
using Svc.Migrations;


namespace Svc
{
    [DependsOn(typeof(SvcCoreModule), typeof(AbpEntityFrameworkModule))]
    public class SvcDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsolationLevel = IsolationLevel.ReadCommitted;
        }
        
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            var abpConfig = IocManager.Resolve<IAbpStartupConfiguration>();
            abpConfig.UnitOfWork.IsolationLevel = IsolationLevel.ReadCommitted;
#if DEBUG
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SvcDbContext, Configuration>());
            Database.SetInitializer<SvcDbContext>(null);
#else
            Database.SetInitializer<SvcDbContext>(null);
#endif
        }
    }
}

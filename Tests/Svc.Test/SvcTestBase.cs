using System;
using System.Data.Common;
using Abp.TestBase;
using Castle.MicroKernel.Registration;
using EntityFramework.DynamicFilters;
using Svc.EntityFramework;
using Svc.Test.InitialData;

namespace Svc.Test
{
    public abstract class SvcTestBase : AbpIntegratedTestBase<SvcTestModule>
    {
        protected SvcTestBase()
        {
            //Seed initial data
            //Effort.Provider.EffortProviderConfiguration.RegisterProvider();
            UsingDbContext(context => new SvcInitialDataBuilder().Build(context));
        }

        protected override void PreInitialize()
        {
            //Fake DbConnection using Effort!
            LocalIocManager.IocContainer.Register(
                Component.For<DbConnection>()
                    .UsingFactoryMethod(Effort.DbConnectionFactory.CreateTransient)
                    .LifestyleSingleton()
            );

            base.PreInitialize();
        }

        public void UsingDbContext(Action<SvcDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<SvcDbContext>())
            {
                context.DisableAllFilters();
                action(context);
                context.SaveChanges();
            }
        }

        public T UsingDbContext<T>(Func<SvcDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<SvcDbContext>())
            {
                context.DisableAllFilters();
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}

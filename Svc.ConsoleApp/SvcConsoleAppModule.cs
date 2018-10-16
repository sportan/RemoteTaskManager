using System.Reflection;
using Abp.Modules;

namespace Svc
{
    [DependsOn(typeof(SvcDataModule), typeof(SvcApplicationModule))]
    public class SvcConsoleAppModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
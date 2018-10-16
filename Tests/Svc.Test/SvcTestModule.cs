using Abp.Modules;
using Abp.TestBase;

namespace Svc.Test
{
    [DependsOn(
        typeof(SvcDataModule),
        typeof(SvcApplicationModule),
        typeof(AbpTestBaseModule)
    )]
    public class SvcTestModule : AbpModule
    {

    }
}

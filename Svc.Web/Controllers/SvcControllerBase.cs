using Abp.Web.Mvc.Controllers;

namespace Svc.Web.Controllers
{
    public abstract class SvcControllerBase : AbpController
    {
        protected SvcControllerBase()
        {
            LocalizationSourceName = SvcConsts.LocalizationSourceName;
        }
    }
}
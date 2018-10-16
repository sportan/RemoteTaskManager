using Abp.Web.Mvc.Views;

namespace Svc.Web.Views
{
    public abstract class SvcWebViewPageBase : SvcWebViewPageBase<dynamic>
    {

    }

    public abstract class SvcWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SvcWebViewPageBase()
        {
            LocalizationSourceName = SvcConsts.LocalizationSourceName;
        }
    }
}
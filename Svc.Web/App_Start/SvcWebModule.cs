using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Web.Mvc;

namespace Svc.Web
{
    [DependsOn(
        typeof(SvcDataModule), 
        typeof(SvcWebApiModule),
        typeof(SvcApplicationModule), 
        typeof(AbpWebMvcModule))]
    public class SvcWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("ru", "Russian", "famfamfam-flag-ru"));
            
            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    SvcConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        HttpContext.Current.Server.MapPath($"~/Localization/{SvcConsts.LocalizationSourceName}")
                        )
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<SvcNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            EnableCors();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void EnableCors()
        {
            //This method enables cross origin request

            var cors = new EnableCorsAttribute("*", "*", "*");
            GlobalConfiguration.Configuration.EnableCors(cors);

            //Then, we can call getTasks method from any web site like that:

            /*
             
                 $.ajax({
                    url: 'http://localhost:6299/api/services/svc/???/Get???',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/json',
                    data: JSON.stringify({})
                }).done(function(result) {
                    console.log(result);
                });
             
             */
        }
    }
}
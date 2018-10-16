using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Web;
using Abp.WebApi;
using Svc.Tasks;

namespace Svc
{
    /// <summary>
    /// 'Web API layer module' for this project.
    /// </summary>
    [DependsOn(typeof(AbpWebApiModule), typeof(SvcApplicationModule))]
    public class SvcWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Creating dynamic Web Api Controllers for application services.
            //Thus, 'web api layer' is created automatically by ABP.

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .For<ITaskAppService>("rtm/task")
                .ForMethod("GetTasksAsync").WithVerb(HttpVerb.Get)
                .ForMethod("CreateTaskAsync").WithVerb(HttpVerb.Post)
                .ForMethod("UpdateTaskAsync").WithVerb(HttpVerb.Put)
                //.ForAll<IApplicationService>(Assembly.GetAssembly(typeof(SvcApplicationModule)), "rtm")
                //.WithConventionalVerbs()
                .Build();
        }
    }
}

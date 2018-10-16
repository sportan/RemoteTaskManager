using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Svc
{
    /// <summary>
    /// 'Application layer module' for this project.
    /// </summary>
    [DependsOn(typeof(SvcCoreModule), typeof(AbpAutoMapperModule))]
    public class SvcApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            //This code is used to register classes to dependency injection system for this assembly using conventions.
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //We must declare mappings to be able to use AutoMapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                DtoMappings.Map(mapper);
            });
        }
    }
}

using System;
using Abp;
using Abp.Dependency;

namespace Svc
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bootstrapper = AbpBootstrapper.Create<SvcConsoleAppModule>())
            {
                bootstrapper.Initialize();

                bootstrapper.IocManager.Using<SystemSpy>(systemSpy =>
                {
                    systemSpy.UpdateStoredTasks();
                    systemSpy.GetStoredTasks();
                });
            }

            Console.ReadLine();
        }
    }
}

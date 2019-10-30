using System.Reflection;
using Autofac;
using Cvtex.Infrastructure.Repositories;

namespace Cvtex.Infrastructure.Configuration.IoC
{
    public class RepositoryModule : ModuleBase
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
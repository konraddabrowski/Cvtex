using System.Reflection;
using Autofac;
using Cvtex.Infrastructure.EF;
using Microsoft.Extensions.Configuration;

namespace Cvtex.Infrastructure.Configuration.IoC
{
    public class SqlModule : ModuleBase
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(SqlModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<ISqlRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
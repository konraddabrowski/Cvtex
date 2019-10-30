using System.Reflection;
using Autofac;
using Cvtex.Infrastructure.Commands;

namespace Cvtex.Infrastructure.Configuration.IoC
{
    public class CommandModule : ModuleBase
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .InstancePerLifetimeScope();

            // Powyższe zamiast krotność poniższeg0 XP
            // builder.RegisterType<CreateUserHandler>()
            //     .As<ICommandHandler<CreateUser>>()
            //     .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .InstancePerLifetimeScope();
        }
    }
}
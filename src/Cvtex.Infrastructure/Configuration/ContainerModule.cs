using Autofac;
using Cvtex.Infrastructure.Configuration.IoC;
using Cvtex.Infrastructure.Configuration.Services;
using Cvtex.Infrastructure.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration
{
    public class ContainerModule : ModuleBase
    {
        public ContainerModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new ServicesModule(_configuration, _services));
            builder.RegisterModule(new IoCModule(_configuration));
        }
    }
}
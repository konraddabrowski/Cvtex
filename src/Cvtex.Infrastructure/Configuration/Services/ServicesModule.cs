using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration.Services
{
    public class ServicesModule : ModuleBase
    {
        public ServicesModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new MvcModule(_configuration, _services));
            builder.RegisterModule(new SqlModule(_configuration, _services));
            builder.RegisterModule(new LoggingModule(_configuration, _services));
            builder.RegisterModule(new AuthorizationModule(_configuration, _services));
            builder.RegisterModule(new AuthenticationModule(_configuration, _services));
            builder.RegisterModule(new MemoryCacheModule(_configuration, _services));
            builder.RegisterModule(new PopulateModule(_configuration, _services));
        }
    }
}
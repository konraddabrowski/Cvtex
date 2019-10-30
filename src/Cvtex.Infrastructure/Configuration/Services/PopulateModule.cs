using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration.Services
{
    public class PopulateModule : ModuleBase
    {
        public PopulateModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Populate(_services);
        }
    }
}
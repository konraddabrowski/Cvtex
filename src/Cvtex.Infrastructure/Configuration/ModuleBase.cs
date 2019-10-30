using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration
{
    public abstract class ModuleBase : Autofac.Module
    {
        protected readonly IConfiguration _configuration;
        protected readonly IServiceCollection _services;

        protected ModuleBase()
        {
        }

        protected ModuleBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected ModuleBase(IConfiguration configuration, IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }

        protected override void Load(ContainerBuilder builder)
            => Configure();

        protected virtual void Configure()
        {
        }
    }
}
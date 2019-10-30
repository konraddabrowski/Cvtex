using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration.Services
{
    public class MemoryCacheModule : ModuleBase
    {
        public MemoryCacheModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Configure()
        {
            _services.AddMemoryCache();
        }
    }
}
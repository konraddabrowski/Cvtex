using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration.Services
{
    public class AuthorizationModule : ModuleBase
    {
        public AuthorizationModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Configure()
        {
            _services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
        }
    }
}
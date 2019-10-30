using System.Reflection;
using Autofac;
using Cvtex.Infrastructure.EF;
using Cvtex.Infrastructure.Extensions;
using Cvtex.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Cvtex.Infrastructure.Configuration.IoC
{
    public class SettingsModule : ModuleBase
    {
        public SettingsModule(IConfiguration configuration)
            :base(configuration)
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
            builder.RegisterInstance(_configuration.GetSettings<SqlSettings>())
                   .SingleInstance();
        }
    }
}
using Cvtex.Infrastructure.EF;
using Cvtex.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cvtex.Infrastructure.Configuration.Services
{
    public class SqlModule : ModuleBase
    {
        public SqlModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Configure()
        {
            var sqlSettings = _configuration.GetSettings<SqlSettings>();
            if (sqlSettings.InMemory)
            {
                _services.AddDbContext<CvtexContext>(options =>
                    options.UseInMemoryDatabase(sqlSettings.DatabaseName));

                return;
            }
            
            _services.AddDbContext<CvtexContext>(x =>
                x.UseSqlServer(sqlSettings.ConnectionString, y =>
                    y.MigrationsAssembly(sqlSettings.AssemblyName)));
        }
    }
}
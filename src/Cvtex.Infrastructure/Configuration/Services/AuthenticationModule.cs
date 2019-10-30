using Cvtex.Infrastructure.Extensions;
using Cvtex.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Cvtex.Infrastructure.Configuration.Services
{
    public class AuthenticationModule : ModuleBase
    {
        public AuthenticationModule(IConfiguration configuration, IServiceCollection services)
            :base(configuration, services)
        {
        }

        protected override void Configure()
        {
            var jwtSettings = _configuration.GetSettings<JwtSettings>();
            _services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtSettings.Key.GetBytes()),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
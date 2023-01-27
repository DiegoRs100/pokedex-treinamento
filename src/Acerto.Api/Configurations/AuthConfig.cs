using Acerto.Business.Core.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Acerto.Api.Configurations
{
    public static class AuthConfig
    {
        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var authSection = configuration.GetSection("AuthSettings");
            var settings = authSection.Get<AuthSettings>();

            services.Configure<AuthSettings>(authSection);

            var key = Encoding.ASCII.GetBytes(settings!.Secret);

            var aurthenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            aurthenticationBuilder.AddJwtBearer(options =>
            {
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = settings!.ValidIn,
                    ValidIssuer = settings!.Issuer
                };
            });

            return services;
        }
    }
}